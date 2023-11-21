﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CsvHelper;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Xml;

namespace AsterixDecoder
{
    public partial class MainWindow : Form
    {
        //Decoding
        //-----------------------------------------------------------

        //Octet position analysed/decoded
        int n_datarecord;
        //All the CAT048 data units decoded
        List<CAT048> elements = new List<CAT048>();
        //Number of csv files that have been done
        int n_outputCSV;

        //Simulation
        //-----------------------------------------------------------

        //For a given AC_ID all the CAT048 objects (data items with the necessary info) associated to it in temporal order
        Dictionary<string, List<CAT048_simulation>> aircraftsList;
        //For a given AC_ID the GMapMarker associated to it
        public Dictionary<string, GMapMarker> aircraftsMarkers;
        //Markers in the map
        GMapOverlay markers;
        //AC icon global for all
        Bitmap ACicon;
        int ACiconSize;

        bool playing;
        DateTime simulationTime;

        //-----------------------------------------------------------
        string projectDirectory;
        UsefulFunctions usefulFunctions = new UsefulFunctions();


        public MainWindow()
        {
            InitializeComponent();

            viewPanel.Visible = false;
            csvGridView.Visible = false;
            progressBar1.Visible = false;
            progressLbl.Visible = false;
            gmap.Visible = false;

            //Logo
            this.projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(projectDirectory, "logo.png");
            pictureBoxLogo.LoadAsync(filePath);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;

            //Logo Label
            title.Font = new Font("Cascadia Code", 16);
            title.Text = "AsTeRiX DeCoDeR";
            title.TextAlign = ContentAlignment.TopCenter;

            //CSV grid 
            generateCSVgrid();
            n_outputCSV = 0;

            

        }

        //Decoding to CSV
        private void generateCSVgrid()
        {
            csvGridView.DefaultCellStyle.Font = new Font("Cascadia Code", 11);
            csvGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            csvGridView.GridColor = SystemColors.ActiveBorder;
            csvGridView.MultiSelect = false;
            csvGridView.ReadOnly = true;
            csvGridView.AllowUserToAddRows = false;
            csvGridView.AllowUserToDeleteRows = false;
            csvGridView.AllowUserToOrderColumns = true;
            csvGridView.AllowUserToResizeColumns = true;
            csvGridView.AllowUserToResizeRows = true;
            csvGridView.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.White
            };
            csvGridView.BackgroundColor = System.Drawing.Color.White;
            csvGridView.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                BackColor = System.Drawing.Color.SteelBlue,
                ForeColor = System.Drawing.Color.White
            };
            csvGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //Decoding to CSV
        private void decodeAll(string path, int init, int final, string resultFileName)
        {
            //Initiate progress bar
            progressBar1.Value = 0;
            progressLbl.Text = "Loading...";
            progressLbl.Visible = true;

            //Decodify
            decodify(path, init, final);

            saveIntoCSV(elements, resultFileName);

            //Visualize CSV in the grid
            string filePath = Path.Combine(this.projectDirectory, resultFileName);
            csvGridView.DataSource = readCSV(filePath);
        }

