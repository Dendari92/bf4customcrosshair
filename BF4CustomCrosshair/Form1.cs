using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BF4CustomCrosshair
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBar1, trackBar1.Value + "");
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            //
            Char nul = (char)0;
            Char tab = (char)9;
            //
            //
            String XhairSize = "CrosshairSize" + nul + tab + nul + nul + nul;
            String XhairVisibility = "CrosshairVisibility" + nul + tab + nul + nul + nul;
            String XhairColorR = "CrosshairColorR" + nul + tab + nul + nul + nul;
            String XhairColorG = "CrosshairColorG" + nul + tab + nul + nul + nul;
            String XhairColorB = "CrosshairColorB" + nul + tab + nul + nul + nul;
            //
            String settingFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Battlefield 4\\settings\\PROFSAVE";
            using (StreamReader fileReader = new StreamReader(settingFile))
            {
                String line = fileReader.ReadToEnd();
                if (line.Contains(XhairSize))
                {
                    String newLine = line.Substring(line.IndexOf(XhairSize) + 18, 8).Replace('.', ',');
                    trackBar1.Value = Convert.ToInt16(Convert.ToDecimal(newLine)) * 100;
                }  
                if (line.Contains(XhairVisibility))
                {
                    String newLine = line.Substring(line.IndexOf(XhairVisibility) + 24, 8).Replace('.', ',');
                    trackBar2.Value = Convert.ToInt16(Convert.ToDecimal(newLine)) * 100;
                }
                if (line.Contains(XhairColorR))
                {
                    String newLine = line.Substring(line.IndexOf(XhairColorR) + 20, 8).Replace('.', ',');                
                    trackBar3.Value = Convert.ToInt16(((Convert.ToDecimal(newLine) * 100) * 255) / 100);
                }
                if (line.Contains(XhairColorG))
                {
                    String newLine = line.Substring(line.IndexOf(XhairColorG) + 20, 8).Replace('.', ',');
                    trackBar4.Value = Convert.ToInt16(((Convert.ToDecimal(newLine) * 100) * 255) / 100);
                }
                if (line.Contains(XhairColorB))
                {
                    String newLine = line.Substring(line.IndexOf(XhairColorB) + 20, 8).Replace('.', ',');
                    trackBar5.Value = Convert.ToInt16(((Convert.ToDecimal(newLine) * 100) * 255) / 100);
                }
            }
            //
            toolTip1.SetToolTip(trackBar1, trackBar1.Value + "");
            toolTip1.SetToolTip(trackBar2, trackBar2.Value + "");
            toolTip1.SetToolTip(trackBar3, trackBar3.Value + "");
            toolTip1.SetToolTip(trackBar4, trackBar4.Value + "");
            toolTip1.SetToolTip(trackBar5, trackBar5.Value + "");
            textBox1.ForeColor = Color.FromArgb(trackBar3.Value, trackBar4.Value, trackBar5.Value);
            //
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBar2, trackBar2.Value + "");
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBar3, trackBar3.Value + "");
            textBox1.ForeColor = Color.FromArgb(trackBar3.Value, trackBar4.Value, trackBar5.Value);
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBar4, trackBar4.Value + "");
            textBox1.ForeColor = Color.FromArgb(trackBar3.Value, trackBar4.Value, trackBar5.Value);
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBar5, trackBar5.Value + "");
            textBox1.ForeColor = Color.FromArgb(trackBar3.Value, trackBar4.Value, trackBar5.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            String XhairSize = ("GstGameplay.CrosshairSize " + (Convert.ToDecimal(trackBar1.Value) / 100));
            String XhairVisibility = ("GstGameplay.CrosshairVisibility " + (Convert.ToDecimal(trackBar2.Value) / 100));
            String XhairColorR = ("GstGameplay.CrosshairColorR " + ((((Convert.ToDecimal(trackBar3.Value) / 100) / 255) * 100).ToString("F")));
            String XhairColorG = ("GstGameplay.CrosshairColorG " + ((((Convert.ToDecimal(trackBar4.Value) / 100) / 255) * 100).ToString("F")));
            String XhairColorB = ("GstGameplay.CrosshairColorB " + ((((Convert.ToDecimal(trackBar5.Value) / 100) / 255) * 100).ToString("F")));
            //
            //
            int checkSize = 0;
            int checkVisibility = 0;
            int checkColorR = 0;
            int checkColorG = 0;
            int checkColorB = 0;
            //
            //
            String settingFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Battlefield 4\\settings\\PROFSAVE_profile";
            using (StreamReader fileReader = new StreamReader(settingFile))
            {
                String line = fileReader.ReadToEnd();
                if (line.Contains(XhairSize.Replace(',', '.')))
                {
                    checkSize = 1;
                }
                if (line.Contains(XhairVisibility.Replace(',', '.')))
                {
                    checkVisibility = 1;
                }
                if (line.Contains(XhairColorR.Replace(',', '.')))
                {
                    checkColorR = 1;
                }
                if (line.Contains(XhairColorG.Replace(',', '.')))
                {
                    checkColorG = 1;
                }
                if (line.Contains(XhairColorB.Replace(',', '.')))
                {
                    checkColorB = 1;
                }
            }
            FileStream fs = null;
            try
            {
                fs = new FileStream(settingFile, FileMode.Append);
                using (StreamWriter fileWriter = new StreamWriter(fs))
                {
                    
                    if (checkSize == 0)
                    {
                        fileWriter.WriteLine();
                        fileWriter.Write(XhairSize.Replace(',', '.'));
                    } 
                    if (checkVisibility == 0)
                    {
                        fileWriter.WriteLine();
                        fileWriter.Write(XhairVisibility.Replace(',', '.'));
                    }
                    if (checkColorR == 0)
                    {
                        fileWriter.WriteLine();
                        fileWriter.Write(XhairColorR.Replace(',', '.'));
                    }
                    if (checkColorG == 0)
                    {
                        fileWriter.WriteLine();
                        fileWriter.Write(XhairColorG.Replace(',', '.'));
                    }
                    if (checkColorB == 0)
                    {
                        fileWriter.WriteLine();
                        fileWriter.Write(XhairColorB.Replace(',', '.'));
                    }
                }
            }
            finally
            {
                if (fs != null)
                    fs.Dispose();
            }
            MessageBox.Show("Operation complete!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
