namespace AvivCRM.Environment.Domain.Responses;
public record ServerResponse(bool IsSuccess = false, string Message = null!, object Data = null!);