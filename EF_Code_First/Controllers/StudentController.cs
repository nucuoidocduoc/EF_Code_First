using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EF_Code_First.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public StudentController(IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            if (student == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            _repository.Student.Add(student);
            _repository.SaveChanges();

            return Created("URI of the created entity", student);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetRequestTest()
        {
            return Ok();
        }
    }
}