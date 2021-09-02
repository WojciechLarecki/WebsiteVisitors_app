using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteVisitorsAPI.Models;
using WebsiteVisitorsAPI.Repositories.Interfaces;

namespace WebsiteVisitorsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorsController : ControllerBase
    {
        private readonly IVisitorsRepository _repo;
        private readonly IMapper _mapper;

        public VisitorsController(IVisitorsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<VisitorDTO>))]
        public IActionResult GetAllVisitors()
        {
            
            IEnumerable<Visitor> visitors = _repo.SelectAllVisitors();
            List<VisitorDTO> visitorsDTO = new List<VisitorDTO>();
            VisitorDTO visitorDTO;

            foreach (var visitor in visitors)
            {
                visitorDTO = _mapper.Map<VisitorDTO>(visitor);
                visitorsDTO.Add(visitorDTO);
            }

            return Ok(visitorsDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<VisitorDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostVisitor([FromBody]VisitorDTO visitorDTO)
        {
            IActionResult result;

            if (visitorDTO == null)
            {
                result = BadRequest();
            }
            else
            {
                _repo.InsertVisitor(visitorDTO);
                result = Ok();
            }

            return result;
        }
    }
}
