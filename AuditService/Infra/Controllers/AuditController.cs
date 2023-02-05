using AuditService.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuditService.Infra.Controllers
{
    [Route("/")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private readonly IGetAllRegistriesService _getAllRegistriesService;

        public AuditController(IGetAllRegistriesService getAllRegistriesService)
        {
            _getAllRegistriesService = getAllRegistriesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? page, int? numberOfItemsPerPage)
        {
            var registries = await _getAllRegistriesService.ExecuteAsync(page, numberOfItemsPerPage);
            return Ok(registries);
        }

        /*
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        */
    }
}
