using AvivCRM.Environment.Application.DTOs.Applications;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Applicationss.CreateApplication;
public record CreateApplicationCommand(CreateApplicationRequest Application) : IRequest<ServerResponse>;