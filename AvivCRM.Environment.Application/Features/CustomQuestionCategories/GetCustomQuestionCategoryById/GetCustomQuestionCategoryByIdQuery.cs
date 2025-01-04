using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.CustomQuestionCategories.GetCustomQuestionCategoryById;

public record GetCustomQuestionCategoryByIdQuery(Guid Id) : IRequest<ServerResponse>;









