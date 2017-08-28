namespace BeenPwned.App.Core.Interfaces
{
    public interface IPushNotificationService
    {
        bool IsRegistered { get; }
        void RegisterForPushNotifications();
        void OpenSettings();
    }
}