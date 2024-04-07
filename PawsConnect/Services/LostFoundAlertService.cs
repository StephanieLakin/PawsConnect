using PawsConnectData.Data;

namespace PawsConnect.Services
{  
    public interface ILostFoundAlertService
    {

    }
    public class LostFoundAlertService : BaseService, ILostFoundAlertService
    {
        public LostFoundAlertService(PawsConnectContext PcContext) : base(PcContext)
        {
        }
    }
}
