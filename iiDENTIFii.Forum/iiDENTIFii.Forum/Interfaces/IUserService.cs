using iiDENTIFii.Forum.Models;

namespace iiDENTIFii.Forum.Interfaces
{
    public interface IUserService
    {
        User GetUser(string name);
    }
}