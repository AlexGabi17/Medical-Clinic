using API.DAL.Entities;
using API.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DAL.Interfaces
{
    public interface IDoctorRepository
    {
        Task<List<DoctorModel>> GetAll();
        Task<DoctorModel> GetById(int id);
        Task<DoctorModel> toModelDoctor(Doctor doctorEntity);
        Task AddDoctor(DoctorModel doctorModel);
        Task deleteDoctor(int id);
    }
}
