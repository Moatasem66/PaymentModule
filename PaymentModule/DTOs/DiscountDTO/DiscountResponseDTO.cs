namespace PaymentModule.DTOs.DiscountDTO;

public class DiscountResponseDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Presentage { get; set; }
    public string Condation { get; set; }
}
