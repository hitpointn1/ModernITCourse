using Microsoft.AspNetCore.Mvc;
using ModernITCourse.Models;
using ModernITCourse.Services;
using ModernITCourse.Services.DomainTransferObjects;
using System.Threading.Tasks;

namespace ModernITCourse.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IUniversitiesService universitiesService;
        private readonly IUpdatesService updatesService;
        public const int VSU_RATING = 296;
        public const int ITERATIONS_COUNT = 10;
        public const int MS_DELAY = 3000;

        public ApiController(IUniversitiesService universitiesService,
            IUpdatesService updatesService)
        {
            this.universitiesService = universitiesService;
            this.updatesService = updatesService;
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

    }
}
