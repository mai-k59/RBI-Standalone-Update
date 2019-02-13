using RBI.DAL.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class RW_STREAM_BUS
    {
        RW_STREAM_ConnectUtils DAL = new RW_STREAM_ConnectUtils();
       public void add(RW_STREAM obj)
        {
            DAL.add(obj.ID, obj.AmineSolution, obj.AqueousOperation, obj.AqueousShutdown, obj.ToxicConstituent, obj.Caustic, obj.Chloride, obj.CO3Concentration, obj.Cyanide, obj.ExposedToGasAmine, obj.ExposedToSulphur, obj.ExposureToAmine, obj.FlammableFluidID, obj.FlowRate, obj.H2S, obj.H2SInWater, obj.Hydrogen, obj.H2SPartialPressure, obj.Hydrofluoric, obj.MaterialExposedToClInt, obj.MaxOperatingPressure, obj.MaxOperatingTemperature, obj.MinOperatingPressure, obj.MinOperatingTemperature, obj.CriticalExposureTemperature, obj.ModelFluidID, obj.NaOHConcentration, obj.NonFlameToxicFluidID, obj.ReleaseFluidPercentToxic, obj.StoragePhase, obj.ToxicFluidID, obj.WaterpH, obj.TankFluidName, obj.FluidHeight, obj.FluidLeaveDikePercent, obj.FluidLeaveDikeRemainOnSitePercent, obj.FluidGoOffSitePercent);
        }
        public void edit(RW_STREAM obj)
        {
            DAL.edit(obj.ID, obj.AmineSolution, obj.AqueousOperation, obj.AqueousShutdown, obj.ToxicConstituent, obj.Caustic, obj.Chloride, obj.CO3Concentration, obj.Cyanide, obj.ExposedToGasAmine, obj.ExposedToSulphur, obj.ExposureToAmine, obj.FlammableFluidID, obj.FlowRate, obj.H2S, obj.H2SInWater, obj.Hydrogen, obj.H2SPartialPressure, obj.Hydrofluoric, obj.MaterialExposedToClInt, obj.MaxOperatingPressure, obj.MaxOperatingTemperature, obj.MinOperatingPressure, obj.MinOperatingTemperature, obj.CriticalExposureTemperature, obj.ModelFluidID, obj.NaOHConcentration, obj.NonFlameToxicFluidID, obj.ReleaseFluidPercentToxic, obj.StoragePhase, obj.ToxicFluidID, obj.WaterpH, obj.TankFluidName, obj.FluidHeight, obj.FluidLeaveDikePercent, obj.FluidLeaveDikeRemainOnSitePercent, obj.FluidGoOffSitePercent);
        }
        public void delete(RW_STREAM obj)
        {
            DAL.delete(obj.ID);
        }
        public void delete(int ID)
        {
            DAL.delete(ID);
        }
        public RW_STREAM getData(int ID)
        {
            return DAL.getData(ID);
        }
        public Boolean checkExistStream(int ID)
        {
            return DAL.checkExistStream(ID);
        }
    }
}
