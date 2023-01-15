using Bookman.Model;
using Bookman.ViewModel;

namespace Bookman.Repository
{
    public interface IBook
    {
        public Task<List<ViewBook>> GetAllBooksAsyns();
        public Task<List<ViewBook>> GetBookAsyns(int Id);
        public Task<int> AddBookAsync(ViewBook model);
        public Task DeleteBookAsync(int Id);
        public Task  UpdateBookAsync(int Idd, ViewBook model);
    }
}
