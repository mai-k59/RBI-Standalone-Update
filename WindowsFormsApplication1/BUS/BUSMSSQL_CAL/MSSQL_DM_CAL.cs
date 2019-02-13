using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.DAL.MSSQL;
using System.Diagnostics;
using RBI.DAL.MSSQL_CAL;
namespace RBI.BUS.BUSMSSQL_CAL
{
    class MSSQL_DM_CAL
    {
        MSSQL_RBI_CAL_ConnUtils DAL_CAL = new MSSQL_RBI_CAL_ConnUtils();
        public String APIComponentType { set; get; }
        //<Thinning>
        public float Diametter { set; get; }
        public float NomalThick { set; get; }
        public float CurrentThick { set; get; }
        public float MinThickReq { set; get; }
        public float CorrosionRate { set; get; }
        public float CA { set; get; }
        public Boolean ProtectedBarrier { set; get; }// tank only
        public float CladdingCorrosionRate { set; get; }
        public Boolean InternalCladding { set; get; }
        public int NoINSP_THINNING { set; get; }
        public String EFF_THIN { set; get; }
        public String OnlineMonitoring { set; get; }
        public Boolean HighlyEffectDeadleg { set; get; }
        public Boolean ContainsDeadlegs { set; get; }
        public Boolean TankMaintain653 { set; get; }
        public String AdjustmentSettle { set; get; }
        public Boolean ComponentIsWeld { set; get; }
        //</Thinning>
        
        //<Lining>
        public String LinningType { set; get; }
        public Boolean LINNER_ONLINE { set; get; }
        public String LINNER_CONDITION { set; get; }
        public int YEAR_IN_SERVICE { set; get; }
        public bool INTERNAL_LINNING { set; get; }
        //</Lining>

        //<SCC CAUSTIC>
        // 1. material is cacbon or allow stell
        // 2. Enviroment contain caustic
        public String CAUSTIC_INSP_EFF { set; get; }// effect caustic
        public int CAUSTIC_INSP_NUM { set; get; }
        public String HEAT_TREATMENT { set; get; }
        public float NaOHConcentration { set; get; }
        public bool HEAT_TRACE { set; get; }
        public bool STEAM_OUT { set; get; }
        //</SCC CAUSTIC>

        //<SCC Amine>
        // 1. material is cacbon or allow stell
        public string AMINE_INSP_EFF { set; get; }
        public int AMINE_INSP_NUM { set; get; }
        public bool AMINE_EXPOSED { set; get; }
        public String AMINE_SOLUTION { set; get; }
        //</SCC Amine>

        //<Sulphide Stress Cracking>
        // 1. material is carbon or allow stell
        // 2.  the process environment contains water
        // 3. Environment Content H2S
        public Boolean ENVIRONMENT_H2S_CONTENT { set; get; }
        public Boolean AQUEOUS_OPERATOR { set; get; }
        public Boolean AQUEOUS_SHUTDOWN { set; get; }
        public string SULPHIDE_INSP_EFF { set; get; }
        public int SULPHIDE_INSP_NUM { set; get; }
        public float H2SContent { set; get; }
        public float PH { set; get; }
        public bool PRESENT_CYANIDE { set; get; }
        public String BRINNEL_HARDNESS { set; get; }
        //</Sulphide Stress Cracking>

        //<HIC/SOHIC H2S>
        // dieu kien giong voi sulphide
        public String SULFUR_INSP_EFF { set; get; }
        public int SULFUR_INSP_NUM { set; get; }
        public String SULFUR_CONTENT { set; get; }
        //</HIC/SOHIC H2S>

        //<Carboonate Cracking>
        // 1. material is carbon or allow stell
        // 2.the process environment contains water
        // 3. PH > 7.5
        public String CACBONATE_INSP_EFF { set; get; }
        public int CACBONATE_INSP_NUM { set; get; }
        public float CO3_CONCENTRATION { set; get; }
        //</Carboonate Cracking>

        //<PTA Cracking>
        // 1. material is an austenitic stainless steel or nickel based alloys
        // 2. component is exposed to sulfur bearing compounds
        public Boolean PTA_SUSCEP { set; get; }
        public Boolean NICKEL_ALLOY { set; get; }
        public Boolean EXPOSED_SULFUR { set; get; }
        public String PTA_INSP_EFF { set; get; }
        public int PTA_INSP_NUM { set; get; }
        public bool ExposedSH2OOperation { set; get; }//Presence of Sulphides, Moisture and Oxygen During Shutdown
        public bool ExposedSH2OShutdown { set; get; }
        public string ThermalHistory { set; get; }
        public string PTAMaterial { set; get; }
        public bool DOWNTIME_PROTECTED { set; get; }
        //</PTA Cracking>

        //<CLSCC>
        // 1. The component’s material of construction is an austenitic stainless steel
        // 2. The component is exposed or potentially exposed to chlorides and water also considering upsets and
        //    hydrotest water remaining in component, and cooling tower drift(consider both under insulation and
        //    process conditions, and
        // 3. The operating temperature is above 38°C
        public Boolean INTERNAL_EXPOSED_FLUID_MIST { set; get; }
        public Boolean EXTERNAL_EXPOSED_FLUID_MIST { set; get; }
        public float CHLORIDE_ION_CONTENT { set; get; }
        public String CLSCC_INSP_EFF { set; get; }
        public int CLSCC_INSP_NUM { set; get; }
        //</CLSCC>

        //<HSC-HF>
        // 1. is carbon or low alloy steel 
        // 2. component is exposed to
        //    hydrofluoric acid
        public String HSC_HF_INSP_EFF { set; get; }
        public int HSC_HF_INSP_NUM { set; get; }
        //</HSC-HF>

        //<HICSOHIC_HF>
        // 1.giong HSC_HF
        public String HICSOHIC_INSP_EFF { set; get; }
        public int HICSOHIC_INSP_NUM { set; get; }
        public Boolean HF_PRESENT { set; get; }
        //<HICSOHIC_HF>

        //<EXTERNAL CORROSION>
        public int EXTERNAL_INSP_NUM { set; get; }
        public String EXTERNAL_INSP_EFF { set; get; }
        //</EXTERNAL CORROSION>

        //<CUI DM>
        public Boolean INTERFACE_SOIL_WATER { set; get; }
        public Boolean SUPPORT_COATING { set; get; }// Support Configuration Which Does Not Allow Coating Maintenance
        public String INSULATION_TYPE { set; get; }
        public int CUI_INSP_NUM { set; get; }
        public String CUI_INSP_EFF { set; get; }
        public DateTime CUI_INSP_DATE { set; get; }
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
        //</CUI DM>

        //<EXTERNAL CLSCC>
        /// INPUT EXTERNAL CLSCC
        // 1. Material is austenitic stainless steel
        // 2. The component external surface is exposed to chloride containing fluids, mists, or solids
        // 3. OP TEMP 49-149*C
        public int EXTERN_CLSCC_INSP_NUM { set; get; }
        public String EXTERN_CLSCC_INSP_EFF { set; get; }
        //</EXTERNAL CLSCC>

        //<EXTERN CUI CLSCC>
        // 1. Material is austenitic stainless steel
        // 2. component is insulated( EXTERNAL ISULATION)
        // 3. The component’s external surface is exposed to chloride containing fluids, mists, or solids, and
        // 4. OP TEMP 50-150*C
        public Boolean EXTERNAL_INSULATION { set; get; }
        public DateTime COMPONENT_INSTALL_DATE { set; get; }
        public Boolean CRACK_PRESENT { set; get; }
        public String EXTERNAL_EVIRONMENT { set; get; }// DRIVER
        public String EXTERN_COAT_QUALITY { set; get; }
        public int EXTERN_CLSCC_CUI_INSP_NUM { set; get; }
        public String EXTERN_CLSCC_CUI_INSP_EFF { set; get; }
        public String PIPING_COMPLEXITY { set; get; }// Complexity of Protrusions
        public String INSULATION_CONDITION { set; get; }// coating
        public Boolean INSULATION_CHLORIDE { set; get; }// Chloride
        //</EXTERN CUI CLSCC>

        //<HTHA>
        // 1.The material is carbon steel, C-0.5Mo, or a Cr-Mo low alloy steel
        // 2.OP_TEMP > 204*C, PH2 > 0.552MPa( 80 Pisa)
        public Boolean MATERIAL_SUSCEP_HTHA { set; get; }
        public String HTHA_MATERIAL { set; get; }
        public int HTHA_NUM_INSP { set; get; }
        public String HTHA_EFFECT { set; get; }
        public float HTHA_PRESSURE { set; get; }
        public float CRITICAL_TEMP { set; get; }
        public Boolean DAMAGE_FOUND { set; get; }
        //</HTHA>

        //<BRITTLE>
        // 1. Carbon or Low Alloy steel
        // 2. The Minimum Design Metal Temperature (MDMT) is unknown, or the MDMT is known but the component may
        //    operate at below the MDMT under normal or upset conditions
        public Boolean LOWEST_TEMP { set; get; }
        //</BRITTLE>

        //<TEMPER EMBRITTLE>
        // TEMPER EMBRITTLE chi duoc danh gia khi thoa man:
        // 1.The material is 1.25Cr -0.5Mo, 2.25Cr -0.5Mo, or 3Cr-1 Mo low alloy steel
        // 2.Op temp 343-577*C
        public Boolean TEMPER_SUSCEP { set; get; }
        public Boolean PWHT { set; get; }
        public float BRITTLE_THICK { set; get; }
        public Boolean CARBON_ALLOY { set; get; }
        public float DELTA_FATT { set; get; }
        //</TEMPER EMBRITTLE>
        
        //<885>
        //  885 chi danh gia khi thoa man hai dieu kien
        //  1. Chromium ≥ 12%
        //  2. nhiet do hoat dong trong khoang 371-566*C
        public float MAX_OP_TEMP { set; get; }
        public Boolean CHROMIUM_12 { set; get; } // Chromium ≥ 12%
        public float MIN_OP_TEMP { set; get; }
        public float MIN_DESIGN_TEMP { set; get; }
        public float REF_TEMP { set; get; }
        //</885>

