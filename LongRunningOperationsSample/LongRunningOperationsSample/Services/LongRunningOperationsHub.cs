using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace LongRunningOperationsSample.Services
{
    public class LongRunningOperationsHub : Hub
    {

        public async Task Subscribe(Guid operationId)
        {
            var groupName = operationId.ToString().ToLowerInvariant();
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

    }
}