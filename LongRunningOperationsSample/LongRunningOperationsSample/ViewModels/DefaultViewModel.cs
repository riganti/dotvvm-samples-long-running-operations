using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using LongRunningOperationsSample.Services;

namespace LongRunningOperationsSample.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        private readonly ILongRunningOperationService longRunningOperationService;

        public LongRunningOperationStatus Status { get; set; }

        public DefaultViewModel(ILongRunningOperationService longRunningOperationService)
        {
            this.longRunningOperationService = longRunningOperationService;
        }
        
        public void StartOperation()
        {
            var operation = longRunningOperationService.Create();
            operation.Status = "Starting...";
            operation.ProgressPercent = 0;
            Status = operation;

            Task.Factory.StartNew(async () =>
            {
                await Task.Delay(1000);

                operation.Status = "Work in progress...";
                operation.ProgressPercent = 20;
                await longRunningOperationService.ReportChange(operation);

                await Task.Delay(1000);

                operation.Status = "Finishing...";
                operation.ProgressPercent = 80;
                await longRunningOperationService.ReportChange(operation);

                await Task.Delay(1000);

                operation.SetCompleted();
                await longRunningOperationService.ReportChange(operation);
            });
        }
    }
}
