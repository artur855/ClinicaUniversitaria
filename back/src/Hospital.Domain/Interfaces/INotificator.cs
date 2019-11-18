using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain.Interfaces
{
    public interface INotificator
    {
        bool hasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
