using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppForSEII2526.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        //ermite interactuar con la base de datos a través de Entity Framework Core.
        private readonly ApplicationDbContext _context;
        //Variable para escribir logs,  Permite registrar información,
        // errores, advertencias, etc. específicos de DeviceController
        private readonly ILogger<DeviceController> _logger;
        public DeviceController(ApplicationDbContext context, ILogger<DeviceController> logger)
        {
            _context = context;
            _logger = logger;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        [HttpGet]// ← Sin esto, no puedes llamar al método vía HTTP GET
        [Route("[action]")]
        [ProducesResponseType(typeof(decimal), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> ComputeDivision(decimal op1, decimal op2)
        {
            //BadRequest si op2 = 0 (división por cero)
            if (op2 == 0)
            {
                _logger.LogError($"{DateTime.Now} Exception: op2=0, division by 0");
                return BadRequest("op2 must be different from 0");
            }
            decimal result = decimal.Round(op1 / op2, 2);
            return Ok(result);
        }

    }
}
