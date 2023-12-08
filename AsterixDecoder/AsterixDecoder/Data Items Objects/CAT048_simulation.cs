using System;
using System.Text.RegularExpressions;

namespace AsterixDecoder
{
    class CAT048_simulation
    {
        //Indexes for the information in the line that we are interested in to plot
        public int gspeed_index { get; }
        public int UTCTime_index { get; }
        public int Flight_Level_index { get; }
        public int Latitude_index { get; }
        public int Longitude_index { get; }
        public int AC_ID_index { get; }
        public int TAS_index { get; }
        public int heading_index { get; }
        public int AC_Adress_index { get; }
        public int Mode_3A_index { get; }
        public int TYP_index { get; }
        public int ModeC_corrected_index { get; }

        //Variables that define the flight trajectory
        public DateTime UTCTime { get; set; }
        public string ground_speed { get; set; }
        public string Flight_Level { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string AC_ID { get; set; }
        public string TAS { get; set; }
        public string heading { get; set; }
        public string AC_Adress { get; set; }
        public string Mode_3A { get; set; }
        public string TYP { get; set; }
       

    public CAT048_simulation()
        {

        }

        public CAT048_simulation(string variables_line)
        {
            string[] variables = variables_line.Split(',');

            //Get variables that we want index
            int index = 0;
            while (index < variables.Length)
            {
                if (variables[index] == "UTCTime")
                {
                    this.UTCTime_index = index;
                }
                if (variables[index] == "Latitude")
                {
                    this.Latitude_index = index;
                }
                if (variables[index] == "Longitude")
                {
                    this.Longitude_index = index;
                }
                if (variables[index] == "Flight_Level")
                {
                    this.Flight_Level_index = index;
                }                
                if (variables[index] == "ground_speed")
                {
                    this.gspeed_index = index;
                }
                if (variables[index] == "AC_ID")
                {
                    this.AC_ID_index = index;
                }
                if (variables[index] == "TAS")
                {
                    this.TAS_index = index;
                }
                if (variables[index] == "heading")
                {
                    this.heading_index = index;
                }
                if (variables[index] == "AC_Adress")
                {
                    this.AC_Adress_index = index;
                }
                if (variables[index] == "Mode_3A")
                {
                    this.Mode_3A_index = index;
                }
                if (variables[index] == "TYP")
                {
                    this.TYP_index = index;
                }
                if (variables[index] == "ModeC_corrected")
                {
                    this.ModeC_corrected_index = index;
                }

                index++;
            }
        }

        public CAT048_simulation(string line, CAT048_simulation index_object)
        {
            string pattern = @"(?<=,|^)(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
            string[] values = Regex.Split(line, pattern);

            char[] charsToTrim = { '*', ' ', '\'', '/', '"', '\\', ',', '"' };

            string time = values[index_object.UTCTime_index + 1].Trim(charsToTrim);

            this.UTCTime = DateTime.ParseExact(time, "HH:mm:ss:fff", null); ;  

            this.Latitude = values[index_object.Latitude_index + 1].Trim(charsToTrim);

            this.Longitude = values[index_object.Longitude_index + 1].Trim(charsToTrim);

            if (values[index_object.ModeC_corrected_index + 1].Trim(charsToTrim) != " ")
            {
                this.Flight_Level = values[index_object.ModeC_corrected_index + 1].Trim(charsToTrim);                
            }
            
            if ((this.Flight_Level) == "")
            {
                if (values[index_object.Flight_Level_index + 1].Trim(charsToTrim) != "N/A")
                {
                    string fl = values[index_object.Flight_Level_index + 1].Trim(charsToTrim);
                    float fl2 = float.Parse(fl) * 100;
                    this.Flight_Level = Convert.ToString(fl2);
                }
                else
                {
                    this.Flight_Level = "0.";
                }
            }

            this.ground_speed = values[index_object.gspeed_index + 1].Trim(charsToTrim);

            this.AC_ID = values[index_object.AC_ID_index + 1].Trim(charsToTrim);

            this.TAS = values[index_object.TAS_index + 1].Trim(charsToTrim);

            this.heading = values[index_object.heading_index + 1].Trim(charsToTrim);

            this.AC_Adress = values[index_object.AC_Adress_index + 1].Trim(charsToTrim);

            this.TYP = values[index_object.TYP_index + 1].Trim(charsToTrim);

            this.Mode_3A = values[index_object.Mode_3A_index + 1].Trim(charsToTrim);
        }

        public CAT048_simulation(CAT048 raw)
        {
            this.UTCTime = DateTime.ParseExact(raw.UTCTime, "HH:mm:ss:fff", null); ;

            this.Latitude = raw.Latitude;

            this.Longitude = raw.Longitude;

            if (raw.ModeC_corrected != " ")
            {
                this.Flight_Level = raw.ModeC_corrected;
            }

            if (this.Flight_Level == "")
            {
                if (raw.Flight_Level != "N/A")
                {
                    string fl = raw.Flight_Level;
                    float fl2 = float.Parse(fl) * 100;
                    this.Flight_Level = Convert.ToString(fl2);
                }
                else
                {
                    this.Flight_Level = "0.";
                }
            }

            this.ground_speed = raw.ground_speed;

            this.AC_ID = raw.AC_ID;

            this.TAS = raw.TAS;

            this.heading = raw.heading;

            this.AC_Adress = raw.AC_Adress;

            this.TYP = raw.TYP;

            this.Mode_3A = raw.Mode_3A;
        }

    }
}
