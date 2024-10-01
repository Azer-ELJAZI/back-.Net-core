using System.Text.Json.Serialization;

namespace stage1.Models
{
    public class Article
    {
        public int ID { get; set; }
        public string? ItemType { get; set; }
        public string? ItemNumber { get; set; }
        public string? Description { get; set; }
        public string? Manufacturer { get; set; }
        public string? Barcode { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string? Quantity { get; set; }
        public int ProductFamilyID { get; set; } // Foreign Key

        [JsonIgnore]
        public ProductFamily? ProductFamily { get; set; } // Nullable Navigation Property

        public string? Qtystep { get; set; }
        public string? ArticleGroup1 { get; set; }
        public string? ArticleGroup2 { get; set; }
        public string? ArticleGroup3 { get; set; }
        public string? ArticleGroup4 { get; set; }
        public string? ArticleGroup5 { get; set; }
        public string? Warranty { get; set; }
        public string? Guarantee { get; set; }
        public string? Vat { get; set; }
        public string? Price { get; set; }
        public string? PurchasePrice { get; set; }
        public string? Currency { get; set; }

        public Article() { }

        public Article(ProductFamily productFamily)
        {
            ProductFamily = productFamily;
            ProductFamilyID = productFamily.ID;
        }
    }
}