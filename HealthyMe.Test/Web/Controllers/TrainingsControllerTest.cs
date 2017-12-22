using FluentAssertions;
using HealthyMe.Web;
using HealthyMe.Web.Areas.Trainer.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Xunit;

namespace HealthyMe.Test.Web.Controllers
{
    public class TrainingsControllerTest
    {
        [Fact]
        public void TrainingsControllerShouldBeInTrainerArea()
        {
            // Arrange
            var controller = typeof(TrainingsController);

            // Act
            var areaAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AreaAttribute))
                as AreaAttribute;

            // Assert
            areaAttribute.Should().NotBeNull();
            areaAttribute.RouteValue.Should().Be(WebConstants.TrainerArea);
        }

        [Fact]
        public void TrainingsControllerShouldBeOnlyForTrainerUsers()
        {
            // Arrange
            var controller = typeof(TrainingsController);

            // Act
            var areaAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AuthorizeAttribute))
                as AuthorizeAttribute;

            // Assert
            areaAttribute.Should().NotBeNull();
            areaAttribute.Roles.Should().Be(WebConstants.TrainerRole);
        }
    }
}