        //<SIGMA>
        // SIGMA chi co khi thoa man hai dieu kien:
        // 1. material an austenitic stainless steel.
        // 2. nhiet do hoat dong 593-927*C
        public Boolean AUSTENITIC_STEEL { set; get; }
        public float PERCENT_SIGMA { set; get; }
        //</SIGMA>

        //<PIPING MECHANICAL>
        // PIPING chi duoc danh gia khi thoa man 2 dieu kien:
        // 1. Component is PIPE( Equipment is pipe)
        // 2. There have been past fatigue failures in this piping system or there is visible/audible shaking in this piping
        //     system or there is a source of cyclic vibration within approximately 15.24 meters[50 feet] and connected to the
        //    piping(directly or indirectly via structure). Shaking and source of shaking can be continuous or intermittent.
        //    Transient conditions often cause intermittent vibration
        public String EquipmentType { set; get; }
        public String PREVIOUS_FAIL { set; get; }
        public String AMOUNT_SHAKING { set; get; }
        public String TIME_SHAKING { set; get; }
        public String CYLIC_LOAD { set; get; }
        public String CORRECT_ACTION { set; get; }
        public String NUM_PIPE { set; get; }
        public String PIPE_CONDITION { set; get; }
        public String JOINT_TYPE { set; get; }
        public String BRANCH_DIAMETER { set; get; }
        //</PIPING MECHANICAL>

        /// <summary>
        ///  CAL THINNING
        /// </summary>
        /// <returns></returns>
        public String PoFCategory(float Df_Total) //table 4.1 page 1-19
        {
            if (Df_Total <= 2)
                return "1";
            else if (Df_Total <= 20)
                return "2";
            else if (Df_Total <= 100)
                return "3";
            else if (Df_Total <= 1000)
                return "4";
            else
                return "5";
        }
        public float getTmin()
        {
            float t = 0;
            if (APIComponentType == "TANKBOTTOM")
            {
                t = ProtectedBarrier ? 3.2f : 6.4f; //inc
            }
            else
            {
                t = MinThickReq;
            }
            return t;
        }
        private float agerc()
        {
            return Math.Max(Math.Abs((CurrentThick - NomalThick) / CorrosionRate), 0);
        }
        
        public float Art(float age)
        {
            if (!InternalCladding)
            {
                Console.WriteLine("Art: " + Math.Max(1 - (CurrentThick - CorrosionRate * age) / (getTmin() + CA), 0));
                return Math.Max(1 - (CurrentThick - CorrosionRate * age) / (getTmin() + CA), 0);
            }
            else
            {
                float x = 1 - (CurrentThick - CladdingCorrosionRate * agerc() - CorrosionRate * (age - agerc())) / (getTmin() + CA);
                Console.WriteLine("Art: "+ x);
                return Math.Max(x, 0);
            }
        }
        public float API_ART(float a)
        {
            float art = 0;
            if (APIComponentType != "TANKBOTTOM")
            {
                float[] data = { 0.02f, 0.04f, 0.06f, 0.08f, 0.1f, 0.12f, 0.14f, 0.16f, 0.18f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f, 0.45f, 0.5f, 0.55f, 0.6f, 0.65f };
                if (a < (data[0] + data[1]) / 2)
                    art = data[0];
                else if (a < (data[1] + data[2]) / 2)
                    art = data[1];
                else if (a < (data[2] + data[3]) / 2)
                    art = data[2];
                else if (a < (data[3] + data[4]) / 2)
                    art = data[3];
                else if (a < (data[4] + data[5]) / 2)
                    art = data[4];
                else if (a < (data[5] + data[6]) / 2)
                    art = data[5];
                else if (a < (data[6] + data[7]) / 2)
                    art = data[6];
                else if (a < (data[7] + data[8]) / 2)
                    art = data[7];
                else if (a < (data[8] + data[9]) / 2)
                    art = data[8];
                else if (a < (data[9] + data[10]) / 2)
                    art = data[9];
                else if (a < (data[10] + data[11]) / 2)
                    art = data[10];
                else if (a < (data[11] + data[12]) / 2)
                    art = data[11];
                else if (a < (data[12] + data[13]) / 2)
                    art = data[12];
                else if (a < (data[13] + data[14]) / 2)
                    art = data[13];
                else if (a < (data[14] + data[15]) / 2)
                    art = data[14];
                else if (a < (data[15] + data[16]) / 2)
                    art = data[15];
                else if (a < (data[16] + data[17]) / 2)
                    art = data[16];
                else if (a < (data[17] + data[18]) / 2)
                    art = data[17];
                else art = data[18];
            }
            else
            {
                float[] data = { 0.05f, 0.1f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f, 0.45f, 0.5f, 0.55f, 0.6f, 0.65f, 0.7f, 0.75f, 0.8f, 0.85f, 0.9f, 0.95f, 1f };
                if (a < (data[0] + data[1]) / 2)
                    art = data[0];
                else if (a < (data[1] + data[2]) / 2)
                    art = data[1];
                else if (a < (data[2] + data[3]) / 2)
                    art = data[2];
                else if (a < (data[3] + data[4]) / 2)
                    art = data[3];
                else if (a < (data[4] + data[5]) / 2)
                    art = data[4];
                else if (a < (data[5] + data[6]) / 2)
                    art = data[5];
                else if (a < (data[6] + data[7]) / 2)
                    art = data[6];
                else if (a < (data[7] + data[8]) / 2)
                    art = data[7];
                else if (a < (data[8] + data[9]) / 2)
                    art = data[8];
                else if (a < (data[9] + data[10]) / 2)
                    art = data[9];
                else if (a < (data[10] + data[11]) / 2)
                    art = data[10];
                else if (a < (data[11] + data[12]) / 2)
                    art = data[11];
                else if (a < (data[12] + data[13]) / 2)
                    art = data[12];
                else if (a < (data[13] + data[14]) / 2)
                    art = data[13];
                else if (a < (data[14] + data[15]) / 2)
                    art = data[14];
                else if (a < (data[15] + data[16]) / 2)
                    art = data[15];
                else if (a < (data[16] + data[17]) / 2)
                    art = data[16];
                else if (a < (data[17] + data[18]) / 2)
                    art = data[17];
                else if (a < (data[18] + data[19]) / 2)
                    art = data[18];
                else art = data[19];
            }
            return art;
        }
        public int DFB_THIN(float age)
        {
            if (EFF_THIN == null || EFF_THIN == "")
                EFF_THIN = "E";
            if (APIComponentType == "TANKBOTTOM")
            {
                if (NomalThick == 0 || CurrentThick == 0)
                    return 1390;
                else
                    Console.WriteLine("Dfb: " + DAL_CAL.GET_TBL_512(API_ART(Art(age)), EFF_THIN));
                    return DAL_CAL.GET_TBL_512(API_ART(Art(age)), EFF_THIN);
            }
            else
            {
                if (NomalThick == 0 || CurrentThick == 0)
                    return 1900;
                else
                    Console.WriteLine("Dfb: " + DAL_CAL.GET_TBL_511(API_ART(Art(age)), NoINSP_THINNING, EFF_THIN));
                    return DAL_CAL.GET_TBL_511(API_ART(Art(age)), NoINSP_THINNING, EFF_THIN);
            }

        }
        public float DF_THIN(float age)
        {
            float Fip = 1, Fdl = 1, Fwd = 1, Fam = 1, Fsm = 1, Fom = 1;
            if (HighlyEffectDeadleg)
                Fip = 3;
            else
                Fip = 1;

            if (ContainsDeadlegs)
                Fdl = 3;
            else
                Fdl = 1;
            if (EquipmentType == "Tank")
            {
                if (!ComponentIsWeld)
                    Fwd = 10;
                else
                    Fwd = 1;

                if (!TankMaintain653)
                    Fam = 5;
                else
                    Fam = 1;
                switch(AdjustmentSettle)
                { 
                    case "Recorded settlement exceeds API 653 criteria":
                        Fsm = 2;
                        break;
                    case "Recorded settlement meets API 653 criteria":
                        Fsm = 1;
                        break;
                    case "Settlement never evaluated":
                        Fsm = 1.5f;
                        break;
                    default:
                        Fsm = 1;
                        break;
                }
            }
            switch(OnlineMonitoring)
            {
                case "Amine high velocity corrosion - Electrical resistance probes":
                case "Amine high velocity corrosion - Key process variable":
                case "Amine low velocity corrosion - Electrical resistance probes":
                case "HCI corrosion - Electrical resistance probes":
                case "HCI corrosion - Key process variable":
                case "HF corrosion - Key process variable":
                case "High temperature H2S/H2 corrosion - Electrical resistance probes":
                case "High temperature Sulfidic / Naphthenic acid corrosion - Electrical resistance probes":
                case "High temperature Sulfidic / Naphthenic acid corrosion - Key process variable":
                case "Sour water high velocity corrosion - Key process variable":
                case "Sour water low velocity corrosion - Electrical resistance probes":
                case "Sulfuric acid (H2S/H2) corrosion high velocity - Electrical resistance probes":
                case "Sulfuric acid (H2S/H2) corrosion high velocity - Key process parameters":
                case "Sulfuric acid (H2S/H2) corrosion low velocity - Electrical resistance probes":
                    Fom = 10;
                    break;
                case "Amine low velocity corrosion - Corrosion coupons":
                case "HCI corrosion - Corrosion coupons":
                case "High temperature Sulfidic / Naphthenic acid corrosion - Corrosion coupons":
                case "Sour water high velocity corrosion - Corrosion coupons":
                case "Sour water high velocity corrosion - Electrical resistance probes":
                case "Sour water low velocity corrosion - Corrosion coupons":
                case "Sulfuric acid (H2S/H2) corrosion low velocity - Corrosion coupons":
                    Fom = 2;
                    break;
                case "Amine low velocity corrosion - Key process variable":
                case "HCI corrosion - Key process variable & Electrical resistance probes":
                case "Sour water low velocity corrosion - Key process variable":
                case "Sulfuric acid (H2S/H2) corrosion high velocity - Key process parameters & electrical resistance probes":
                case "Sulfuric acid(H2S / H2) corrosion low velocity - Key process parameters":
                    Fom = 20;
                    break;
                default:
                    Fom = 1;
                    break;
            }
            Console.WriteLine("Df thin: " + DFB_THIN(age));
            return DFB_THIN(age) * Fip * Fdl * Fwd * Fsm * Fam / Fom;
        }