        private void saveIntoCSV(List<CAT048> things, string resultFileName)
        {
            //Save CSV
            string filePath = Path.Combine(this.projectDirectory, resultFileName);
            using (var writer = new StreamWriter(filePath))

            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords<CAT048>(things);
            }
        }

        //Decoding to CSV
        private void ReportProgess(int percent)
        {
            progressLbl.Visible = true;
            progressBar1.Visible = true;
            progressLbl.Text = "Loading... " + Convert.ToString(percent) + " %";
            progressLbl.Refresh();
            progressBar1.Value = percent;

            if (percent == 100)
            {
                progressLbl.Visible = false;
                progressBar1.Visible = false;
            }
        }

        //Decoding to CSV
        public void decodify(string path, int init, int final)
        {
            byte[] message = File.ReadAllBytes(path);
            int i = 0;

            // Number of total data records in the file
            this.n_datarecord = 0;


            while (i < message.Length)
            {

                //First octet describes the category of the message
                byte cat = message[i];

                //Second and third octets are the data record length
                //Second and third byte equivals to the length of the data record 
                byte b1 = message[i + 1];
                byte b2 = message[i + 2];

                //Getting the length of the message 
                int length_dr = b1 << 8 | b2;

                List<byte> datablock = new List<byte>();
                List<byte> FSPEC = new List<byte>();

                //Identification of the length of each FSPEC. 
                int j = 1;
                byte octet = message[i + 3];
                if (octet % 2 != 0) // This octet is odd (ends in 1) then the next one is included
                {
                    // j = 1;
                    FSPEC.Add(octet);
                    while (octet % 2 != 0) // The last octet ends in 0 indicating there are no more
                    {
                        octet = message[i + 3 + j];
                        FSPEC.Add(octet);
                        j++;
                    }
                }
                else
                {
                    // j = 1;
                    FSPEC.Add(octet);
                }

                //Length of the Asterix record length minus the Cat octet and the 2 length octets 
                while (j < (length_dr - 3))
                {
                    datablock.Add(message[i + j + 3]);
                    j++;
                }

                this.n_datarecord++;
                i = i + length_dr;

                int valProgress = Convert.ToInt32(Convert.ToDouble(i) / message.Length * 100);
                ReportProgess(valProgress);


                if (cat == 48)
                {
                    //Funció per a decodificar la cat48 
                    CAT048 element = new CAT048(FSPEC, datablock, i, 0, n_datarecord);

                    this.elements.Add(element);
                }

                else
                {
                    //Passem olimpicament del missatge
                }

            }

        }

        //Decoding to CSV
        public DataTable readCSV(string filePath)
        {
            DataTable dt = new DataTable();
            string[] lines = System.IO.File.ReadAllLines(filePath);
            if (lines.Length > 0)
            {
                //first line to create header
                string firstLine = lines[0];
                string[] headerLabels = firstLine.Split(',');
                foreach (string headerWord in headerLabels)
                {
                    dt.Columns.Add(new DataColumn(headerWord));
                }
                //For Data
                for (int i = 1; i < lines.Length; i++)
                {
                    string pattern = @"(?<=,|^)(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
                    string[] dataWords = Regex.Split(lines[i], pattern);
                    DataRow dr = dt.NewRow();
                    int columnIndex = 0;

                    foreach (string headerWord in headerLabels)
                    {
                        string cleanedItem = dataWords[columnIndex + 1].Trim('"').Trim(',').Replace('"', ' ');
                        dr[headerWord] = cleanedItem;
                        columnIndex++;
                    }
                    dt.Rows.Add(dr);
                }
            }
            if (dt.Rows.Count > 0)
            {
                csvGridView.DataSource = dt;
            }

            return dt;
        }

        //Decoding to CSV
        private void cSVToolboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hide simulation stuff
            viewPanel.Visible = false;
            gmap.Visible = false;
        }

        //Decoding to CSV
        private void importBinaryFileToDecodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hide simulation stuff
            viewPanel.Visible = false;
            gmap.Visible = false;

            OpenFileDialog ofd = new OpenFileDialog();
            using (ofd)
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string path = ofd.FileName.ToString();

                    if (elements.Count == 0)
                    {
                        decodeAll(path, 0, 0, "output.csv");
                        n_outputCSV = 1;
                    }
                    else
                    {
                        n_outputCSV++;
                        decodeAll(path, 0, 0, "output" + Convert.ToString(n_outputCSV) + ".csv");

                    }

                    msg message = new msg("Your binary code has been correctly decoded. \nYou can find a CSV file in your bin folder :)");
                    message.ShowDialog();

                    csvGridView.Visible = true;
                }
            }
        }

        private void visualizeCSVFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            using (ofd)
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string path = ofd.FileName.ToString();

                    //Visualize CSV in the grid
                    csvGridView.DataSource = readCSV(path);

                    csvGridView.Visible = true;
                }
            }
        }


        //Decoding to CSV
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set initial directory and file name filters if needed
            saveFileDialog.InitialDirectory = this.projectDirectory;
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

            // Show the dialog and check if the user clicked OK
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file name
                string filePath = saveFileDialog.FileName;

                // Your existing code to write to CSV
                using (var writer = new StreamWriter(filePath))
                using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords<CAT048>(elements);
                }

            }

        }

        ///-----------------------------------------SIMULATION-----------------------------------------------

        //Simulation
        private void trajectoriesSimulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hide all the other forms
            csvGridView.Visible = false;

            //View all the ones in the simulator
            viewPanel.Visible = true;

            //Keyboard            
            //Play button
            string imagePath = Path.Combine(this.projectDirectory, "playButton.png");
            playPictureBox.Image = new Bitmap(imagePath);
            playPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            playPictureBox.Visible = true;
            //Back button
            string imagePath2 = Path.Combine(this.projectDirectory, "backButton.png");
            backPictureBox.Image = new Bitmap(imagePath2);
            backPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            backPictureBox.Visible = true;
            //Foward button
            string imagePath3 = Path.Combine(this.projectDirectory, "fowardButton.png");
            fowardPictureBox.Image = new Bitmap(imagePath3);
            fowardPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            fowardPictureBox.Visible = true;

            //Markers overlayed in the map
            markers = new GMapOverlay("markers");
            this.ACiconSize = 30;
            string iconPath = Path.Combine(this.projectDirectory, "aircraft_icon.png");
            ACicon = new Bitmap(new Bitmap(iconPath), new Size(this.ACiconSize, this.ACiconSize));

            //Gmap
            gmap.MapProvider = GMapProviders.GoogleMap;
            gmap.Position = new PointLatLng(41.298, 2.080);
            gmap.MinZoom = 2;
            gmap.MaxZoom = 24;
            gmap.Zoom = 6;
            gmap.AutoScroll = true;
            gmap.DragButton = MouseButtons.Left;
            gmap.CanDragMap = true;

            Controls.Add(gmap);

            speedDecisionBox.SelectedItem = "x 1";
            speedDecisionBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //JUST TO TEST!!
        //Simulation
        private void viewBtn_Click(object sender, EventArgs e)
        {
            gmap.Visible = true;


            gmap.Overlays.Add(markers);
        }

        // Simulation
        private void visualizeCSVFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Set time
            string simTime = hourBox.Text;
            this.simulationTime = DateTime.ParseExact(simTime, "HH:mm:ss", null);

            //Simulation
            this.playing = false;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV files (*.csv)|*.csv|XML files (*.xml)|*.xml";
            using (ofd)
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Generate the dictionary with each AC_ID and its list of data items associated
                        generateACDictionary(ofd.FileName);

                        gmap.Visible = true;

                        //Generate the dictionary with the AC_ID and its associated marker
                        aircraftsMarkers = new Dictionary<string, GMapMarker>();

                        foreach (string id in aircraftsList.Keys)
                        {
                            plotTheCurrentDataItemForAGivenTime(id);                      
                        }

                        //First you generate the markers and then you put it in the map
                        gmap.Overlays.Add(markers);

                    }
                    catch
                    {
                        Console.WriteLine("He petat");
                    }

                }
            }
        }


        //Simulation
        public void generateACDictionary(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            string first_line = reader.ReadLine();
            if (first_line != null)
            {
                CAT048_simulation index_object = new CAT048_simulation(first_line);

                aircraftsList = new Dictionary<string, List<CAT048_simulation>>();

                int numlines = System.IO.File.ReadAllLines(filename).Length;
                int num = 1;
                string nextLine = reader.ReadLine();
                while (nextLine != null)
                {
                    CAT048_simulation aircraft = new CAT048_simulation(nextLine, index_object);

                    int valProgress = Convert.ToInt32(Convert.ToDouble(num) / numlines * 100);
                    ReportProgess(valProgress);
                    num++;

                    // Check if the AC_ID is already in
                    if (aircraftsList.ContainsKey(aircraft.AC_ID))
                    {
                        // Add the element to the existing list
                        aircraftsList[aircraft.AC_ID].Add(aircraft);

                    }
                    else
                    {
                        // If the category doesn't exist, create a new category with the element
                        aircraftsList.Add(aircraft.AC_ID, new List<CAT048_simulation> { aircraft });
                    }

                    nextLine = reader.ReadLine();
                }

            }
        }

        

        //Simulator
        private void playPictureBox_Click(object sender, EventArgs e)
        {
            //If it is playing and you click
            if (playing)
            {
                //Not playing any more
                this.playing = !playing;

                //Now the button tells you to play it again
                string imagePath = Path.Combine(this.projectDirectory, "playButton.png");
                playPictureBox.Image = new Bitmap(imagePath);

                timer1.Stop();
            }
            else
            {
                this.playing = !playing;
                //Play button
                string imagePath = Path.Combine(this.projectDirectory, "pauseButton.png");
                playPictureBox.Image = new Bitmap(imagePath);

                //Set timer interval
                speedDecisionBox_SelectedIndexChanged(sender, e);

                timer1.Start();

                //Set time
                string simTime = hourBox.Text;
                this.simulationTime = DateTime.ParseExact(simTime, "HH:mm:ss", null);

            }

        }

        //Simulator

        // Code to be executed on each timer tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Set time in case the our is changed manually
            string simTime = hourBox.Text;
            this.simulationTime = DateTime.ParseExact(simTime, "HH:mm:ss", null);

            //Change hour
            this.simulationTime = this.simulationTime.AddSeconds(timer1.Interval/1000);
            hourBox.Text = this.simulationTime.TimeOfDay.ToString();
            hourBox.Refresh();

                           
            foreach (string id in aircraftsList.Keys)
            {
                plotTheCurrentDataItemForAGivenTime(id);
            } 

        }


        private void saveTrajectoriesInKMLFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            using (ofd)
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName.ToString();

                    List<CAT048> list;

                    //Read the CSV
                    using (var reader = new StreamReader(filePath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        list = csv.GetRecords<CAT048>().ToList();
                        
                        Console.WriteLine(list.Count);
                    }

                    //Generate a KML file
                    var settings = new XmlWriterSettings
                    {
                        Indent = true
                    };

                    string kmlFilePath = Path.Combine(this.projectDirectory, "test.kml");

                    using (var writer = XmlWriter.Create(kmlFilePath, settings))
                    {
                        writer.WriteStartElement("kml", "http://www.opengis.net/kml/2.2");
                        writer.WriteStartElement("Document");

                        foreach (var item in list)
                        {
                            Console.WriteLine(item.Latitude);
                            Console.WriteLine(item.Longitude);

                            writer.WriteStartElement("Placemark");
                            writer.WriteElementString("name", item.AC_ID);
                            writer.WriteElementString("description","Address - "+ item.AC_Adress);
                            writer.WriteStartElement("Point");
                            writer.WriteElementString("coordinates", $"{item.Longitude.Replace(",", ".")},{item.Latitude.Replace(",", ".")}");
                            writer.WriteEndElement(); // End Point
                            writer.WriteEndElement(); // End Placemark
                        }

                        writer.WriteEndElement(); // End Document
                        writer.WriteEndElement(); // End kml
                    }
                }




            }


        }

        private void speedDecisionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = speedDecisionBox.Items[speedDecisionBox.SelectedIndex].ToString();
            string factor = selectedItem.Split(' ')[1];
            Console.WriteLine(factor);
            int interval = Convert.ToInt32(4000.0m / Convert.ToDecimal(factor));

            if (interval == 800)
            {
                interval = interval * 10;
            }
            if (interval == 267)
            {
                interval = 3000;
            }

            timer1.Interval = interval;

            Console.WriteLine(timer1.Interval);
        }


        private void plotTheCurrentDataItemForAGivenTime(string AC_ID)
        {
            bool found = false;
            int initialDataItem = 0;
            while (!found)
            {
                if (initialDataItem < aircraftsList[AC_ID].Count)
                {
                    found = usefulFunctions.isDateBetween(simulationTime, simulationTime.AddSeconds(timer1.Interval), aircraftsList[AC_ID][initialDataItem].UTCTime);

                    if (found)
                    {
                        double latt = Convert.ToDouble(aircraftsList[AC_ID][initialDataItem].Latitude);
                        double lonn = Convert.ToDouble(aircraftsList[AC_ID][initialDataItem].Longitude);

                        PointLatLng newPosition = new PointLatLng(latt, lonn);

                        if (aircraftsMarkers.ContainsKey(AC_ID))
                        {
                            aircraftsMarkers[AC_ID].Position = newPosition;
                        }
                        else
                        {
                            //Generate the bitmap with the aircraft image and its ID
                            Bitmap bitmap = usefulFunctions.AddTextBelowImage(ACicon, AC_ID);

                            GMapMarker marker = new GMarkerGoogle(
                                newPosition, //Position
                                bitmap);

                            //Associate the AC_ID to its marker
                            aircraftsMarkers.Add(AC_ID, marker);

                            //Add the marker to the gmap
                            markers.Markers.Add(marker);
                        }
                    }

                    initialDataItem++;
                }
                else
                {
                    found = true;
                }

            }
        }


    }
}
