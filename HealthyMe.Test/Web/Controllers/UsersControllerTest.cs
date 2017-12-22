using FluentAssertions;
using HealthyMe.Web;
using HealthyMe.Web.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Xunit;

namespace HealthyMe.Test.Web.Controllers
{
    public class UsersControllerTest
    {
        [Fact]
        public void UsersControllerShouldBeInAdminArea()
        {
            // Arrange
            var controller = typeof(UsersController);

            // Act
            var areaAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AreaAttribute))
                as AreaAttribute;

            // Assert
            areaAttribute.Should().NotBeNull();
            areaAttribute.RouteValue.Should().Be(WebConstants.AdminArea);
        }

        [Fact]
        public void UsersControllerShouldBeOnlyForAdminUsers()
        {
            // Arrange
            var controller = typeof(UsersController);

            // Act
            var areaAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AuthorizeAttribute))
                as AuthorizeAttribute;

            // Assert
            areaAttribute.Should().NotBeNull();
            areaAttribute.Roles.Should().Be(WebConstants.AdministratorRole);
        }
    }
}