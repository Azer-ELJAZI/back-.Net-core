namespace stage1.Models
{
    public class ProductFamily
    {
        public int ID { get; set; }
        public string? Name { get; set; } // Nullable property
        public ICollection<Article> Articles { get; set; } = new List<Article>();

        // Ensure there's a parameterless constructor for EF
        public ProductFamily() { }

        public ProductFamily(string name)
        {
            Name = name;
        }
    }
}
