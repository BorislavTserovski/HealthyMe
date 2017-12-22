namespace HealthyMe.Data.Models
{
    public class DietProduct
    {
        public int DietId { get; set; }

        public Diet Diet { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}