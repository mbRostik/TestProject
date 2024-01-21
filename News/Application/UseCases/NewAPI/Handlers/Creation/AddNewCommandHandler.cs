using Application.SQLContracts.NewAPI;
using Application.UseCases.NewAPI.Commands;
using Domain.NewAPI_Models;
using Domain.PostAPI_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.NewAPI.Handlers.Creation
{
    public class AddNewCommandHandler : IRequestHandler<AddNewCommand, New>
    {
        private readonly INewUOW uow;
        private readonly IMediator _mediator;

        public AddNewCommandHandler(INewUOW _uow, IMediator mediator)
        {
            uow = _uow;
            _mediator = mediator;
        }

        public async Task<New> Handle(AddNewCommand request, CancellationToken cancellationToken)
        {
            New temp = new New();
            temp.Title= request.model.Title;
            temp.Description= request.model.Description;
            await uow.newRepository.AddAsync(temp);
            await uow.SaveChangesAsync();

            return temp;
        }
    }
}