        /// <summary>
        /// CAL LINNING
        /// </summary>
        /// <returns></returns>
        private float DFB_LINNING(float age)
        {
            String SUSCEP_LINNING;
            if (LinningType == "Organic")
            {
                if (age <= 3)
                    SUSCEP_LINNING = "WithinLast3Years";
                else if ((age > 3) && (age <= 6))
                    SUSCEP_LINNING = "WithinLast6Years";
                else
                    SUSCEP_LINNING = "MoreThan6Years";
                YEAR_IN_SERVICE = YEAR_IN_SERVICE > 25 ? 25 : YEAR_IN_SERVICE;
                return DAL_CAL.GET_TBL_65(YEAR_IN_SERVICE, SUSCEP_LINNING);
            }
            else
            {
                age = age > 25 ? 25 : age;
                return DAL_CAL.GET_TBL_64((int)age, LinningType);
            }
        }
        public float DF_LINNING(float age)
        {
            if (INTERNAL_LINNING)
            {
                float Fdl = 1, Fom = 1;
                if (LINNER_CONDITION == "Poor")
                    Fdl = 10;
                else if (LINNER_CONDITION == "Average")
                    Fdl = 2;
                else
                    Fdl = 1;
                if (LINNER_ONLINE)
                    Fom = 0.1f;
                else
                    Fom = 1;
                return DFB_LINNING(age) * Fom * Fdl;
            }
            else
                return 0;
        }

        /// <summary>
        /// CAL CAUSTIC
        /// </summary>
        /// <returns></returns>
        private char plotinArea() //tinh lai
        {
            char k = 'B';
            if (MAX_OP_TEMP < 80)
            {
                k = 'A';
            }
            else
            {
                k = 'B';
            }
            return k;
        }
        private string getSusceptibility_Caustic()
        {
            string sus = null;
            if (CRACK_PRESENT) sus = "High";
            else if (HEAT_TREATMENT == "Stress Relieved") sus = "None";
            else
            {
                if (plotinArea() == 'A')
                {
                    if (NaOHConcentration < 5)
                    {
                        if (HEAT_TRACE) sus = "Medium";
                        else if (STEAM_OUT) sus = "Low";
                        else sus = "None";
                    }
                    else if (HEAT_TRACE) sus = "High";
                    else if (STEAM_OUT) sus = "Medium";
                    else sus = "None";
                }
                else
                {
                    if (NaOHConcentration < 5) sus = "Medium";
                    else sus = "High";
                }
            }

            return sus;
        }
        private int SVI_CAUSTIC()
        {
            int sev = 0;
            switch (getSusceptibility_Caustic())
            {
                case "High": sev = 5000; break;
                case "Medium": sev = 500; break;
                case "Low": sev = 50; break;
                default: sev = 1; break;
            }
            return sev;
        }
        public float DF_CAUSTIC(float age)
        {
            if (CARBON_ALLOY)
            {
                String FIELD = null;
                if (CAUSTIC_INSP_EFF == "E" || CAUSTIC_INSP_NUM == 0)
                    FIELD = "E";
                else
                    FIELD = CAUSTIC_INSP_NUM + CAUSTIC_INSP_EFF;
                float DFB_CAUSTIC = DAL_CAL.GET_TBL_74(SVI_CAUSTIC(), FIELD);
                return DFB_CAUSTIC * (float)Math.Pow(age, 1.1);
            }
            else
                return 0;
        }

        ///<summary>
        /// CAL SCC AMINE
        ///</summary>
        private string getSusceptibility_Amine()
        {
            string sus = null;
            if (CRACK_PRESENT) sus = "High";
            else if (HEAT_TREATMENT == "Stress Relieved") sus = "None";
            else if (!AMINE_EXPOSED) sus = "None";
            else
            {
                if (AMINE_SOLUTION == "Methyldiethanolamine MDEA" || AMINE_SOLUTION == "Disopropanolamine DIPA")
                {
                    if (MAX_OP_TEMP > 82.22f) sus = "High";
                    else if ((MAX_OP_TEMP < 82.22f && MAX_OP_TEMP > 37.78f) || HEAT_TRACE || STEAM_OUT) sus = "Medium";
                    else sus = "Low";
                }
                else if (AMINE_SOLUTION == "Diethanolamine DEA")
                {
                    if (MAX_OP_TEMP > 82.22f) sus = "Medium";
                    else if ((MAX_OP_TEMP < 82.22f && MAX_OP_TEMP > 60f) || HEAT_TRACE || STEAM_OUT) sus = "Low";
                    else sus = "None";
                }
                else
                {
                    sus = ((MAX_OP_TEMP > 82.22f) || HEAT_TRACE || STEAM_OUT) ? "Low" : "None";
                }
            }
            return sus;
        }
        private int SVI_AMINE()
        {
            switch (getSusceptibility_Amine())
            {
                case "High": return 1000;
                case "Medium": return 100;
                case "Low": return 10;
                default: return 1;
            }
        }
        public float DF_AMINE(float age)
        {
            if (CARBON_ALLOY)
            {
                String FIELD = null;
                if (AMINE_INSP_EFF == "E" || AMINE_INSP_NUM == 0)
                    FIELD = "E";
                else
                    FIELD = AMINE_INSP_NUM + AMINE_INSP_EFF;

                float DFB_AMIN = DAL_CAL.GET_TBL_74(SVI_AMINE(), FIELD);
                return DFB_AMIN * (float)Math.Pow(age, 1.1);
            }
            else
                return 0;
        }

        ///<summary>
        /// CAL Sulphide stress cracking
        ///</summary>
        private string GET_ENVIRONMENTAL_SEVERITY()
        {
            string env = null;
            if (PH < 5.5)
            {
                if (H2SContent < 50) env = "Low";
                else if (H2SContent <= 1000) env = "Moderate";
                else env = "High";
            }
            else if (PH <= 7.5 && PH >= 5.5)
            {
                if (H2SContent > 10000) env = "Moderate";
                else env = "Low";
            }
            else if (PH >= 7.6 && PH <= 8.3)
            {
                if (H2SContent < 50) env = "Low";
                else env = "Moderate";
            }
            else if (PH >= 8.4 && PH <= 8.9)
            {
                if (H2SContent < 50) env = "Low";
                else if (H2SContent <= 10000 && PRESENT_CYANIDE) env = "High";
                else if (H2SContent <= 10000) env = "Moderate";
                else env = "High";
            }
            else
            {
                if (H2SContent < 50) env = "Low";
                else if (H2SContent <= 1000) env = "Moderate";
                else env = "High";
            }

            return env;
        }
        private string GET_SUSCEPTIBILITY_SULPHIDE()
        {
            string sus = "None";
            string env = GET_ENVIRONMENTAL_SEVERITY();
            if (CRACK_PRESENT) sus = "High";
            else if (PWHT)
            {
                if (BRINNEL_HARDNESS == "Below 200") sus = "None";
                else if (BRINNEL_HARDNESS == "Between 200 and 237")
                {
                    sus = (env == "High") ? "Low" : "None";
                }
                else
                {
                    sus = (env == "High") ? "Medium" : (env == "Moderate" ? "Low" : "None");
                }
            }
            else
            {
                if (BRINNEL_HARDNESS == "Below 200") sus = "Low";
                else if (BRINNEL_HARDNESS == "Between 200 and 237")
                {
                    sus = (env == "Low") ? "Low" : "Medium";
                }
                else
                {
                    sus = (env == "Low") ? "Medium" : "High";
                }
            }
            return sus;
        }
        private int SVI_SULPHIDE()
        {
            switch (GET_SUSCEPTIBILITY_SULPHIDE())
            {
                case "High": return 100;
                case "Medium": return 10;
                default: return 1;
            }
        }
        public float DF_SULPHIDE(float age)
        {
            if (CARBON_ALLOY && AQUEOUS_OPERATOR && ENVIRONMENT_H2S_CONTENT)
            {
                string FIELD = null;
                if (SULPHIDE_INSP_EFF == "E" || SULPHIDE_INSP_NUM == 0)
                    FIELD = "E";
                else
                    FIELD = SULPHIDE_INSP_NUM + SULPHIDE_INSP_EFF;

                float DFB_SULPHIDE = DAL_CAL.GET_TBL_74(SVI_SULPHIDE(), FIELD);
                return DFB_SULPHIDE * (float)Math.Pow(age, 1.1);
            }
            else
                return 0;
        }

