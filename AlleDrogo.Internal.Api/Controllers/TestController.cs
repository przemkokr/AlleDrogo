using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlleDrogo.Internal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private static readonly string[] Descriptions = new[]
        {
            "Description 1", "Description 2", "Description 3", "Description 4", "Description 5"
        };

        private static readonly string[] Names = new[]
        {
            "Name 1", "Name 2", "Name 3", "Name 4", "Name 5"
        };

        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<SampleData>> Get()
        {
            await Task.CompletedTask;

            var rng = new Random();
            var result = Enumerable.Range(1, 5).Select(index => new SampleData
            {
                SomeDate = DateTime.Now.AddDays(index),
                SomeDecimalValue = rng.Next(-10, 10),
                Description = Descriptions[rng.Next(Descriptions.Length)],
                Name = Names[rng.Next(Names.Length)]
            });

            return result;
        }        
    }

    public class SampleData
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal SomeDecimalValue { get; set; }

        public DateTime SomeDate { get; set; }
    }
}
