using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    public class RW_EQUIPMENT
    {
        public int ID { get; set; }
        public DateTime CommissionDate { get; set; }
        public int AdminUpsetManagement { get; set; }
        public int ContainsDeadlegs { get; set; }
        public int CyclicOperation { get; set; }
        public int HighlyDeadlegInsp { get; set; }
        public int DowntimeProtectionUsed { get; set; }
        public String ExternalEnvironment { get; set; }
        public int HeatTraced { get; set; }
        public int InterfaceSoilWater { get; set; }
        public int LinerOnlineMonitoring { get; set; }
        public int MaterialExposedToClExt { get; set; }
        public float MinReqTemperaturePressurisation { get; set; }
        public String OnlineMonitoring { get; set; }
        public int PresenceSulphidesO2 { get; set; }
        public int PresenceSulphidesO2Shutdown { get; set; }
        public int PressurisationControlled { get; set; }
        public int PWHT { get; set; }
        public int SteamOutWaterFlush { get; set; }
        public float ManagementFactor { get; set; }
        public String ThermalHistory { get; set; }
        public int YearLowestExpTemp { get; set; }
        public float Volume { get; set; }
        public String TypeOfSoil { get; set; }//6 truong nay chua duoc gan
        public String EnvironmentSensitivity { get; set; }
        public float DistanceToGroundWater { get; set; }
        public String AdjustmentSettle { get; set; }
        public int ComponentIsWelded { get; set; }
        public int TankIsMaintained { get; set; }
    }
}
