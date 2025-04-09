using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await _db.Category.AddAsync(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var product = _db.Category.FirstOrDefault(c => c.Id == Id);
            if (product != null) 
            { 
                _db.Category.Remove(product);
                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;
        }

        public async Task<Category> GetAsync(int Id)
        {
            var product = await _db.Category.FirstOrDefaultAsync(c => c.Id == Id);
            if(product != null)
            {
                return product;
            }
            return new Category();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _db.Category.ToListAsync();
        }
        
        public async Task<Category> UpdateAsync(Category category)
        {
            var product = await _db.Category.FirstOrDefaultAsync(u=>u.Id == category.Id);
            if (product != null)
            {
                product.Name = category.Name;
                _db.Category.Update(product);
                await _db.SaveChangesAsync();
                return product;
            }
            return new Category();
        }
    }
}
