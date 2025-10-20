using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Core.DTOs;                       
using MinimalAPI.ServiceLocator.Helper;      

namespace MinimalAPI.ServiceLocator.Controllers
{
    public class ServiceControllerBase : ControllerBase
    {

        protected readonly Dictionary<string, Func<Task<IEnumerable<object>>>> ListResolvers;
        protected readonly Dictionary<string, Func<object, Task<object>>> CreateResolvers;
        protected readonly Dictionary<string, Func<int, object, Task<bool>>> UpdateResolvers;
        protected readonly Dictionary<string, Func<int, Task<bool>>> DeleteResolvers;

        protected ServiceControllerBase(IServiceMapper serviceMapper)
        {
            // ReadResolvers 
            ListResolvers = new()
            {
                ["tickets"] = async () =>
                {
                    // defer resolution until invocation time
                    var service = await serviceMapper.GetServiceAsync<TicketDTO>("tickets");
                    var data = await service.GetDataAsync();
                    return data.Cast<object>();
                }
            };

            // CreateResolvers

            CreateResolvers = new()
            {
                ["tickets.cud"] = async (body) =>
                {
                    var service = await serviceMapper.GetServiceAsync<TicketDTO>("tickets.cud");
                    var dto = (TicketDTO)body;
                    var created = await service.CreateDataAsync(dto);
                    return created!;
                }
            };

            // UpdateResolvers

            UpdateResolvers = new()
            {
                ["tickets.cud"] = async (id, body) =>
                {
                    var service = await serviceMapper.GetServiceAsync<TicketDTO>("tickets.cud");
                    var dto = (TicketDTO)body;
                    var ok = await service.UpdateDataAsync(id, dto);
                    return ok;
                }
            };

            //DeleteResolvers

            DeleteResolvers = new()
            {
                ["tickets.cud"] = async (id) =>
                {
                    var service = await serviceMapper.GetServiceAsync<TicketDTO>("tickets.cud");
                    var ok = await service.DeleteDataAsync(id);
                    return ok;
                }
            };
        }
    }
}

//TicketDTO should be defined in MinimalAPI.Core.DTOs namespace.
//Awaiting further merge