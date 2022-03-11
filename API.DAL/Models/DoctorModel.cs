using API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DAL.Models
{
    public class DoctorModel
    {
        public string Name { get; set; }
        public string Specialization { get; set; }
        public int OfficeId { get; set; }
    }
}
