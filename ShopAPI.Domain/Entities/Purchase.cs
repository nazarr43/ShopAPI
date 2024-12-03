namespace ShopAPI.Domain.Entities;
public class Purchase
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalAmount { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }

    public List<PurchaseItem> Items { get; set; }
}

