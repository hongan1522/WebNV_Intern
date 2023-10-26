using System;
using System.Collections.Generic;

namespace WebIntern.Models;

public partial class Employee
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? Position { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public Employee()
    {
        if (Position == "Backend")
        {
            Id = "BE" + GenerateId(); 
        }
        else if (Position == "Frontend")
        {
        }
        else if (Position == "Teamlead")
        {
            Id = "TL" + GenerateId(); 
        }
    }
    private int counter = 1; 

    private string GenerateId()
    {
        string number = counter.ToString().PadLeft(4, '0'); // Đưa số vào chuỗi, đảm bảo có 4 chữ số, ví dụ: "0001", "0002", ...
        counter++; 

        return number;
    }

}
