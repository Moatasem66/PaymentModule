namespace PaymentModule.DTOs.DiscountDTO;

public class DiscountRequestDTO
{
    public string Desciption { get; set; }
    public decimal Presentage { get; set; }
    public string Condation { get; set; }
    public int? InsurenceId { get; set; }
}
