using Microsoft.AspNetCore.Mvc;
using ModernITCourse.Services;
using System.Threading.Tasks;

namespace ModernITCourse.Controllers
{
    [Route("update/")]
    [ApiController]
    public class UpdateController : Controller
    {
        private readonly IUniversitiesService universitiesService;

        public UpdateController(IUniversitiesService universitiesService)
        {
            this.universitiesService = universitiesService;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            await universitiesService.UpdateUniversities();
            return "Success";
        }

        [HttpPut]
        public async Task<string> Put()
        {
            await universitiesService.UpdateUniversities();
            return "Success";
        }
    }
}
