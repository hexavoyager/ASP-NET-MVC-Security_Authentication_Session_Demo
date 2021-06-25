using BxlForm.DemoSecurity.Models.Client.Data;

namespace BxlForm.DemoSecurity.Infrastructure.Session
{
    public interface ISessionManager
    {
        UserSession User { get; set; }

        void Clear();
    }
}