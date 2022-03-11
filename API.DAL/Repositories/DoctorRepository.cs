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
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;
        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddDoctor(DoctorModel doctorModel)
        {
            var doctorEntity = new Doctor
            {
                Name = doctorModel.Name,
                Specialization = doctorModel.Specialization,
                OfficeId = doctorModel.OfficeId
            };
            await _context.AddAsync(doctorEntity);
            await _context.SaveChangesAsync();
        }

        public async Task deleteDoctor(int id)
        {
            var patientEntity = await _context.Doctors.Where(x => x.Id == id).FirstOrDefaultAsync();

            _context.Remove(patientEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DoctorModel>> GetAll()
        {
            var doctors = await _context.Doctors.ToListAsync();
            var list = new List<DoctorModel>();
            foreach (var doctor in doctors)
            {
                var doctorModel = await toModelDoctor(doctor);
                list.Add(doctorModel);
            }
            return list;
        }

        public async Task<DoctorModel> GetById( int id)
        {
            var doctor = await _context.Doctors.Where(x => x.Id == id).FirstOrDefaultAsync();
            var doctorModel = await toModelDoctor(doctor);
            return doctorModel;
        }
        
        public async Task<DoctorModel> toModelDoctor(Doctor doctorEntity)
        {
            var doctorModel = new DoctorModel
            {
                Name = doctorEntity.Name,
                Specialization = doctorEntity.Specialization,
                OfficeId = doctorEntity.OfficeId
            };
            return doctorModel;
        }
    }
}
