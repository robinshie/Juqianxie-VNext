using IdentityService.Domain;
using Juqianxie.EventBus;

namespace IdentityService.Domain
{
    [EventName("DrainageLiquid.Liquid.Add")]
    public class DraingeLiquidAddEventHandler : DynamicIntegrationEventHandler
    {
        private readonly IIdRepository _idRepository;
        private readonly IEventBus _eventBus;
        public DraingeLiquidAddEventHandler(IIdRepository idRepository, IEventBus eventBus)
        {
            _idRepository = idRepository;
            _eventBus = eventBus;


        }
        public override async Task HandleDynamic(string eventName, dynamic eventData)
        {
            long id = eventData.Uid;
            var user = await _idRepository.FindByIdAsync(id);

            if (user == null) { throw new NotFiniteNumberException(id); }
            var userDetails = await _idRepository.FindUserdeteilByUidsAsync(id);

            _eventBus.Publish("DrainageLiquid.Liquid.Add.Back", new
            {
                Uid = id,
                Username = user.UserName,
                CreationTime = user.CreationTime,
                Sex = userDetails.Sex,
                Age = userDetails.Age,
                HospitalNumber = userDetails.HospitalNumber,
                OperationTime = userDetails.OperationTime,
                DischargeTime = userDetails.DischargeTime,
                SurgicalMethod = userDetails.SurgicalMethod

            });
        }
    }
}