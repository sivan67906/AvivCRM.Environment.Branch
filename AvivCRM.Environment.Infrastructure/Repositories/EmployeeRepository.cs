﻿using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;

public class EmployeeRepository(EnvironmentDbContext context) : GenericRepository<Employee>(context, context.Employees), IEmployee { }