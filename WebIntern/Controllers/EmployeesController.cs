using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployee(string id)
        //{
        //    if (_context.Employees == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Employees.Remove(employee);

        //    // Lấy ra danh sách các Employee có cùng Position và Id lớn hơn
        //    var employeesToUpdate = await _context.Employees
        //        .Where(e => e.Position == employee.Position && e.Id.CompareTo(id) > 0)
        //        .ToListAsync();

        //    // Chuyển dữ liệu từ mã cao hơn về mã thấp hơn
        //    foreach (var emp in employeesToUpdate)
        //    {
        //        emp.Id = GenerateId(emp.Position);
        //        _context.Entry(emp).Property("Id").IsModified = true;
        //    }

        //    // Xác định và xóa nhân viên cuối cùng
        //    var lastEmployee = await _context.Employees
        //        .Where(e => e.Position == employee.Position)
        //        .OrderByDescending(e => e.Id)
        //        .FirstOrDefaultAsync();

        //    if (lastEmployee != null)
        //    {
        //        _context.Employees.Remove(lastEmployee);
        //    }

        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployee(string id)
        //{
        //    if (_context.Employees == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Employees.Remove(employee);

        //    var employeesToUpdate = await _context.Employees
        //        .Where(e => e.Position == employee.Position && String.Compare(e.Id, id) > 0)
        //        .ToListAsync();

        //    foreach (var emp in employeesToUpdate)
        //    {
        //        emp.Id = GenerateId(emp.Position);
        //        _context.Entry(emp).Property(x => x.Id).IsModified = true;
        //    }

        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployee(string id)
        //{
        //    if (_context.Employees == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Employees.Remove(employee);

        //    await UpdateEmployeeIds(employee.Position, id);

        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployee(string id)
        //{
        //    var employeeToDelete = await _context.Employees.FindAsync(id);
        //    if (employeeToDelete == null)
        //    {
        //        return NotFound();
        //    }

        //    var employeeToMove = await _context.Employees
        //        .Where(e => e.Position == employeeToDelete.Position && e.Id.CompareTo(id) > 0)
        //        .OrderBy(e => e.Id)
        //        .FirstOrDefaultAsync();

        //    if (employeeToMove != null)
        //    {
        //        employeeToMove.Name = employeeToDelete.Name;
        //        employeeToMove.Birthday = employeeToDelete.Birthday;
        //        employeeToMove.Email = employeeToDelete.Email;
        //        employeeToMove.Phone = employeeToDelete.Phone;
        //        employeeToMove.Address = employeeToDelete.Address;

        //        _context.Entry(employeeToMove).State = EntityState.Modified;
        //    }

        //    _context.Employees.Remove(employeeToDelete);

        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployee(string id)
        //{
        //    var employeeToDelete = await _context.Employees.FindAsync(id);
        //    if (employeeToDelete == null)
        //    {
        //        return NotFound();
        //    }

        //    var employeesToUpdate = await _context.Employees
        //        .Where(e => e.Position == employeeToDelete.Position && e.Id.CompareTo(id) > 0)
        //        .OrderBy(e => e.Id)
        //        .ToListAsync();

        //    if (employeesToUpdate.Any())
        //    {
        //        for (int i = 0; i < employeesToUpdate.Count; i++)
        //        {
        //            var targetId = i == 0 ? id : employeesToUpdate[i - 1].Id;
        //            employeesToUpdate[i].Id = targetId;
        //            _context.Entry(employeesToUpdate[i]).State = EntityState.Modified;
        //        }
        //    }

        //    _context.Employees.Remove(employeeToDelete);

        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployee(string id)
        //{
        //    var employeeToDelete = await _context.Employees.FindAsync(id);
        //    if (employeeToDelete == null)
        //    {
        //        return NotFound();
        //    }

        //    var position = employeeToDelete.Position;

        //    if (await IsMaxId(position, id))
        //    {
        //        _context.Employees.Remove(employeeToDelete);
        //    }
        //    else
        //    {
        //        var employeesToUpdate = await _context.Employees
        //            .Where(e => e.Position == position && e.Id.CompareTo(id) > 0)
        //            .OrderBy(e => e.Id)
        //            .ToListAsync();

        //        if (employeesToUpdate.Any())
        //        {
        //            for (int i = 0; i < employeesToUpdate.Count; i++)
        //            {
        //                var targetId = i == 0 ? id : employeesToUpdate[i - 1].Id;
        //                employeesToUpdate[i].Id = targetId;
        //                _context.Entry(employeesToUpdate[i]).State = EntityState.Modified;
        //            }
        //        }

        //        _context.Employees.Remove(employeeToDelete);
        //    }

        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private async Task<bool> IsMaxId(string position, string id)
        //{
        //    var maxId = await _context.Employees
        //        .Where(e => e.Position == position)
        //        .Select(e => e.Id)
        //        .MaxAsync();

        //    return id == maxId;
        //}


        //private async Task UpdateEmployeeIds(string position, string deletedId)
        //{
        //    var employeesToUpdate = await _context.Employees
        //        .Where(e => e.Position == position && e.Id.CompareTo(deletedId) > 0)
        //        .ToListAsync();

        //    foreach (var emp in employeesToUpdate)
        //    {
        //        emp.Id = GenerateId(emp.Position);
        //        _context.Entry(emp).State = EntityState.Modified;
        //    }
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployee(string id)
        //{
        //    var employeeToDelete = await _context.Employees.FindAsync(id);
        //    if (employeeToDelete == null)
        //    {
        //        return NotFound();
        //    }

        //    var position = employeeToDelete.Position;

        //    if (await IsMaxId(position, id))
        //    {
        //        _context.Employees.Remove(employeeToDelete);
        //    }
        //    else
        //    {
        //        var employeesToUpdate = await _context.Employees
        //            .Where(e => e.Position == position && e.Id.CompareTo(id) > 0)
        //            .OrderBy(e => e.Id)
        //            .ToListAsync();

        //        if (employeesToUpdate.Any())
        //        {
        //            for (int i = 0; i < employeesToUpdate.Count; i++)
        //            {
        //                var targetId = i == 0 ? id : employeesToUpdate[i - 1].Id;
        //                employeesToUpdate[i].Id = targetId;
        //                _context.Entry(employeesToUpdate[i]).State = EntityState.Modified;
        //            }
        //        }

        //        _context.Employees.Remove(employeeToDelete);
        //    }

        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private async Task<bool> IsMaxId(string position, string id)
        //{
        //    var maxId = await _context.Employees
        //        .Where(e => e.Position == position)
        //        .Select(e => e.Id)
        //        .MaxAsync();

        //    return id == maxId;
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployee(string id)
        //{
        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Employees.Remove(employee);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployee(string id)
        //{
        //    var employeeToDelete = await _context.Employees.FindAsync(id);
        //    if (employeeToDelete == null)
        //    {
        //        return NotFound();
        //    }

        //    // Lấy ra danh sách các Employee có cùng Position và Id lớn hơn
        //    var employeesToUpdate = await _context.Employees
        //        .Where(e => e.Position == employeeToDelete.Position && e.Id.CompareTo(id) > 0)
        //        .ToListAsync();

        //    // Xóa nhân viên cần xóa
        //    _context.Employees.Remove(employeeToDelete);

        //    // Cập nhật lại Id của các Employee
        //    for (int i = 0; i < employeesToUpdate.Count; i++)
        //    {
        //        var targetId = i == 0 ? id : employeesToUpdate[i - 1].Id;
        //        employeesToUpdate[i].Id = targetId;
        //    }

        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployee(string id)
        //{
        //    var employeeToDelete = await _context.Employees.FindAsync(id);
        //    if (employeeToDelete == null)
        //    {
        //        return NotFound();
        //    }

        //    // Lấy ra danh sách các Employee có cùng Position và Id lớn hơn
        //    var employeesToUpdate = await _context.Employees
        //        .Where(e => e.Position == employeeToDelete.Position && e.Id.CompareTo(id) > 0)
        //        .ToListAsync();

        //    // Xóa nhân viên cần xóa
        //    _context.Employees.Remove(employeeToDelete);

        //    // Cập nhật lại Id của các Employee
        //    for (int i = 0; i < employeesToUpdate.Count; i++)
        //    {
        //        var targetId = i == 0 ? id : employeesToUpdate[i - 1].Id;
        //        employeesToUpdate[i].Name = employeeToDelete.Name; // Thay OtherProperty bằng thuộc tính bạn muốn cập nhật
        //        employeesToUpdate[i].Email = employeeToDelete.Email;
        //        employeesToUpdate[i].Phone = employeeToDelete.Phone;
        //        employeesToUpdate[i].Position = employeeToDelete.Position;
        //        employeesToUpdate[i].Birthday = employeeToDelete.Birthday;
        //        employeesToUpdate[i].Address = employeeToDelete.Address;
        //    }

        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployee(string id)
        //{
        //    var employeeToDelete = await _context.Employees.FindAsync(id);
        //    if (employeeToDelete == null)
        //    {
        //        return NotFound();
        //    }

        //    // Lấy ra danh sách các Employee có cùng Position và Id lớn hơn
        //    var employeesToUpdate = await _context.Employees
        //        .Where(e => e.Position == employeeToDelete.Position && e.Id.CompareTo(id) > 0)
        //        .ToListAsync();

        //    // Thay đổi các thuộc tính trừ Id của Employee có Id3 thành giá trị của Employee có Id2
        //    var employeeId2 = employeesToUpdate.FirstOrDefault(e => e.Id == "FE0002");
        //    if (employeeId2 != null)
        //    {
        //        employeeId2.Name = employeeToDelete.Name;
        //        employeeId2.Position = employeeToDelete.Position;
        //        employeeId2.Birthday = employeeToDelete.Birthday;
        //        employeeId2.Email = employeeToDelete.Email;
        //        employeeId2.Phone = employeeToDelete.Phone;
        //        employeeId2.Address = employeeToDelete.Address;
        //        _context.Entry(employeeId2).State = EntityState.Modified;
        //    }

        //    // Xóa nhân viên cần xóa
        //    _context.Employees.Remove(employeeToDelete);

        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

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
                _context.Entry(emp).State = EntityState.Modified;
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
