using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class User : EntityBase
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public ICollection <Loan>? loans { get; set; }

    public User(string fullName, string email)
    {
        FullName = fullName;
        Email = email;
    }
}
