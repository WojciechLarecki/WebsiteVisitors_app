using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteVisitorsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorsController : ControllerBase
    {
        private readonly IVisitorsRepository _repo;
        private readonly IMapper mapper;

        [HttpGet]
        public IActionResult GetAllVisitors()
        {
            
            IEnumerable<Visitor> visitors = _repo.LoadAllVisitors();
            List<VisitorDTO> visitorsDTO = new List<VisitorDTO>();
            VisitorDTO visitorDTO;

            foreach (var visitor in visitors)
            {
                visitorDTO = mapper.Map<VisitorDTO>(visitor);
                visitorsDTO.Add(visitorDTO);
            }

            return Ok(visitorsDTO);
        }

        [HttpPost]
        public IActionResult PostVisitor([FromBody]VisitorDTO visitorDTO)
        {
            IActionResult result;

            if (visitorDTO == null)
            {
                result = BadRequest();
            }
            else if (_repo.VisitorExist(visitorDTO))
            {
                ModelState.AddModelError("", "Visitor already exists");
                result = StatusCode(StatusCodes.Status406NotAcceptable, ModelState);
            }
            else
            {
                _repo.InsertVisitor();
                result = Ok();
            }

            return result;
        }
    }
}
