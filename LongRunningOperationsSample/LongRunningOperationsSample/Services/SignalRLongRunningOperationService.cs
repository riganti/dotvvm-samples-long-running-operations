using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace LongRunningOperationsSample.Services
{
    public class SignalRLongRunningOperationService : ILongRunningOperationService
    {
        private readonly IHubContext<LongRunningOperationsHub> hubContext;

        public SignalRLongRunningOperationService(IHubContext<LongRunningOperationsHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public LongRunningOperationStatus Create()
        {
            return new LongRunningOperationStatus()
            {
                OperationId = Guid.NewGuid()
            };
        }

        public async Task ReportChange(LongRunningOperationStatus status)
        {
            var groupName = status.OperationId.ToString().ToLowerInvariant();
            await hubContext.Clients.Group(groupName).SendCoreAsync("newStatus", new object[] { status });
        }
    }
}