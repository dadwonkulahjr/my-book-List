using MyBookList.Models;


namespace MyBookList.Services.Repository.IRepository
{
    public interface IBook : IDefaultRepository<Book>
    {
        void UpdateBook(Book bookToUpdate);
    }
}
