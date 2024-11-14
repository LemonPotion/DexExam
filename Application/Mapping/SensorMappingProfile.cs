using Application.Dto.Sensor.Requests;
using Application.Dto.Sensor.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class SensorMappingProfile : Profile
{
    public SensorMappingProfile()
    {
        CreateMap<CreateSensorRequest, Sensor>()
            .ForMember(dest => dest.BuildingId, opt => opt.MapFrom(src => src.BuildingId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.XCoord, opt => opt.MapFrom(src => src.XCoord))
            .ForMember(dest => dest.YCoord, opt => opt.MapFrom(src => src.YCoord))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ImageFilePath, opt => opt.MapFrom(src => src.ImageFilePath));

        CreateMap<UpdateSensorRequest, Sensor>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.BuildingId, opt => opt.MapFrom(src => src.BuildingId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.XCoord, opt => opt.MapFrom(src => src.XCoord))
            .ForMember(dest => dest.YCoord, opt => opt.MapFrom(src => src.YCoord))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ImageFilePath, opt => opt.MapFrom(src => src.ImageFilePath));

        CreateMap<Sensor, CreateSensorResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.BuildingId, opt => opt.MapFrom(src => src.BuildingId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.XCoord, opt => opt.MapFrom(src => src.XCoord))
            .ForMember(dest => dest.YCoord, opt => opt.MapFrom(src => src.YCoord))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ImageFilePath, opt => opt.MapFrom(src => src.ImageFilePath));

        CreateMap<Sensor, GetSensorResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.BuildingId, opt => opt.MapFrom(src => src.BuildingId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.XCoord, opt => opt.MapFrom(src => src.XCoord))
            .ForMember(dest => dest.YCoord, opt => opt.MapFrom(src => src.YCoord))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ImageFilePath, opt => opt.MapFrom(src => src.ImageFilePath));

        CreateMap<Sensor, UpdateSensorResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.BuildingId, opt => opt.MapFrom(src => src.BuildingId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.XCoord, opt => opt.MapFrom(src => src.XCoord))
            .ForMember(dest => dest.YCoord, opt => opt.MapFrom(src => src.YCoord))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ImageFilePath, opt => opt.MapFrom(src => src.ImageFilePath));
    }
}