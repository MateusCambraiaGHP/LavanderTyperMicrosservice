using AutoMapper;
using FluentValidation.Results;
using LavanderTyperWeb.Application.Features.Commands.Equipaments;
using LavanderTyperWeb.Application.Features.Responses.Equipaments;
using LavanderTyperWeb.Application.Features.Validations.Employees;
using LavanderTyperWeb.Application.Features.Validations.Equipaments;
using LavanderTyperWeb.Application.Features.ViewModel.Equipaments;
using LavanderTyperWeb.Core.Data;
using LavanderTyperWeb.Core.Messages.CommonMessages;
using LavanderTyperWeb.Data.Repositories;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Domain.Primitives.Entities.Employees;
using LavanderTyperWeb.Domain.Primitives.Entities.Equipaments;

namespace LavanderTyperWeb.Application.Features.CommandHandlers.Equipaments
{
    public class UpdateEquipamentHandler : Handler<UpdateEquipamentCommand, UpdateEquipamentCommandResponse>
    {
        private readonly IEquipamentRepository _equipamentRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEquipamentHandler(
            IEquipamentRepository equipamentRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IBranchRepository branchRepository)
            : base(mapper)
        {
            _equipamentRepository = equipamentRepository;
            _unitOfWork = unitOfWork;
            _branchRepository = branchRepository;
        }

        public override async Task<UpdateEquipamentCommandResponse> Handle(UpdateEquipamentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("fail on update employee", request.ValidationResult);

                var equipamentMap = _mapper.Map<Equipament>(request.Request);
                await _equipamentRepository.Update(equipamentMap);
                await _unitOfWork.CommitChangesAsync();

                var equipamentViewModel = _mapper.Map<EquipamentViewModel>(equipamentMap);
                var response = new UpdateEquipamentCommandResponse(equipamentViewModel);

                return response;
            }
            catch (Exception ex)
            {
                return ResponseOnFailValidation(ex.Message, request.ValidationResult);
            }
        }

        public override List<ValidationFailure> Validate(UpdateEquipamentCommand request)
        {
            var erros = new UpdateEquipamentCommandValidation().Validate(request);
            return erros.Errors;
        }
    }
}
