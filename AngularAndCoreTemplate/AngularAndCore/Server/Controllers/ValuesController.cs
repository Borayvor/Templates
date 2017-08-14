using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AngularAndCore.Server.Controllers
{
  [Route("api/[controller]")]
  public class ValuesController : Controller
  {
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "First", "Second", "Thid", "Fourth", "Fifth" };
    }
  }
}
