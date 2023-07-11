using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IProductoLogic
    {
        bool Insert(ProductoDTO data);
        IEnumerable<ListadoProductosDTO> GetAll();
    }
}
