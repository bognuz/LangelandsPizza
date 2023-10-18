namespace LangelandsPizza.Models.Interfaces
{
    public interface ICategory
    {
        IEnumerable<Category> GetCategories();
    }
}
