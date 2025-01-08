#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionTypes.DeleteCustomQuestionType;
public record DeleteCustomQuestionTypeCommand(Guid Id) : IRequest<ServerResponse>;