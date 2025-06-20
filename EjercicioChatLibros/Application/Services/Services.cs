using Application.Dtos;
using Application.Exceptions;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class Services
    {
        private readonly IRepository _repository;

        public Services(IRepository repository)
        {
            _repository = repository;
        }
        #region Book
        public async Task<Book?> GetBookById(Guid id)
        {
            return await _repository.GetByIdAsync<Book>(id);
        }

        public async Task<List<Book>?> GetBooks()
        {
             return await _repository.GetAll<Book>();
                       
        }

        public async Task<BookModel.Response> AddProduct(BookModel.Request request)
        {
            if (string.IsNullOrWhiteSpace(request.ISBN) ||
                string.IsNullOrWhiteSpace(request.Title) ||
                string.IsNullOrWhiteSpace(request.Author))
            {
                throw new ArgumentException("Valores para el producto no válidos");
            }

            var exist = await _repository.First<Book>(p => p.ISBN == request.ISBN);
            if (exist != null) throw new DuplicatedEntityException($"Ya existe un producto con el ISBN {request.ISBN}");

            var book = new Book(request.Title, request.Author, request.Year, request.ISBN);
            await _repository.AddAsync(book);
            return new BookModel.Response(book.Id);
        }
        #endregion

        #region Loan
        public async Task<Loan?> GetLoanById(Guid id)
        {
            return await _repository.GetByIdAsync<Loan>(id);
        }

        public async Task<List<Loan>?> GetLoan()
        {
            return await _repository.GetAll<Loan>();

        }

        public async Task<LoanModel.Response> AddLoan(LoanModel.Request request)
        {
            var loan = new Loan(request.LoanDate,request.ReturnDate);
            await _repository.AddAsync(loan);
            return new LoanModel.Response(loan.Id);
        }
        #endregion

        #region User
        public async Task<User?> GetUSerById(Guid id)
        {
            return await _repository.GetByIdAsync<User>(id);
        }

        public async Task<List<User>?> GetUser()
        {
            return await _repository.GetAll<User>();

        }

        public async Task<UserModel.Response> AddUser(UserModel.Request request)
        {
            var user = new User(request.Name,request.Email);
            await _repository.AddAsync(user);
            return new UserModel.Response(user.Id);
        }
        #endregion
       
        #region Category
        public async Task<Category?> GetCategoryById(Guid id)
        {
            return await _repository.GetByIdAsync<Category>(id);
        }

        public async Task<List<Category>?> GetCategory()
        {
            return await _repository.GetAll<Category>();

        }

        public async Task<CategoryModel.Response> AddCategory(CategoryModel.Request request)
        {
            var category = new Category(request.Name);
            await _repository.AddAsync(category);
            return new CategoryModel.Response(category.Id);
        }
        #endregion
    }

}
