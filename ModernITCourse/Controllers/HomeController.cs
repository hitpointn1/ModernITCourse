using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ModernITCourse.Models;
using ModernITCourse.Services;
using ModernITCourse.Services.DomainTransferObjects;
using System;
using System.Diagnostics;

namespace ModernITCourse.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInitService initService;
        private readonly IUniversitiesService universitiesService;
        private readonly bool NeedInitData;
        public const int VSU_RATING = 296;
        public const int DEFAULT_COUNT = 15;

        public HomeController(
            IConfiguration configuration,
            IInitService initService,
            IUniversitiesService universitiesService)
        {
            NeedInitData = Convert.ToBoolean(configuration[nameof(NeedInitData)]);
            this.initService = initService;
            this.universitiesService = universitiesService;
        }

        public IActionResult Index()
        {
            if (NeedInitData)
                initService.InsertInitialData();

            return View();
        }

        [HttpGet("[action]/{rating?}")]
        public IActionResult TaskEight(int? rating)
        {
            if (!rating.HasValue)
                return RedirectToAction(nameof(TaskEight), new { rating = VSU_RATING });

            UniversityDto[] universityDtos = universitiesService.GetUniversitiesAboveRating(rating.Value);
            var vm = new TaskEightViewModel()
            {
                Rating = rating.Value,
                Universities = universityDtos
            };
            return View(vm);
        }

        [HttpGet("[action]/{count?}")]
        public IActionResult TaskNine(int? count)
        {
            if (!count.HasValue)
                return RedirectToAction(nameof(TaskNine), new { count = DEFAULT_COUNT });

            var universityDtos = universitiesService.GetUniversitiesWithStudentsOverCount(count.Value);
            var vm = new TaskNineViewModel()
            {
                StudentsCount = count.Value,
                Universities = universityDtos
            };
            return View(vm);
        }

        [HttpGet("[action]")]
        public IActionResult JSExample(int? count)
        {
            return View(VSU_RATING);
        }

        [HttpGet("[action]")]
        public IActionResult SSEExample()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
