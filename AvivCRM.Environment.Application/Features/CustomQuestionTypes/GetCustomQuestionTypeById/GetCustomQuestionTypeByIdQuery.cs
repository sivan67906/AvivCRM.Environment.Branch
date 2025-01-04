using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.CustomQuestionTypes.GetCustomQuestionTypeById;

public record GetCustomQuestionTypeByIdQuery(Guid Id) : IRequest<ServerResponse>;









