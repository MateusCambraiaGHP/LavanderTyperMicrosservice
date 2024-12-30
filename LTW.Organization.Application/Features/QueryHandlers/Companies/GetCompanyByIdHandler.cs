using AutoMapper;
using FluentValidation.Results;
using LavanderTyperWeb.Core.Messages.CommonMessages;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;
using LTW.Organization.Application.Features.Queries.Companies;
using LTW.Organization.Application.Features.Responses.Companies;
using LTW.Organization.Application.Features.ViewModel.Companies;

namespace LTW.Organization.Application.Features.QueryHandlers.Companies
{
  public class GetCompanyByIdHandler : Handler<GetCompanyByIdQuery, GetCompanyByIdQueryResponse>
  {
    private readonly ICompanyRepository _companyRepository;
    private readonly ILoggerService _loggerService;

    public GetCompanyByIdHandler(
        ICompanyRepository companyRepository,
        IMapper mapper,
        ILoggerService loggerService)
        : base(mapper)
    {
      _companyRepository = companyRepository;
      _loggerService = loggerService;
    }

    public override async Task<GetCompanyByIdQueryResponse> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
      try
      {
        await _loggerService.LogInfoAsync(
            request,
            "Start Handle Request",
            nameof(GetCompanyByIdHandler));
        var currentCompany = await _companyRepository.GetAsync(ep => ep.Id == request.Id, null, null);
        var companyMap = _mapper.Map<CompanyViewModel>(currentCompany.FirstOrDefault());

        var response = new GetCompanyByIdQueryResponse(companyMap);
        await _loggerService.LogInfoAsync(
            null,
            "End Handle Request",
            nameof(GetCompanyByIdHandler),
            response);

        return response;
      }
      catch (Exception ex)
      {
        return ResponseOnFailValidation(ex.Message, request.ValidationResult);
      }
    }

    public override List<ValidationFailure> Validate(GetCompanyByIdQuery request)
    {
      throw new NotImplementedException();
    }
  }
}
