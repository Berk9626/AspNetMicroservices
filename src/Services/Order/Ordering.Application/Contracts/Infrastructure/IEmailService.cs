using Ordering.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Contracts.Infrastructure
{
    //customer wants from us to send mail when new order coming
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(Email email);
    }
}
