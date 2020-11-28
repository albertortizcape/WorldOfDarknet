using Game.Domain;
using Game.Domain.Entities.UserAggregate;
using Game.Infraestructura;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GameContext context;

        public UserRepository(GameContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => context;

        public User Add(User user)
        {
            return context.Users.Add(user).Entity;
        }

        public async Task<User> GetByIdAsync(Guid userId)
        {
            return await context.Users.FindAsync(userId);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await context.Users.FirstOrDefaultAsync(i => i.Email == email);
        }

        public async Task<bool> CheckEmailExistAsync(string email)
        {
            return await context.Users.AnyAsync(i => i.Email.ToUpper().Equals(email.ToUpper()));
        }

        public IQueryable<User> AsQueryable()
        {
            throw new NotImplementedException();
        }
    }
}
