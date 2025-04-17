using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;
        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            Professor professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if(professor == null) return BadRequest("Professor não foi encontrado");

            return Ok(professor);
        }

        [HttpGet("byName/{nome}")]
        public IActionResult GetByName(string nome)
        {
            Professor professor = _context.Professores.FirstOrDefault(p => p.Nome == nome);
            if(professor == null) return BadRequest("Professor não foi encontrado");

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut]
        public IActionResult Put(Professor professor)
        {
            Professor prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == professor.Id);
            if(prof == null) return BadRequest("Professor não foi encontrado");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPatch]
        public IActionResult Patch(Professor professor)
        {
            Professor prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == professor.Id);
            if(prof == null) return BadRequest("Professor não foi encontrado");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Professor professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if(professor == null) return BadRequest("Professor ja foi removido");

            _context.Remove(professor);
            _context.SaveChanges();
            return Ok();
        }
    }
}