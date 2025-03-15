using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Demo.PL.Helpers;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IEmployeeRepository _employeeRepo;


        public EmployeeController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_employeeRepo = employeeRepo;
        }

        
        public IActionResult Index(string searchInp)
        {
            var emplpyee = Enumerable.Empty<Employee>();

            if (string.IsNullOrEmpty(searchInp))
                emplpyee = _unitOfWork.EmployeeRepository.GetAll();
            else
                emplpyee = _unitOfWork.EmployeeRepository.SearchByName(searchInp.ToLower());

            var mappedEmp = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(emplpyee);
            return View(mappedEmp);
            
        }


        public IActionResult Create()
        {

            //ViewData["Departments"] = _deptRepo.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
                ///// var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                ///var count = _unitOfWork.EmployeeRepository.Add(mappedEmp);
                ///if (count > 0)
                ///{
                ///    return RedirectToAction(nameof(Index));
                ///} 

                var imageName = DocumentSettings.UploadFile(employeeVM.Image, "images");
                employeeVM.ImageName = imageName;

                var employee = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);

                _unitOfWork.EmployeeRepository.Add(employee);
                
                _unitOfWork.Complete();

                return RedirectToAction(nameof(Index));
                
            }
            return View(employeeVM);
        }

        //[HttpGet]
        public IActionResult Details(int? id, string ViewName = "Details") //Detailes 
        {
            if (!id.HasValue)
                return BadRequest();

            var employees = _unitOfWork.EmployeeRepository.Get(id.Value);

            if (employees is null)
                return NotFound();

            var mappedEmp = _mapper.Map<Employee, EmployeeViewModel>(employees);


            return View(ViewName, mappedEmp);
        }

        public IActionResult Edit(int? id)
        {

            return Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                var employee = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                _unitOfWork.EmployeeRepository.Update(employee);
                _unitOfWork.Complete();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                    return RedirectToAction(nameof(Index)); 
            }
            return View(employeeVM);
        }
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete( EmployeeViewModel employeeVM)
        {
            try
            {
                var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);

                _unitOfWork.EmployeeRepository.Delete(mappedEmp);
                var count = _unitOfWork.Complete();
                if (count > 0)
                    DocumentSettings.DeleteFile(employeeVM.ImageName, "images"); 
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(employeeVM);

        }
    }
}
