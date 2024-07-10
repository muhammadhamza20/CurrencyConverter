using AutoMapper;
using CurrencyConverter.Services.DTOs;
using CurrencyConverter.Services.Models;

namespace CurrencyConverter.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Reverse Mapping: HistoricalCurrencyRate & HistoricalRatesResponseDTO
            CreateMap<HistoricalCurrencyRate, HistoricalRatesResponseDTO>()
                .ForMember(dest => dest.StartDate,
                        opt => opt.MapFrom(src => src.Start_Date))
                .ForMember(dest => dest.EndDate,
                        opt => opt.MapFrom(src => src.End_Date))
                .ForMember(dest => dest.Rates,
                         opt => opt.Ignore())
                 .ReverseMap();

            //Reverse Mapping: HistoricalRatesRequestDTO & HistoricalRatesResponseDTO
            CreateMap<HistoricalRatesRequestDTO, HistoricalRatesResponseDTO>()
                .ForMember(dest => dest.Base,
                        opt => opt.MapFrom(src => src.BaseCurrency))
                .ForPath(dest => dest.Rates.PageNumber,
                        opt => opt.MapFrom(src => src.PageNumber))
                .ForPath(dest => dest.Rates.PageSize,
                        opt => opt.MapFrom(src => src.PageSize))
                .ReverseMap();
        }
    }
}
