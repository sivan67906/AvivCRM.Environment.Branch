using AvivCRM.Environment.Application.Contracts.Purchase;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;

public class VendorCreditRepository(EnvironmentDbContext context) : GenericRepository<VendorCredit>(context, context.VendorCredits), IVendorCredit { }
