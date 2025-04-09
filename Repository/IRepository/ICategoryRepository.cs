using YumBlazor.Data;

namespace YumBlazor.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Task<Category> CreateAsync(Category category);
        public Task<Category> UpdateAsync(Category category);
        public Task<bool> DeleteAsync(int Id);
        public Task<Category> GetAsync(int Id);
        public Task<IEnumerable<Category>> GetAllAsync();

    }
}
