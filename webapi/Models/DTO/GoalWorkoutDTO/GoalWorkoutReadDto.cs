﻿namespace webapi.Models.DTO.GoalWorkoutDTO
{
    public class GoalWorkoutReadDto
    {
        public int Id { get; set; }
        public int FkGoalId { get; set; }
        public int FkWorkoutId { get; set; }
        public string Name{ get; set; }
        public int FkStatusId { get; set; }
    }
}
