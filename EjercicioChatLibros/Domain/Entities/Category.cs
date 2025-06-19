using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Category : EntityBase
{
    public string? Name { get; set; }
    public ICollection<Book>? Books { get; set; }
    public Category(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
    }
}
