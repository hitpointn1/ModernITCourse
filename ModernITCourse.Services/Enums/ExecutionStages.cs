using System.ComponentModel;

namespace ModernITCourse.Services.Enums
{
    public enum ExecutionStages : byte
    {
        [Description("Starting...")]
        Starting = 0,
        [Description("Preparing...")]
        Preparing = 1,
        [Description("Creating Backups...")]
        Backups = 2,
        [Description("Loading prerequisites...")]
        LoadingPrerequisites = 3,
        [Description("Execution...")]
        Execution = 4,
        [Description("Cleanup...")]
        Cleanup = 8,
        [Description("Finish!")]
        Finish = 10,
    }
}
