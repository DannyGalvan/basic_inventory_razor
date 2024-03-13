using DataAccess;
using Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Bussiness
{
    public class B_Storage
    {
        private readonly InventaryContext _context;
        public B_Storage(InventaryContext context)
        {
            _context = context;
        }
        public async Task<List<StorageEntity>> StorageList()
        {
            return await _context.Storage.ToListAsync();
        }

        public void CrearAlmacen(StorageEntity oStorage)
        {
            _context.Storage.Add(oStorage);
            _context.SaveChanges();
        }

        public bool IsProductoInWarehouse(string IdStorage)
        {
            var product = _context.Storage.ToList().Where(s => s.Id == IdStorage);
            return product.Any();
        }

        public List<StorageEntity> StorageProductsByWarehouse(string idWarehouse)
        {
            return _context.Storage
                   .Include(s => s.Product)
                   .Include(s => s.Warehouse)
                   .Where(s => s.WarehouseId == idWarehouse).ToList();
        }

        public void UpdateAlmacen(StorageEntity oStorage)
        {
            _context.Storage.Update(oStorage);
            _context.SaveChanges();
        }
    }
}