        ///<summary>
        /// CAL HIC/SOHIC H2S
        ///</summary>
        private string GET_ENVIROMENTAL_HICSOHIC_H2S()
        {
            string env = "None";
            if (PH < 5.5)
            {
                if (H2SContent < 50) env = "Low";
                else if (H2SContent <= 1000) env = "Moderate";
                else env = "High";
            }
            else if (PH <= 7.5 && PH >= 5.5)
            {
                if (H2SContent > 10000) env = "Moderate";
                else env = "Low";
            }
            else if (PH >= 7.6 && PH <= 8.3)
            {
                if (H2SContent < 50) env = "Low";
                else env = "Moderate";
            }
            else if (PH >= 8.4 && PH <= 8.9)
            {
                if (H2SContent < 50) env = "Low";
                else if (H2SContent <= 10000 && PRESENT_CYANIDE) env = "High";
                else if (H2SContent <= 10000) env = "Moderate";
                else env = "High";
            }
            else
            {
                if (H2SContent < 50) env = "Low";
                else if (H2SContent <= 1000) env = "Moderate";
                else env = "High";
            }

            return env;
        }
        private string GET_SUSCEPTIBILITY_HICSOHIC_H2S()
        {
            string sus = "None";
            string env = GET_ENVIROMENTAL_HICSOHIC_H2S();

            if (CRACK_PRESENT) sus = "High";
            else if (PWHT)
            {
                if (SULFUR_CONTENT == "High > 0.01%")
                {
                    sus = (env == "High") ? "High" : ((env == "Moderate") ? "Medium" : "Low");
                }
                else if (SULFUR_CONTENT == "Low 0.002 - 0.01%")
                {
                    sus = (env == "High") ? "Medium" : "Low";
                }
                else
                {
                    sus = (env == "Low") ? "None" : "Low";
                }
            }
            else
            {
                if (SULFUR_CONTENT == "High > 0.01%")
                {
                    sus = (env == "Low") ? "Medium" : "High";
                }
                else if (SULFUR_CONTENT == "Low 0.002 - 0.01%")
                {
                    sus = (env == "High") ? "High" : ((env == "Moderate") ? "Medium" : "Low");
                }
                else
                {
                    sus = (env == "High") ? "Medium" : (env == "Moderate" ? "Low" : "None");
                }
            }
            return sus;
        }
        private int SVI_HICSOHIC_H2S()
        {
            switch (GET_SUSCEPTIBILITY_HICSOHIC_H2S())
            {
                case "High": return 100;
                case "Medium": return 10;
                default: return 1;
            }
        }
        public float DF_HICSOHIC_H2S(float age)
        {
            if (CARBON_ALLOY && AQUEOUS_OPERATOR && ENVIRONMENT_H2S_CONTENT)
            {
                String FIELD = null;
                if (SULFUR_INSP_EFF == "E" || SULFUR_INSP_NUM == 0)
                    FIELD = "E";
                else
                    FIELD = SULFUR_INSP_NUM + SULFUR_INSP_EFF;
                float DFB_SULFUR = DAL_CAL.GET_TBL_74(SVI_HICSOHIC_H2S(), FIELD);
                return DFB_SULFUR * (float)Math.Pow(age, 1.1);
            }
            else
                return 0;
        }

        ///<summary>
        /// CAL CACBONATE CRACKING
        ///</summary>
        private string GET_SUSCEPTIBILITY_CARBONATE()
        {
            string sus = "None";
            if (CRACK_PRESENT) sus = "High";
            else
            {
                if (CO3_CONCENTRATION < 100) sus = "Low";
                else if (CO3_CONCENTRATION <= 500)
                    sus = (PH >= 9.0) ? "Medium" : "Low";
                else if (CO3_CONCENTRATION <= 1000)
                    sus = (PH >= 9.0) ? "High" : ((PH > 8.3) ? "Medium" : "Low");
                else
                    sus = (PH >= 7.6 && PH <= 8.3) ? "Medium" : "High";
            }
            return sus;
        }
        private int SVI_CARBONATE()
        {
            switch (GET_SUSCEPTIBILITY_CARBONATE())
            {
                case "High": return 1000;
                case "Medium": return 100;
                case "Low": return 10;
                default: return 1;
            }
        }
        public float DF_CACBONATE(float age)
        {
            if (CARBON_ALLOY && AQUEOUS_OPERATOR && PH >= 7.5)
            {
                String FIELD = null;
                if (CACBONATE_INSP_EFF == "E" || CACBONATE_INSP_NUM == 0)
                    FIELD = "E";
                else
                    FIELD = CACBONATE_INSP_NUM + CACBONATE_INSP_EFF;
                float DFB_CACBONATE = DAL_CAL.GET_TBL_74(SVI_CARBONATE(), FIELD);
                return DFB_CACBONATE * (float)Math.Pow(age, 1.1);
            }
            else
                return 0;
        }

        ///<summary>
        /// CAL PTA CRACKING
        ///</summary>
        
        //private string SUSCEPPTA
        private string GET_SUSCEPTIBILITY_PTA()
        {
            string sus = "None";
            if (CRACK_PRESENT) { sus = "High"; return sus; }
            if (!ExposedSH2OOperation && !ExposedSH2OShutdown) sus = "None";
            else
            {
                if (MAX_OP_TEMP < 427)
                {
                    if (ThermalHistory == "Solution Annealed")
                    {
                        switch (PTAMaterial)
                        {
                            case "Regular 300 series Stainless Steels and Alloys 600 and 800": sus = "Medium"; break;
                            case "H Grade 300 series Stainless Steels": sus = "High"; break;
                            case "L Grade 300 series Stainless Steels": sus = "Low"; break;
                            case "321 Stainless Steel": sus = "Medium"; break;
                            case "347 Stainless Steel, Alloy 20, Alloy 625, All austenitic weld overlay": sus = "Low"; break;
                            default: sus = "None"; break;
                        }
                    }
                    else if (ThermalHistory == "Stabilised Before Welding")
                    {
                        switch (PTAMaterial)
                        {
                            case "321 Stainless Steel": sus = "Medium"; break;
                            case "347 Stainless Steel, Alloy 20, Alloy 625, All austenitic weld overlay": sus = "Low"; break;
                            default: sus = "None"; break;
                        }
                    }
                    else if (ThermalHistory == "Stabilised After Welding")
                    {
                        switch (PTAMaterial)
                        {
                            case "321 Stainless Steel": sus = "Low"; break;
                            case "347 Stainless Steel, Alloy 20, Alloy 625, All austenitic weld overlay": sus = "Low"; break;
                            default: sus = "None"; break;
                        }
                    }
                    else sus = "None";
                }
                else
                {
                    if (ThermalHistory == "Solution Annealed")
                    {
                        switch (PTAMaterial)
                        {
                            case "Regular 300 series Stainless Steels and Alloys 600 and 800": sus = "High"; break;
                            case "H Grade 300 series Stainless Steels": sus = "High"; break;
                            case "L Grade 300 series Stainless Steels": sus = "Medium"; break;
                            case "321 Stainless Steel": sus = "High"; break;
                            case "347 Stainless Steel, Alloy 20, Alloy 625, All austenitic weld overlay": sus = "Medium"; break;
                            default: sus = "None"; break;
                        }
                    }
                    else if (ThermalHistory == "Stabilised Before Welding")
                    {
                        switch (PTAMaterial)
                        {
                            case "321 Stainless Steel": sus = "High"; break;
                            case "347 Stainless Steel, Alloy 20, Alloy 625, All austenitic weld overlay": sus = "Low"; break;
                            default: sus = "None"; break;
                        }
                    }
                    else if (ThermalHistory == "Stabilised After Welding")
                    {
                        switch (PTAMaterial)
                        {
                            case "321 Stainless Steel": sus = "Low"; break;
                            case "347 Stainless Steel, Alloy 20, Alloy 625, All austenitic weld overlay": sus = "Low"; break;
                            default: sus = "None"; break;
                        }
                    }
                    else sus = "None";
                }
            }
            if (DOWNTIME_PROTECTED)
            {
                switch (sus)
                {
                    case "High": sus = "Medium"; break;
                    case "Medium": sus = "Low"; break;
                    default: sus = "None"; break;
                }
            }
            return sus;
        }
        private int SVI_PTA()
        {
            switch (GET_SUSCEPTIBILITY_PTA())
            {
                case "High": return 5000;
                case "Medium": return 500;
                case "Low": return 50;
                default: return 1;
            }
        }
        public float DF_PTA(float age)
        {
            if (PTA_SUSCEP || ((AUSTENITIC_STEEL || NICKEL_ALLOY) && EXPOSED_SULFUR))
            {
                String FIELD = null;
                if (PTA_INSP_EFF == "E" || PTA_INSP_NUM == 0)
                    FIELD = "E";
                else
                    FIELD = PTA_INSP_NUM + PTA_INSP_EFF;

                float DFB_PTA = DAL_CAL.GET_TBL_74(SVI_PTA(), FIELD);
                return DFB_PTA * (float)Math.Pow(age, 1.1);
            }
            else
                return 0;
        }

        ///<summary>
        /// CAL CLSCC
        ///</summary>
        private string GET_SUSCEPTIBILITY_CLSCC()
        {
            string sus = "None";
            if (CRACK_PRESENT) { sus = "High"; return sus; }
            if (PH > 10)
            {
                sus = (MAX_OP_TEMP >= 93 && MAX_OP_TEMP <= 149 && CHLORIDE_ION_CONTENT > 1000) ? "Medium" : "Low";
            }
            else
            {
                if (MAX_OP_TEMP <= 66 && MAX_OP_TEMP > 38)
                {
                    sus = (CHLORIDE_ION_CONTENT <= 10) ? "Low" : ((CHLORIDE_ION_CONTENT <= 1000) ? "Medium" : "High");
                }
                else if (MAX_OP_TEMP <= 93 && MAX_OP_TEMP > 66)
                {
                    sus = (CHLORIDE_ION_CONTENT <= 100) ? "Medium" : "High";
                }
                else if (MAX_OP_TEMP > 93 && MAX_OP_TEMP <= 149)
                {
                    sus = (CHLORIDE_ION_CONTENT < 10) ? "Medium" : "High";
                }
                else
                    sus = "None";
            }
            return sus;
        }
        private int SVI_CLSCC()
        {
            switch (GET_SUSCEPTIBILITY_CLSCC())
            {
                case "High": return 5000;
                case "Medium": return 500;
                case "Low": return 50;
                default: return 1;
            }
        }
        public float DF_CLSCC(float age)
        {
            if (INTERNAL_EXPOSED_FLUID_MIST && AUSTENITIC_STEEL && MAX_OP_TEMP > 38)
            {
                String FIELD = null;
                if (CLSCC_INSP_EFF == "E" || CLSCC_INSP_NUM == 0)
                    FIELD = "E";
                else
                    FIELD = CLSCC_INSP_NUM + CLSCC_INSP_EFF;
                float DFB_CLSCC = DAL_CAL.GET_TBL_74(SVI_CLSCC(), FIELD);
                return DFB_CLSCC * (float)Math.Pow(age, 1.1);
            }
            else
                return 0;
        }

