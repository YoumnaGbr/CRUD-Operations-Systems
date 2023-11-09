using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
	public class Email : ModelBase
	{
        public string Subject { get; set; }
        public string Recipients { get; set; }
        public string Body { get; set; }
    }
}
