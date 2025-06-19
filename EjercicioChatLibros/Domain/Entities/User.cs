using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class User
{
    public string? Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public ICollection <Loan>? loans { get; set; }
}
