﻿using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;

public class TaxRepository(EnvironmentDbContext context) : GenericRepository<Tax>(context, context.Taxs), ITax { }