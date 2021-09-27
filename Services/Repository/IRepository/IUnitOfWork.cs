using System;

namespace MyBookList.Services.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        public IBook Book { get;}
        //public IAuthor Author { get; }
    }
}
