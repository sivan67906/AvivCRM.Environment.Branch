using AvivCRM.Environment.Domain.Contracts.Purchase;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;

public class PurchaseOrderRepository(EnvironmentDbContext context) : GenericRepository<PurchaseOrder>(context, context.PurchaseOrders), IPurchaseOrder { }
