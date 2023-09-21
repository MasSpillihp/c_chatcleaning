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

namespace chat_cleaning
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
    }
}
