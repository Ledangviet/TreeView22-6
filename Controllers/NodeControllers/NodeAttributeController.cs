using Excercise_2_Business_Logic_Layer.Node_BLL;
using Excercise_2_Business_Logic_Layer.NodeAttributeBLL;
using Excercise_2_Data_Transfer_Object.NodeAttributeDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace Excercise_2_API.Controllers.NodeControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeAttributeController : ControllerBase
    {
        private readonly INodeRepository _nodeRepository;
        private readonly INodeAttributeRepository _nodeAttributeRepository;
        public NodeAttributeController(INodeAttributeRepository nodeAttributeRepository, INodeRepository nodeRepository)
        {
            _nodeAttributeRepository = nodeAttributeRepository;
            _nodeRepository = nodeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllNodeAsync()
        {
            var list = await _nodeAttributeRepository.GetAllNodeAttributeAsync();
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> AddNodeAttributeAsync(AddNodeAttributeModel model)
        {
            try
            {
                var node = await _nodeRepository.GetNodeByIdAsync(model.NodeId);
                if (node == null)
                    return BadRequest("Node doesn't exist!");
                var list = await _nodeAttributeRepository.AddNodeAttributeAsync(model);
                return Ok(list);
;            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
