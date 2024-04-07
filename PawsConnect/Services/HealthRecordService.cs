using PawsConnectData.Data;

namespace PawsConnect.Services
{
    public interface IHealthRecordService
    {

    }
    public class HealthRecordService : BaseService, IHealthRecordService
    {
        public HealthRecordService(PawsConnectContext PcContext) : base(PcContext)
        {
        }
    }
}
