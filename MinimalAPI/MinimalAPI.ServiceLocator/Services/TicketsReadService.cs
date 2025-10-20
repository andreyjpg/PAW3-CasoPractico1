using MinimalAPI.MinimalAPI.ServiceLocator.Services.Contracts;
using MinimalAPI.MinimalAPI.Architecture.Providers;
using MinimalAPI.MinimalAPI.Core.DTOs;

namespace MinimalAPI.ServiceLocator.Services;

public interface ITicketsReadService
{
    Task<IEnumerable<TicketDTO>> GetDataAsync();
}

public class TicketsReadService(IRestProvider restProvider, IConfiguration configuration)
    : IService<TicketDTO>, ITicketsReadService
{
    public async Task<IEnumerable<TicketDTO>> GetDataAsync()
    {
        // APIS.TicketsRead → debe apuntar a tu Minimal: http://localhost:5091/tickets
        var url = configuration.GetStringFromAppSettings("APIS", "TicketsRead");
        var response = await restProvider.GetAsync(url, null);
        return await JsonProvider.DeserializeAsync<IEnumerable<TicketDTO>>(response);
    }
}
