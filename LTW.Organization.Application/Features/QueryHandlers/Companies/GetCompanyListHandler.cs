using AutoMapper;
using FluentValidation.Results;
using LTW.Core.Messages.CommonMessages;
using LTW.Organization.Application.Features.Queries.Companies;
using LTW.Organization.Application.Features.Responses.Companies;
using LTW.Organization.Application.Features.ViewModel.Companies;
using LTW.Organization.Domain.Primitives.Common.Interfaces.Repositories;

namespace LTW.Organization.Application.Features.QueryHandlers.Companies
{
  public class GetCompanyListHandler : Handler<GetCompanyListQuery, GetCompanyListQueryResponse>
  {
    private readonly ICompanyRepository _companyRepository;

    public GetCompanyListHandler(
        IMapper mapper,
        ICompanyRepository companyRepository)
        : base(mapper)
    {
      _companyRepository = companyRepository;
    }

    public override async Task<GetCompanyListQueryResponse> Handle(GetCompanyListQuery request, CancellationToken cancellationToken)
    {
      try
      {
        //await _loggerService.LogInfoAsync(
        //    request,
        //    "Start Handle Request",
        //    nameof(GetCompanyListHandler));

        var companyList = await _companyRepository.GetAsync(null, null, null);
        var companyListMap = _mapper.Map<List<CompanyViewModel>>(companyList);

        var response = new GetCompanyListQueryResponse(companyListMap);
        //await _loggerService.LogInfoAsync(
        //    null,
        //    "End Handle Request",
        //    nameof(GetCompanyListHandler),
        //    response);

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
