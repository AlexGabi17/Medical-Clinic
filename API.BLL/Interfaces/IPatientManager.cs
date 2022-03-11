using API.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.BLL.Interfaces
{
    public interface IPatientManager
    {
        Task<List<PatientModelForReturningData>> ShowAllPatients();
        Task addPatient(PatientModel pacientModel);
        Task removePatient(int id);
        Task<PatientModelForReturningData> getPatientById(int id);
        
    }
}
