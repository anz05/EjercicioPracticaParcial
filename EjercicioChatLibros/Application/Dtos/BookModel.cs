using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos;

public record BookModel
{
    public record Request(string Title, string Author, string ISBN, int Year);
    public record Response(Guid Id);
}
