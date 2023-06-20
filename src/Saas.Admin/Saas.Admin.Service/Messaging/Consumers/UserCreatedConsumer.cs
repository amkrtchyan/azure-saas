using MassTransit;
using Saas.Admin.Service.Data;
using Saas.Admin.Service.Data.Entities;
using Saas.Shared.Constants;
using Saas.Shared.Messages;

namespace Saas.Admin.Messaging.Consumers;

public class UserCreatedConsumer : IConsumer<ICreateRole>
{
    private readonly TenantsContext _context;

    public UserCreatedConsumer(TenantsContext context)
    {
        _context = context;
    }

    public async Task Consume(ConsumeContext<ICreateRole> context)
    {
        var message = context.Message;

        _context.Add(new TenantApplicationRole()
        {
            ApplicationId = ApplicationContants.PayrollServicesApplicationId,
            Role = message.Name,
            TenantId = Guid.Parse("8F566A1E-F2BC-495A-AD82-08DB6E58180D"),
        });

        await _context.SaveChangesAsync();
    }
}
