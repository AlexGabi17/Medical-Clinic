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
    public class DoctorManager : IDoctorManager
    {
        private readonly IDoctorRepository _doctorRepo;
        public DoctorManager(IDoctorRepository doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }

        public async Task addDoctor(DoctorModel doctorModel)
        {
            await _doctorRepo.AddDoctor(doctorModel);   
        }

        public async Task<DoctorModel> getDocById(int id)
        {
            var doc = await _doctorRepo.GetById(id);
            return doc;
        }

        public async Task removeDoctor(int id)
        {
            await _doctorRepo.deleteDoctor(id);
        }

        public async Task<List<DoctorModel>> ShowAllDoctors()
        {
            var docs = await _doctorRepo.GetAll();
            return docs;
        }
    }
}
