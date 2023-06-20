namespace Saas.Shared.Messages;

public interface ICreateUser
{
    public Guid UserObjectId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string[] Roles { get; set; }
}
