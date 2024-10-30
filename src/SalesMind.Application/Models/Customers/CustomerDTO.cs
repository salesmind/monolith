﻿namespace SalesMind.Application.Models.Customers;
public class CustomerDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public string CreatedBy { get; set; }
    public string ModifiedBy { get; set; }
}
