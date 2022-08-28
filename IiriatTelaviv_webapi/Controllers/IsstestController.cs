using DomainIriatTelaviv.Classes;
using DomainIriatTelaviv.Interfaces;
using DomainIriatTelaviv.Res_Req.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IiriatTelaviv_webapi.Controllers
{




    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IsstestController : ControllerBase
    {

        private readonly IgeneralService _generalService;

        public IsstestController(IgeneralService generalService)
        {

            _generalService = generalService;
        }

        [AllowAnonymous]
        [HttpPost]
        [ActionName("GetIssCurrentLocation")]
        public IActionResult GetIssCurrentLocation()
        {
            var res= _generalService.GetIssResponse();
            return Ok(res);
        }


        [AllowAnonymous]
        [HttpPost]
        [ActionName("AddLocationTolist")]
        public IActionResult AddLocationTolist(IssRequests req)
        {
            var res = _generalService.AddLocationTolist(req);
            return Ok(res);
        }



    }
}
