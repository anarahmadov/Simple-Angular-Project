using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        private IBookDAL _bookDAL;
        public BookManager(IBookDAL bookDAL)
        {
            _bookDAL = bookDAL;
        }

        public void Add(Book book)
        {
            _bookDAL.Add(book);
        }

        public void Delete(Book book)
        {
            _bookDAL.Delete(book);
        }

        public List<Book> GetAll()
        {
            return _bookDAL.GetList().ToList();
        }

        public List<Book> GetByAuthorId(int id)
        {
            return _bookDAL.GetList(x => x.Id == id).ToList();
        }

        public Book GetById(int id)
        {
            return _bookDAL.Get(x => x.Id == id);
        }

        public void Update(Book book)
        {
            if (_bookDAL.Get(x => x.Name == book.Name) == null)
            {
                _bookDAL.Update(book);
            }
            else
            {
                throw new Exception("Bu kitab zaten mevcut");
            }
        }
    }
}
