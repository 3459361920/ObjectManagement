using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Common
{
    [Route("api/[controller]/[action]")]  //路由
    [Common.ResultExecuted]
    [Common.ExecutedFilter]
    public class BaseController: Microsoft.AspNetCore.Mvc.ControllerBase
    {
    }
}
