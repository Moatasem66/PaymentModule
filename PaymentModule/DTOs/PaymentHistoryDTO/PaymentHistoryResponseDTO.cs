using PaymentModule.Entities;
using PaymentModule.DTOs.PaymentDTO;

namespace PaymentModule.DTOs.PaymentHistoryDTO;
public class PaymentHistoryResponseDTO
{
    public int Id { get; set; }
    public DateOnly ActionDate { get; set; }
    public string Status { get; set; }
    public string Comment { get; set; }
    public virtual PaymentResponseDTO? Payment  { get; set; }
}
