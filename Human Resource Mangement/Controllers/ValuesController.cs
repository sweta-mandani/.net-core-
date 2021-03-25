using HRM.DATA;
using HRM.DATA.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Human_Resource_Mangement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
        // GET: api/<ValuesController>
        public class ValuesController : ControllerBase
        {
            private readonly IEmployeeRepo _repo;

            public ValuesController(IEmployeeRepo repo)
            {
                _repo = repo;
            }

            // GET: api/[controller]
            [HttpGet]
            public ActionResult<IEnumerable<Employee>> GetValues()
            {
                try
                {
                    var students = _repo.GetAllEmployee();
                    return Ok(students);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }

            // POST api/<ValuesController>
            [HttpPost]
            public async Task<ActionResult> Post([FromBody] Employee employee)
            {
            if (employee == null)
            {
                return NotFound();
            }
            try
            {
                _repo.SaveEmployee(employee);
                return Ok("Value Added");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return NotFound();
            }
            try
            {
                _repo.UpdateEmployee(employee);
                return Ok("Value updated");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
