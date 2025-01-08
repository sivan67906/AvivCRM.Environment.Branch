#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionCategories.DeleteCustomQuestionCategory;
public record DeleteCustomQuestionCategoryCommand(Guid Id) : IRequest<ServerResponse>;