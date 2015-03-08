namespace SimpleIdentity.Models.Contracts
{
    public interface IUser
    {
        string UserName { get; set; }
        string Password { get; set; }
    }
}
