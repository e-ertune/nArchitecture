using Application.Features.Models.Models;
using Application.Features.Models.Queries.GetListModel;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetListModelByDynamic
{
    public class GetListModelByDynamicQuery : IRequest<ModelListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListModelDynamicQueryHandler : IRequestHandler<GetListModelByDynamicQuery, ModelListModel>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;
            public GetListModelDynamicQueryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ModelListModel> Handle(GetListModelByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Model> models = await _modelRepository.GetListByDynamicAsync(
                    dynamic: request.Dynamic,
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize,
                    include: m => m.Include(e => e.Brand));
                return _mapper.Map<ModelListModel>(models);
            }
        }
    }
}
