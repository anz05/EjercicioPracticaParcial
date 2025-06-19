namespace Domain.Entities
{
    public class Book : EntityBase
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required int Year { get; set; }
        public required string ISBN { get; set; }

        //relacion 1 a 1 entre libro y categoria
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        //relacion 1 a muchos con prestamo
        public ICollection<Loan>? Loan { get; set; }

        public Book(string title, string author, int year, string isbn, int idCategory)
        {
            Title = title;
            Author = author;
            Year = year;
            ISBN = isbn;
            Id = Guid.NewGuid();
            CategoryId = idCategory;
            
        }


    }
}
