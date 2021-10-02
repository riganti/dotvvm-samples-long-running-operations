using System;

namespace LongRunningOperationsSample.Services
{
    public class LongRunningOperationStatus
    {

        public Guid OperationId { get; set; }

        public int? ProgressPercent { get; set; }

        public string Status { get; set; }

        public bool IsCompleted { get; set; }

        public bool HasError { get; set; }

        public void SetProgress(int progressPercent)
        {
            ProgressPercent = progressPercent;
        }

        public void SetStatus(string status)
        {
            Status = status;
        }

        public void SetCompleted(string status = "")
        {
            ProgressPercent = 100;
            Status = status;
            IsCompleted = true;
            HasError = false;
        }

        public void SetFailed(string status = "")
        {
            ProgressPercent = 100;
            Status = status;
            IsCompleted = true;
            HasError = true;
        }
    }
}
