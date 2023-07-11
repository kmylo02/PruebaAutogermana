using AutoMapper;
using BusinessLogic.Interface;
using Domain.Dto;
using Domain.Entity;
using Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkUnit.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessLogic.Implement
{
    public class ProductoLogic : IProductoLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        internal DataIRContext _context;

        public ProductoLogic(IUnitOfWork unitOfWork, IMapper mapper, DataIRContext context)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public bool Insert(ProductoDTO data)
        {
            Producto producto = (Producto)_mapper.Map<ProductoDTO, Producto>(data);
            _unitOfWork.Repository<Producto>().Insert(producto);
            return _unitOfWork.Save();
        }

        public IEnumerable<ListadoProductosDTO> GetAll()
        {
            IEnumerable<ListadoProductosDTO> result = _context.Productos.Select(x => new ListadoProductosDTO
            {
                Idproducto = x.Idproducto,
                Categoria = x.IdcategoriaNavigation.Nombre,
                Codigo = x.Codigo,
                Nombre = x.Nombre,
                PrecioVenta = x.PrecioVenta,
                Stock = x.Stock,
                Descripcion = x.Descripcion
            }).AsEnumerable();

            //var result = _unitOfWork.Repository<Producto>().GetAllBy(x => x.Estado == true).Select(x => new  
            //{
            //    Idproducto=x.Idproducto,
            //    Categoria = x.IdcategoriaNavigation.Nombre,
            //    Codigo=x.Codigo,
            //    Nombre=x.Nombre,
            //    PrecioVenta = x.PrecioVenta,
            //    Stock=x.Stock,
            //    Descripcion = x.Descripcion


            //}).AsEnumerable();
            return result;
        }
    }
}
