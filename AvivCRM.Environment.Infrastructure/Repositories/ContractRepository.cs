﻿using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;

public class ContractRepository(EnvironmentDbContext context) : GenericRepository<Contract>(context, context.Contracts), IContract { }