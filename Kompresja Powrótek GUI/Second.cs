using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kompresja_Powrótek_GUI
{
    public partial class Second : Form
    {
        public Second()
        {
            InitializeComponent();

            // Ścieżki
            InitalizeFolderTextBoxes();
            InitalizeResolutionComboBox();

        }

        private void InitalizeFolderTextBoxes()
        {
            textBoxInputFolder.Text = "C:\\Users\\macie\\Wideo Lokalne\\OBS Studio\\Klipy 1080p";
            textBoxOutputFolder.Text = "C:\\Users\\macie\\Wideo Lokalne\\OBS Studio\\Klipy 360p";
        }

        private void InitalizeResolutionComboBox()
        {
            comboBoxResolution.Items.Add("640x360");
            comboBoxResolution.Items.Add("854x480");
            comboBoxResolution.Items.Add("1280x720");
            comboBoxResolution.Items.Add("1920x1080");
            comboBoxResolution.SelectedIndex = 0;
        }

        private void buttonInputFolder_Click(object sender, EventArgs e)
        {
            /*
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Wybierz folder docelowy";
            dialog.ShowDialog();

            textBox1.Text = dialog.SelectedPath;
        */
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "";
            dialog.Multiselect = false;
            dialog.Title = "XDDD";
            dialog.CheckPathExists = true;
            
            dialog.ShowDialog();

            textBoxInputFolder.Text = dialog.FileName;
        }
    }
}
