using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;


namespace chat_cleaning
{
    public partial class Form1 : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]


        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            PnlNav.Height = BtnDashboard.Height;
            PnlNav.Top = BtnDashboard.Top;
            PnlNav.Left = BtnDashboard.Left;
            BtnDashboard.BackColor = Color.FromArgb(46, 51, 73);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // button highlight formatting
            PnlNav.Height = BtnOpenFile.Height;
            PnlNav.Top = BtnOpenFile.Top;
            PnlNav.Left = BtnOpenFile.Left;
            BtnOpenFile.BackColor = Color.FromArgb(46, 51, 73);


            // create an instance of OpenFIleDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // set the file filter to allow only Excel files
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";

            // show the dialog and wait for user to select file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;

                // check if selected file is Excel
                if (selectedFilePath.EndsWith(".xlsx") || selectedFilePath.EndsWith(".xls"))
                {
                    try
                    {
                        Excel.Application exelApp = new Excel.Application();
                        exelApp.Visible = true;
                        Excel.Workbook workbook = exelApp.Workbooks.Open(selectedFilePath);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("An error occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);    
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid excel file.", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // button highlight formatting
            PnlNav.Height = BtnAnalytics.Height;
            PnlNav.Top = BtnAnalytics.Top;
            PnlNav.Left = BtnAnalytics.Left;
            BtnAnalytics.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            // button highlight formatting
            PnlNav.Height = BtnDashboard.Height;
            PnlNav.Top = BtnDashboard.Top;
            PnlNav.Left = BtnDashboard.Left;
            BtnDashboard.BackColor = Color.FromArgb(46, 51, 73);

        }

        private void BtnContacts_Click(object sender, EventArgs e)
        {
            // button highlight formatting
            PnlNav.Height = BtnContacts.Height;
            PnlNav.Top = BtnContacts.Top;
            PnlNav.Left = BtnContacts.Left;
            BtnContacts.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // button highlight formatting
            PnlNav.Height = BtnSettings.Height;
            PnlNav.Top = BtnSettings.Top;
            PnlNav.Left = BtnSettings.Left;
            BtnSettings.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void BtnDashboard_Leave(object sender, EventArgs e)
        {
            BtnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void BtnOpenFile_Leave(object sender, EventArgs e)
        {
            BtnOpenFile.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void BtnAnalytics_Leave(object sender, EventArgs e)
        {
            BtnAnalytics.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void BtnContacts_Leave(object sender, EventArgs e)
        {
            BtnContacts.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void BtnSettings_Leave(object sender, EventArgs e)
        {
            BtnSettings.BackColor = Color.FromArgb(24, 30, 54);
        }
    }
}
