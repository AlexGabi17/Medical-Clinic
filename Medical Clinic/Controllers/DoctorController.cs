using API.BLL.Interfaces;
using API.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorManager _doctorManager;
        public DoctorController(IDoctorManager docMan)
        {
            _doctorManager = docMan;
        }

        [Authorize("Admin")]
        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var list = await _doctorManager.ShowAllDoctors();
            return Ok(list);
        }


        [Authorize("Admin")]
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var doctor = await _doctorManager.getDocById(id);
            return Ok(doctor);
        }


        [Authorize("Admin")]
        [HttpPost("addDoctor")]
        public async Task<IActionResult> addDoctor([FromBody] DoctorModel doctorModel)
        {
            if (string.IsNullOrEmpty(doctorModel.Name))
            {
                return BadRequest("Name is null");
            }
            await _doctorManager.addDoctor(doctorModel);
            return Ok("Doctor succesfully added.");
        }
        [Authorize("Admin")]
        [HttpDelete("deleteDoctor/{id}")]
        public async Task<IActionResult> deleteDoctor(int id)
        {
            await _doctorManager.removeDoctor(id);
            return Ok("Doctor succesfully removed.");
        }

    }
}
