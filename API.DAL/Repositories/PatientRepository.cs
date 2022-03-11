using API.DAL.Entities;
using API.DAL.Interfaces;
using API.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DAL.Repositories
{
    public class PatientRepository : IPatientRepository
    {

        private readonly AppDbContext _context;
        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task addPatient(PatientModel patient)
        {
            var patientEntity = new Patient
            {
                Name = patient.Name,
                Age = patient.Age,
                DoctorPatients = patient.DoctorPatients,
                Diagnostic = patient.Diagnostic
            };
            patientEntity.Diagnostic.Patient = null;
            await _context.Patients.AddAsync(patientEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PatientModelForReturningData>> getAllPatients()
        {
            var patientsEntity = await _context.Patients
                .Include(x => x.Diagnostic).ToListAsync();
            var list = new List<PatientModelForReturningData>();
            foreach(var patient in patientsEntity)
            {
                var patientModel = new PatientModelForReturningData
                {
                    Name = patient.Name,
                    Age = patient.Age,
                    DiagnosticModel = new DiagnosticModel
                    {
                        Observations = patient.Diagnostic.Observations
                    }
                };
                list.Add(patientModel);
            }
            return list;
        }

        public async Task<PatientModelForReturningData> getPatientById(int id)
        {
            var patientEntity = await _context.Patients.Where(x => x.Id == id).Include(x => x.Diagnostic).FirstOrDefaultAsync();
            var patientModel = new PatientModelForReturningData
            {
                Name = patientEntity.Name,
                Age = patientEntity.Age,
                DiagnosticModel = new DiagnosticModel
                {
                   Observations = patientEntity.Diagnostic.Observations
                }
            };
            return patientModel;
        }

        public async Task removePatient(int id)
        {
            var patientEntity = await _context.Patients.Where(x => x.Id == id).FirstOrDefaultAsync();
            /*
             dorim sa eliminam din baza de date doar
            pacientul cu id-ul dat si diagnosticul sau
            + legatura sa din DoctorPatient.
            */
            _context.Remove(patientEntity);
            await _context.SaveChangesAsync();
            
        }
    }
}
