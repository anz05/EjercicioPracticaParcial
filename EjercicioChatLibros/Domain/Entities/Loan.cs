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
    
    public int? BookId { get; set; }
    public Book? Book { get; set; }

    public Guid? UserId { get; set; }
    public User? User { get; set; }

    public Loan(DateTime loanDate, DateTime returnDate, int idBook, Guid idUser, User user)
    {
        LoanDate = loanDate;
        ReturnDate = returnDate;
        Id = Guid.NewGuid();
        BookId = idBook;
        UserId = idUser;

        if (user.Id == idUser) 
        { 
            user?.loans.Add(new Loan (){ });
        }
    }

}
