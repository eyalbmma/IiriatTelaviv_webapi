using DomainIriatTelaviv.Entities;
using DomainIriatTelaviv.Interfaces;
using DomainIriatTelaviv.Storedprocedures.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IiriatTelaviv_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetTestDataController : ControllerBase
    {
        private readonly IgeneralService _generalService;

        public GetTestDataController(IgeneralService generalService)
        {

            _generalService = generalService;
        }


        [AllowAnonymous]
        [HttpPost]
        public IEnumerable<TestTableResponse> GetTestData([FromBody] TestData Test)
        {

            var res = this._generalService.GetTestdataResponseById(Test.id);
            return res.ToList();
        }


    }
}
