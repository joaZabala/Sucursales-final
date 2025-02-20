using AutoMapper;
using repasoFinal2daMesa.DTOS;
using repasoFinal2daMesa.Models;
using repasoFinal2daMesa.repositories;
using repasoFinal2daMesa.response;

namespace repasoFinal2daMesa.services
{
    public class SucursalesService
    {

        private readonly SucursalesRepository _repository;
        private readonly IMapper _mapper;

        public SucursalesService(SucursalesRepository repo , IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper; 
        }


        public async Task<ApiResponse<Sucursales>> SucursalAsync()
        {
            var response = new ApiResponse<Sucursales>();
            try
            {
                var respuesta = await _repository.getSucursalNoBsAs();

                // Check if respuesta is null before setting response.Data
                if (respuesta == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "No se encontró ninguna sucursal que cumpla con los criterios.";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return response;
                }
                else
                {

                    response.Data = respuesta;
                    response.Success = true;
                }
               

                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                response.StatusCode=System.Net.HttpStatusCode.InternalServerError;
                return response;
            }
        }
         
        public async Task<ApiResponse<List<Configuraciones>>> getConfigs()
        {
            var response = new ApiResponse<List<Configuraciones>>();

            var configs = await _repository.getConfig();
            response.Data = configs;
            response.Success = true;
           return response;
        }

        public async Task<ApiResponse<Sucursales>> PutSucursales(SucursalRequest sucursalRequest , Guid id)
        {
            var Response = new ApiResponse<Sucursales>();

            try
            {
                var existe = await _repository.existSucursal(id);

                if (existe == null)
                {
                    Response.Success = false;
                    Response.ErrorMessage = "No existe la sucurlas con el id especificado";
                    Response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return Response;
                }
                else
                {

                    /* existe.ApellidoTitular = sucursalRequest.ApellidoTitular;
                     existe.NombreTitular = sucursalRequest.NombreTitular;
                     existe.Nombre = sucursalRequest.Nombre;
                     existe.Telefono = sucursalRequest.Telefono;
                     existe.IdProvincia = sucursalRequest.IdProvincia;
                     existe.IdCiudad = sucursalRequest.IdCiudad;
                     existe.IdTipo = sucursalRequest.IdTipo;*/

                    _mapper.Map(sucursalRequest, existe);


                    var sucursalUpdated = _repository.updateSucursal(existe);
                    Response.Success = true;
                    Response.Data = sucursalUpdated.Result;
                }
            }
            catch (Exception ex) {

                Response.SetError(ex.Message, System.Net.HttpStatusCode.InternalServerError);
            
            }
            return Response;

        }


        public async Task<ApiResponse<List<Tipos>>> getTipos()
        {
            var response = new ApiResponse<List<Tipos>>();

            try
            {
                var list = await _repository.getAllTipos();

                response.Data = list;
            }
            catch (Exception ex)
            {
                response.SetError(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
            return response;
        }

        public async Task<ApiResponse<List<Provincias>>> getProvincias()
        {
            var response = new ApiResponse<List<Provincias>>();
            response.Data = await _repository.getAllProvincias();
            return response;
        }
    }
}
