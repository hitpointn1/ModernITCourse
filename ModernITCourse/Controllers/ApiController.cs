using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernITCourse.Models;
using ModernITCourse.Services;
using ModernITCourse.Services.DomainTransferObjects;
using System.Text.Json;
using System.Threading.Tasks;

namespace ModernITCourse.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IUniversitiesService universitiesService;
        private readonly IUpdatesService updatesService;
        private readonly IExecutionService executionService;
        public const int VSU_RATING = 296;
        public const int ITERATIONS_COUNT = 10;
        public const int MS_DELAY = 3000;

        public ApiController(IUniversitiesService universitiesService,
            IUpdatesService updatesService,
            IExecutionService executionService)
        {
            this.universitiesService = universitiesService;
            this.updatesService = updatesService;
            this.executionService = executionService;
        }

        [HttpGet("vsu")]
        public UniversityDto[] GetTaskEightData()
        {
            return universitiesService.GetUniversitiesAboveRating(VSU_RATING);
        }

        [HttpPost("vsu")]
        public async Task<LongPollingResponse> GetTaskEightData([FromBody] LongPollingRequest request)
        {
            UpdateDto update = null;
            UniversityDto[] dtos = null;
            int iterationsCount = ITERATIONS_COUNT;
            do
            {
                update = await updatesService.GetUniversitiesListUpdate(request.TimeStamp);
                if (update.NeedUpdate)
                {
                    dtos = universitiesService.GetUniversitiesAboveRating(VSU_RATING);
                    break;
                }

                if (iterationsCount == 0)
                {
                    await NoContent().ExecuteResultAsync(ControllerContext);
                    return null;
                }

                iterationsCount--;
                await Task.Delay(MS_DELAY);
            }
            while (!update.NeedUpdate);

            return new LongPollingResponse()
            {
                IsFinished = update.IsFinished,
                TimeStamp = update.TimeStamp,
                Universities = dtos
            };
        }

        [HttpGet("execute")]
        public async Task Execute()
        {
            Response.ContentType = "text/event-stream";
            ExecutionDto execution;
            do
            {
                execution = executionService.GetStage();
                if (execution.NeedUpdate)
                {
                    await HttpContext.Response.WriteAsync($"data:{JsonSerializer.Serialize(execution)}\n\n");
                    await HttpContext.Response.Body.FlushAsync();
                }
                await Task.Delay(500);
            }
            while (!execution.IsFinished);

            Response.Body.Close();
        }

    }
}
