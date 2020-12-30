using SimpleStore.Domain.BaseModels;

namespace SimpleStore.Domain.Products
{
    public class CategoryModel : BaseModel
    {
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
