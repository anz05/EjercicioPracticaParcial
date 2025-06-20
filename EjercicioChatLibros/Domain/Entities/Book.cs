namespace Domain.Entities
{
    public class Book : EntityBase
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int? Year { get; set; }
        public string? ISBN { get; set; }

        //relacion 1 a 1 entre libro y categoria
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        //relacion 1 a muchos con prestamo
        public ICollection<Loan>? Loan { get; set; }

        public Book(string title, string author, int year, string isbn)
        {
            Title = title;
            Author = author;
            Year = year;
            ISBN = isbn;
        }
    }
}
