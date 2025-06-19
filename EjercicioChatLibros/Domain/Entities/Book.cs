namespace Domain.Entities
{
    public class Book
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required int Year { get; set; }
        public required string ISBN { get; set; }

        //relacion 1 a 1 entre libro y categoria
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        //relacion 1 a muchos con prestamo
        public ICollection<Loan>? Loan { get; set; }
    }
}
