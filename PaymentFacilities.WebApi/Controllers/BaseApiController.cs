using Microsoft.AspNetCore.Mvc;

namespace PaymentFacilities.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
