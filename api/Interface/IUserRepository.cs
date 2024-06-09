namespace api.Interface;

public interface IUserRepository
{
    bool IsloggedIn();
    string GetUserID();
    string GetUserName();
}
