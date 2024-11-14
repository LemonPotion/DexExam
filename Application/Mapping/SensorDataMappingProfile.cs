using Application.Dto.SensorData.Requests;
using Application.Dto.SensorData.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class SensorDataMappingProfile : Profile
{
    public SensorDataMappingProfile()
    {
        CreateMap<CreateSensorDataRequest, SensorData>()
            .ForMember(dest => dest.Temperature, opt => opt.MapFrom(src => src.Temperature))
            .ForMember(dest => dest.Humidity, opt => opt.MapFrom(src => src.Humidity))
            .ForMember(dest => dest.Charge, opt => opt.MapFrom(src => src.Charge))
            .ForMember(dest => dest.SensorId, opt => opt.MapFrom(src => src.SensorId));

        CreateMap<UpdateSensorDataRequest, SensorData>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Temperature, opt => opt.MapFrom(src => src.Temperature))
            .ForMember(dest => dest.Humidity, opt => opt.MapFrom(src => src.Humidity))
            .ForMember(dest => dest.Charge, opt => opt.MapFrom(src => src.Charge))
            .ForMember(dest => dest.SensorId, opt => opt.MapFrom(src => src.SensorId));

        CreateMap<SensorData, CreateSensorDataResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Temperature, opt => opt.MapFrom(src => src.Temperature))
            .ForMember(dest => dest.Humidity, opt => opt.MapFrom(src => src.Humidity))
            .ForMember(dest => dest.Charge, opt => opt.MapFrom(src => src.Charge))
            .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate))
            .ForMember(dest => dest.SensorId, opt => opt.MapFrom(src => src.SensorId));

        CreateMap<SensorData, GetSensorDataResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Temperature, opt => opt.MapFrom(src => src.Temperature))
            .ForMember(dest => dest.Humidity, opt => opt.MapFrom(src => src.Humidity))
            .ForMember(dest => dest.Charge, opt => opt.MapFrom(src => src.Charge))
            .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate))
            .ForMember(dest => dest.SensorId, opt => opt.MapFrom(src => src.SensorId));

        CreateMap<SensorData, UpdateSensorDataResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Temperature, opt => opt.MapFrom(src => src.Temperature))
            .ForMember(dest => dest.Humidity, opt => opt.MapFrom(src => src.Humidity))
            .ForMember(dest => dest.Charge, opt => opt.MapFrom(src => src.Charge))
            .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate))
            .ForMember(dest => dest.SensorId, opt => opt.MapFrom(src => src.SensorId));
    }
}