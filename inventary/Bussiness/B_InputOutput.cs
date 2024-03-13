using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bussiness
{
    public class B_InputOutput : IIntputOutput
    {
        private readonly InventaryContext _context;
        public B_InputOutput(InventaryContext context)
        {
            _context = context;
        }
        public async Task<List<InputOutputEntity>> IntOutList()
        {
            return await _context.IntOut
                .Include(i => i.Storage).ThenInclude(s => s.Product)
                .Include(i => i.Storage).ThenInclude(s => s.Warehouse)
                .OrderByDescending(i => i.InOutDate)
                .ToListAsync();
        }

        public void CrearEntradasYsalidas(InputOutputEntity oIntOut)
        {
            _context.IntOut.Add(oIntOut);
            _context.SaveChanges();
        }

        public void UpdateEntradasYsalidas(InputOutputEntity oIntOut)
        {
            _context.IntOut.Update(oIntOut);
            _context.SaveChanges();
        }
    }
}