        ///<summary>
        /// CAL HSC-HF
        ///</summary>
        private string GET_SUSCEPTIBILITY_HSCHF()
        {
            string sus = "None";
            if (CRACK_PRESENT) { sus = "High"; return sus; }
            if (!HF_PRESENT || !CARBON_ALLOY) sus = "None";
            else
            {
                if (PWHT)
                {
                    sus = (BRINNEL_HARDNESS == "Below 200") ? "None" : ((BRINNEL_HARDNESS == "Between 200 and 237") ? "Low" : "High");
                }
                else
                {
                    sus = (BRINNEL_HARDNESS == "Below 200") ? "Low" : ((BRINNEL_HARDNESS == "Between 200 and 237") ? "Medium" : "High");
                }
            }
            return sus;
        }
        private int SVI_HSCHF()
        {
            switch (GET_SUSCEPTIBILITY_HSCHF())
            {
                case "High": return 100;
                case "Medium": return 10;
                default: return 1;
            }
        }
        public float DF_HSCHF(float age)
        {
            if (CARBON_ALLOY && HF_PRESENT)
            {
                String FIELD = null;
                if (HSC_HF_INSP_EFF == "E" || HSC_HF_INSP_NUM == 0)
                    FIELD = "E";
                else
                    FIELD = HSC_HF_INSP_NUM + HSC_HF_INSP_EFF;
                float DFB_HSCHF = DAL_CAL.GET_TBL_74(SVI_HSCHF(), FIELD);
                return DFB_HSCHF * (float)Math.Pow(age, 1.1);
            }
            else
                return 0;
        }
        ///<summary>
        /// CAL HICSOHIC-HF
        ///</summary>
        private string GET_SUSCEPTIBILITY_HICSOHIC_HF()
        {
            string sus = "None";
            if (CRACK_PRESENT) return "High";
            if (!HF_PRESENT || !CARBON_ALLOY) return "None";
            if (PWHT)
            {
                sus = (SULFUR_CONTENT == "High > 0.01%") ? "High" : ((SULFUR_CONTENT == "Low 0.002 - 0.01%") ? "Medium" : "Low");
            }
            else
            {
                sus = (SULFUR_CONTENT == "High > 0.01%" || SULFUR_CONTENT == "Low 0.002 - 0.01%") ? "High" : "Medium";
            }
            return sus;
        }
        private int SVI_HICSOHIC_HF()
        {
            switch (GET_SUSCEPTIBILITY_HICSOHIC_HF())
            {
                case "High": return 100;
                case "Medium": return 10;
                default: return 1;
            }
        }
        public float DF_HIC_SOHIC_HF(float age)
        {
            if (CARBON_ALLOY && HF_PRESENT)
            {
                String FIELD = null;
                if (HICSOHIC_INSP_EFF == "E" || HICSOHIC_INSP_NUM == 0)
                    FIELD = "E";
                else
                    FIELD = HICSOHIC_INSP_NUM + HICSOHIC_INSP_EFF;
                float DFB_HICSOHIC_HF = DAL_CAL.GET_TBL_74(SVI_HICSOHIC_HF(), FIELD);
                return DFB_HICSOHIC_HF * (float)Math.Pow(age, 1.1);
            }
            else
                return 0;
        }

        ///<summary>
        /// CAL EXTERNAL CORROSION
        ///</summary>
        private int API_EXTERNAL_CORROSION_TEMP()
        {
            List<float> List = new List<float>();
            List.Add(CUI_PERCENT_1);
            List.Add(CUI_PERCENT_2);
            List.Add(CUI_PERCENT_3);
            List.Add(CUI_PERCENT_4);
            List.Add(CUI_PERCENT_5);
            List.Add(CUI_PERCENT_6);
            List.Add(CUI_PERCENT_7);
            List.Add(CUI_PERCENT_8);
            List.Add(CUI_PERCENT_9);
            List.Add(CUI_PERCENT_10);
            int[] data = { -12, -8, 6, 32, 71, 107, 121, 135, 176 };
            return data[List.IndexOf(List.Max())]; // tìm chỉ số (vị trí) của giá trị Max
        }
        private float API_EXTERNAL_CORROSION_RATE()
        {
            int EXTERNAL_TEMP = API_EXTERNAL_CORROSION_TEMP();
            float CR_EXTERN = 0;
            if (EXTERNAL_EVIRONMENT == "Arid/dry")
            {
                switch (EXTERNAL_TEMP)
                {
                    case -12:
                    case -8:
                    case 107:
                    case 121:
                        CR_EXTERN = 0;
                        break;
                    case 6:
                    case 32:
                    case 71:
                        CR_EXTERN = 0.025f;
                        break;
                    default:
                        CR_EXTERN = 0;
                        break;
                }
            }
            else if (EXTERNAL_EVIRONMENT == "Marine")
            {
                switch (EXTERNAL_TEMP)
                {
                    case -12:
                    case 121:
                        CR_EXTERN = 0;
                        break;
                    case -8:
                    case 107:
                        CR_EXTERN = 0.025f;
                        break;
                    case 6:
                    case 32:
                    case 71:
                        CR_EXTERN = 0.127f;
                        break;
                    default:
                        CR_EXTERN = 0;
                        break;
                }
            }
            else if (EXTERNAL_EVIRONMENT == "Severe")
            {
                switch (EXTERNAL_TEMP)
                {
                    case -12:
                    case -8:
                    case 121:
                        CR_EXTERN = 0;
                        break;
                    case 6:
                    case 32:
                    case 71:
                        CR_EXTERN = 0.254f;
                        break;
                    case 107:
                        CR_EXTERN = 0.051f;
                        break;
                    default:
                        CR_EXTERN = 0;
                        break;
                }
            }
            else if (EXTERNAL_EVIRONMENT == "Temperate")
            {
                switch (EXTERNAL_TEMP)
                {
                    case -12:
                    case -8:
                    case 107:
                    case 121:
                        CR_EXTERN = 0;
                        break;
                    case 6:
                    case 32:
                        CR_EXTERN = 0.076f;
                        break;
                    case 71:
                        CR_EXTERN = 0.051f;
                        break;
                    default:
                        CR_EXTERN = 0;
                        break;
                }
            }
            else
                CR_EXTERN = 0;
            return CR_EXTERN;
        }
        private float API_ART_EXTERNAL(float age)
        {
            float FPS = 1, FIP = 1;
            if (SUPPORT_COATING)
                FPS = 2;
            else
                FPS = 1; 

            if (INTERFACE_SOIL_WATER)
                FIP = 2;
            else
                FIP = 1;
            float CR = API_CORROSION_RATE() * Math.Max(FPS, FIP);
            float ART_EXT = Math.Max(1 - (CurrentThick - CR * AGE_CUI(age)) / (getTmin() + CA), 0);
            return API_ART(ART_EXT);
        }
        public float DF_EXTERNAL_CORROSION(float age)
        {
            if (EXTERNAL_EXPOSED_FLUID_MIST || (CARBON_ALLOY && !(MAX_OP_TEMP < -23 || MIN_OP_TEMP > 121)))
            {
                if (EXTERNAL_INSP_EFF == "" || EXTERNAL_INSP_EFF == null || EXTERNAL_INSP_NUM == 0)
                    EXTERNAL_INSP_EFF = "E";
                if (APIComponentType == "TANKBOTTOM")
                {
                    if (NomalThick == 0 || CurrentThick == 0)
                        return 1390;
                    else
                        return DAL_CAL.GET_TBL_512(API_ART_EXTERNAL(age), EXTERNAL_INSP_EFF);
                }
                else
                {
                    if (NomalThick == 0 || CurrentThick == 0)
                        return 1900;
                    else
                        return DAL_CAL.GET_TBL_511(API_ART_EXTERNAL(age), EXTERNAL_INSP_NUM, EXTERNAL_INSP_EFF);
                }
            }
            else
                return 0;
        }

