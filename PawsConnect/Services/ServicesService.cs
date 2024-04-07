using PawsConnectData.Data;

namespace PawsConnect.Services
{
    public interface IServicesService
    {

    }
    public class ServicesService : BaseService, IServicesService
    {
        public ServicesService(PawsConnectContext PcContext) : base(PcContext)
        {
        }
    }
}
