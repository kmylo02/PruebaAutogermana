using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface ICategoriaLogic
    {
        bool Insert(CategoriumDTO data);
        IEnumerable<CategoriumDTO> GetAll();
    }
}
