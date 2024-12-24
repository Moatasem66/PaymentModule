using PaymentModule.Entities;

namespace PaymentModule.DTOs.PaymentHistoryDTO;

public class PaymentHistoryRequestDTO
{
    public DateOnly ActionDate { get; set; }
    public string Status { get; set; }
    public string Comment { get; set; }
    public int PaymentId { get; set; }

}
