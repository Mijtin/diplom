using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace diploom
{
    internal class car
    {
        public int id { get; set; }

        private string GosNumber, YearNumber, RudderPosition, TCNumber, Power_Engin, Weight, Full_Engin, Type_Engin, Type_privod, Eco_class, Optinal, VIN;
        public string gosNumber { get { return GosNumber; } set { GosNumber = value; } }
        public string yearNumber { get { return YearNumber; } set { YearNumber = value; } }
        public string rudderPosition { get { return RudderPosition; } set { RudderPosition = value; } }
        public string tCNumber { get { return TCNumber; } set { TCNumber = value; } }
        public string power_Engin { get { return Power_Engin; } set { Power_Engin = value; } }
        public string weight { get { return Weight; } set { Weight = value; } }
        public string full_Engin { get { return Full_Engin; } set { Full_Engin = value; } }
        public string type_Engin { get { return Type_Engin; } set { Type_Engin = value; } }
        public string type_privod { get { return Type_privod; } set { Type_privod = value; } }
        public string eco_class { get { return Eco_class; } set { Eco_class = value; } }

        public string optinal { get { return Optinal; } set { Optinal = value; } }
        public string vin { get { return VIN; } set { VIN = value; } }



        public car() { }

        public car(string GosNumber,string YearNumber, string RudderPosition, string TCNumber, string Power_Engin, string Weight, string Full_Engin, string Type_Engin, string Type_privod, string Eco_class, string Optinal,string VIN)
        {
            this.id = id;
            this.GosNumber = GosNumber;
            this.YearNumber = YearNumber;
            this.RudderPosition = RudderPosition;
            this.TCNumber = TCNumber;
            this.Power_Engin= Power_Engin;
            this.Weight = Weight;
            this.Full_Engin= Full_Engin;
            this.Type_Engin = Type_Engin;
            this.Type_privod= Type_privod;
            this.Eco_class= Eco_class;
            this.Optinal = Optinal;
            this.VIN = VIN;
        }

    }
}
