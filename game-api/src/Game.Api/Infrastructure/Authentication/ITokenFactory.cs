using Game.Domain.Entities.UserAggregate;
using System;

namespace Game.Api.Infrastructure.Authentication
{
    public interface ITokenFactory
    {
        string Create(User user, DateTime expires);
    }
}
