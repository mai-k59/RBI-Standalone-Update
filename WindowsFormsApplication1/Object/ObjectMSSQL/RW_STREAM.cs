using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    public class RW_STREAM
    {
        public int ID { set; get; }
        public String AmineSolution { set; get; }
        public int AqueousOperation { set; get; }
        public int AqueousShutdown { set; get; }
        public int ToxicConstituent { set; get; }
        public int Caustic { set; get; }
        public float Chloride { set; get; }
        public float CO3Concentration { set; get; }
        public int Cyanide { set; get; }
        public int ExposedToGasAmine { set; get; }
        public int ExposedToSulphur { set; get; }
        public String ExposureToAmine { set; get; }
        public int FlammableFluidID { set; get; }
        public float FlowRate { set; get; } //nằm ở file Operating
        public int H2S { set; get; }
        public float H2SInWater { set; get; }
        public int Hydrogen { set; get; } //??
        public float H2SPartialPressure { set; get; }//??
        public int Hydrofluoric { set; get; }
        public int MaterialExposedToClInt { set; get; }
        public float MaxOperatingPressure { set; get; }
        public float MaxOperatingTemperature { set; get; }
        public float MinOperatingPressure { set; get; }
        public float MinOperatingTemperature { set; get; }
        public float CriticalExposureTemperature { set; get; } //ben file Operating
        public int ModelFluidID { set; get; }
        public float NaOHConcentration { set; get; }
        public int NonFlameToxicFluidID { set; get; }
        public float ReleaseFluidPercentToxic { set; get; }
        public String StoragePhase { set; get; } //??
        public int ToxicFluidID { set; get; }
        public float WaterpH { set; get; }
        public String TankFluidName { set; get; }//??
        public float FluidHeight { set; get; }
        public float FluidLeaveDikePercent { set; get; }
        public float FluidLeaveDikeRemainOnSitePercent { set; get; }
        public float FluidGoOffSitePercent { set; get; }
        public float CUI_PERCENT_1 { set; get; }// % Operating at -12 °C to -8 °C
        public float CUI_PERCENT_2 { set; get; }// % Operating at -8 °C to 6 °C
        public float CUI_PERCENT_3 { set; get; }// % Operating at 6 °C to 32 °C
        public float CUI_PERCENT_4 { set; get; }// % Operating at 32 °C to 71 °C
        public float CUI_PERCENT_5 { set; get; }// % Operating at 71 °C to 107 °C
        public float CUI_PERCENT_6 { set; get; }// % Operating at 107 °C to 121 °C
        public float CUI_PERCENT_7 { set; get; }// % Operating at 121 °C to 135 °C
        public float CUI_PERCENT_8 { set; get; }// % Operating at 135 °C to 162 °C
        public float CUI_PERCENT_9 { set; get; }// % Operating at 162 °C to 176 °C
        public float CUI_PERCENT_10 { set; get; }// % Operating at 176 °C or above
        
    }
}
