using LangelandsPizza.Models.Dbfiles;
using LangelandsPizza.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LangelandsPizza.Models.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly AppDbContext appDbConctext;

        public CategoryRepository(AppDbContext appDbConctext)
        {
            this.appDbConctext = appDbConctext;
        }

        public IEnumerable<Category> GetCategories() => appDbConctext.Category;
      
    }
}
