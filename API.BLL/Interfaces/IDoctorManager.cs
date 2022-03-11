using API.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.BLL.Interfaces
{
    public interface IDoctorManager
    {
        Task<List<DoctorModel>> ShowAllDoctors();
        Task<DoctorModel> getDocById(int id);
        Task addDoctor(DoctorModel doctorModel);
        Task removeDoctor(int id);
    }
}
