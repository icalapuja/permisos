using System;
using AutoMapper;
using empresax.permiso.api.domain.model;
using empresax.permiso.api.domain.DTO;


namespace empresax.permiso.api.infraestructure.transform.mapper
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<PermissionDTO, Permission>()
                .ForMember(dest => dest.PermissionTypeId, opt => opt.MapFrom(src => src.type.id))
                .ForMember(dest =>dest.PermissionType, opt=>opt.MapFrom(src => src.type));

            CreateMap<Permission, PermissionDTO>()
                .ForMember(dest=>dest.date,
                                opt => opt.MapFrom(src => src.Date.ToString("yyyy-MM-dd hh:mm:ss")))
                .ForMember(dest =>dest.type, opt=>opt.MapFrom(src => src.PermissionType));
        }
    }
}