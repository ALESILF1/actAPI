using FluentValidation.Validators;
using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.ViewModel.Rota;
using Layer.Architecture.Helper.Extension;
using Layer.Architecture.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Layer.Architecture.Application.Controllers
{
    /// <summary>
    /// Manutencao de rota
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RotaController : ControllerBase
    {
        private readonly IRotaService _rotaService;

        /// <summary>
        /// Manutencao de rota
        /// </summary>
        /// <param name="rotaService"></param>
        public RotaController(IRotaService rotaService)
        {
            _rotaService = rotaService;
        }

        /// <summary>
        /// Criar nova rota
        /// </summary>
        /// <param name="rota"></param>
        /// <returns></returns>
        [SwaggerOperation(Summary = "Criar uma nova rota", Description = "Cria uma nova rota.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Item encontrado.", typeof(Rota))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Item não encontrado.")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRotaVM rota)
        {
            try
            {
                if (rota == null)
                    return NotFound();
                
                await _rotaService.Add(rota);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400,ex.Message);
            }
        }

        /// <summary>
        /// Atualizar nova rota
        /// </summary>
        /// <param name="rota"></param>
        /// <returns></returns>
        [SwaggerOperation(Summary = "Atualizar uma nova rota", Description = "Atualizar uma nova rota.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Item encontrado.", typeof(Rota))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Item não encontrado.")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RotaVM rota)
        {
            if (rota == null)
                return NotFound();
            
            await _rotaService.Update(rota);
            return Ok();
        }

        /// <summary>
        /// Escluir uma rota
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SwaggerOperation(Summary = "Excluir uma  rota", Description = "Excluir uma  rota.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Item encontrado.", typeof(Rota))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Item não encontrado.")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            await _rotaService.Delete(id);

            return new NoContentResult();
        }

        /// <summary>
        /// Busca todos Rotas
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation(Summary = "Listar todas as rota", Description = "Listar todas as  rotas.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Item encontrado.", typeof(Rota))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Item não encontrado.")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ret = await _rotaService.Get();
            return Ok(ret);
        }

        /// <summary>
        /// Busca rota por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SwaggerOperation(Summary = "Buscar uma nova rota", Description = "Buscar uma nova rota.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Item encontrado.", typeof(Rota))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Item não encontrado.")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound();
            var ret = await _rotaService.GetById(id);
            return Ok(ret);
        }

        /// <summary>
        /// Calcula rota mais barata
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        [HttpGet("getCalculoRota/{origin}/{destination}")]
        public async Task<IActionResult> getCalculoRota([FromRoute]string origin, [FromRoute] string destination)
        {
            var cheapestRoute = await _rotaService.FindCheapestRoute(origin, destination);
            if (cheapestRoute == null)
            {
                return NotFound();
            }
            return Ok(cheapestRoute);

        }
    }
}
