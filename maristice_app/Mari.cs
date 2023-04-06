using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace maristice_app
{
    public partial class Mari : Form
    {
        static ProcessMemory pm = new ProcessMemory();
        string dFile;
        static string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string path = appdata + @"\FkMaristice\pos.cfg";

        public Mari()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void Mari_Load(object sender, EventArgs e)
        {
            string x, y;

            if (!Directory.Exists(appdata + @"\FkMaristice"))
                Directory.CreateDirectory(appdata + @"\FkMaristice");

            if (File.Exists(path)) //check if pos.cfg exists
            {
                using (StreamReader sr = System.IO.File.OpenText(path))
                {
                    x = sr.ReadLine();
                    y = sr.ReadLine();
                }
                Location = new Point(int.Parse(x), int.Parse(y)); //place application at the same position it was in the last time
            }

            Load_Saves();
        }

        private void Mari_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (StreamWriter sw = System.IO.File.CreateText(path)) //saving application's position upon closing
            {
                sw.WriteLine(Location.X);
                sw.WriteLine(Location.Y);
            }
        }

        void Load_Saves()
        {
            //check saves placed in the saves folder and puts them in listbox
            if(Directory.Exists(@"saves"))
            {
                string[] files = Directory.GetFiles(@"saves", "*.dat", SearchOption.TopDirectoryOnly); //stores all files in string tab
                for (int i=0;i<files.Length;i++)
                {
                    files[i] = files[i].Remove(0, 6); //gets rid of the first 6 characters -> saves\
                    files[i] = files[i].Remove(files[i].Length - 4); //gets rid of the 4 last characters -> .dat
                    listBox.Items.Add(files[i]);
                }
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            Load_Saves();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            byte[] buffer;

            if (textBoxLives.Text != "")
            {
                buffer = BitConverter.GetBytes(int.Parse(textBoxLives.Text));
                pm.WriteMaristice(0xFB598, buffer);
            }

            if (textBoxBlue.Text != "")
            {
                buffer = BitConverter.GetBytes(int.Parse(textBoxBlue.Text));
                pm.WriteMaristice(0xFB528, buffer);
            }

            if (textBoxYellow.Text != "")
            {
                buffer = BitConverter.GetBytes(int.Parse(textBoxYellow.Text));
                pm.WriteMaristice(0xFB52C, buffer);
            }

            if (textBoxPurple.Text != "")
            {
                buffer = BitConverter.GetBytes(int.Parse(textBoxPurple.Text));
                pm.WriteMaristice(0xFB524, buffer);
            }

            if (textBoxGreen.Text != "")
            {
                buffer = BitConverter.GetBytes(int.Parse(textBoxGreen.Text));
                pm.WriteMaristice(0xFB520, buffer);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            dFile = @"dat\save.dat";

            if (listBox.Text != "")
            {
                string sFile = @"saves\" + listBox.Text + ".dat";

                if (File.Exists(sFile))
                {
                    File.Delete(dFile);

                    File.Copy(sFile, dFile);
                    labelSave.Text = listBox.Text + " loaded";
                }
                else
                    labelSave.Text = "Save doesn't exist!";
            }
            else
                labelSave.Text = "Select a save!";
        }
    }
}
