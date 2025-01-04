using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruiterSettings.DeleteRecruiterSetting;
public record DeleteRecruiterSettingCommand(Guid Id) : IRequest<ServerResponse>;









