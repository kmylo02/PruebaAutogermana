using BusinessLogic.Interface;
using Domain.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IFactoryLogic _factoryLogic;

        public CategoriaController(IFactoryLogic factoryLogic)
        {
            _factoryLogic = factoryLogic;
        }

        [HttpPost]
        [Route("CrearCategoria")]
        public ActionResult<bool> Insert(CategoriumDTO data)
        {
            return _factoryLogic.CategoriaLogic.Insert(data);
        }
        
        [HttpGet]
        [Route("ListadoCategoria")]
        public ActionResult<List<CategoriumDTO>> GetAll()
        {
            return _factoryLogic.CategoriaLogic.GetAll().ToList();
        }


    }
}
