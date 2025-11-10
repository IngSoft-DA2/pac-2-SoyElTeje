using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace BackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReflectionController : ControllerBase
    {
        private readonly IImporterLogic _importerLogic;

        public ReflectionController(IImporterLogic importerLogic)
        {
            _importerLogic = importerLogic;
        }

        [HttpGet("importers")]
        public IActionResult GetImporters()
        {
            var dllNames = _importerLogic.GetDllNamesWithImporters();
            return Ok(dllNames);
        }
    }
}
