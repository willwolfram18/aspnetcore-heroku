using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.Web.Models;
using NSwag.Annotations;

namespace NetCore.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private static readonly ValueViewModel[] _data = new []
        {
            new ValueViewModel
            {
                Id = 1,
                Name = "Item 1",
            },
            new ValueViewModel
            {
                Id = 2,
                Name = "Item 2"
            },
            new ValueViewModel
            {
                Id = 3,
                Name = "Item 3"
            },
            new ValueViewModel
            {
                Id = 4,
                Name = "Item 4"
            }
        };


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ValueViewModel>), StatusCodes.Status200OK)]
        public IActionResult GetValues()
        {
            return Ok(_data);
        }

        /// <summary>
        /// Retrieves a specific value by id.
        /// </summary>
        /// <param name="id">The id of the value to get.</param>
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(ValueViewModel), Description = "Returns the value associated with the given id.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, typeof(void), Description = "The value does not exist.")]
        public IActionResult GetValue(int id)
        {
            var item = _data.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpGet("name")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(ValueViewModel), Description = "Returns the name of the value associated with the given id.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, typeof(void), Description = "The value does not exist.")]
        public IActionResult GetValueName([FromQuery] ExampleGetModel model)
        {
            var item = _data.FirstOrDefault(i => i.Id == model.Id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item.Name);
        }
    }
}