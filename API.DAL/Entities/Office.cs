using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DAL.Entities
{
    public class Office
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
