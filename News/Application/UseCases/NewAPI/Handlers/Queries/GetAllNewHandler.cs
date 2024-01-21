using Application.SQLContracts.NewAPI;
using Application.UseCases.NewAPI.Queries;
using Domain.NewAPI_Models;
using Domain.PostAPI_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.NewAPI.Handlers.Queries
{
    public class GetAllNewHandler : IRequestHandler<GetAllNewQuery, IEnumerable<New>>
    {
        private readonly INewUOW UnitOfWork;

        public GetAllNewHandler(INewUOW uof)
        {
            UnitOfWork = uof;
        }

        public async Task<IEnumerable<New>> Handle(GetAllNewQuery request, CancellationToken cancellationToken)
        {
            return await UnitOfWork.newRepository.GetAllAsync();
        }
    }
}