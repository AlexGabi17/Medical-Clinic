using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DAL.Entities
{
    public class Diagnostic
    {
        public int Id { get; set; }
        public string Observations { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
