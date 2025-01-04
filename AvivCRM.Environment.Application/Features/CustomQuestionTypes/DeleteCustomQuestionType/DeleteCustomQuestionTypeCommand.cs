using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.CustomQuestionTypes.DeleteCustomQuestionType;
public record DeleteCustomQuestionTypeCommand(Guid Id) : IRequest<ServerResponse>;









