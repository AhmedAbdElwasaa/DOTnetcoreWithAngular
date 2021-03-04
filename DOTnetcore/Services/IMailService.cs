namespace DOTnetcore.Services
{
    public interface IMailService
    {
        void SendMessage(string reciver, string subject, string body);
    }
}