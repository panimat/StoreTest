namespace POSStore.Data.Model
{
    public class Product : ModelBase
    {
        public decimal price { get; set; }

        public bool isAvailable { get; set; }

        public bool isMostPopular { get; set; }

        public int categoryId { get; set; }

        public virtual Category Categ { get; set; }
    }
}
