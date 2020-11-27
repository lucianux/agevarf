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
        // [HttpGet]
        // public string Get()
        // {
        //     return "Hello";
        // }

        // GET: api/PaymentFacilities
        [HttpGet]
        public async Task<IActionResult> List()
        {
            //var items = (await _repository.ListAsync<PaymentFacility>());
            //var items = _repository.ListAsync<PaymentFacility>();
            var items = "sss";
            return Ok(items);
        }

    }
}