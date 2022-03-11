using API.DAL.Entities;
using API.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DAL.Interfaces
{
    public interface IPatientRepository
    {
        Task<List<PatientModelForReturningData>> getAllPatients();
        Task addPatient(PatientModel patient);
        Task<PatientModelForReturningData> getPatientById(int id);
        Task removePatient(int id);
    }
}
