using System;
using System.Collections.Generic;
using empresax.permiso.api.domain.aggregate;
using empresax.permiso.api.domain.DTO;
using empresax.permiso.api.domain.model;
using empresax.permiso.api.application.transform;
using AutoMapper;

namespace empresax.permiso.api.infraestructure.transform
{
    public class PermissionTransform : IPermissionTransform
    {

        private readonly IMapper mapper;

        public PermissionTransform(IMapper mapper){
            this.mapper = mapper;
        }

        public PermissionAggregate getAggregate(PermissionDTO dto)
        {
            if(dto == null)
            {
                return null;
            }

            if(dto.date == null)
            {
                dto.date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            }

            return new PermissionAggregate(mapper.Map<Permission>(dto));
        }

        public PermissionDTO getDTO(PermissionAggregate aggregate)
        {
            if(aggregate == null || aggregate.root == null){
                return null;
            }

            return mapper.Map<PermissionDTO>(aggregate.root);
        }

        public List<PermissionAggregate> getAggregates(List<PermissionDTO> DTOs)
        {
            List<PermissionAggregate> aggregates = new List<PermissionAggregate>();
            
            if(DTOs != null){
                DTOs.ForEach(item=>aggregates.Add(this.getAggregate(item)));
            }

            return aggregates;
        }

        public List<PermissionDTO> getDTOs(List<PermissionAggregate> aggregates)
        {
            List<PermissionDTO> dtos = new List<PermissionDTO>();

            if(aggregates != null){
                aggregates.ForEach(item=>dtos.Add(this.getDTO(item)));
            }

            return dtos;
        }
    }
}