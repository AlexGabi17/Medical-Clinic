using API.BLL.Interfaces;
using API.DAL.Interfaces;
using API.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.BLL.Managers
{
    public class PatientManager : IPatientManager
    {
        private readonly IPatientRepository _patientRepo;
        public PatientManager(IPatientRepository patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public async Task addPatient(PatientModel pacientModel)
        {
            await _patientRepo.addPatient(pacientModel);
        }

        public async Task<PatientModelForReturningData> getPatientById(int id)
        {
            var patientModel = await _patientRepo.getPatientById(id);
            return patientModel;
        }

        public async Task removePatient(int id)
        {
            await _patientRepo.removePatient(id);    
        }

        public async Task<List<PatientModelForReturningData>> ShowAllPatients()
        {
            var patients = await _patientRepo.getAllPatients();
            return patients;
        }
    }
}
