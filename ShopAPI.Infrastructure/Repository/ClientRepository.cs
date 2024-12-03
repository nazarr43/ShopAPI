using Microsoft.EntityFrameworkCore;
using ShopAPI.Application.DTOs;
using ShopAPI.Application.Interfaces;
using ShopAPI.Infrastructure.Data;

namespace ShopAPI.Infrastructure.Repository;
public class ClientRepository : IClientRepository
{
    private readonly ShopDbContext _context;

    public ClientRepository(ShopDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ClientBirthdayDto>> GetBirthdayClientsAsync(DateTime date)
    {
        var currentDate = date.Date; 
        return await _context.Clients
            .Where(c => c.BirthDate.Month == currentDate.Month && c.BirthDate.Day == currentDate.Day)
            .Select(c => new ClientBirthdayDto
            {
                Id = c.Id,
                FullName = c.FullName
            })
            .ToListAsync();
    }
    public async Task<IEnumerable<ClientLastPurchaseDto>> GetRecentBuyersAsync(int days)
    {
        var dateFrom = DateTime.UtcNow.AddDays(-days).Date;

        return await _context.Purchases
            .Where(p => p.Date.Date >= dateFrom) 
            .GroupBy(p => new { p.Client.Id, p.Client.FullName })
            .Select(g => new ClientLastPurchaseDto
            {
                Id = g.Key.Id,
                FullName = g.Key.FullName,
                LastPurchaseDate = g.Max(p => p.Date)
            })
            .ToListAsync();

    }
    public async Task<IEnumerable<ClientCategoryDto>> GetClientCategoriesAsync(int clientId)
    {
        return await _context.PurchaseItems
            .Where(pi => pi.Purchase.ClientId == clientId)
            .GroupBy(pi => pi.Product.Category)
            .Select(g => new ClientCategoryDto
            {
                Category = g.Key,
                Quantity = g.Sum(pi => pi.Quantity)
            })
            .ToListAsync();
    }
}

