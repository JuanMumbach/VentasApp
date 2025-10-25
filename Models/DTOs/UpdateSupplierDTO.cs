namespace VentasApp.Models.DTOs
{
    public class UpdateSupplierDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Cuil { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}