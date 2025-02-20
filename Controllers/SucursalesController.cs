using Microsoft.AspNetCore.Mvc;
using repasoFinal2daMesa.DTOS;
using repasoFinal2daMesa.Models;
using repasoFinal2daMesa.response;
using repasoFinal2daMesa.services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace repasoFinal2daMesa.Controllers
{
    [Route("parcial/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly SucursalesService _sucursalesService;
        public SucursalesController(SucursalesService sucursalesService)
        {
            _sucursalesService = sucursalesService;
        }
        // GET: api/<SucursalesController>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<Sucursales>>> Get()
        {
            var respuesta = await _sucursalesService.SucursalAsync();

            if (respuesta.Success)
            {
                return Ok(respuesta);
            }
            else
            {
                return NotFound(respuesta);
            }
        }


        [HttpGet("configuraciones")]
        public async Task<ActionResult<ApiResponse<Sucursales>>> GetConfigs()
        {
            var respuesta = await _sucursalesService.getConfigs();

            if (respuesta.Success)
            {
                return Ok(respuesta);
            }
            else
            {
                return NotFound(respuesta);
            }
        }

        [HttpGet("tipos")]
        public async Task<ActionResult<ApiResponse<Sucursales>>> GetTipos()
        {
            var respuesta = await _sucursalesService.getTipos();

            if (respuesta.Success)
            {
                return Ok(respuesta);
            }
            else
            {
                return NotFound(respuesta);
            }
        }

        [HttpGet("provincias")]
        public async Task<ActionResult<ApiResponse<Sucursales>>> GetProvincia()
        {
            var respuesta = await _sucursalesService.getProvincias();

            if (respuesta.Success)
            {
                return Ok(respuesta);
            }
            else
            {
                return NotFound(respuesta);
            }
        }



        // PUT api/<SucursalesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<Sucursales>>> Put(Guid id, [FromBody] SucursalRequest value)
        {
            var respuesta = await _sucursalesService.PutSucursales(value,id);

            if (respuesta.Success)
            {
                return Ok(respuesta);
            }
            else
            {
                return NotFound(respuesta);
            }

        }
    }
}
