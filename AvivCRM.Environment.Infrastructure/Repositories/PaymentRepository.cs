﻿using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;

public class PaymentRepository(EnvironmentDbContext context) : GenericRepository<Payment>(context, context.Payments), IPayment { }