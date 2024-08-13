using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCase.Common.BaseController
{
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("/api/v1")]
    public class BaseApiController : ControllerBase
    {

    }
}
