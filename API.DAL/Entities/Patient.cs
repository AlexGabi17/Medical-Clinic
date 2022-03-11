using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DAL.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual ICollection<DoctorPatient> DoctorPatients { get; set; }
        public virtual Diagnostic Diagnostic { get; set; }
    }
}
