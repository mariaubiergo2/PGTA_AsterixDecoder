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

        //Variables that define the flight trajectory
        public DateTime UTCTime { get; set; }
        public string ground_speed { get; set; }
        public string Flight_Level { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string AC_ID { get; set; }
        public string TAS { get; set; }

        public string heading { get; set; }


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

            this.Flight_Level = values[index_object.Flight_Level_index + 1].Trim(charsToTrim);

            this.ground_speed = values[index_object.gspeed_index + 1].Trim(charsToTrim);

            this.AC_ID = values[index_object.AC_ID_index + 1].Trim(charsToTrim);

            this.TAS = values[index_object.TAS_index + 1].Trim(charsToTrim);

            this.heading = values[index_object.heading_index + 1].Trim(charsToTrim);

        }

    }
}
