using PawsConnectData.Data;

namespace PawsConnect.Services
{
    public class BaseService
    {
        protected readonly PawsConnectContext _pcContext;

        public BaseService(PawsConnectContext PcContext)
        {
            _pcContext = PcContext;
        }
    }
}
