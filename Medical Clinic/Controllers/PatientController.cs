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
    public class PatientController : ControllerBase
    {
        private readonly IPatientManager _patientManager;
        public PatientController(IPatientManager patientManager)
        {
            _patientManager = patientManager;
        }


        [Authorize("Admin")]
        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var list = await _patientManager.ShowAllPatients();
            return Ok(list);
        }

        [Authorize("Admin")]
        [HttpGet("GetPatient/{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _patientManager.getPatientById(id);
            return Ok(patient);
        }

        [Authorize("Admin")]
        [HttpPost("AddPatient")]
        public async Task<IActionResult> AddPatient([FromBody] PatientModel patientModel)
        {
            if(string.IsNullOrEmpty(patientModel.Name))
            {
                return BadRequest("Name is null");
            }
            await _patientManager.addPatient(patientModel);
            return Ok("Patient succesfully added.");
        }

        /* Structura
         * 
            {
              "name": "string",
              "age": number,
              "doctorPatients": [
                {
                  "doctorId": number
                }
              ],
              "diagnostic":
                      {
                        "observations":"string"
                      }
            } 
         */

        [Authorize("Admin")]
        [HttpDelete("deletePatient/{id}")]
        public async Task<IActionResult> deletePatient(int id)
        {
            await _patientManager.removePatient(id);
            return Ok("Patient succesfully removed from database");
        }

    }
}
