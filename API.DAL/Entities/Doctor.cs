using API.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DAL.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public int OfficeId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public virtual ICollection<DoctorPatient> DoctorPatients { get; set; }
        public virtual Office Office { get; set; }
        

    }
}
