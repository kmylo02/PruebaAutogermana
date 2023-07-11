using BusinessLogic.Interface;
using Domain.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IFactoryLogic _factoryLogic;

        public ProductoController(IFactoryLogic factoryLogic)
        {
            _factoryLogic = factoryLogic;
        }

        [HttpPost]
        [Route("CrearProducto")]
        public ActionResult<bool> Insert(ProductoDTO data)
        {
            return _factoryLogic.ProductoLogic.Insert(data);
        }

        [HttpGet]
        [Route("ListadoProducto")]
        public ActionResult<List<ListadoProductosDTO>> GetAll()
        {
            return _factoryLogic.ProductoLogic.GetAll().ToList();
        }
    }
}
