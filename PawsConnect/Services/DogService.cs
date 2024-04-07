using PawsConnectData.Data;

namespace PawsConnect.Services
{
    public interface IDogService
    {

    }
    public class DogService : BaseService, IDogService
    {
        public DogService(PawsConnectContext PcContext) : base(PcContext)
        {
        }
    }

}
