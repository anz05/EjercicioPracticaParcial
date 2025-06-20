using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class CategoryModel
    {
        public record Request(string Name);
        public record Response(Guid Id);
    }
}
