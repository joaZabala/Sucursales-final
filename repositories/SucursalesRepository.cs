using Microsoft.EntityFrameworkCore;
using repasoFinal2daMesa.data;
using repasoFinal2daMesa.Models;

namespace repasoFinal2daMesa.repositories
{
    public class SucursalesRepository
    {

        private readonly ContextDb _context;

        public SucursalesRepository(ContextDb context)
        {
            _context = context;
        }


        public async Task<Sucursales?> getSucursalNoBsAs()
        {
            var response = await _context.Sucursales.Include( s => s.Provincias).Include(s => s.Tipos)
                .Where(s => s.Provincias.Nombre != "Buenos Aires")
                .OrderByDescending( su => su.FechaAlta)
                .FirstOrDefaultAsync();

            return response;
        }

        public async Task<List<Configuraciones>> getConfig()
        {
            var response = await _context.Configuraciones.ToListAsync();
            return response;
        }


        public async Task<Sucursales> updateSucursal(Sucursales sucursales)
        {

            _context.Sucursales.Update(sucursales); 
            await _context.SaveChangesAsync();     // Guarda los cambios en la base de datos
            return sucursales;


        }


        public async Task<Sucursales> existSucursal(Guid id)
        {
            var exist = await _context.Sucursales.FirstOrDefaultAsync(s => s.Id == id);
            return exist;
        }

        public async Task<List<Tipos>> getAllTipos()
        {
            return  await _context.Tipos.ToListAsync();
        }


        public async Task<List<Provincias>> getAllProvincias()
        {
            return await _context.Provincias.ToListAsync();
        }
    }
}
