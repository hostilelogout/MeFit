﻿using webapi.Models;

namespace webapi.Services.UserProfileService
{
    public interface IUserProfileService:IServices<UserProfile,int>
    {
        Task ContributorRequest(int id);

    }
}