        ///<summary>
        /// CAL CUI
        ///</summary>
        private float AGE_CUI(float age)
        {
            //TimeSpan TCK = DateTime.Now.Subtract(CUI_INSP_DATE);
            //float AGE_TK = (float)Math.Round((double)TCK.Days / 365, 2);
            //return Math.Min(AGE_CLSCC(), AGE_TK);
            return Math.Min(AGE_CLSCC(), age);
        }
        private int API_CUI_TEMP()
        {
            List<float> List = new List<float>();
            List.Add(CUI_PERCENT_1);
            List.Add(CUI_PERCENT_2);
            List.Add(CUI_PERCENT_3);
            List.Add(CUI_PERCENT_4);
            List.Add(CUI_PERCENT_5);
            List.Add(CUI_PERCENT_6);
            List.Add(CUI_PERCENT_7);
            List.Add(CUI_PERCENT_8);
            List.Add(CUI_PERCENT_9);
            List.Add(CUI_PERCENT_10);
            int[] data = { -12, -8, 6, 32, 71, 107, 107, 135, 162, 176 };
            return data[List.IndexOf(List.Max())];
        }
        private float API_CORROSION_RATE()
        {
            int CUI_TEMP = API_CUI_TEMP();
            float CR_CUI = 0;
            if (EXTERNAL_EVIRONMENT == "Arid/dry")
            {
                switch (CUI_TEMP)
                {
                    case -12:
                    case -8:
                    case 135:
                    case 162:
                    case 176:
                        CR_CUI = 0;
                        break;
                    case 6:
                    case 32:
                    case 107:
                        CR_CUI = 0.025f;
                        break;
                    case 71:
                        CR_CUI = 0.051f;
                        break;
                    default:
                        CR_CUI = 0;
                        break;
                }
            }
            else if (EXTERNAL_EVIRONMENT == "Marine")
            {
                switch (CUI_TEMP)
                {
                    case -12:
                    case 176:
                        CR_CUI = 0;
                        break;
                    case -8:
                    case 162:
                        CR_CUI = 0.025f;
                        break;
                    case 6:
                    case 32:
                    case 107:
                        CR_CUI = 0.127f;
                        break;
                    case 135:
                        CR_CUI = 0.051f;
                        break;
                    case 71:
                        CR_CUI = 0.254f;
                        break;
                    default:
                        CR_CUI = 0;
                        break;
                }
            }
            else if (EXTERNAL_EVIRONMENT == "Severe")
            {
                switch (CUI_TEMP)
                {
                    case -12:
                    case 176:
                        CR_CUI = 0;
                        break;
                    case -8:
                        CR_CUI = 0.076f;
                        break;
                    case 162:
                        CR_CUI = 0.127f;
                        break;
                    case 6:
                    case 32:
                    case 107:
                    case 135:
                        CR_CUI = 0.254f;
                        break;
                    case 71:
                        CR_CUI = 0.508f;
                        break;
                    default:
                        CR_CUI = 0;
                        break;
                }
            }
            else if (EXTERNAL_EVIRONMENT == "Temperate")
            {
                switch (CUI_TEMP)
                {
                    case -12:
                    case -8:
                    case 162:
                    case 176:
                        CR_CUI = 0;
                        break;
                    case 107:
                    case 135:
                        CR_CUI = 0.025f;
                        break;
                    case 6:
                    case 32:
                        CR_CUI = 0.076f;
                        break;
                    case 71:
                        CR_CUI = 0.127f;
                        break;
                    default:
                        CR_CUI = 0;
                        break;
                }
            }
            else
                CR_CUI = 0;
            return CR_CUI;
        }
        private float API_ART_CUI(float age)
        {
            float FIN = 1, FCM = 1, FIC = 1, FPS = 1, FIP = 1;

            if (INSULATION_TYPE == "Asbestos" || INSULATION_TYPE == "Calcium Silicate" || INSULATION_TYPE == "Mineral Wool" || INSULATION_TYPE == "Fibreglass")
                FIN = 1.25f;
            else if (INSULATION_TYPE == "Foam Glass")
                FIN = 0.75f;
            else
                FIN = 1;

            if (PIPING_COMPLEXITY == "Below average")
                FCM = 0.75f;
            else if (PIPING_COMPLEXITY == "Above average")
                FCM = 1.75f;
            else
                FCM = 1;

            if (INSULATION_CONDITION == "Below average")
                FIC = 1.25f;
            else if (INSULATION_CONDITION == "Above average")
                FIC = 0.75f;
            else
                FIC = 1;

            if (SUPPORT_COATING)
                FPS = 2;
            else
                FPS = 1;

            if (INTERFACE_SOIL_WATER)
                FIP = 2;
            else
                FIP = 1;

            float CR = API_CORROSION_RATE() * FIN * FCM * FIC * Math.Max(FPS, FIP);
            float ART_CUI = Math.Max(1 - (CurrentThick - CR * AGE_CUI(age)) / (getTmin() + CA), 0);
            return API_ART(ART_CUI);
        }
        public float DF_CUI(float age)
        {
            if (CUI_INSP_EFF == null || CUI_INSP_EFF == "" || CUI_INSP_NUM == 0)
                CUI_INSP_EFF = "E";
            if (APIComponentType == "TANKBOTTOM")
            {
                if (NomalThick == 0 || CurrentThick == 0)
                    return 1390;
                else
                    return DAL_CAL.GET_TBL_512(API_ART_CUI(age), CUI_INSP_EFF);
            }
            else
            {
                if (NomalThick == 0 || CurrentThick == 0)
                    return 1900;
                else
                    return DAL_CAL.GET_TBL_511(API_ART_CUI(age), CUI_INSP_NUM, CUI_INSP_EFF);
            }
        }

        ///<summary>
        /// CAL EXTERNAL CLSCC
        ///</summary>
        private String CLSCC_SUSCEP()
        {
            String SUSCEP = null;
            if (CRACK_PRESENT)
                SUSCEP = "High";
            else
            {
                if (EXTERNAL_EVIRONMENT == "Arid/dry")
                {
                    SUSCEP = "Not";
                }
                else if (EXTERNAL_EVIRONMENT == "Marine")
                {
                    if (MAX_OP_TEMP < 49 || MAX_OP_TEMP > 149)
                        SUSCEP = "Not";
                    else if (MAX_OP_TEMP >= 49 && MAX_OP_TEMP < 93)
                        SUSCEP = "Medium";
                    else
                        SUSCEP = "Low";
                }
                else if (EXTERNAL_EVIRONMENT == "Severe")
                {
                    if (MAX_OP_TEMP < 49 || MAX_OP_TEMP > 149)
                        SUSCEP = "Not";
                    else if (MAX_OP_TEMP >= 49 && MAX_OP_TEMP < 93)
                        SUSCEP = "High";
                    else
                        SUSCEP = "Medium";
                }
                else if (EXTERNAL_EVIRONMENT == "Temperate")
                {
                    if (MAX_OP_TEMP < 49 || MAX_OP_TEMP > 149)
                        SUSCEP = "Not";
                    else
                        SUSCEP = "Low";
                }
                else
                    SUSCEP = "Not";
            }
            return SUSCEP;
        }
        private float DFB_EXTERN_CLSCC()
        {
            int SVI = 1;
            String FIELD = null;
            String SUSCEP = CLSCC_SUSCEP();

            if (SUSCEP == "High")
                SVI = 50;
            else if (SUSCEP == "Medium")
                SVI = 10;
            else
                SVI = 1;

            if (EXTERN_CLSCC_INSP_EFF == "E" || EXTERN_CLSCC_INSP_NUM == 0)
                FIELD = "E";
            else
                FIELD = EXTERN_CLSCC_INSP_NUM + EXTERN_CLSCC_INSP_EFF;

            return DAL_CAL.GET_TBL_74(SVI, FIELD);
        }
        public float DF_EXTERN_CLSCC()
        {
            if (AUSTENITIC_STEEL && EXTERNAL_EXPOSED_FLUID_MIST && !(MAX_OP_TEMP < 49 || MIN_DESIGN_TEMP > 149))
            {
                return DFB_EXTERN_CLSCC() * (float)Math.Pow((double)AGE_CLSCC(), 1.1);
            }
            else
                return 0;
        }

        ///<summary>
        /// CAL EXTERN CUI CLSCC
        ///</summary>
        private float AGE_CLSCC()
        {
            DateTime AGE_COAT = COMPONENT_INSTALL_DATE;
            if (EXTERN_COAT_QUALITY == "High coating quality")
                AGE_COAT = COMPONENT_INSTALL_DATE.AddYears(15);
            else if (EXTERN_COAT_QUALITY == "Medium coating quality")
                AGE_COAT = COMPONENT_INSTALL_DATE.AddYears(5);
            else
                AGE_COAT = COMPONENT_INSTALL_DATE;
            TimeSpan TICK_SPAN = DateTime.Now.Subtract(AGE_COAT);
            float DATA = Math.Max(0, (float)Math.Round((double)TICK_SPAN.Days / 365, 2));
            //Debug.WriteLine("jahdasd " + DATA +" Datetime "+AGE_COAT.ToString());
            return DATA;
        }
        private String CUI_CLSCC_SUSCEP()
        {
            String SUSCEP = null;
            if (CRACK_PRESENT)
                SUSCEP = "High";
            else
            {
                if (EXTERNAL_EVIRONMENT == "Arid/dry")
                {
                    if (MAX_OP_TEMP >= 49 && MAX_OP_TEMP < 93)
                        SUSCEP = "Low";
                    else
                        SUSCEP = "Not";
                }
                else if (EXTERNAL_EVIRONMENT == "Marine")
                {
                    if (MAX_OP_TEMP < 49 || MAX_OP_TEMP > 149)
                        SUSCEP = "Not";
                    else if (MAX_OP_TEMP >= 49 && MAX_OP_TEMP < 93)
                        SUSCEP = "High";
                    else
                        SUSCEP = "Medium";
                }
                else if (EXTERNAL_EVIRONMENT == "Severe")
                {
                    if (MAX_OP_TEMP < 49 || MAX_OP_TEMP > 149)
                        SUSCEP = "Not";
                    else
                        SUSCEP = "High";
                }
                else if (EXTERNAL_EVIRONMENT == "Temperate")
                {
                    if (MAX_OP_TEMP < 49 || MAX_OP_TEMP > 149)
                        SUSCEP = "Not";
                    else if (MAX_OP_TEMP >= 49 && MAX_OP_TEMP < 93)
                        SUSCEP = "Medium";
                    else
                        SUSCEP = "Low";
                }
                else
                    SUSCEP = "Not";
            }
            return SUSCEP;

        }
        private String ADJUST_COMPLEXITY()
        {
            String SCP = CUI_CLSCC_SUSCEP();
            if (SCP == "High")
            {
                if (PIPING_COMPLEXITY == "Below average")
                    SCP = "Medium";
                else
                    SCP = "High";

            }
            else if (SCP == "Medium")
            {
                if (PIPING_COMPLEXITY == "Below average")
                    SCP = "Low";
                else if (PIPING_COMPLEXITY == "Above average")
                    SCP = "High";
                else
                    SCP = "Medium";
            }
            else
            {
                if (PIPING_COMPLEXITY == "Above average")
                    SCP = "Medium";
                else
                    SCP = "Low";
            }
            return SCP;
        }
        private String ADJUST_ISULATION()
        {
            String SCP = ADJUST_COMPLEXITY();
            if (SCP == "High")
            {
                if (INSULATION_CONDITION == "Above average")
                    SCP = "Medium";
                else
                    SCP = "High";
            }
            else if (SCP == "Medium")
            {
                if (INSULATION_CONDITION == "Above average")
                    SCP = "Low";
                else if (INSULATION_CONDITION == "Below average")
                    SCP = "High";
                else
                    SCP = "Medium";
            }
            else
            {
                if (INSULATION_CONDITION == "Below average")
                    SCP = "Medium";
                else
                    SCP = "Low";
            }
            return SCP;
        }
        private String ADJUST_CHLORIDE_INSULATION()
        {
            String SCP = ADJUST_ISULATION();
            if (INSULATION_CHLORIDE)
            {
                if (SCP == "High")
                    SCP = "Medium";
                else// if (SCP == "Medium")
                    SCP = "Low";
                //else
                //    SCP = "Low";
            }
            return SCP;
        }
        private float DFB_CUI_CLSCC()
        {
            String FIELD = null;
            String SCP = ADJUST_CHLORIDE_INSULATION();

            int SVI = 1;

            if (SCP == "High")
                SVI = 50;
            else if (SCP == "Medium")
                SVI = 10;
            else
                SVI = 1;

            if (EXTERN_CLSCC_CUI_INSP_EFF == "E" || EXTERN_CLSCC_CUI_INSP_NUM == 0)
                FIELD = "E";
            else
                FIELD = EXTERN_CLSCC_CUI_INSP_NUM + EXTERN_CLSCC_CUI_INSP_EFF;

            return DAL_CAL.GET_TBL_74(SVI, FIELD);
        }
        public float DF_CUI_CLSCC()
        {
            if (AUSTENITIC_STEEL && EXTERNAL_INSULATION && EXTERNAL_EXPOSED_FLUID_MIST && !(MIN_OP_TEMP > 150 || MAX_OP_TEMP < 50))
            {
                return DFB_CUI_CLSCC() * (float)Math.Pow((double)AGE_CLSCC(), 1.1);
            }
            else
                return 0;
        }

