using Excercise_2_Business_Logic_Layer.Node_BLL;
using Excercise_2_Business_Logic_Layer.NodeAttributeBLL;
using Excercise_2_Data_Transfer_Object.NodeAttributeDTO;
using Excercise_2_Data_Transfer_Object.NodeDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Excercise_2_API.Controllers.NodeControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        private readonly INodeRepository _nodeRepository;
        private readonly INodeAttributeRepository _nodeAttributeRepository;

        public NodeController(INodeRepository nodeRepository, INodeAttributeRepository nodeAttributeRepository)
        {
            _nodeRepository = nodeRepository;
            _nodeAttributeRepository = nodeAttributeRepository;
        }

        /// <summary>
        /// get all node
        /// </summary>
        /// <returns>A list of GetNodeModel</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllNodeAsync()
        {
            try
            {
                List<GetNodeModel> nodemodels = await _nodeRepository.GetAllNodeAsync();
                return Ok(nodemodels);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// get node by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>a GetNodeModel</returns>
        [HttpGet("id")]
        public async Task<IActionResult> GetNodeByIdAsync([FromHeader]int id)
        {
            try
            {
                GetNodeModel nodemodel = await _nodeRepository.GetNodeByIdAsync(id);
                if (nodemodel == null)
                    return BadRequest("Node doesn't exist!");
                else
                    return Ok(nodemodel);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Add a node and it's list nodeAttribute 
        /// </summary>
        /// <param name="nodemodel"></param>
        /// <param name="nodeAttributeModels"></param>
        /// <returns>return a list of all node</returns>
        [HttpPost]
        public async Task<IActionResult> AddNodeAsync([FromBody]AddNodeModel nodemodel,[FromForm]AddNodeAttributeModel[]? nodeAttributeModels)
        {
            try
            {
                var result = await _nodeRepository.AddNodeAsync(nodemodel);
                if (nodeAttributeModels == null)
                    return Ok(result);
                foreach (AddNodeAttributeModel nodeAttributeModel in nodeAttributeModels)
                {
                    await _nodeAttributeRepository.AddNodeAttributeAsync(nodeAttributeModel);
                }
                return Ok(result);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Update a node
        /// </summary>
        /// <param name="nodeModel"></param>
        /// <returns> return node after update</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateNodeAsync(UpdateNodeModel nodeModel)
        {
            try
            {
                var node = await _nodeRepository.GetNodeByIdAsync(nodeModel.Id);
                if(node==null)
                {
                    return BadRequest("Node doesn't exist!");
                }    
                var result = await _nodeRepository.UpdateNodeAsync(nodeModel);
                if (result == null)
                {
                    return BadRequest("Update fail!");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete node by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> return list of all node after delete</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteNodeById(int id)
        {
            try
            {
                var node = await _nodeRepository.GetNodeByIdAsync(id);
                if(node == null)
                {
                    return BadRequest("Node doesn't exist!");
                }
                var result = await _nodeRepository.DeleteNodeAsync(id); 
                if (result == null)
                {
                    return BadRequest("Delete fail!");
                }
                return Ok(result);

            }catch(Exception)
            {
                throw;
            }
        }
    }
}
