using API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DAL.Models
{
    public class PatientModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<DoctorPatient> DoctorPatients { get; set; }
        public Diagnostic Diagnostic { get; set; }
    }
}
