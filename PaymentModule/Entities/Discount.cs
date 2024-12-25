namespace PaymentModule.Entities;
/// <summary>
/// this entity for Discount to Apply .
/// Contain properties Id , Description , Presentage , Condation 
/// </summary>
public class Discount
{
    public int Id { get; set; }
    public string Desciption { get; set; }
    public decimal Presentage { get; set; }
    public string Condation { get; set; }
    public int? InsurenceId { get; set; }
    public virtual ICollection<Invoice>? Invoices { get; set; } 
}
