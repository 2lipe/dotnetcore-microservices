using System.Threading.Tasks;
using Ordering.Application.Models;

namespace Ordering.Application.Contracts.Infraestructure
{
    public interface IMailService
    {
        Task<bool> SendEmail(Email email);
    }
}