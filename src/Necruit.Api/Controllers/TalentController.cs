using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Necruit.Api.Common;
using Necruit.Application;
using Necruit.Application.Service.Talents;
using Necruit.Application.Service.Talents.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Necruit.Api.Controllers
{
    [Route("api/talents")]
    [ApiController]
    public class TalentController : Controller
    {
        private ITalentService talentService;
        private IMapper mapper;

        public TalentController(ITalentService talentService, IMapper mapper)
        {
            this.talentService = talentService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<TalentDetailDto>>> GetAll([FromQuery] PageQuery filter)
        {
            var query = new PageRequest(filter.PageNumber, filter.PageSize);
            var result = await talentService.GetActives(query);
            return Ok(result);
        }

        [HttpGet("passive")]
        public async Task<ActionResult<List<TalentDetailDto>>> GetPassives([FromQuery] PageQuery filter)
        {
            var query = new PageRequest(filter.PageNumber, filter.PageSize);
            var result = await talentService.GetPassives(query);
            return Ok(result);
        }
        [HttpGet("pool")]
        public async Task<ActionResult<List<TalentDetailDto>>> GetInPools([FromQuery] PageQuery filter)
        {
            var query = new PageRequest(filter.PageNumber, filter.PageSize);
            var result = await talentService.GetTalentsInPool(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TalentDetailDto>> GetJobDetail(int id)
        {
            var result = await talentService.GetDetail(id);
            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Post(CreateUpdateTalentDto request)
        {
            var result = await talentService.Create(request);
            return CreatedAtAction("Get", new { id = result });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Put(int id, CreateUpdateTalentDto request)
        {
            var result = await talentService.Update(id, request);
            if (result == 0)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await talentService.Delete(id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<int>> Pathc(int id, [FromBody] JsonPatchDocument<TalentPathcDto> request)
        {
            TalentDetailDto talent = await talentService.GetDetail(id);
            if (talent == null)
                return NotFound();
            var talentPatch = mapper.Map<TalentPathcDto>(talent);
            request.ApplyTo(talentPatch);
            await talentService.Patch(id, talentPatch);
            return NoContent();
        }
    }
}
