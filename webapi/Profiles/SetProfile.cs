﻿using AutoMapper;
using webapi.Models;
using webapi.Models.DTO.SetDTO;

namespace webapi.Profiles
{
    public class SetProfile:Profile
    {
        public SetProfile()
        {
            CreateMap<SetCreateDto, Set>();
            CreateMap<Set, SetReadDto>()
                .ForMember(dto => dto.Exercises, options =>
                options.MapFrom(setDomain => setDomain.Exercises.Select(excercise => $"api/v1/excercises/{excercise.Id}").ToList()));
            CreateMap<SetUpdateDto, Set>();
        }
    }
}
