using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.CustomQuestionCategories.DeleteCustomQuestionCategory;
public record DeleteCustomQuestionCategoryCommand(Guid Id) : IRequest<ServerResponse>;









