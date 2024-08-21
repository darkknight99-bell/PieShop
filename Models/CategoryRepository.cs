
namespace PieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PieShopDbContext _context;

        public CategoryRepository(PieShopDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> AllCategories => 
            _context.Categories.OrderBy(c => c.CategoryName);
    }
}
