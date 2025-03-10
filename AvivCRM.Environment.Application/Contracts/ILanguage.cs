﻿#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Application.Contracts;
public interface ILanguage
{
    void Add(Language language);
    void Update(Language language);
    void Delete(Language language);
    Task<Language?> GetByIdAsync(Guid id);
    Task<IEnumerable<Language>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string languageName);
}