using ModernITCourse.DataAccessLayer;
using ModernITCourse.Services.DomainTransferObjects;
using ModernITCourse.Services.Enums;
using System;
using System.Collections.Generic;

namespace ModernITCourse.Services
{
    public class ExecutionService : ServiceBase, IExecutionService
    {
        private static Random _rand = new Random();
        private Queue<ExecutionStages> Stages = new Queue<ExecutionStages>(Enum.GetValues<ExecutionStages>());
        private ExecutionStages? CurrentStage;
        private DateTime Next;
        public ExecutionService(CourseContext context) : base(context)
        {
        }

        public ExecutionDto GetStage()
        {
            if (CurrentStage == null)
                return GoToNext();

            if (Next < DateTime.Now)
                return GoToNext();

            return new ExecutionDto()
            {
                NeedUpdate = false
            };
        }

        private ExecutionDto GoToNext()
        {
            CurrentStage = Stages.Dequeue();
            Next = DateTime.Now.AddMilliseconds(_rand.Next(500, 3000));
            if (CurrentStage == ExecutionStages.Execution)
                Next = DateTime.Now.AddSeconds(_rand.Next(7, 12));
            return new ExecutionDto()
            {
                IsFinished = CurrentStage == ExecutionStages.Finish,
                Load = (int)CurrentStage * 10,
                Message = CurrentStage.GetEnumDescription(),
                NeedUpdate = true
            };
        }
    }
}
