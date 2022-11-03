using AutoMapper;

namespace VSAMovie.WebAPI.Features
{
    public class HandlerBase
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;

        public HandlerBase(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
