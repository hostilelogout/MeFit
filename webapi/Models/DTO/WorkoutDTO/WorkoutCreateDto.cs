﻿using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models.DTO.WorkoutDTO
{

    public class WorkoutCreateDto
    {
        public string Name { get; set; } = null!;

        public string Type { get; set; } = null!;        

        public List<int> ExerciseIds { get; set; }

    }

}