        ///<summary>
        /// CAL HTHA
        ///</summary>
        private float HTHA_PV(float age)
        {
            float HTHA_AGE = age * 24 * 365;
            float log1 = (float)Math.Log10(HTHA_PRESSURE / 0.0979);
            float log2 = (float)(3.09 * Math.Pow(10, -4) * (CRITICAL_TEMP + 273) * (Math.Log10(HTHA_AGE) + 14));
            return log1 + log2;
        }
        private String HTHA_SUSCEP(float age)
        {
            float PV = HTHA_PV(age);
            String SUSCEP = null;
            if (HTHA_PRESSURE > 8.274) HTHA_MATERIAL = "1.25Cr-0.5Mo";
            switch (HTHA_MATERIAL)
            {
                case "Carbon Steel":
                    {
                        if (PV > 4.7) SUSCEP = "High";
                        else if (PV > 4.61 && PV <= 4.7) SUSCEP = "Medium";
                        else if (PV > 4.53 && PV <= 4.61) SUSCEP = "Low";
                        else SUSCEP = "Not";
                        break;
                    }
                case "C-0.5Mo (Annealed)":
                    {
                        if (PV > 4.95) SUSCEP = "High";
                        else if (PV > 4.87 && PV <= 4.95) SUSCEP = "Medium";
                        else if (PV > 4.78 && PV <= 4.87) SUSCEP = "Low";
                        else SUSCEP = "Not";
                        break;
                    }
                case "C-0.5Mo (Normalised)":
                    {
                        if (PV > 5.6) SUSCEP = "High";
                        else if (PV > 5.51 && PV <= 5.6) SUSCEP = "Medium";
                        else if (PV > 5.43 && PV <= 5.51) SUSCEP = "Low";
                        else SUSCEP = "Not";
                        break;
                    }
                case "1Cr-0.5Mo":
                    {
                        if (PV > 5.8) SUSCEP = "High";
                        else if (PV > 5.71 && PV <= 5.8) SUSCEP = "Medium";
                        else if (PV > 5.63 && PV <= 5.71) SUSCEP = "Low";
                        else SUSCEP = "Not";
                        break;
                    }
                case "1.25Cr-0.5Mo":
                    {
                        if (PV > 6.0) SUSCEP = "High";
                        else if (PV > 5.92 && PV <= 6.0) SUSCEP = "Medium";
                        else if (PV > 5.83 && PV <= 5.92) SUSCEP = "Low";
                        else SUSCEP = "Not";
                        break;
                    }
                case "2.25Cr-1Mo":
                    {
                        if (PV > 6.53) SUSCEP = "High";
                        else if (PV > 6.45 && PV <= 6.53) SUSCEP = "Medium";
                        else if (PV > 6.36 && PV <= 6.45) SUSCEP = "Low";
                        else SUSCEP = "Not";
                        break;
                    }
                default: SUSCEP = "Not"; break;
            }
            //Debug.WriteLine("Suscep: " + SUSCEP);
            return SUSCEP;
        }
        private int API_DF_HTHA(float age)
        {
            int[] API_HTHA = DAL_CAL.GET_TBL_204(HTHA_SUSCEP(age));
            if (DAMAGE_FOUND)
                return 2000;
            else
            {
                if (HTHA_NUM_INSP == 0)
                    return API_HTHA[0];
                else if (HTHA_NUM_INSP == 1 && HTHA_EFFECT == "D")
                    return API_HTHA[1];
                else if (HTHA_NUM_INSP == 1 && HTHA_EFFECT == "C")
                    return API_HTHA[2];
                else if (HTHA_NUM_INSP == 1 && HTHA_EFFECT == "B")
                    return API_HTHA[3];
                else if (HTHA_NUM_INSP == 2 && HTHA_EFFECT == "D")
                    return API_HTHA[4];
                else if (HTHA_NUM_INSP == 2 && HTHA_EFFECT == "C")
                    return API_HTHA[5];
                else
                    return API_HTHA[6];
            }
        }
        public float DF_HTHA(float age)
        {
            
            if (MATERIAL_SUSCEP_HTHA)
            {
                if (CRITICAL_TEMP <= 204 && HTHA_PRESSURE <= 0.552) //80.06 psi
                    return 1;
                else
                    return API_DF_HTHA(age);
            }
            else
                return 0;
        }

        ///<summary>
        /// CAL BRITTLE
        ///</summary>
        private float DFB_BRITTLE()
        {
            float TEMP_BRITTLE = Math.Min(MIN_DESIGN_TEMP, MIN_OP_TEMP);
            if (PWHT)
                return DAL_CAL.GET_TBL_215(API_TEMP(TEMP_BRITTLE - REF_TEMP), API_SIZE_BRITTLE(BRITTLE_THICK));
            else
                return DAL_CAL.GET_TBL_214(API_TEMP(TEMP_BRITTLE - REF_TEMP), API_SIZE_BRITTLE(BRITTLE_THICK));
        }
        public float DF_BRITTLE()
        {
            if (CARBON_ALLOY && (CRITICAL_TEMP < MIN_DESIGN_TEMP || MAX_OP_TEMP < MIN_DESIGN_TEMP))
            {
                if (LOWEST_TEMP)
                    return DFB_BRITTLE() * 0.01f;
                else
                    return DFB_BRITTLE();
            }
            else
                return 0;
        }

        ///<summary>
        /// CAL TEMP EMBRITTLE
        ///</summary>
        private float API_SIZE_BRITTLE(float SIZE)
        {
            float[] data = { 6.4f, 12.7f, 25.4f, 38.1f, 50.8f, 63.5f, 76.2f, 88.9f, 101.6f };
            if (SIZE < (data[0] + data[1]) / 2)
                return data[0];
            else if (SIZE < (data[1] + data[2]) / 2)
                return data[1];
            else if (SIZE < (data[2] + data[3]) / 2)
                return data[2];
            else if (SIZE < (data[3] + data[4]) / 2)
                return data[3];
            else if (SIZE < (data[4] + data[5]) / 2)
                return data[4];
            else if (SIZE < (data[5] + data[6]) / 2)
                return data[5];
            else if (SIZE < (data[6] + data[7]) / 2)
                return data[6];
            else if (SIZE < (data[7] + data[8]) / 2)
                return data[7];
            else
                return data[8];

        }
        private float API_TEMP(float TEMP)
        {
            float[] data = { -73, -62, -51, -40, -29, -18, -7, 4, 16, 27, 38 };
            if (TEMP < (data[0] + data[1]) / 2)
                return data[0];
            else if (TEMP < (data[1] + data[2]) / 2)
                return data[1];
            else if (TEMP < (data[2] + data[3]) / 2)
                return data[2];
            else if (TEMP < (data[3] + data[4]) / 2)
                return data[3];
            else if (TEMP < (data[4] + data[5]) / 2)
                return data[4];
            else if (TEMP < (data[5] + data[6]) / 2)
                return data[5];
            else if (TEMP < (data[6] + data[7]) / 2)
                return data[6];
            else if (TEMP < (data[7] + data[8]) / 2)
                return data[7];
            else if (TEMP < (data[8] + data[9]) / 2)
                return data[8];
            else if (TEMP < (data[9] + data[10]) / 2)
                return data[9];
            else
                return data[10];
        }
        public float DF_TEMP_EMBRITTLE()
        {
            if (TEMPER_SUSCEP || (CARBON_ALLOY && !(MAX_OP_TEMP < 343 || MIN_OP_TEMP > 577)))
            {
                float TEMP_EMBRITTLE = Math.Min(MIN_DESIGN_TEMP, MIN_OP_TEMP) - (REF_TEMP + DELTA_FATT);
                if (PWHT)
                {
                    return DAL_CAL.GET_TBL_215(API_TEMP(TEMP_EMBRITTLE), API_SIZE_BRITTLE(BRITTLE_THICK));
                }
                else
                    return DAL_CAL.GET_TBL_214(API_TEMP(TEMP_EMBRITTLE), API_SIZE_BRITTLE(BRITTLE_THICK));
            }
            else
                return 0;
        }

