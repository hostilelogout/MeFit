using AutoMapper;
using webapi.Models.DTO.SetDTO;
using webapi.Models;
using webapi.Models.DTO.MusclegroupDTO;

namespace webapi.Profiles
{
    public class MusclegroupPF:Profile
    {
        public MusclegroupPF()
        {
            CreateMap<MusclegroupCreateDto, Musclegroup>();
            CreateMap<Musclegroup, MusclegroupReadDto>()
                .ForMember(dto => dto.Exercises, options =>
                options.MapFrom(musclegroupDomain => musclegroupDomain.Exercises.Select(excercise => excercise.Id).ToList()));
            CreateMap<MusclegroupUpdateDto, Musclegroup>();

        }
    }
}
