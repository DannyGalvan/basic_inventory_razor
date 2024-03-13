using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bussiness
{
    public interface IIntputOutput
    {
        public Task<List<InputOutputEntity>> IntOutList();
        public void CrearEntradasYsalidas(InputOutputEntity oIntOut);
        public void UpdateEntradasYsalidas(InputOutputEntity oIntOut);
    }
}