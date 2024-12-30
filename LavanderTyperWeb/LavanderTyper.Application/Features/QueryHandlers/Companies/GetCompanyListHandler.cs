using AutoMapper;
using FluentValidation.Results;
using LavanderTyperWeb.Application.Features.Queries.Companies;
using LavanderTyperWeb.Application.Features.Responses.Companies;
using LavanderTyperWeb.Application.Features.ViewModel.Companies;
using LavanderTyperWeb.Core.Messages.CommonMessages;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;

namespace LavanderTyperWeb.Application.Features.QueryHandlers.Companies
{
    public class GetCompanyListHandler : Handler<GetCompanyListQuery, GetCompanyListQueryResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILoggerService _loggerService;

        public GetCompanyListHandler(
            IMapper mapper,
            ILoggerService loggerService,
            ICompanyRepository companyRepository)
            : base(mapper)
        {
            _loggerService = loggerService;
            _companyRepository = companyRepository;
        }

        public override async Task<GetCompanyListQueryResponse> Handle(GetCompanyListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                await _loggerService.LogInfoAsync(
                    request,
                    "Start Handle Request",
                    nameof(GetCompanyListHandler));

                var companyList = await _companyRepository.GetAsync(null, null, null);
                var companyListMap = _mapper.Map<List<CompanyViewModel>>(companyList);

                var response = new GetCompanyListQueryResponse(companyListMap);
                await _loggerService.LogInfoAsync(
                    null,
                    "End Handle Request",
                    nameof(GetCompanyListHandler),
                    response);

                return response;
            }
            catch (Exception ex)
            {
                return ResponseOnFailValidation(ex.Message, request.ValidationResult);
            }
        }

        public override List<ValidationFailure> Validate(GetCompanyListQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
