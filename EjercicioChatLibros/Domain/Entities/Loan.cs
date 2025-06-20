using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Loan : EntityBase
{
    public DateTime? LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool? IsActive { get; set; }
    
    public int? BookId { get; set; }
    public Book? Book { get; set; }

    public Guid? UserId { get; set; }
    public User? User { get; set; }

    public Loan(DateTime loanDate, DateTime returnDate)
    {
        LoanDate = loanDate;
        ReturnDate = returnDate;
        IsActive = true;
    }
}
