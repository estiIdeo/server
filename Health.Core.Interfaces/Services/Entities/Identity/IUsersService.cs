using Health.Core.Domain.Identity;
using Health.Core.Framework.Account.Users;
using Ideo.NetCore.Web.CRUD.Core.Interfaces;

namespace Health.Core.Interfaces.Services.Entities.Identity
{
    public interface IUsersService : ICrudService<long, ApplicationUser, UserLogicModel, UserRegistrationLogicModel>
    {
        //Task<CustomerChangeSubscriptionResponseLogicModel> SetSubscription(long partnerId, long userId, long pendingSubscriptionId, long? mediaId = null);
        Task<bool> Logout(long id);
        Task<bool> ApproveSubscriptionChangeRequest(long id, bool approved, string rejectMessage = null);

        Task<bool> LockUser(long id);
        Task<bool> UnlockUser(long id);

        Task<int> ApprovedUser(long id, bool isApproved);
        Task<int> SendAlertRequestApprove(long userId);

    }
}
