namespace ModernITCourse.Services.DomainTransferObjects
{
    public class ExecutionDto
    {
        public string Message { get; set; }
        public int Load { get; set; }
        public bool NeedUpdate { get; set; }
        public bool IsFinished { get; set; }
    }
}
