using Microsoft.EntityFrameworkCore;
using SalesWebSystem.Infrastructure.Data.Contexts;
using SalesWebSystem.Infrastructure.Data.Entities;
using SalesWebSystem.Infrastructure.Repositories.Abstracts;
using SalesWebSystem.Models.Models.DTO;

namespace SalesWebSystem.Infrastructure.Repositories
{
    public class NCFRepositories : DataTransactionManager, INCFRepositories
    {
        public NCFRepositories(InvSysContext context) : base(context) { }

        public async Task<bool> NcfGenerator(int id_secuencia, string secuencia, int idNcf)
        {
            // Obtener la secuencia inicial
            var ncf = await _context.Ncfs.FirstOrDefaultAsync(x => x.id_ncf == idNcf);
            if (ncf == null)
                return false;

            int id = ncf.secuenciaIni;

            // Obtener nueva secuencia
            bool existe = await _context.nCFGenerados.AnyAsync(x => x.id_secuencia == id);
            if (!existe)
                id_secuencia = 1;
            else
                id_secuencia = await _context.nCFGenerados.MaxAsync(x => x.id_secuencia) + 1;

            // Insertar nuevo NCF generado
            var nuevoGenerado = new NCFGenerados
            {
                id_secuencia = id_secuencia,
                secuenciaNCF = secuencia,
                fecha = DateTime.Now
            };

            await _context.nCFGenerados.AddAsync(nuevoGenerado);

            // Actualizar secuencia en tabla ncf
            ncf.secuenciaIni = (ncf.secuenciaIni) + 1;
            _context.Ncfs.Update(ncf);

            // Guardar cambios
            return await CommitTransactionAsync();
        }

        public async Task<List<DropBoxDto>> ListNcfGenerate()
        {
            return await (from n in _context.Ncfs
                          join c in _context.Comprobante on n.id_ncf equals c.id_comprobante
                          where !c.Activo // Activo=0
                          orderby n.id_ncf
                          select new DropBoxDto
                          {
                              Id = n.id_ncf,
                              Descripcion = n.descripcion_ncf ?? string.Empty
                          }).ToListAsync();
        }
    }
}
