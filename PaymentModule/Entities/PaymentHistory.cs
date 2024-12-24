﻿namespace PaymentModule.Entities;
/// <summary>
/// Entity PaymentHistory to Paymnet .
/// Contain  properties Id , ActionDate , Status , Comment 
/// there are relation with Payment One-to-many 
/// </summary>
public class PaymentHistory
{
    public int Id { get; set; }
    public DateOnly ActionDate { get; set; }
    public string Status { get; set; }
    public string Comment { get; set; }
    public int PaymentId {  get; set; }
    public virtual Payment? Payment { get; set; }

}