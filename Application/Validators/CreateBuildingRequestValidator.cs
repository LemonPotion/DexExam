using Application.Dto.Building.Requests;
using FluentValidation;

namespace Application.Validators;

public class CreateBuildingRequestValidator : AbstractValidator<CreateBuildingRequest>
{
    public CreateBuildingRequestValidator()
    {
        
    }
}