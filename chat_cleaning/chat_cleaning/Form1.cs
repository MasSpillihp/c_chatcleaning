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


            // Create an instance of OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the file filter to allow only Excel files
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";

            // Show the dialog and wait for the user to select a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;

                // Check if the selected file is an Excel file
                if (selectedFilePath.EndsWith(".xlsx") || selectedFilePath.EndsWith(".xls"))
                {
                    try
                    {
                        // Create a new Excel Application
                        Excel.Application excelApp = new Excel.Application();
                        excelApp.Visible = false; // Set to true to make Excel visible (for debugging)

                        // Open the Excel workbook
                        Excel.Workbook workbook = excelApp.Workbooks.Open(selectedFilePath);

                        // Assuming the first worksheet contains the data
                        Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

                        // Get the used range of the worksheet
                        Excel.Range usedRange = worksheet.UsedRange;

                        // Get the number of rows and columns in the used range
                        int rowCount = usedRange.Rows.Count;
                        int colCount = usedRange.Columns.Count;

                        // Create a DataTable to store the Excel data
                        DataTable excelDataTable = new DataTable();

                        // Add columns to the DataTable based on the Excel data
                        for (int i = 1; i <= colCount; i++)
                        {
                            excelDataTable.Columns.Add("Column" + i);
                        }

                        // Populate the DataTable with data from Excel
                        for (int row = 1; row <= rowCount; row++)
                        {
                            DataRow dataRow = excelDataTable.NewRow();
                            for (int col = 1; col <= colCount; col++)
                            {
                                dataRow[col - 1] = usedRange.Cells[row, col].Value;
                            }
                            excelDataTable.Rows.Add(dataRow);
                        }

                        // Bind the DataTable to the DataGridView to display the data
                        dataGridView1.DataSource = excelDataTable;

                        // Close the Excel workbook and release resources
                        workbook.Close();
                        Marshal.ReleaseComObject(workbook);
                        excelApp.Quit();
                        Marshal.ReleaseComObject(excelApp);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid Excel file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button1_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
