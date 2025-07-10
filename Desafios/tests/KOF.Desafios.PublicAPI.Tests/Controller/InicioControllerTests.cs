using Xunit;
using Microsoft.AspNetCore.Mvc;
using KOF.Desafios.PublicAPI.Controllers;

namespace KOF.Desafios.PublicAPI.Tests.Controllers
{
    public class InicioControllerTests
    {
        [Fact]
        public void Index_ReturnsOkResult_WithExpectedMessage()
        {
            // Arrange
            var controller = new InicioController();

            // Act
            var result = controller.Index();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var message = Assert.IsType<string>(okResult.Value);
            Assert.Equal("🚀 Bienvenido a KOF.Desafios.API", message);
        }
    }
}