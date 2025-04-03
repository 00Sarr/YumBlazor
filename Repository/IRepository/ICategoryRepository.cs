using YumBlazor.Data;

namespace YumBlazor.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Category Create(Category category);
        public Category Update(Category category);
        public bool Delete(int Id);
        public Category Get(int Id);
        public IEnumerable<Category> GetAll();

    }
}
