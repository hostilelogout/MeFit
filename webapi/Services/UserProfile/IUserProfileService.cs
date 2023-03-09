using webapi.Models;

namespace webapi.Services.UserProfile
{
    public interface IUserProfileService:IServices<Models.UserProfile,int>
    {
        Task ContributorRequest(int id);
    }
}
