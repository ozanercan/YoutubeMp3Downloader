using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IConvertService
    {
        public Task SendToIdAsync(string videoId);
    }
}
