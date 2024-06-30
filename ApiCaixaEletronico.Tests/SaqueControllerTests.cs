using ApiCaixaEletronico.Controllers;
using ApiCaixaEletronico.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCaixaEletronico.Tests
{
    public class SaqueControllerTests
    {
        private readonly SaqueController _controller;

        public SaqueControllerTests()
        {
            _controller = new SaqueController();
        }


        //Teste de entrada de valor negativo
        [Fact]
        public void Post_ReturnsBadRequest_NegativeValue()
        {            
            var request = new SaqueRequest { Valor = -50 };           
            var result = _controller.Post(request);            
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }


        //Teste de entrada de valor zerado
        [Fact]
        public void Post_ReturnsBadRequest_ZeroValue()
        {            
            var request = new SaqueRequest { Valor = 0 };           
            var result = _controller.Post(request);            
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }


        //Teste de entrada de valor correto e possível
        [Fact]
        public void Post_ReturnsCorrectNotes_ValidRequest()
        {            
            var request = new SaqueRequest { Valor = 380 };
           
            var actionResult = _controller.Post(request);
            var okResult = actionResult.Result as OkObjectResult;
            var result = okResult?.Value as Dictionary<string, int>;
            
            Assert.NotNull(okResult);
            Assert.NotNull(result);

            var expected = new Dictionary<string,int>
            {
                { "100", 3 },
                { "50", 1 },
                { "20", 1 },
                { "10", 1 },
                { "5", 0 },
                { "2", 0 }
            };

            Assert.Equal(expected, result);
        }


        //Teste de entrada de valor que não é possivel com as notas disponíveis
        [Fact]
        public void Post_ReturnsBadRequest_UnattainableValue()
        {           
            var request = new SaqueRequest { Valor = 3 };           
            var result = _controller.Post(request);           
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }
    }
}
