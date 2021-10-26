using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using movie_api_WaiChun.Services;
using movie_api_WaiChun.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace movie_api_WaiChun.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MetadataController : ControllerBase
    {
        private readonly MetadataService _metadataService;

        public MetadataController(MetadataService metadataService)
        {
            _metadataService = metadataService;
        }

        // GET <MetadataController>/5
        [HttpGet("{id}")]
        public ActionResult<List<Metadata>> Get(int id)
        {
            List<Metadata> metadata = _metadataService.GetMetadataById(id);
            if (metadata.Count != 0)
                return Ok(metadata);
            else
                return NotFound();

        }

        // POST <MetadataController>
        [HttpPost]
        public ActionResult Post([FromBody]Metadata itemData)
        {
            bool AddNewItem = _metadataService.PostItem(itemData);

            if(AddNewItem)
            return CreatedAtAction(nameof(Post), "", "");

            return BadRequest();
        }



    }
}
