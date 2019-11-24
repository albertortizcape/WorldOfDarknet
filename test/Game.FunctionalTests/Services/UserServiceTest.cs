using Game.Domain.Entities.UserAggregate;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Game.FunctionalTests.Services
{
    public class UserServiceTest
    {
        IUserService sut;
        Mock<IUserRepository> userRepositoryMock;

        public UserServiceTest()
        {
            userRepositoryMock = new Mock<IUserRepository>();


        }

        [Fact]
        public void GIVEN_valid_user_WHEN_register_THEN_user_is_registered()
        {
            User user = new User { Email = "avazquez@hotmail.com" };


        }
    }
}
