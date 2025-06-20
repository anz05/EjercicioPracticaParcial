using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class LoanModel
    {
        public record Request(DateTime LoanDate, DateTime ReturnDate, bool IsActive);
        public record Response(Guid Id);
    }
}
