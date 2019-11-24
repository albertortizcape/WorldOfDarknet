using Game.Domain.Entities.UserAggregate;
using Game.Infrastructure.Providers;
using System;
using System.Threading.Tasks;

namespace Game.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ICypherProvider cypherProvider;

        public UserService(IUserRepository userRepository,
                               ICypherProvider cypherProvider)
        {
            this.userRepository = userRepository ?? throw new UserException(nameof(userRepository));
            this.cypherProvider = cypherProvider ?? throw new UserException(nameof(cypherProvider));
        }

        public async Task<User> LoginAsync(string userName, string password)
        {
            var user = await userRepository.GetByEmailAsync(userName) 
                ?? throw new UserException("The user name doesn´t exist.");

            if (!cypherProvider.VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
                throw new UserException("The password is incorrect.");

            return user;
        }

        public async Task<User> RegisterAsync(User user, string password)
        {
            if (await userRepository.GetByEmailAsync(user.Email) != null)
            {
                throw new UserException("User name already exists");
            }

            cypherProvider.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            userRepository.Add(user);
            await userRepository.UnitOfWork.SaveChangesAsync();

            return user;
        }
    }
}
