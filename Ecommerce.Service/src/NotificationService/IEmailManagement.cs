using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Service.src.NotificationService
{
    public interface IEmailManagement
    {
        Task SendEmailAsync(string to, string subject, string body);

    }
}