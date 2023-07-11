using AutoMapper;
using BusinessLogic.Interface;
using Domain.Dto;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkUnit.Interface;

namespace BusinessLogic.Implement
{
    public class CategoriaLogic : ICategoriaLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriaLogic(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public bool Insert(CategoriumDTO data)
        {
            Categorium categorium = (Categorium)_mapper.Map<CategoriumDTO, Categorium>(data);
            _unitOfWork.Repository<Categorium>().Insert(categorium);
            return _unitOfWork.Save();
        }

        public IEnumerable<CategoriumDTO> GetAll()
        {
            var result = _unitOfWork.Repository<Categorium>().GetAllBy(x => x.Estado == true).AsEnumerable();
            return _mapper.Map<IEnumerable<Categorium>, IEnumerable<CategoriumDTO>>(result);
        }
    }
}
