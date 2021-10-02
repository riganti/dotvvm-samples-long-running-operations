using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LongRunningOperationsSample.Services
{
    public interface ILongRunningOperationService
    {

        LongRunningOperationStatus Create();

        Task ReportChange(LongRunningOperationStatus status);

    }
}
