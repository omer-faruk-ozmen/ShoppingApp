using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingApp.Domain.Entities.Identity;

namespace ShoppingApp.Application.Abstractions.Services
{
    public interface IMailService
    {
        Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true);
        Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true);
        Task SendPasswordResetMailAsync(string to, string userId, string resetToken);
        Task SendCompletedOrderMailAsync( AppUser user, string orderCode, DateTime orderDate);
    }
}
