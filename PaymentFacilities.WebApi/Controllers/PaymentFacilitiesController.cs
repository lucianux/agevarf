using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaymentFacilities.SharedKernel.Interfaces;
using PaymentFacilities.Core.Entities;

namespace PaymentFacilities.WebApi.Controllers
{
    public class PaymentFacilitiesController : BaseApiController
    {
        private readonly IRepository _repository;

        public PaymentFacilitiesController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/PaymentFacilities
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var items = (await _repository.ListAsync<PaymentFacility>());
            return Ok(items);
        }

        // POST api/PaymentFacilities
        [HttpPost]
        public async Task<ActionResult<PaymentFacility>> Post([FromBody] PaymentFacility pf)
        {
            pf.IdNumber = await _repository.GetNextId();
            pf.Id = Guid.NewGuid();
            await _repository.Create<PaymentFacility>(pf);
            return new OkObjectResult(pf);
        }
    }
}