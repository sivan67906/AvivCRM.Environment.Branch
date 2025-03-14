﻿#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Application.Contracts;
public interface ICurrency
{
    void Add(Currency currency);
    void Update(Currency currency);
    void Delete(Currency currency);
    Task<Currency?> GetByIdAsync(Guid id);
    Task<IEnumerable<Currency>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string currencyName);
}