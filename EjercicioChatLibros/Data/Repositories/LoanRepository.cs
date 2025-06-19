using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data.Repositories;

public class LoanRepository
{
    private readonly AppDbContext _context;

    public LoanRepository(AppDbContext context)
    {
        _context = context;
    }

    // Obtener todos los préstamos con libro y usuario incluidos
    public async Task<IEnumerable<Loan>> GetAllAsync()
    {
        return await _context.Loans
            .Include(l => l.Book)
            .Include(l => l.User)
            .ToListAsync();
    }

    // Obtener un préstamo por ID
    public async Task<Loan?> GetByIdAsync(int id)
    {
        return await _context.Loans
            .Include(l => l.Book)
            .Include(l => l.User)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    // Agregar un nuevo préstamo
    public async Task AddAsync(Loan loan)
    {
        _context.Loans.Add(loan);
        await _context.SaveChangesAsync();
    }

    // Marcar devolución (ejemplo de lógica personalizada)
    public async Task MarkAsReturnedAsync(int loanId)
    {
        var loan = await _context.Loans.FindAsync(loanId);
        if (loan != null && loan.ReturnDate == null)
        {
            loan.ReturnDate = DateTime.Now;
            await _context.SaveChangesAsync();
        }
    }

    // Eliminar un préstamo (opcional)
    public async Task DeleteAsync(int id)
    {
        var loan = await _context.Loans.FindAsync(id);
        if (loan != null)
        {
            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();
        }
    }
}
