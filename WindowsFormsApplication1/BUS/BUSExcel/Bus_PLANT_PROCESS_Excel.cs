using RBI.BUS.BUSMSSQL;
using RBI.DAL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.BUS.BUSExcel
{
    class Bus_PLANT_PROCESS_Excel
    {
        //RW_COATING rwCoat;
        //RW_COMPONENT rwComp;
        //RW_ASSESSMENT rwAss;
        //RW_EQUIPMENT rwEq;
        //RW_STREAM rwStream;
        //RW_MATERIAL rwMaterial;
        //RW_EXTCOR_TEMPERATURE rwExtcor;
        SITES site;
        FACILITY facility;

        // BUS
        FACILITY_BUS busFacility = new FACILITY_BUS();
        SITES_BUS busSite = new SITES_BUS();
        EQUIPMENT_TYPE_BUS busEquipmentType = new EQUIPMENT_TYPE_BUS();
        DESIGN_CODE_BUS busDesignCode = new DESIGN_CODE_BUS();
        MANUFACTURER_BUS busManufacture = new MANUFACTURER_BUS();
        COMPONENT_TYPE__BUS busComponentType = new COMPONENT_TYPE__BUS();
        API_COMPONENT_TYPE_BUS busAPIComp = new API_COMPONENT_TYPE_BUS();
        EQUIPMENT_MASTER_BUS busEquipMaster = new EQUIPMENT_MASTER_BUS();
        COMPONENT_MASTER_BUS busCompMaster = new COMPONENT_MASTER_BUS();
        RW_ASSESSMENT_BUS busAssesment = new RW_ASSESSMENT_BUS();

        /// <summary>
        /// value
        /// </summary>
        public String path { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public class facilityExcel
        {
            public String siteName { set; get; }
            public String facilityName { set; get; }
        }
        public class equipementExcel
        {
            public String facilityName { set; get; }
            public String equipmentName { set; get; }
        }
        public class componentExcel
        {
            public String equipmentName { set; get; }
            public String componentName { set; get; }
        }
        private class environSensitivity
        {
            public int ID { set; get; }
            public String environ { set; get; }
        }

        ExcelConnect exConn = new ExcelConnect();
        public OleDbConnection getConnect()
        {
            return exConn.connectionExcel(path);
        }
        

        /// <summary>
        /// get data
        /// </summary>
        /// <returns></returns>
        public List<SITES> getAllSite()
        {
            List<SITES> list = new List<SITES>();
            OleDbConnection conn = getConnect();
            try
            {
                conn.Open();
                String sql = "SELECT DISTINCT Site FROM [Equipment$]";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!reader.IsDBNull(0))
                        {
                            site = new SITES();
                            site.SiteID = busSite.getIDbyName(reader[0].ToString());
                            site.SiteName = reader[0].ToString();
                            list.Add(site);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Format sheet Equipment error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        public List<facilityExcel> getAllFacility(String SiteName)
        {
            List<facilityExcel> list = new List<facilityExcel>();
            facilityExcel obj = null;
            OleDbConnection conn = getConnect();
            try
            {
                conn.Open();
                String sql = "SELECT DISTINCT Facility FROM [Equipment$] WHERE Site ='" + SiteName + "'";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!reader.IsDBNull(0))
                        {
                            obj = new facilityExcel();
                            obj.siteName = SiteName;
                            obj.facilityName = reader[0].ToString();
                            list.Add(obj);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Format sheet Equipment error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        public List<equipementExcel> getAllEquipment(String FacilityName)
        {
            List<equipementExcel> list = new List<equipementExcel>();
            equipementExcel obj = null;
            OleDbConnection conn = getConnect();
            try
            {
                conn.Open();
                String sql = "SELECT DISTINCT [Equipment Number] FROM [Equipment$] WHERE Facility ='" + FacilityName + "'";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!reader.IsDBNull(0))
                        {
                            obj = new equipementExcel();
                            obj.facilityName = FacilityName;
                            obj.equipmentName = reader[0].ToString();
                            list.Add(obj);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Format sheet Equipment error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        public List<componentExcel> getAllComponent(String EquipNum)
        {
            List<componentExcel> list = new List<componentExcel>();
            componentExcel obj = null;
            OleDbConnection conn = getConnect();
            try
            {
                conn.Open();
                String sql = "SELECT DISTINCT [Component Number] FROM [Component$] WHERE [Equipment Number] ='" + EquipNum + "'";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!reader.IsDBNull(0))
                        {
                            obj = new componentExcel();
                            obj.equipmentName = EquipNum;
                            obj.componentName = reader[0].ToString();
                            list.Add(obj);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Format sheet Component error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        public List<String> getAllDesigncode()
        {
            List<String> list = new List<String>();
            OleDbConnection conn = getConnect();
            try
            {
                conn.Open();
                String sql = "SELECT DISTINCT [Design Code] FROM [Equipment$]";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!reader.IsDBNull(0))
                        {
                            list.Add(reader[0].ToString());
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Format sheet Equipment error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        public List<String> getAllManufacture()
        {
            List<String> list = new List<String>();
            OleDbConnection conn = getConnect();
            try
            {
                conn.Open();
                String sql = "SELECT DISTINCT [Manufacturer] FROM [Equipment$]";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!reader.IsDBNull(0))
                        {
                            list.Add(reader[0].ToString());
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Format sheet Equipment error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }

        private List<environSensitivity> getenviron()
        {
            List<environSensitivity> list = new List<environSensitivity>();
            environSensitivity obj = null;
            List<RW_ASSESSMENT> list1 = busAssesment.getDataSource();
            OleDbConnection conn = getConnect();
            try
            {
                conn.Open();
                String sql1 = "SELECT * FROM [Stream$]";
                OleDbCommand cmd = new OleDbCommand(sql1, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!reader.IsDBNull(0))
                        {
                            for (int i = 0; i < list1.Count; i++)
                            {
                                if (list1[i].ComponentID == busCompMaster.getIDbyName(reader[0].ToString()))
                                {
                                    obj = new environSensitivity();
                                    obj.ID = list1[i].ID;
                                    obj.environ = reader[25].ToString();
                                    list.Add(obj);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Format sheet Stream error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }

        // yeu cau phai add site vao truoc
        public List<FACILITY> getFacility()
        {
            List<FACILITY> list = new List<FACILITY>();
            OleDbConnection conn = getConnect();
            try
            {
                conn.Open();
                String sql = "SELECT DISTINCT [Site], [Facility], [System Management Factor] FROM [Equipment$] ";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!(reader.IsDBNull(0) || reader.IsDBNull(1)))
                        {
                            facility = new FACILITY();
                            facility.FacilityID = busFacility.getIDbyName(reader[1].ToString());
                            facility.SiteID = busSite.getIDbyName(reader[0].ToString());
                            facility.FacilityName = reader[1].ToString();
                            try
                            {
                                facility.ManagementFactor = float.Parse(reader[2].ToString());
                            }
                            catch
                            {
                                facility.ManagementFactor = 0.1f;
                            }
                            list.Add(facility);
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("Format sheet Equipment error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }

        // yeu cau phai add facility, manufacture, design code vao truoc
        public List<EQUIPMENT_MASTER> getEquipmentMaster()
        {
            List<EQUIPMENT_MASTER> list = new List<EQUIPMENT_MASTER>();
            EQUIPMENT_MASTER obj = null;
            OleDbConnection conn = getConnect();
            try
            {
                // PFD No
                conn.Open();
                String sql = "SELECT * FROM [Equipment$] ";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!(reader.IsDBNull(0) || reader.IsDBNull(1) || reader.IsDBNull(2) || reader.IsDBNull(3) || reader.IsDBNull(4) || reader.IsDBNull(5) || reader.IsDBNull(6) || reader.IsDBNull(7)))
                        {
                            obj = new EQUIPMENT_MASTER();
                            obj.EquipmentID = busEquipMaster.getIDbyName(reader[0].ToString());
                            obj.EquipmentNumber = reader[0].ToString();
                            obj.EquipmentTypeID = busEquipmentType.getIDbyName(reader[1].ToString());
                            obj.EquipmentName = reader[2].ToString();
                            obj.DesignCodeID = busDesignCode.getIDbyName(reader[3].ToString());
                            obj.SiteID = busSite.getIDbyName(reader[4].ToString());
                            obj.FacilityID = busFacility.getIDbyName(reader[5].ToString());
                            obj.ManufacturerID = busManufacture.getIDbyName(reader[6].ToString());
                            obj.IsArchived = 1;
                            obj.Archived = DateTime.Now;
                            obj.CommissionDate = Convert.ToDateTime(reader[7].ToString());
                            obj.PFDNo = reader[8].ToString();
                            obj.ProcessDescription = reader[9].ToString();
                            obj.EquipmentDesc = reader[10].ToString();
                            list.Add(obj);
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("Format sheet Equipment error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        // yeu cau phai add EQUIPMENT_MASTER vao trc
        public List<COMPONENT_MASTER> getComponentMaster()
        {
            List<COMPONENT_MASTER> list = new List<COMPONENT_MASTER>();
            COMPONENT_MASTER obj = null;
            OleDbConnection conn = getConnect();
            try
            {
                conn.Open();
                String sql = "SELECT * FROM [Component$] ";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!(reader.IsDBNull(0) || reader.IsDBNull(1) || reader.IsDBNull(2) || reader.IsDBNull(3) || reader.IsDBNull(4) || reader.IsDBNull(5)))
                        {
                            obj = new COMPONENT_MASTER();
                            obj.EquipmentID = busEquipMaster.getIDbyName(reader[0].ToString());
                            obj.ComponentNumber = reader[1].ToString();
                            obj.ComponentTypeID = busComponentType.getIDbyName(reader[2].ToString());
                            obj.APIComponentTypeID = busAPIComp.getIDbyName(reader[3].ToString());
                            obj.ComponentName = reader[4].ToString();
                            try
                            {
                                obj.IsEquipmentLinked = Convert.ToInt32(reader.GetBoolean(5));
                            }
                            catch
                            {
                                obj.IsEquipmentLinked = 0;
                            }
                            obj.ComponentDesc = reader[6].ToString();
                            list.Add(obj);
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("Format sheet Component error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }

        // tao file assessment yeu cau equipment phai duoc add vao truoc
        public List<RW_ASSESSMENT> getAssessment()
        {
            RW_ASSESSMENT obj = null;
            List<RW_ASSESSMENT> list = new List<RW_ASSESSMENT>();
            OleDbConnection conn = getConnect();
            try
            {
                conn.Open();
                String sql = "SELECT * FROM [Component$]";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!(reader.IsDBNull(0) || reader.IsDBNull(1) || reader.IsDBNull(7)))
                        {
                            obj = new RW_ASSESSMENT();
                            obj.EquipmentID = busEquipMaster.getIDbyName(reader[0].ToString());
                            obj.ComponentID = busCompMaster.getIDbyName(reader[1].ToString());
                            try
                            {
                                obj.IsEquipmentLinked = Convert.ToInt32(reader.GetBoolean(5));
                            }
                            catch
                            {
                                obj.IsEquipmentLinked = 0;
                            }
                            obj.AssessmentDate = Convert.ToDateTime(reader[7].ToString());
                            try
                            {
                                obj.RiskAnalysisPeriod = Convert.ToInt32(reader[8].ToString());
                            }
                            catch
                            {
                                obj.RiskAnalysisPeriod = 36;
                            }

                            obj.ProposalName = "New Proposal " + (busAssesment.countProposal(obj.ComponentID) + 1);
                            obj.AdoptedDate = DateTime.Now;
                            obj.RecommendedDate = DateTime.Now;
                            list.Add(obj);
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("Format sheet Component error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        // cac file theo sau assessment( yeu cau assessment phai duoc add truoc):
        //1. RW_EQUIPMENT
        public List<RW_EQUIPMENT> getRwEquipment()
        {
            RW_EQUIPMENT obj = null;
            List<RW_EQUIPMENT> list = new List<RW_EQUIPMENT>();
            List<RW_ASSESSMENT> list1 = busAssesment.getDataSource();
            OleDbConnection conn = getConnect();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM [Equipment$]";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!(reader.IsDBNull(0) || reader.IsDBNull(31)))
                        {
                            for (int i = 0; i < list1.Count; i++)
                            {
                                if (list1[i].EquipmentID == busEquipMaster.getIDbyName(reader[0].ToString()))
                                {
                                    obj = new RW_EQUIPMENT();
                                    obj.ID = list1[i].ID;
                                    obj.CommissionDate = Convert.ToDateTime(reader[7].ToString());
                                    try
                                    {
                                        obj.AdminUpsetManagement = Convert.ToInt32(reader.GetBoolean(11));
                                    }
                                    catch
                                    {
                                        obj.AdminUpsetManagement = 0;
                                    }
                                    try
                                    {
                                        obj.ContainsDeadlegs = Convert.ToInt32(reader.GetBoolean(12));
                                    }
                                    catch
                                    {
                                        obj.ContainsDeadlegs = 0;
                                    }
                                    try
                                    {
                                        obj.CyclicOperation = Convert.ToInt32(reader.GetBoolean(14));
                                    }
                                    catch
                                    {
                                        obj.CyclicOperation = 0;
                                    }
                                    try
                                    {
                                        obj.HighlyDeadlegInsp = Convert.ToInt32(reader.GetBoolean(13));
                                    }
                                    catch
                                    {
                                        obj.HighlyDeadlegInsp = 0;
                                    }
                                    try
                                    {
                                        obj.DowntimeProtectionUsed = Convert.ToInt32(reader.GetBoolean(15));
                                    }
                                    catch
                                    {
                                        obj.DowntimeProtectionUsed = 0;
                                    }
                                    obj.ExternalEnvironment = reader[27].ToString();
                                    try
                                    {
                                        obj.HeatTraced = Convert.ToInt32(reader.GetBoolean(17));
                                    }
                                    catch
                                    {
                                        obj.HeatTraced = 0;
                                    }
                                    try
                                    {
                                        obj.InterfaceSoilWater = Convert.ToInt32(reader.GetBoolean(19));
                                    }
                                    catch
                                    {
                                        obj.InterfaceSoilWater = 0;
                                    }
                                    try
                                    {
                                        obj.LinerOnlineMonitoring = Convert.ToInt32(reader.GetBoolean(24));
                                    }
                                    catch
                                    {
                                        obj.LinerOnlineMonitoring = 0;
                                    }
                                    try
                                    {
                                        obj.MaterialExposedToClExt = Convert.ToInt32(reader.GetBoolean(23));
                                    }
                                    catch
                                    {
                                        obj.MaterialExposedToClExt = 0;
                                    }
                                    try
                                    {
                                        obj.MinReqTemperaturePressurisation = (float)reader.GetDouble(21);
                                    }
                                    catch
                                    {
                                        obj.MinReqTemperaturePressurisation = 0;
                                    }
                                    obj.OnlineMonitoring = reader[29].ToString();
                                    try
                                    {
                                        obj.PresenceSulphidesO2 = Convert.ToInt32(reader.GetBoolean(25));
                                    }
                                    catch
                                    {
                                        obj.PresenceSulphidesO2 = 0;
                                    }
                                    try
                                    {
                                        obj.PresenceSulphidesO2Shutdown = Convert.ToInt32(reader.GetBoolean(26));
                                    }
                                    catch
                                    {
                                        obj.PresenceSulphidesO2Shutdown = 0;
                                    }
                                    try
                                    {
                                        obj.PressurisationControlled = Convert.ToInt32(reader.GetBoolean(20));
                                    }
                                    catch
                                    {
                                        obj.PressurisationControlled = 0;
                                    }
                                    try
                                    {
                                        obj.PWHT = Convert.ToInt32(reader.GetBoolean(18));
                                    }
                                    catch
                                    {
                                        obj.PWHT = 0;
                                    }
                                    try
                                    {
                                        obj.SteamOutWaterFlush = Convert.ToInt32(reader.GetBoolean(16));
                                    }
                                    catch
                                    {
                                        obj.SteamOutWaterFlush = 0;
                                    }
                                    obj.ManagementFactor = (float)reader.GetDouble(31);
                                    obj.ThermalHistory = reader[28].ToString();
                                    try
                                    {
                                        obj.YearLowestExpTemp = Convert.ToInt32(reader.GetBoolean(22));
                                    }
                                    catch
                                    {
                                        obj.YearLowestExpTemp = 0;
                                    }
                                    try
                                    {
                                        obj.Volume = (float)reader.GetDouble(30);
                                    }
                                    catch
                                    {
                                        obj.Volume = 0;
                                    }
                                    list.Add(obj);
                                }
                           }
                        }
                    }
                }

            }
            catch
            {
                MessageBox.Show("Format sheet Equipment error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        public List<RW_EQUIPMENT> getRwEquipmentTank()
        {
            RW_EQUIPMENT obj = null;
            List<RW_EQUIPMENT> list = new List<RW_EQUIPMENT>();
            List<RW_ASSESSMENT> list1 = busAssesment.getDataSource();
            OleDbConnection conn = getConnect();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM [Equipment$]";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!(reader.IsDBNull(0) || reader.IsDBNull(29) || reader.IsDBNull(7)))
                        {
                            for (int i = 0; i < list1.Count; i++)
                            {
                                if (list1[i].EquipmentID == busEquipMaster.getIDbyName(reader[0].ToString()))
                                {
                                    obj = new RW_EQUIPMENT();
                                    obj.ID = list1[i].ID;
                                    obj.CommissionDate = Convert.ToDateTime(reader[7].ToString());
                                    try
                                    {
                                        obj.AdminUpsetManagement = Convert.ToInt32(reader.GetBoolean(11));
                                    }
                                    catch
                                    {
                                        obj.AdminUpsetManagement = 0;
                                    }
                                    try
                                    {
                                        obj.CyclicOperation = Convert.ToInt32(reader.GetBoolean(12));
                                    }
                                    catch
                                    {
                                        obj.CyclicOperation = 0;
                                    }
                                    try
                                    {
                                        obj.DowntimeProtectionUsed = Convert.ToInt32(reader.GetBoolean(13));
                                    }
                                    catch
                                    {
                                        obj.DowntimeProtectionUsed = 0;
                                        Console.WriteLine("Hello error 3");
                                    }
                                    try
                                    {
                                        obj.SteamOutWaterFlush = Convert.ToInt32(reader.GetBoolean(14));
                                    }
                                    catch
                                    {
                                        obj.SteamOutWaterFlush = 0;
                                    }
                                    try
                                    {
                                        obj.HeatTraced = Convert.ToInt32(reader.GetBoolean(15));
                                    }
                                    catch
                                    {
                                        obj.HeatTraced = 0;
                                    }
                                    try
                                    {
                                        obj.PWHT = Convert.ToInt32(reader.GetBoolean(16));
                                    }
                                    catch
                                    {
                                        obj.PWHT = 0;
                                    }
                                    try
                                    {
                                        obj.InterfaceSoilWater = Convert.ToInt32(reader.GetBoolean(17));
                                    }
                                    catch
                                    {
                                        obj.InterfaceSoilWater = 0;
                                    }
                                    try
                                    {
                                        obj.PressurisationControlled = Convert.ToInt32(reader.GetBoolean(18));
                                    }
                                    catch
                                    {
                                        obj.PressurisationControlled = 0;
                                    }
                                    try
                                    {
                                        obj.MinReqTemperaturePressurisation = (float)reader.GetDouble(19);
                                    }
                                    catch
                                    {
                                        obj.MinReqTemperaturePressurisation = 0;
                                    }
                                    try
                                    {
                                        obj.YearLowestExpTemp = Convert.ToInt32(reader.GetBoolean(20));
                                    }
                                    catch
                                    {
                                        obj.YearLowestExpTemp = 0;
                                    }
                                    try
                                    {
                                        obj.MaterialExposedToClExt = Convert.ToInt32(reader.GetBoolean(21));
                                    }
                                    catch
                                    {
                                        obj.MaterialExposedToClExt = 0;
                                    }
                                    try
                                    {
                                        obj.LinerOnlineMonitoring = Convert.ToInt32(reader.GetBoolean(22));
                                    }
                                    catch
                                    {
                                        obj.LinerOnlineMonitoring = 0;
                                    }
                                    try
                                    {
                                        obj.PresenceSulphidesO2 = Convert.ToInt32(reader.GetBoolean(23));
                                    }
                                    catch
                                    {
                                        obj.PresenceSulphidesO2 = 0;
                                    }
                                    try
                                    {
                                        obj.PresenceSulphidesO2Shutdown = Convert.ToInt32(reader.GetBoolean(24));
                                    }
                                    catch
                                    {
                                        obj.PresenceSulphidesO2Shutdown = 0;
                                    }
                                    obj.ExternalEnvironment = reader[25].ToString();
                                    obj.ThermalHistory = reader[26].ToString();
                                    obj.OnlineMonitoring = reader[27].ToString();
                                    try
                                    {
                                        obj.Volume = (float)reader.GetDouble(28);
                                    }
                                    catch
                                    {
                                        obj.Volume = 0;
                                    }
                                    try
                                    {
                                        obj.ManagementFactor = (float)reader.GetDouble(29);
                                    }
                                    catch
                                    {
                                        obj.ManagementFactor = 0;
                                    }
                                    obj.TypeOfSoil = reader[30].ToString();
                                    try
                                    {
                                        obj.DistanceToGroundWater = (float)reader.GetDouble(31);
                                    }
                                    catch
                                    {
                                        obj.DistanceToGroundWater = 0;
                                    }
                                    obj.EnvironmentSensitivity = reader[32].ToString();
                                    obj.AdjustmentSettle = reader[33].ToString();
                                    try
                                    {
                                        obj.ComponentIsWelded = Convert.ToInt32(reader.GetBoolean(34));
                                    }
                                    catch
                                    {
                                        obj.ComponentIsWelded = 0;
                                    }
                                    try
                                    {
                                        obj.TankIsMaintained = Convert.ToInt32(reader.GetBoolean(35));
                                    }
                                    catch
                                    {
                                        obj.TankIsMaintained = 0;
                                    }
                                    list.Add(obj);
                                }
                            }
                        }
                    }
                }

            }
            catch
            {
                MessageBox.Show("Format sheet Equipment error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }

        //2. RW_COMPONENT
        public List<RW_COMPONENT> getRwComponent()
        {
            RW_COMPONENT obj = null;
            List<RW_COMPONENT> list = new List<RW_COMPONENT>();
            List<RW_ASSESSMENT> list1 = busAssesment.getDataSource();
            OleDbConnection conn = getConnect();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM [Component$]";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!(reader.IsDBNull(0) || reader.IsDBNull(1)))
                        {
                            for (int i = 0; i < list1.Count; i++)
                            {
                                if (list1[i].ComponentID == busCompMaster.getIDbyName(reader[1].ToString()))
                                {
                                    obj = new RW_COMPONENT();
                                    obj.ID = list1[i].ID;
                                    try
                                    {
                                        obj.NominalDiameter = (float)reader.GetDouble(9);
                                    }
                                    catch
                                    {
                                        obj.NominalDiameter = 0;
                                    }
                                    try
                                    {
                                        obj.NominalThickness = (float)reader.GetDouble(10);
                                    }
                                    catch
                                    {
                                        obj.NominalThickness = 0;
                                    }
                                    try
                                    {
                                        obj.CurrentThickness = (float)reader.GetDouble(11);
                                    }
                                    catch
                                    {
                                        obj.CurrentThickness = 0;
                                    }
                                    try
                                    {
                                        obj.MinReqThickness = (float)reader.GetDouble(12);
                                    }
                                    catch
                                    {
                                        obj.MinReqThickness = 0;
                                    }
                                    try
                                    {
                                        obj.CurrentCorrosionRate = (float)reader.GetDouble(13);
                                    }
                                    catch
                                    {
                                        obj.CurrentCorrosionRate = 0;
                                    }
                                    obj.BranchDiameter = reader[23].ToString();
                                    obj.BranchJointType = reader[24].ToString();
                                    obj.BrinnelHardness = reader[20].ToString();
                                    try
                                    {
                                        obj.ChemicalInjection = Convert.ToInt32(reader.GetBoolean(17));
                                    }
                                    catch
                                    {
                                        obj.ChemicalInjection = 0;
                                    }
                                    try
                                    {
                                        obj.HighlyInjectionInsp = Convert.ToInt32(reader.GetBoolean(19));
                                    }
                                    catch
                                    {
                                        obj.HighlyInjectionInsp = 0;
                                    }
                                    obj.ComplexityProtrusion = reader[21].ToString();
                                    obj.CorrectiveAction = reader[31].ToString();
                                    try
                                    {
                                        obj.CracksPresent = Convert.ToInt32(reader.GetBoolean(16));
                                    }
                                    catch
                                    {
                                        obj.CracksPresent = 0;
                                    }
                                    obj.CyclicLoadingWitin15_25m = reader[22].ToString();
                                    try
                                    {
                                        obj.DamageFoundInspection = Convert.ToInt32(reader.GetBoolean(15));
                                    }
                                    catch
                                    {
                                        obj.DamageFoundInspection = 0;
                                    }
                                    try
                                    {
                                        obj.DeltaFATT = (float)reader.GetDouble(14);
                                    }
                                    catch
                                    {
                                        obj.DeltaFATT = 0;
                                    }
                                    obj.NumberPipeFittings = reader[25].ToString();
                                    obj.PipeCondition = reader[26].ToString();
                                    obj.PreviousFailures = reader[27].ToString();
                                    obj.ShakingAmount = reader[29].ToString();
                                    try
                                    {
                                        obj.ShakingDetected = Convert.ToInt32(reader.GetBoolean(28));
                                    }
                                    catch
                                    {
                                        obj.ShakingDetected = 0;
                                    }
                                    obj.ShakingTime = reader[30].ToString();
                                    try
                                    {
                                        obj.TrampElements = Convert.ToInt32(reader.GetBoolean(18));
                                    }
                                    catch
                                    {
                                        obj.TrampElements = 0;
                                    }
                                    list.Add(obj);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Format sheet Component error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        public List<RW_COMPONENT> getRwComponentTank()
        {
            RW_COMPONENT obj = null;
            List<RW_COMPONENT> list = new List<RW_COMPONENT>();
            List<RW_ASSESSMENT> list1 = busAssesment.getDataSource();
            OleDbConnection conn = getConnect();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM [Component$]";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!(reader.IsDBNull(0) || reader.IsDBNull(1)))
                        {
                            for (int i = 0; i < list1.Count; i++)
                            {
                                if (list1[i].ComponentID == busCompMaster.getIDbyName(reader[1].ToString()))
                                {
                                    obj = new RW_COMPONENT();
                                    obj.ID = list1[i].ID;
                                    try
                                    {
                                        obj.NominalDiameter = (float)reader.GetDouble(9);
                                    }
                                    catch
                                    {
                                        obj.NominalDiameter = 0;
                                    }
                                    try
                                    {
                                        obj.NominalThickness = (float)reader.GetDouble(10);
                                    }
                                    catch
                                    {
                                        obj.NominalThickness = 0;
                                    }
                                    try
                                    {
                                        obj.CurrentThickness = (float)reader.GetDouble(11);
                                    }
                                    catch
                                    {
                                        obj.CurrentThickness = 0;
                                    }
                                    try
                                    {
                                        obj.MinReqThickness = (float)reader.GetDouble(12);
                                    }
                                    catch
                                    {
                                        obj.MinReqThickness = 0;
                                    }
                                    try
                                    {
                                        obj.CurrentCorrosionRate = (float)reader.GetDouble(13);
                                    }
                                    catch
                                    {
                                        obj.CurrentCorrosionRate = 0;
                                    }
                                    obj.BrinnelHardness = reader[18].ToString();
                                    obj.ComplexityProtrusion = reader[19].ToString();
                                    obj.SeverityOfVibration = reader[20].ToString();
                                    try
                                    {
                                        obj.ReleasePreventionBarrier = Convert.ToInt32(reader.GetBoolean(21));
                                    }
                                    catch
                                    {
                                        obj.ReleasePreventionBarrier = 0;
                                    }
                                    try
                                    {
                                        obj.ConcreteFoundation = Convert.ToInt32(reader.GetBoolean(22));
                                    }
                                    catch
                                    {
                                        obj.ConcreteFoundation = 0;
                                    }
                                    try
                                    {
                                        obj.ShellHeight = (float)reader.GetDouble(23);
                                    }
                                    catch
                                    {
                                        obj.ShellHeight = 0;
                                    }
                                    try
                                    {
                                        obj.CracksPresent = Convert.ToInt32(reader.GetBoolean(16));
                                    }
                                    catch
                                    {
                                        obj.CracksPresent = 0;
                                    }

                                    try
                                    {
                                        obj.DamageFoundInspection = Convert.ToInt32(reader.GetBoolean(15));
                                    }
                                    catch
                                    {
                                        obj.DamageFoundInspection = 0;
                                    }
                                    try
                                    {
                                        obj.DeltaFATT = (float)reader.GetDouble(14);
                                    }
                                    catch
                                    {
                                        obj.DeltaFATT = 0;
                                    }
                                    try
                                    {
                                        obj.TrampElements = Convert.ToInt32(reader.GetBoolean(17));
                                    }
                                    catch
                                    {
                                        obj.TrampElements = 0;
                                    }
                                    list.Add(obj);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Format sheet Component error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }

        //3. RW_EXTCOR_TEMPERATURE
        public List<RW_EXTCOR_TEMPERATURE> getRwExtTemp()
        {
            RW_EXTCOR_TEMPERATURE obj = null;
            List<RW_EXTCOR_TEMPERATURE> list = new List<RW_EXTCOR_TEMPERATURE>();
            List<RW_ASSESSMENT> list1 = busAssesment.getDataSource();
            OleDbConnection conn = getConnect();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM [Operating Condition$]";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!reader.IsDBNull(0))
                        {
                            for (int i = 0; i < list1.Count; i++)
                            {
                                if (list1[i].ComponentID == busCompMaster.getIDbyName(reader[0].ToString()))
                                {
                                    obj = new RW_EXTCOR_TEMPERATURE();
                                    obj.ID = list1[i].ID;
                                    try
                                    {
                                        obj.Minus12ToMinus8 = (float)reader.GetDouble(8);
                                    }
                                    catch
                                    {
                                        obj.Minus12ToMinus8 = 0;
                                    }
                                    try
                                    {
                                        obj.Minus8ToPlus6 = (float)reader.GetDouble(9);
                                    }
                                    catch
                                    {
                                        obj.Minus8ToPlus6 = 0;
                                    }
                                    try
                                    {
                                        obj.Plus6ToPlus32 = (float)reader.GetDouble(10);
                                    }
                                    catch
                                    {
                                        obj.Plus6ToPlus32 = 0;
                                    }
                                    try
                                    {
                                        obj.Plus32ToPlus71 = (float)reader.GetDouble(11);
                                    }
                                    catch
                                    {
                                        obj.Plus32ToPlus71 = 0;
                                    }
                                    try
                                    {
                                        obj.Plus71ToPlus107 = (float)reader.GetDouble(12);
                                    }
                                    catch
                                    {
                                        obj.Plus71ToPlus107 = 0;
                                    }
                                    try
                                    {
                                        obj.Plus107ToPlus121 = (float)reader.GetDouble(13);
                                    }
                                    catch
                                    {
                                        obj.Plus107ToPlus121 = 0;
                                    }
                                    try
                                    {
                                        obj.Plus121ToPlus135 = (float)reader.GetDouble(14);
                                    }
                                    catch
                                    {
                                        obj.Plus121ToPlus135 = 0;
                                    }
                                    try
                                    {
                                        obj.Plus135ToPlus162 = (float)reader.GetDouble(15);
                                    }
                                    catch
                                    {
                                        obj.Plus135ToPlus162 = 0;
                                    }
                                    try
                                    {
                                        obj.Plus162ToPlus176 = (float)reader.GetDouble(16);
                                    }
                                    catch
                                    {
                                        obj.Plus162ToPlus176 = 0;
                                    }
                                    try
                                    {
                                        obj.MoreThanPlus176 = (float)reader.GetDouble(17);
                                    }
                                    catch
                                    {
                                        obj.MoreThanPlus176 = 0;
                                    }
                                    list.Add(obj);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Format sheet Operating Condition error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;

        }
        //4. RW_STEAM
        private List<RW_STREAM> getStream1()
        {
            RW_STREAM obj = null;
            List<RW_STREAM> list = new List<RW_STREAM>();
            List<RW_ASSESSMENT> list1 = busAssesment.getDataSource();
            OleDbConnection conn = getConnect();
            try
            {
                conn.Open();
                String sql1 = "SELECT * FROM [Operating Condition$]";
                OleDbCommand cmd = new OleDbCommand(sql1, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!reader.IsDBNull(0))
                        {
                            for (int i = 0; i < list1.Count; i++)
                            {
                                if (list1[i].ComponentID == busCompMaster.getIDbyName(reader[0].ToString()))
                                {
                                    obj = new RW_STREAM();
                                    obj.ID = list1[i].ID;
                                    try
                                    {
                                        obj.MaxOperatingTemperature = (float)reader.GetDouble(1);
                                    }
                                    catch
                                    {
                                        obj.MaxOperatingTemperature = 0;
                                    }
                                    try
                                    {
                                        obj.MinOperatingTemperature = (float)reader.GetDouble(2);
                                    }
                                    catch
                                    {
                                        obj.MinOperatingTemperature = 0;
                                    }
                                    try
                                    {
                                        obj.CriticalExposureTemperature = (float)reader.GetDouble(3);
                                    }
                                    catch
                                    {
                                        obj.CriticalExposureTemperature = 0;
                                    }
                                    try
                                    {
                                        obj.MaxOperatingPressure = (float)reader.GetDouble(4);
                                    }
                                    catch
                                    {
                                        obj.MaxOperatingPressure = 0;
                                    }
                                    try
                                    {
                                        obj.MinOperatingPressure = (float)reader.GetDouble(5);
                                    }
                                    catch
                                    {
                                        obj.MinOperatingPressure = 0;
                                    }
                                    try
                                    {
                                        obj.H2SPartialPressure = (float)reader.GetDouble(6);
                                    }
                                    catch
                                    {
                                        obj.H2SPartialPressure = 0;
                                    }
                                    try
                                    {
                                        obj.FlowRate = (float)reader.GetDouble(7);
                                    }
                                    catch
                                    {
                                        obj.FlowRate = 0;
                                    }
                                    list.Add(obj);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Format sheet Operating Condition error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        private List<RW_STREAM> getStream2()
        {
            RW_STREAM obj = null;
            List<RW_STREAM> list = new List<RW_STREAM>();
            List<RW_ASSESSMENT> list1 = busAssesment.getDataSource();
            OleDbConnection conn = getConnect();
            try
            {
                conn.Open();
                String sql1 = "SELECT * FROM [Stream$]";
                OleDbCommand cmd = new OleDbCommand(sql1, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!reader.IsDBNull(0))
                        {
                            for (int i = 0; i < list1.Count; i++)
                            {
                                if (list1[i].ComponentID == busCompMaster.getIDbyName(reader[0].ToString()))
                                {
                                    obj = new RW_STREAM();
                                    obj.ID = list1[i].ID;
                                    try
                                    {
                                        obj.NaOHConcentration = (float)reader.GetDouble(3);
                                    }
                                    catch
                                    {
                                        obj.NaOHConcentration = 0;
                                    }
                                    try
                                    {
                                        obj.ReleaseFluidPercentToxic = (float)reader.GetDouble(4);
                                    }
                                    catch
                                    {
                                        obj.ReleaseFluidPercentToxic = 0;
                                    }
                                    try
                                    {
                                        obj.Chloride = (float)reader.GetDouble(5);
                                    }
                                    catch
                                    {
                                        obj.Chloride = 0;
                                    }
                                    try
                                    {
                                        obj.CO3Concentration = (float)reader.GetDouble(6);
                                    }
                                    catch
                                    {
                                        obj.CO3Concentration = 0;
                                    }
                                    try
                                    {
                                        obj.H2SInWater = (float)reader.GetDouble(7);
                                    }
                                    catch
                                    {
                                        obj.H2SInWater = 0;
                                    }
                                    try
                                    {
                                        obj.WaterpH = (float)reader.GetDouble(8);
                                    }
                                    catch
                                    {
                                        obj.WaterpH = 0;
                                    }
                                    try
                                    {
                                        obj.ExposedToGasAmine = Convert.ToInt32(reader.GetBoolean(9));
                                    }
                                    catch
                                    {
                                        obj.ExposedToGasAmine = 0;
                                    }
                                    try
                                    {
                                        obj.ToxicConstituent = Convert.ToInt32(reader.GetBoolean(10));
                                    }
                                    catch
                                    {
                                        obj.ToxicConstituent = 0;
                                    }
                                    obj.ExposureToAmine = reader[11].ToString();
                                    obj.AmineSolution = reader[12].ToString();
                                    try
                                    {
                                        obj.AqueousOperation = Convert.ToInt32(reader.GetBoolean(13));
                                    }
                                    catch
                                    {
                                        obj.AqueousOperation = 0;
                                    }
                                    try
                                    {
                                        obj.AqueousShutdown = Convert.ToInt32(reader.GetBoolean(14));
                                    }
                                    catch
                                    {
                                        obj.AqueousShutdown = 0;
                                    }
                                    try
                                    {
                                        obj.H2S = Convert.ToInt32(reader.GetBoolean(15));
                                    }
                                    catch
                                    {
                                        obj.H2S = 0;
                                    }
                                    try
                                    {
                                        obj.Hydrofluoric = Convert.ToInt32(reader.GetBoolean(16));
                                    }
                                    catch
                                    {
                                        obj.Hydrofluoric = 0;
                                    }
                                    try
                                    {
                                        obj.Cyanide = Convert.ToInt32(reader.GetBoolean(17));
                                    }
                                    catch
                                    {
                                        obj.Cyanide = 0;
                                    }
                                    try
                                    {
                                        obj.Hydrogen = Convert.ToInt32(reader.GetBoolean(18));
                                    }
                                    catch
                                    {
                                        obj.Hydrogen = 0;
                                    }
                                    try
                                    {
                                        obj.Caustic = Convert.ToInt32(reader.GetBoolean(19));
                                    }
                                    catch
                                    {
                                        obj.Caustic = 0;
                                    }
                                    try
                                    {
                                        obj.ExposedToSulphur = Convert.ToInt32(reader.GetBoolean(20));
                                    }
                                    catch
                                    {
                                        obj.ExposedToSulphur = 0;
                                    }
                                    try
                                    {
                                        obj.MaterialExposedToClInt = Convert.ToInt32(reader.GetBoolean(21));
                                    }
                                    catch
                                    {
                                        obj.MaterialExposedToClInt = 0;
                                    }
                                    list.Add(obj);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Format sheet Stream error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        private List<RW_STREAM> getStream2Tank()
        {
            RW_STREAM obj = null;
            List<RW_STREAM> list = new List<RW_STREAM>();
            List<RW_ASSESSMENT> list1 = busAssesment.getDataSource();
            OleDbConnection conn = getConnect();
            try
            {
                conn.Open();
                String sql1 = "SELECT * FROM [Stream$]";
                OleDbCommand cmd = new OleDbCommand(sql1, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!reader.IsDBNull(0))
                        {
                            for (int i = 0; i < list1.Count; i++)
                            {
                                if (list1[i].ComponentID == busCompMaster.getIDbyName(reader[0].ToString()))
                                {
                                    obj = new RW_STREAM();
                                    obj.ID = list1[i].ID;
                                    try
                                    {
                                        obj.NaOHConcentration = (float)reader.GetDouble(1);
                                    }
                                    catch
                                    {
                                        obj.NaOHConcentration = 0;
                                    }
                                    try
                                    {
                                        obj.ReleaseFluidPercentToxic = (float)reader.GetDouble(2);
                                    }
                                    catch
                                    {
                                        obj.ReleaseFluidPercentToxic = 0;
                                    }
                                    try
                                    {
                                        obj.Chloride = (float)reader.GetDouble(3);
                                    }
                                    catch
                                    {
                                        obj.Chloride = 0;
                                    }
                                    try
                                    {
                                        obj.CO3Concentration = (float)reader.GetDouble(4);
                                    }
                                    catch
                                    {
                                        obj.CO3Concentration = 0;
                                    }
                                    try
                                    {
                                        obj.H2SInWater = (float)reader.GetDouble(5);
                                    }
                                    catch
                                    {
                                        obj.H2SInWater = 0;
                                    }
                                    try
                                    {
                                        obj.WaterpH = (float)reader.GetDouble(6);
                                    }
                                    catch
                                    {
                                        obj.WaterpH = 0;
                                    }
                                    try
                                    {
                                        obj.ExposedToGasAmine = Convert.ToInt32(reader.GetBoolean(7));
                                    }
                                    catch
                                    {
                                        obj.ExposedToGasAmine = 0;
                                    }
                                    try
                                    {
                                        obj.ToxicConstituent = Convert.ToInt32(reader.GetBoolean(8));
                                    }
                                    catch
                                    {
                                        obj.ToxicConstituent = 0;
                                    }
                                    obj.ExposureToAmine = reader[9].ToString();
                                    obj.AmineSolution = reader[10].ToString();
                                    try
                                    {
                                        obj.AqueousOperation = Convert.ToInt32(reader.GetBoolean(11));
                                    }
                                    catch
                                    {
                                        obj.AqueousOperation = 0;
                                    }
                                    try
                                    {
                                        obj.AqueousShutdown = Convert.ToInt32(reader.GetBoolean(12));
                                    }
                                    catch
                                    {
                                        obj.AqueousShutdown = 0;
                                    }
                                    try
                                    {
                                        obj.H2S = Convert.ToInt32(reader.GetBoolean(13));
                                    }
                                    catch
                                    {
                                        obj.H2S = 0;
                                    }
                                    try
                                    {
                                        obj.Hydrofluoric = Convert.ToInt32(reader.GetBoolean(14));
                                    }
                                    catch
                                    {
                                        obj.Hydrofluoric = 0;
                                    }
                                    try
                                    {
                                        obj.Cyanide = Convert.ToInt32(reader.GetBoolean(15));
                                    }
                                    catch
                                    {
                                        obj.Cyanide = 0;
                                    }
                                    try
                                    {
                                        obj.Hydrogen = Convert.ToInt32(reader.GetBoolean(16));
                                    }
                                    catch
                                    {
                                        obj.Hydrogen = 0;
                                    }
                                    try
                                    {
                                        obj.Caustic = Convert.ToInt32(reader.GetBoolean(17));
                                    }
                                    catch
                                    {
                                        obj.Caustic = 0;
                                    }
                                    try
                                    {
                                        obj.ExposedToSulphur = Convert.ToInt32(reader.GetBoolean(18));
                                    }
                                    catch
                                    {
                                        obj.ExposedToSulphur = 0;
                                    }
                                    try
                                    {
                                        obj.MaterialExposedToClInt = Convert.ToInt32(reader.GetBoolean(19));
                                    }
                                    catch
                                    {
                                        obj.MaterialExposedToClInt = 0;
                                    }
                                    obj.TankFluidName = reader[20].ToString();
                                    try
                                    {
                                        obj.FluidHeight = (float)reader.GetDouble(21);
                                    }
                                    catch
                                    {
                                        obj.FluidHeight = 0;
                                    }
                                    try
                                    {
                                        obj.FluidLeaveDikePercent = (float)reader.GetDouble(22);
                                    }
                                    catch
                                    {
                                        obj.FluidLeaveDikePercent = 0;
                                    }
                                    try
                                    {
                                        obj.FluidLeaveDikeRemainOnSitePercent = (float)reader.GetDouble(23);
                                    }
                                    catch
                                    {
                                        obj.FluidLeaveDikeRemainOnSitePercent = 0;
                                    }
                                    try
                                    {
                                        obj.FluidGoOffSitePercent = (float)reader.GetDouble(24);
                                    }
                                    catch
                                    {
                                        obj.FluidGoOffSitePercent = 0;
                                    }
                                    list.Add(obj);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Format sheet Operating Condition error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        public List<RW_STREAM> getRwStream()
        {
            List<RW_STREAM> list1 = getStream1();
            List<RW_STREAM> list2 = getStream2();
            List<RW_STREAM> list = new List<RW_STREAM>();
            RW_STREAM obj = null;
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].ID == list2[i].ID)
                {
                    obj = new RW_STREAM();
                    obj.ID = list2[i].ID;
                    obj.MaxOperatingTemperature = list1[i].MaxOperatingTemperature;
                    obj.MinOperatingTemperature = list1[i].MinOperatingTemperature;
                    obj.CriticalExposureTemperature = list1[i].CriticalExposureTemperature;
                    obj.MaxOperatingPressure = list1[i].MaxOperatingPressure;
                    obj.MinOperatingPressure = list1[i].MinOperatingPressure;
                    obj.H2SPartialPressure = list1[i].H2SPartialPressure;
                    obj.FlowRate = list1[i].FlowRate;
                    obj.NaOHConcentration = list2[i].NaOHConcentration;
                    obj.ReleaseFluidPercentToxic = list2[i].ReleaseFluidPercentToxic;
                    obj.Chloride = list2[i].Chloride;
                    obj.CO3Concentration = list2[i].CO3Concentration;
                    obj.H2SInWater = list2[i].H2SInWater;
                    obj.WaterpH = list2[i].WaterpH;
                    obj.ExposedToGasAmine = list2[i].ExposedToGasAmine;
                    obj.ToxicConstituent = list2[i].ToxicConstituent;
                    obj.ExposureToAmine = list2[i].ExposureToAmine;
                    obj.AmineSolution = list2[i].AmineSolution;
                    obj.AqueousOperation = list2[i].AqueousOperation;
                    obj.AqueousShutdown = list2[i].AqueousShutdown;
                    obj.H2S = list2[i].H2S;
                    obj.Hydrofluoric = list2[i].Hydrofluoric;
                    obj.Cyanide = list2[i].Cyanide;
                    obj.Hydrogen = list2[i].Hydrogen;
                    obj.Caustic = list2[i].Caustic;
                    obj.ExposedToSulphur = list2[i].ExposedToSulphur;
                    obj.MaterialExposedToClInt = list2[i].MaterialExposedToClInt;
                    list.Add(obj);
                }
            }
            return list;
        }
        public List<RW_STREAM> getRwStreamTank()
        {
            List<RW_STREAM> list1 = getStream1();
            List<RW_STREAM> list2 = getStream2Tank();
            List<RW_STREAM> list = new List<RW_STREAM>();
            RW_STREAM obj = null;
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].ID == list2[i].ID)
                {
                    obj = new RW_STREAM();
                    obj.ID = list2[i].ID;
                    obj.MaxOperatingTemperature = list1[i].MaxOperatingTemperature;
                    obj.MinOperatingTemperature = list1[i].MinOperatingTemperature;
                    obj.CriticalExposureTemperature = list1[i].CriticalExposureTemperature;
                    obj.MaxOperatingPressure = list1[i].MaxOperatingPressure;
                    obj.MinOperatingPressure = list1[i].MinOperatingPressure;
                    obj.H2SPartialPressure = list1[i].H2SPartialPressure;
                    obj.FlowRate = list1[i].FlowRate;
                    obj.NaOHConcentration = list2[i].NaOHConcentration;
                    obj.ReleaseFluidPercentToxic = list2[i].ReleaseFluidPercentToxic;
                    obj.Chloride = list2[i].Chloride;
                    obj.CO3Concentration = list2[i].CO3Concentration;
                    obj.H2SInWater = list2[i].H2SInWater;
                    obj.WaterpH = list2[i].WaterpH;
                    obj.ExposedToGasAmine = list2[i].ExposedToGasAmine;
                    obj.ToxicConstituent = list2[i].ToxicConstituent;
                    obj.ExposureToAmine = list2[i].ExposureToAmine;
                    obj.AmineSolution = list2[i].AmineSolution;
                    obj.AqueousOperation = list2[i].AqueousOperation;
                    obj.AqueousShutdown = list2[i].AqueousShutdown;
                    obj.H2S = list2[i].H2S;
                    obj.Hydrofluoric = list2[i].Hydrofluoric;
                    obj.Cyanide = list2[i].Cyanide;
                    obj.Hydrogen = list2[i].Hydrogen;
                    obj.Caustic = list2[i].Caustic;
                    obj.ExposedToSulphur = list2[i].ExposedToSulphur;
                    obj.MaterialExposedToClInt = list2[i].MaterialExposedToClInt;
                    obj.TankFluidName = list2[i].TankFluidName;
                    obj.FluidHeight = list2[i].FluidHeight;
                    obj.FluidLeaveDikePercent = list2[i].FluidLeaveDikePercent;
                    obj.FluidLeaveDikeRemainOnSitePercent = list2[i].FluidLeaveDikeRemainOnSitePercent;
                    obj.FluidGoOffSitePercent = list2[i].FluidGoOffSitePercent;
                    list.Add(obj);
                }
            }
            return list;
        }
        //5. RW_MATERIAL
        public List<RW_MATERIAL> getRwMaterial()
        {
            RW_MATERIAL obj = null;
            List<RW_MATERIAL> list = new List<RW_MATERIAL>();
            List<RW_ASSESSMENT> list1 = busAssesment.getDataSource();
            OleDbConnection conn = getConnect();
            try
            {
                conn.Open();
                String sql1 = "SELECT * FROM [Material$]";
                OleDbCommand cmd = new OleDbCommand(sql1, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!reader.IsDBNull(0))
                        {
                            for (int i = 0; i < list1.Count; i++)
                            {
                                if (list1[i].ComponentID == busCompMaster.getIDbyName(reader[0].ToString()))
                                {
                                    obj = new RW_MATERIAL();
                                    obj.ID = list1[i].ID;
                                    obj.MaterialName = reader[1].ToString();
                                    try
                                    {
                                        obj.DesignPressure = (float)reader.GetDouble(2);
                                    }
                                    catch
                                    {
                                        obj.DesignPressure = 0;
                                    }
                                    try
                                    {
                                        obj.DesignTemperature = (float)reader.GetDouble(3);
                                    }
                                    catch
                                    {
                                        obj.DesignTemperature = 0;
                                    }
                                    try
                                    {
                                        obj.MinDesignTemperature = (float)reader.GetDouble(4);
                                    }
                                    catch
                                    {
                                        obj.MinDesignTemperature = 0;
                                    }
                                    try
                                    {
                                        obj.ReferenceTemperature = (float)reader.GetDouble(5);
                                    }
                                    catch
                                    {
                                        obj.ReferenceTemperature = 0;
                                    }
                                    try
                                    {
                                        obj.BrittleFractureThickness = (float)reader.GetDouble(6);
                                    }
                                    catch
                                    {
                                        obj.BrittleFractureThickness = 0;
                                    }
                                    try
                                    {
                                        obj.AllowableStress = (float)reader.GetDouble(7);
                                    }
                                    catch
                                    {
                                        obj.AllowableStress = 0;
                                    }
                                    try
                                    {
                                        obj.CorrosionAllowance = (float)reader.GetDouble(8);
                                    }
                                    catch
                                    {
                                        obj.CorrosionAllowance = 0;
                                    }
                                    try
                                    {
                                        obj.SigmaPhase = (float)reader.GetDouble(9);
                                    }
                                    catch
                                    {
                                        obj.SigmaPhase = 0;
                                    }
                                    try
                                    {
                                        obj.CarbonLowAlloy = Convert.ToInt32(reader.GetBoolean(10));
                                    }
                                    catch
                                    {
                                        obj.CarbonLowAlloy = 0;
                                    }
                                    try
                                    {
                                        obj.Austenitic = Convert.ToInt32(reader.GetBoolean(11));
                                    }
                                    catch
                                    {
                                        obj.Austenitic = 0;
                                    }
                                    try
                                    {
                                        obj.Temper = Convert.ToInt32(reader.GetBoolean(12));
                                    }
                                    catch
                                    {
                                        obj.Temper = 0;
                                    }
                                    try
                                    {
                                        obj.NickelBased = Convert.ToInt32(reader.GetBoolean(13));
                                    }
                                    catch
                                    {
                                        obj.NickelBased = 0;
                                    }
                                    try
                                    {
                                        obj.ChromeMoreEqual12 = Convert.ToInt32(reader.GetBoolean(14));
                                    }
                                    catch
                                    {
                                        obj.ChromeMoreEqual12 = 0;
                                    }
                                    obj.SulfurContent = reader[15].ToString();
                                    obj.HeatTreatment = reader[16].ToString();
                                    try
                                    {
                                        obj.IsHTHA = Convert.ToInt32(reader.GetBoolean(17));
                                    }
                                    catch
                                    {
                                        obj.IsHTHA = 0;
                                    }
                                    obj.HTHAMaterialCode = reader[18].ToString();
                                    try
                                    {
                                        obj.IsPTA = Convert.ToInt32(reader.GetBoolean(19));
                                    }
                                    catch
                                    {
                                        obj.IsPTA = 0;
                                    }
                                    obj.PTAMaterialCode = reader[20].ToString();
                                    try
                                    {
                                        double a = reader.GetDouble(21);
                                        obj.CostFactor = (float)a;
                                    }
                                    catch
                                    {
                                        obj.CostFactor = 0;
                                    }
                                    list.Add(obj);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Format sheet Material error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        public List<RW_MATERIAL> getRwMaterialTank()
        {
            RW_MATERIAL obj = null;
            List<RW_MATERIAL> list = new List<RW_MATERIAL>();
            List<RW_ASSESSMENT> list1 = busAssesment.getDataSource();
            OleDbConnection conn = getConnect();
            try
            {
                conn.Open();
                String sql1 = "SELECT * FROM [Material$]";
                OleDbCommand cmd = new OleDbCommand(sql1, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!reader.IsDBNull(0))
                        {
                            for (int i = 0; i < list1.Count; i++)
                            {
                                if (list1[i].ComponentID == busCompMaster.getIDbyName(reader[0].ToString()))
                                {
                                    obj = new RW_MATERIAL();
                                    obj.ID = list1[i].ID;
                                    obj.MaterialName = reader[1].ToString();
                                    try
                                    {
                                        obj.DesignPressure = (float)reader.GetDouble(2);
                                    }
                                    catch
                                    {
                                        obj.DesignPressure = 0;
                                    }
                                    try
                                    {
                                        obj.DesignTemperature = (float)reader.GetDouble(3);
                                    }
                                    catch
                                    {
                                        obj.DesignTemperature = 0;
                                    }
                                    try
                                    {
                                        obj.MinDesignTemperature = (float)reader.GetDouble(4);
                                    }
                                    catch
                                    {
                                        obj.MinDesignTemperature = 0;
                                    }
                                    try
                                    {
                                        obj.ReferenceTemperature = (float)reader.GetDouble(5);
                                    }
                                    catch
                                    {
                                        obj.ReferenceTemperature = 0;
                                    }
                                    try
                                    {
                                        obj.BrittleFractureThickness = (float)reader.GetDouble(6);
                                    }
                                    catch
                                    {
                                        obj.BrittleFractureThickness = 0;
                                    }
                                    try
                                    {
                                        obj.AllowableStress = (float)reader.GetDouble(7);
                                    }
                                    catch
                                    {
                                        obj.AllowableStress = 0;
                                    }
                                    try
                                    {
                                        obj.CorrosionAllowance = (float)reader.GetDouble(8);
                                    }
                                    catch
                                    {
                                        obj.CorrosionAllowance = 0;
                                    }
                                    try
                                    {
                                        obj.CarbonLowAlloy = Convert.ToInt32(reader.GetBoolean(9));
                                    }
                                    catch
                                    {
                                        obj.CarbonLowAlloy = 0;
                                    }
                                    try
                                    {
                                        obj.Austenitic = Convert.ToInt32(reader.GetBoolean(10));
                                    }
                                    catch
                                    {
                                        obj.Austenitic = 0;
                                    }
                                    try
                                    {
                                        obj.NickelBased = Convert.ToInt32(reader.GetBoolean(11));
                                    }
                                    catch
                                    {
                                        obj.NickelBased = 0;
                                    }
                                    try
                                    {
                                        obj.ChromeMoreEqual12 = Convert.ToInt32(reader.GetBoolean(12));
                                    }
                                    catch
                                    {
                                        obj.ChromeMoreEqual12 = 0;
                                    }
                                    obj.SulfurContent = reader[13].ToString();
                                    obj.HeatTreatment = reader[14].ToString();
                                    try
                                    {
                                        obj.IsPTA = Convert.ToInt32(reader.GetBoolean(15));
                                    }
                                    catch
                                    {
                                        obj.IsPTA = 0;
                                    }
                                    obj.PTAMaterialCode = reader[16].ToString();
                                    try
                                    {
                                        obj.CostFactor = (float)reader.GetDouble(17);
                                    }
                                    catch
                                    {
                                        obj.CostFactor = 0;
                                    }
                                    list.Add(obj);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Format sheet Material error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        //6. RW_COATING
        public List<RW_COATING> getRwCoating()
        {
            RW_COATING obj = null;
            List<RW_COATING> list = new List<RW_COATING>();
            List<RW_ASSESSMENT> list1 = busAssesment.getDataSource();
            OleDbConnection conn = getConnect();
            try
            {
                conn.Open();
                String sql1 = "SELECT * FROM [CoatingCladdingLiningInsulation$]";
                OleDbCommand cmd = new OleDbCommand(sql1, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!reader.IsDBNull(0))
                        {
                            for (int i = 0; i < list1.Count; i++)
                            {
                                if (list1[i].ComponentID == busCompMaster.getIDbyName(reader[0].ToString()))
                                {
                                    obj = new RW_COATING();
                                    obj.ID = list1[i].ID;
                                    try
                                    {
                                        obj.InternalCoating = Convert.ToInt32(reader.GetBoolean(1));
                                    }
                                    catch
                                    {
                                        obj.InternalCoating = 0;
                                    }
                                    try
                                    {
                                        obj.ExternalCoating = Convert.ToInt32(reader.GetBoolean(2));
                                    }
                                    catch
                                    {
                                        obj.ExternalCoating = 0;
                                    }
                                    try
                                    {
                                        obj.ExternalCoatingDate = Convert.ToDateTime(reader[3].ToString());
                                    }
                                    catch
                                    {
                                        obj.ExternalCoatingDate = busEquipMaster.getComissionDate(list1[i].EquipmentID);
                                    }
                                    obj.ExternalCoatingQuality = reader[4].ToString();
                                    try
                                    {
                                        obj.SupportConfigNotAllowCoatingMaint = Convert.ToInt32(reader.GetBoolean(5));
                                    }
                                    catch
                                    {
                                        obj.SupportConfigNotAllowCoatingMaint = 0;
                                    }
                                    try
                                    {
                                        obj.InternalCladding = Convert.ToInt32(reader.GetBoolean(6));
                                    }
                                    catch
                                    {
                                        obj.InternalCladding = 0;
                                    }
                                    try
                                    {
                                        obj.CladdingCorrosionRate = (float)reader.GetDouble(7);
                                    }
                                    catch
                                    {
                                        obj.CladdingCorrosionRate = 0;
                                    }
                                    try
                                    {
                                        obj.InternalLining = Convert.ToInt32(reader.GetBoolean(8));
                                    }
                                    catch
                                    {
                                        obj.InternalLining = 0;
                                    }
                                    obj.InternalLinerType = reader[9].ToString();
                                    obj.InternalLinerCondition = reader[10].ToString();
                                    try
                                    {
                                        obj.ExternalInsulation = Convert.ToInt32(reader.GetBoolean(11));
                                    }
                                    catch
                                    {
                                        obj.ExternalInsulation = 0;
                                    }
                                    try
                                    {
                                        obj.InsulationContainsChloride = Convert.ToInt32(reader.GetBoolean(12));
                                    }
                                    catch
                                    {
                                        obj.InsulationContainsChloride = 0;
                                    }
                                    obj.ExternalInsulationType = reader[13].ToString();
                                    obj.InsulationCondition = reader[14].ToString();
                                    list.Add(obj);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Format sheet CoatingCladdingLiningInsulation error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }

        //7. RW_INPUT_CA_TANK
        public String getAPItankFluid(String fluid)
        {
            string data;
            if (fluid == "Gasoline")
                data = "C6-C8";
            else if (fluid == "Light Diesel Oil")
                data = "C9-C12";
            else if (fluid == "Heavy Diesel Oil")
                data = "C13-C16";
            else if (fluid == "Fuel Oil" || fluid == "Crude Oil")
                data = "C17-C25";
            else
                data = "C25+";
            return data;
        }
        public List<RW_INPUT_CA_TANK> getRwInputCaTank()
        {
            List<RW_STREAM> listSteam = getRwStreamTank();
            List<RW_INPUT_CA_TANK> list = new List<RW_INPUT_CA_TANK>();
            List<RW_COMPONENT> listComp = getRwComponentTank();
            List<RW_EQUIPMENT> listEq = getRwEquipment();
            List<environSensitivity> listEnv = getenviron();
            for (int i = 0; i < listComp.Count; i++)
            {
                RW_INPUT_CA_TANK obj = new RW_INPUT_CA_TANK();
                obj.ID = listComp[i].ID;
                obj.FLUID_HEIGHT = listSteam[i].FluidHeight;
                obj.SHELL_COURSE_HEIGHT = listComp[i].ShellHeight;
                obj.TANK_DIAMETTER = listComp[i].NominalDiameter;
                obj.Prevention_Barrier = listComp[i].ReleasePreventionBarrier;
                obj.Environ_Sensitivity = listEnv[i].environ;
                obj.P_lvdike = listSteam[i].FluidLeaveDikePercent;
                obj.P_onsite = listSteam[i].FluidLeaveDikeRemainOnSitePercent;
                obj.P_offsite = listSteam[i].FluidGoOffSitePercent;
                obj.Soil_Type = listEq[i].TypeOfSoil;
                obj.TANK_FLUID = listSteam[i].TankFluidName;
                obj.API_FLUID = getAPItankFluid(listSteam[i].TankFluidName);
                obj.SW = listEq[i].DistanceToGroundWater;
                list.Add(obj);
            }
            return list;
        }
    }
}
