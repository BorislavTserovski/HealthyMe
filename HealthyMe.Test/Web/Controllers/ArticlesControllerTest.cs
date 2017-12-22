using FluentAssertions;
using HealthyMe.Web;
using HealthyMe.Web.Areas.Writer.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Xunit;

namespace HealthyMe.Test.Web.Controllers
{
    public class ArticlesControllerTest
    {
        [Fact]
        public void ArticlesControllerShouldBeInWriterArea()
        {
            // Arrange
            var controller = typeof(ArticlesController);

            // Act
            var areaAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AreaAttribute))
                as AreaAttribute;

            // Assert
            areaAttribute.Should().NotBeNull();
            areaAttribute.RouteValue.Should().Be(WebConstants.WriterArea);
        }

        [Fact]
        public void ArticlesControllerShouldBeOnlyForWriterUsers()
        {
            // Arrange
            var controller = typeof(ArticlesController);

            // Act
            var areaAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AuthorizeAttribute))
                as AuthorizeAttribute;

            // Assert
            areaAttribute.Should().NotBeNull();
            areaAttribute.Roles.Should().Be(WebConstants.WriterRole);
        }
    }
}