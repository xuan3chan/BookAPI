using AutoMapper;
using Bookman.Data;
using Bookman.ViewModel;
using Microsoft.EntityFrameworkCore;
using Autofac;
using Bookman.Model;

namespace Bookman.Repository
{
    public class Book : IBook
    {
        private readonly BookmanContext _context;
        private readonly IMapper _mapper;

        public Book(BookmanContext Context, IMapper mapper)
        {
            _context = Context;
            _mapper = mapper;
;       }
        public async Task<int> AddBookAsync(ViewBook model)
        {
            var NewBook=_mapper.Map<BookModel>(model);
            _context.Book.Add(NewBook);
            await _context.SaveChangesAsync();
            return NewBook.Id;
        }

        public async Task DeleteBookAsync(int Id)
        {
            var DeleteBook=_context.Book!.SingleOrDefault(b=>b.Id==Id);
            if (DeleteBook != null)
            {
                _context.Book!.Remove(DeleteBook);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ViewBook>> GetAllBooksAsyns()
        {
            var books = await _context.Book.ToListAsync();
            return _mapper.Map<List<ViewBook>>(books);
        }
        
        public async Task<List<ViewBook>> GetBookAsyns(int Id)
        {
            var books = await _context.Book.FindAsync(Id);
            return _mapper.Map<List<ViewBook>>(books);
        }

        public async Task UpdateBookAsync(int Id, ViewBook model)
        {
            if(Id == model.Id)
            {
                var UpdateBook = _mapper.Map<BookModel>(model);
                _context.Book!.Update(UpdateBook);
                await _context.SaveChangesAsync();
            };
        }
    }
}
