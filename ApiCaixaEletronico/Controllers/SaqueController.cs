using ApiCaixaEletronico;
using Microsoft.AspNetCore.Mvc;
using ApiCaixaEletronico.Models;

namespace ApiCaixaEletronico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaqueController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Dictionary<string, int>> Post([FromBody] SaqueRequest request)
        {
            if (request.Valor <= 0)
            {
                return BadRequest("O valor deve ser um inteiro positivo.");
            }

            var notasDisponiveis = new[] { 100, 50, 20, 10, 5, 2 };
            var valorRestante = request.Valor;
            var resultado = new Dictionary<string, int>();

            foreach (var nota in notasDisponiveis)
            {
                var quantidadeDeNotas = valorRestante / nota;
                valorRestante %= nota;
                resultado[nota.ToString()] = quantidadeDeNotas;
            }

            if (valorRestante > 0)
            {
                return BadRequest("O valor de saque não pode ser atendido com as cédulas disponíveis.");
            }

            return Ok(resultado);
        }
    }
}
