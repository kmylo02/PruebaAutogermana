using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IFactoryLogic
    {
        ICategoriaLogic CategoriaLogic { get; }
        IProductoLogic ProductoLogic { get; }
    }
}