        ///<summary>
        /// CAL 885
        ///</summary>
        public float DF_885()
        {
            if (CHROMIUM_12 && !(MIN_OP_TEMP > 566 || MAX_OP_TEMP < 371))
            {
                float TEMP_885 = Math.Min(MIN_DESIGN_TEMP, MIN_OP_TEMP) - REF_TEMP;
                float[] data = { -73, -62, -51, -40, -29, -18, -7, 4, 16, 27, 38 };
                if (TEMP_885 < (data[0] + data[1]) / 2)
                    return 1381;
                else if (TEMP_885 < (data[1] + data[2]) / 2)
                    return 1216;
                else if (TEMP_885 < (data[2] + data[3]) / 2)
                    return 1022;
                else if (TEMP_885 < (data[3] + data[4]) / 2)
                    return 806;
                else if (TEMP_885 < (data[4] + data[5]) / 2)
                    return 581;
                else if (TEMP_885 < (data[5] + data[6]) / 2)
                    return 371;
                else if (TEMP_885 < (data[6] + data[7]) / 2)
                    return 200;
                else if (TEMP_885 < (data[7] + data[8]) / 2)
                    return 87;
                else if (TEMP_885 < (data[8] + data[9]) / 2)
                    return 30;
                else if (TEMP_885 < (data[9] + data[10]) / 2)
                    return 8;
                else
                    return 2;
            }
            else
                return 0;
        }

        ///<summary>
        /// CAL SIGMA
        ///</summary>
        private float API_TEMP_SIGMA()
        {
            float TEMP = 0;
            float[] DATA = { -46, -18, 10, 38, 66, 93, 204, 316, 427, 538, 649 };
            if (MIN_OP_TEMP < (DATA[0] + DATA[1]) / 2)
                TEMP = DATA[0];
            else if (MIN_OP_TEMP < (DATA[1] + DATA[2]) / 2)
                TEMP = DATA[1];
            else if (MIN_OP_TEMP < (DATA[2] + DATA[3]) / 2)
                TEMP = DATA[2];
            else if (MIN_OP_TEMP < (DATA[3] + DATA[4]) / 2)
                TEMP = DATA[3];
            else if (MIN_OP_TEMP < (DATA[4] + DATA[5]) / 2)
                TEMP = DATA[4];
            else if (MIN_OP_TEMP < (DATA[5] + DATA[6]) / 2)
                TEMP = DATA[5];
            else if (MIN_OP_TEMP < (DATA[6] + DATA[7]) / 2)
                TEMP = DATA[6];
            else if (MIN_OP_TEMP < (DATA[7] + DATA[8]) / 2)
                TEMP = DATA[7];
            else if (MIN_OP_TEMP < (DATA[8] + DATA[9]) / 2)
                TEMP = DATA[8];
            else if (MIN_OP_TEMP < (DATA[9] + DATA[10]) / 2)
                TEMP = DATA[9];
            else
                TEMP = DATA[10];
            return TEMP;
        }
        public float DF_SIGMA()
        {
            if (AUSTENITIC_STEEL && !(MIN_OP_TEMP > 927 || MAX_OP_TEMP < 593))
            {
                float TEMP = API_TEMP_SIGMA();
                float DFB_SIGMA = 0;
                if (TEMP == 649)
                {
                    if (PERCENT_SIGMA < 10)
                        DFB_SIGMA = 0;
                    else
                        DFB_SIGMA = 18;
                }
                else if (TEMP == 538)
                {
                    if (PERCENT_SIGMA < 10)
                        DFB_SIGMA = 0;
                    else
                        DFB_SIGMA = 53;
                }
                else if (TEMP == 427)
                {
                    if (PERCENT_SIGMA < 5)
                        DFB_SIGMA = 0;
                    else if (PERCENT_SIGMA >= 5 && PERCENT_SIGMA < 10)
                        DFB_SIGMA = 0.2f;
                    else
                        DFB_SIGMA = 160;
                }
                else if (TEMP == 316)
                {
                    if (PERCENT_SIGMA < 5)
                        DFB_SIGMA = 0;
                    else if (PERCENT_SIGMA >= 5 && PERCENT_SIGMA < 10)
                        DFB_SIGMA = 0.9f;
                    else
                        DFB_SIGMA = 481;
                }
                else if (TEMP == 204)
                {
                    if (PERCENT_SIGMA < 5)
                        DFB_SIGMA = 0;
                    else if (PERCENT_SIGMA >= 5 && PERCENT_SIGMA < 10)
                        DFB_SIGMA = 1.3f;
                    else
                        DFB_SIGMA = 1333;
                }
                else if (TEMP == 93)
                {
                    if (PERCENT_SIGMA < 5)
                        DFB_SIGMA = 0.1f;
                    else if (PERCENT_SIGMA >= 5 && PERCENT_SIGMA < 10)
                        DFB_SIGMA = 3;
                    else
                        DFB_SIGMA = 3202;
                }
                else if (TEMP == 66)
                {
                    if (PERCENT_SIGMA < 5)
                        DFB_SIGMA = 0.3f;
                    else if (PERCENT_SIGMA >= 5 && PERCENT_SIGMA < 10)
                        DFB_SIGMA = 5;
                    else
                        DFB_SIGMA = 3871;
                }
                else if (TEMP == 38)
                {
                    if (PERCENT_SIGMA < 5)
                        DFB_SIGMA = 0.6f;
                    else if (PERCENT_SIGMA >= 5 && PERCENT_SIGMA < 10)
                        DFB_SIGMA = 7;
                    else
                        DFB_SIGMA = 4196;
                }
                else if (TEMP == 10)
                {
                    if (PERCENT_SIGMA < 5)
                        DFB_SIGMA = 0.9f;
                    else if (PERCENT_SIGMA >= 5 && PERCENT_SIGMA < 10)
                        DFB_SIGMA = 11;
                    else
                        DFB_SIGMA = 4196;
                }
                else if (TEMP == -18)
                {
                    if (PERCENT_SIGMA < 5)
                        DFB_SIGMA = 1;
                    else if (PERCENT_SIGMA >= 5 && PERCENT_SIGMA < 10)
                        DFB_SIGMA = 20;
                    else
                        DFB_SIGMA = 4196;
                }
                else
                {
                    if (PERCENT_SIGMA < 5)
                        DFB_SIGMA = 1.1f;
                    else if (PERCENT_SIGMA >= 5 && PERCENT_SIGMA < 10)
                        DFB_SIGMA = 34;
                    else
                        DFB_SIGMA = 4196;
                }
                return DFB_SIGMA;
            }
            else
                return 0;
        }

        ///<summary>
        /// CAL PIPING
        ///</summary>
        private float DFB_PIPE()
        {
            float DFB_PF = 1, DFB_AS = 1, FFB_AS = 1, DFB_CF = 1;
            
            switch(PREVIOUS_FAIL)
            {
                case "Greater than one":
                    DFB_PF = 500;
                    break;
                case "One":
                    DFB_PF = 50;
                    break;
                default:
                    DFB_PF = 1;
                    break;
            }
            
            switch(AMOUNT_SHAKING)
            {
                case "Severe":
                    DFB_AS = 500;
                    break;
                case "Moderate":
                    DFB_AS = 50;
                    break;
                default:
                    DFB_AS = 1;
                    break;
            }
            
            switch(TIME_SHAKING)
            {
                case "13 to 52 weeks":
                    FFB_AS = 0.02f;
                    break;
                case "2 to 13 weeks":
                    FFB_AS = 0.2f;
                    break;
                default:
                    FFB_AS = 1;
                    break;
            }
            
            switch (CYLIC_LOAD)
            {
                case "Reciprocating machinery":
                    DFB_CF = 50;
                    break;
                case "PRV chatter":
                    DFB_CF = 25;
                    break;
                case "Valve with high pressure drop":
                    DFB_CF = 10;
                    break;
                default:
                    DFB_CF = 1;
                    break;
            }
            return Math.Max(DFB_PF, Math.Max(DFB_AS * FFB_AS, DFB_CF));
        }
        public float DF_PIPE()
        {
            if (EquipmentType == "Piping")
            {
                float FCA = 1, FPC = 1, FCP = 1, FJB = 1, FBD = 1;
                switch(CORRECT_ACTION)
                {
                    case "Engineering Analysis":
                        FCA = 0.002f;
                        break;
                    case "Experience":
                        FCA = 0.2f;
                        break;
                    default:
                        FCA = 2;
                        break;
                }
                
                switch(NUM_PIPE)
                {
                    case "Up to 5":
                        FPC = 0.5f;
                        break;
                    case "6 to 10":
                        FPC = 1;
                        break;
                    default:
                        FPC = 2;
                        break;
                }

                switch(PIPE_CONDITION)
                {
                    case "Broken gussets or gussets welded directly to pipe":
                    case "Missing or damage supports, improper support":
                        FCP = 2;
                        break;
                    default:
                        FCP = 1;
                        break;
                }

                switch(JOINT_TYPE)
                {
                    case "Sweepolets":
                        FJB = 0.02f;
                        break;
                    case "Piping tee weldolets":
                        FJB = 0.2f;
                        break;
                    case "Threaded, socket welded, or saddle on":
                        FJB = 2;
                        break;
                    default:
                        FJB = 1;
                        break;
                }
                if (BRANCH_DIAMETER == "All branches greater than 2\" Nominal OD")
                    FBD = 0.02f;
                else
                    FBD = 1;

                return DFB_PIPE() * FCA * FPC * FCP * FJB * FBD;
            }
            else
                return 0;
        }

    }
}
