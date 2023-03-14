﻿using webapi.Models;

namespace webapi.Services.GoalServices
{
    public interface IGoalService:IServices<Goal,int>
    {
        Task<ICollection<Goal>> GetAchievedGoals(int id);
        Task<ICollection<Workout>> GetGoalWorkouts(int id);
        Task<ICollection<Workout>> GetGoalCompletedWorkouts(int id);
        
    }
}