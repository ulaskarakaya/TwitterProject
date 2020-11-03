using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterProject.ApplicationLayer.Models.DTOs;
using TwitterProject.ApplicationLayer.Services.Abstraction;
using TwitterProject.DomainLayer.Entities.Concrete;
using TwitterProject.DomainLayer.UnitofWork.Abstraction;

namespace TwitterProject.ApplicationLayer.Services.Concrete
{
    public class MentionService : IMentionService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public MentionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddMention(AddMentionDto model)
        {
            var mention = _mapper.Map<AddMentionDto, Mention>(model);
            await _unitOfWork.Mention.Add(mention);
            await _unitOfWork.Commit();
        }
    }
}
