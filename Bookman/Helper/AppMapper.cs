using AutoMapper;
using Bookman.Model;
using Bookman.ViewModel;

namespace Bookman.Helper
{
    public class AppMapper :Profile
    {
        public AppMapper()
        {
            CreateMap<BookModel,ViewBook>().ReverseMap();
        }
    }
}
