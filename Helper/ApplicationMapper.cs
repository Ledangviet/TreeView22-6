using AutoMapper;
using Excercise_2_Data_Access_Layer.Data.Entities;
using Excercise_2_Data_Transfer_Object.NodeAttributeDTO;
using Excercise_2_Data_Transfer_Object.NodeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_2_Business_Logic_Layer.Helper
{
    internal class ApplicationMapper : Profile
    {
        /// <summary>
        /// Map Entities to Models
        /// </summary>
        public ApplicationMapper()
        {
            CreateMap<Node, GetNodeModel>().ReverseMap();
            CreateMap<Node, UpdateNodeModel>().ReverseMap();
            CreateMap<Node, AddNodeModel>().ReverseMap();
            CreateMap<NodeAttribute, GetNodeAttributeModel>().ReverseMap();
            CreateMap<NodeAttribute, AddNodeAttributeModel>().ReverseMap();
            CreateMap<NodeAttribute, UpdateNodeAttributeModel>().ReverseMap();
        }
    }
}
