using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;
using Api.Data;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly Context _db;

        public PacienteController(Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetPacientes() 
        {
            return Ok(_db.Pacientes.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddPaciente([FromBody] Paciente objPaciente) 
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Error While Creating New Paciente");
            }
            _db.Pacientes.Add(objPaciente);
            await _db.SaveChangesAsync();

            return new JsonResult("Paciente Created Successfully");
        }

    }
}
