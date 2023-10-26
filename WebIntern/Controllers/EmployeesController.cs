using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebIntern.Models;

namespace WebIntern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmpManagerContext _context;

        public EmployeesController(EmpManagerContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees
                .OrderBy(e => e.Position == "Teamlead" ? 0 : e.Position == "Backend" ? 1 : 2)
                .ToListAsync();

            return employees;
        }


        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(string id)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(string id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'EmpManagerContext.Employees'  is null.");
            }

            employee.Id = GenerateId(employee.Position);

            var existingEmployee = await _context.Employees.FindAsync(employee.Id);
            if (existingEmployee != null)
            {
                return Conflict();
            }

            _context.Employees.Add(employee);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return Conflict();
            }

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }
        private int GetMaxIdForPosition(string position)
        {
            var employees = _context.Employees
                .Where(e => e.Position == position)
                .AsEnumerable();

            if (!employees.Any())
            {
                return 0;
            }

            int maxId = employees
                .Select(e => int.Parse(e.Id.Substring(2)))
                .Max();

            return maxId;
        }
        private int GetNextAvailableNumber(string position)
        {
            var maxId = GetMaxIdForPosition(position);

            var existingNumbers = _context.Employees
                .Where(e => e.Position == position)
                .AsEnumerable()
                .Select(e => int.Parse(e.Id.Substring(2)))
                .OrderBy(n => n)
                .ToList();

            for (int i = 1; i <= maxId; i++)
            {
                if (!existingNumbers.Contains(i))
                {
                    return i;
                }
            }

            return maxId + 1;
        }
        private string GenerateId(string position)
        {
            string prefix = "";

            switch (position)
            {
                case "Backend":
                    prefix = "BE";
                    break;
                case "Frontend":
                    prefix = "FE";
                    break;
                case "Teamlead":
                    prefix = "TL";
                    break;
                default:
                    break;
            }

            int nextNumber = GetNextAvailableNumber(position);

            string newId = $"{prefix}{nextNumber:D4}";

            return newId;
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            var employeeToDelete = await _context.Employees.FindAsync(id);
            if (employeeToDelete == null)
            {
                return NotFound();
            }

            var employeesToUpdate = await _context.Employees
                .Where(e => e.Position == employeeToDelete.Position && e.Id.CompareTo(id) > 0)
                .ToListAsync();

            foreach (var emp in employeesToUpdate)
            {
                emp.Name = employeeToDelete.Name;
                emp.Position = employeeToDelete.Position;
                emp.Birthday = employeeToDelete.Birthday;
                emp.Email = employeeToDelete.Email;
                emp.Phone = employeeToDelete.Phone;
                emp.Address = employeeToDelete.Address;
            }

            _context.Employees.Remove(employeeToDelete);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(string id)
        {
            return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
