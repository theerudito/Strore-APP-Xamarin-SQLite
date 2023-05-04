using MyStore.Models;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface ICode
    {
        Task<MCodeApp> getCodeAsync(int codeAdmin);
    }
}