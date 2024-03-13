using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class B_Warehouse
    {
        private readonly InventaryContext _context;
        public B_Warehouse(InventaryContext context)
        {
            _context = context;
        }
        public async Task<List<WarehouseEntity>> WarehouseList()
        {
            return await _context.Warehouse.ToListAsync();
        }
        
        public async Task<WarehouseEntity> WarehouseById(string id)
        {
            return await _context.Warehouse.FirstOrDefaultAsync(w => w.Id == id);
        }

        public void CrearBodega(WarehouseEntity oWarehouse)
        {
            _context.Warehouse.Add(oWarehouse);
            _context.SaveChanges();
        }

        public void UpdateBodega(WarehouseEntity oWarehouse)
        {
            _context.Warehouse.Update(oWarehouse);
            _context.SaveChanges();
        }
    }
}
