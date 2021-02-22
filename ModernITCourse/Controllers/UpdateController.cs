using Microsoft.AspNetCore.Mvc;
using ModernITCourse.Services;
using System.Threading.Tasks;

namespace ModernITCourse.Controllers
{
    public class UpdateController : Controller
    {
        private readonly IUniversitiesService universitiesService;

        public UpdateController(IUniversitiesService universitiesService)
        {
            this.universitiesService = universitiesService;
        }

        public async Task<string> Index()
        {
            await universitiesService.UpdateUniversities();
            return "Success";
        }
    }
}
