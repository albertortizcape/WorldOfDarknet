using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.Entities.UserAggregate
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByIdAsync(Guid userId);
        Task<User> GetByEmailAsync(string email);
        Task<bool> CheckEmailExistAsync(string email);
        User Add(User user);
    }
}
