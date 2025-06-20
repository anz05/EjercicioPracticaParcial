using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class UserModel
    {
        public record Request(string Name, string Email);
        public record Response(Guid Id);
    }
}
