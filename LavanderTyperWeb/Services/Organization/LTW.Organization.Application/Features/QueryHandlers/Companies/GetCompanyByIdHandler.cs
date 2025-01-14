using AutoMapper;
using FluentValidation.Results;
using LTW.Core.Messages.CommonMessages;
using LTW.Organization.Application.Features.Queries.Companies;
using LTW.Organization.Application.Features.Responses.Companies;
using LTW.Organization.Application.Features.ViewModel.Companies;
using LTW.Organization.Domain.Primitives.Common.Interfaces.Repositories;

namespace LTW.Organization.Application.Features.QueryHandlers.Companies
{
  public class GetCompanyByIdHandler : Handler<GetCompanyByIdQuery, GetCompanyByIdQueryResponse>
  {
    private readonly ICompanyRepository _companyRepository;

    public GetCompanyByIdHandler(
        ICompanyRepository companyRepository,
        IMapper mapper)
        : base(mapper)
    {
      _companyRepository = companyRepository;
    }

    public override async Task<GetCompanyByIdQueryResponse> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
      try
      {
        //await _loggerService.LogInfoAsync(
        //    request,
        //    "Start Handle Request",
        //    nameof(GetCompanyByIdHandler));
        var currentCompany = await _companyRepository.GetAsync(ep => ep.Id == request.Id, null, null);
        var companyMap = _mapper.Map<CompanyViewModel>(currentCompany.FirstOrDefault());

        var response = new GetCompanyByIdQueryResponse(companyMap);
        //await _loggerService.LogInfoAsync(
        //    null,
        //    "End Handle Request",
        //    nameof(GetCompanyByIdHandler),
        //    response);

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
