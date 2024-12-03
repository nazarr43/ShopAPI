using Microsoft.AspNetCore.Mvc;
using ShopAPI.Application.Interfaces;
using System.Runtime.InteropServices;

namespace ShopAPI.Presentation.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("birthdays")]
    public async Task<IActionResult> GetBirthdayClients([FromQuery] DateTime date)
    {
        var clients = await _clientService.GetBirthdayClientsAsync(date);
        return Ok(clients.Select(c => new { c.Id, c.FullName }));
    }

    [HttpGet("recent-buyers")]
    public async Task<IActionResult> GetRecentBuyers([FromQuery] int days)
    {
        var buyers = await _clientService.GetRecentBuyersAsync(days);
        return Ok(buyers);
    }

    [HttpGet("{clientId}/categories")]
    public async Task<IActionResult> GetClientCategories(int clientId)
    {
        var categories = await _clientService.GetClientCategoriesAsync(clientId);
        return Ok(categories);
    }

}

