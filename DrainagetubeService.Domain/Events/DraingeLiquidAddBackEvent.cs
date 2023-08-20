using DrainagetubeService.Domain.Entities;
using Juqianxie.EventBus;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;

namespace DrainagetubeService.Domain.Events
{
    [EventName("DrainageLiquid.Liquid.Add.Back")]
    public class DraingeLiquidAddBackEvent : DynamicIntegrationEventHandler
    {
        private readonly IDrainageUserReporterRepository _userReporterRepository;
        private readonly IDrainageLiquidRepository _drainageLiquidRepository;
        private readonly IDrainagetubeRepository _drainagetubeRepository;
        private readonly IDrainageLiquidReporterRepository _drainageLiquidReporterRepository;
        public DraingeLiquidAddBackEvent(IDrainageUserReporterRepository userReporterRepository, IDrainageLiquidRepository drainageLiquidRepository,
            IDrainagetubeRepository drainagetubeRepository, IDrainageLiquidReporterRepository drainageLiquidReporterRepository)
        {
            _userReporterRepository = userReporterRepository;
            _drainageLiquidRepository = drainageLiquidRepository;
            _drainagetubeRepository = drainagetubeRepository;
            _drainageLiquidReporterRepository = drainageLiquidReporterRepository;
        }
        public override async Task HandleDynamic(string eventName, dynamic eventData)
        {
            await InserterUserReport(eventData);
            await InserterLiqueReport(eventData);
        }

        private async Task InserterLiqueReport(dynamic eventData)
        {
            long uid = long.Parse(eventData.Uid);
            string Username = eventData.Username;
            DateTime CreationTime = DateTime.Parse(eventData.CreationTime);
            int intsex = int.Parse(eventData.Sex);
            Sex sex = Sex.Man;
            if (Enum.IsDefined(typeof(Sex), intsex))
            {
                sex = (Sex)intsex;
            }
            int Age = int.Parse(eventData.Age);
            string HospitalNumber = eventData.HospitalNumber;
            DateTime OperationTime = DateTime.Parse(eventData.OperationTime);
            DateTime DischargeTime = DateTime.Parse(eventData.DischargeTime);
            string SurgicalMethod = eventData.SurgicalMethod ?? "know";


            var tubes = await _drainagetubeRepository.FindByuserAsync(uid, -1, -1, CancellationToken.None);
            var item = tubes.OrderByDescending(u => u.CreationTime).LastOrDefault();
            List<DrainageLiquidReporter> repo = new List<DrainageLiquidReporter>();
            if (item == null) 
            {
                return;
            }
            var liques = await _drainageLiquidRepository.FindByTubeKeysAsync(item.Key.ToString(), CancellationToken.None);
            foreach (var lique in liques)
            {
                
                repo.Add(new DrainageLiquidReporter(uid, Username, DateTime.Now, sex, Age, HospitalNumber, OperationTime,
                    DischargeTime, SurgicalMethod, item.TubeType, lique.RecordTime, lique.LiquidColor, lique.LiquidProperty, lique.Liquidodour, lique.TubeState, lique.Volume
                    ));
            }
            await _drainageLiquidReporterRepository.AddRangeLiquidReporter(repo, CancellationToken.None);
        }

        private async Task InserterUserReport(dynamic eventData)
        {
            long uid = long.Parse(eventData.Uid);
            var tubes = await _drainagetubeRepository.FindByuserAsync(uid, -1, -1, CancellationToken.None);
            var item = tubes.OrderByDescending(u => u.CreationTime).LastOrDefault();
            if (item == null) 
            {
                return;
            }

            string Username = eventData.Username;
            DateTime CreationTime = DateTime.Parse(eventData.CreationTime);
            int intsex = int.Parse(eventData.Sex);
            Sex sex = Sex.Man;
            if (Enum.IsDefined(typeof(Sex), intsex))
            {
                sex = (Sex)intsex;
            }
            int Age = int.Parse(eventData.Age);
            string HospitalNumber = eventData.HospitalNumber;
            DateTime OperationTime = DateTime.Parse(eventData.OperationTime);
            DateTime DischargeTime = DateTime.Parse(eventData.DischargeTime);
            string SurgicalMethod = eventData.SurgicalMethod ?? "know";
            
            DrainageUserReporter reporter = DrainageUserReporter.Create(
                 uid,
                 Username,
                 CreationTime,
                 sex,
                 Age,
                 HospitalNumber,
                 OperationTime,
                 DischargeTime,
                 SurgicalMethod,
                 item.TubeType
                 );
            await _userReporterRepository.AddDrainagetubeAsync(reporter, CancellationToken.None);
        }
    }
}
