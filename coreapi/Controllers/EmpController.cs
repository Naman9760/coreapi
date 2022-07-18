using coreapi.Context;
using coreapi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace coreapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public EmpController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {

            return Ok(await dbContext.Employees.ToListAsync());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {

            var employee = await dbContext.Employees.FindAsync(id);

            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult>AddEmployee(AddEmpRequest addEmp )
        {
            var Emp = new Employees()
            {
                EMPID=Guid.NewGuid(),
                Name=addEmp.Name,
                Age=addEmp.Age,
                Gender=addEmp.Gender,
                Salary=addEmp.Salary,
                Mobile=addEmp.Mobile,   
            };
            await dbContext.Employees.AddAsync(Emp);
            await dbContext.SaveChangesAsync();
            return Ok(Emp);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id,UpdateEmp Edit)
        {
            var emp = await dbContext.Employees.FindAsync(id);
            if (emp != null)
            {
                emp.Name = Edit.Name;
                emp.Age = Edit.Age;
                emp.Gender = Edit.Gender;
                emp.Salary = Edit.Salary;
                emp.Mobile = Edit.Mobile;
                await dbContext.SaveChangesAsync();
                return Ok(emp);
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var emp = await dbContext.Employees.FindAsync(id);
            if (emp != null)
            {
                dbContext.Remove(emp);
                await dbContext.SaveChangesAsync();
                return Ok(emp);
            }
            return NotFound();
        }
    }
}
