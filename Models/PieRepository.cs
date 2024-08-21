using Microsoft.EntityFrameworkCore;

namespace PieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly PieShopDbContext _context;

        public PieRepository(PieShopDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _context.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _context.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int id)
        {
            return _context.Pies.FirstOrDefault(p => p.PieId == id);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return _context.Pies.Where(p => p.Name.Contains(searchQuery));
        }
    }
}
