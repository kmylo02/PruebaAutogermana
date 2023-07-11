using AutoMapper;
using BusinessLogic.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkUnit.Interface;

namespace BusinessLogic.Implement
{
    public class FactoryLogic : IFactoryLogic
    {
        public ICategoriaLogic CategoriaLogic { get; private set; }
        public IProductoLogic ProductoLogic { get; private set; }
        public FactoryLogic(IUnitOfWork unitOfWork, IMapper mapper, IFactoryAbstractRepository factoryAbstractRepository, DataIRContext context)
        {
            CategoriaLogic = new CategoriaLogic(unitOfWork, mapper);
            ProductoLogic = new ProductoLogic(unitOfWork, mapper, context);
        }
    }
}
