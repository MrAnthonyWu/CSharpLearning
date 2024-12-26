// See https://aka.ms/new-console-template for more information
using MySql.Data.MySqlClient;
using Microsoft.Office.Interop.Excel;
using Data;
using System.Reflection;
using System.Xml.Linq;

class ReadFromDBAndWriteToExcel { 
    static void Main(string[] args)
    {
        var dbCon = DBConnection.Instance();
        dbCon.Server = "localhost";
        dbCon.DatabaseName = "test_schema";
        dbCon.UserName = "root";
        dbCon.Password = "admin";

        if (dbCon.IsConnect())
        {
            //suppose col0 and col1 are defined as VARCHAR in the DB
            string query = "SELECT id,name,class,mark,gender FROM student";
            var cmd = new MySqlCommand(query, dbCon.Connection);
            var reader = cmd.ExecuteReader();

            var app = new Application { Visible = false };
            Workbook workbook = app.Workbooks.Add();
            Worksheet worksheet = app.ActiveSheet;
            worksheet.Name = "Students";
            int row = 1;

            worksheet.Cells[row, 1].Value = "ID";
            worksheet.Cells[row, 2].Value = "Name";
            worksheet.Cells[row, 3].Value = "Class";
            worksheet.Cells[row, 4].Value = "Mark";
            worksheet.Cells[row, 5].Value = "Gender";
            row++;

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string class1 = reader.GetString(2);
                int mark = reader.GetInt32(3);
                string gender = reader.GetString(4);
                Console.WriteLine(id + "," + name);
                worksheet.Cells[row, 1].Value = id;
                worksheet.Cells[row, 2].Value = name;
                worksheet.Cells[row, 3].Value = class1;
                worksheet.Cells[row, 4].Value = mark;
                worksheet.Cells[row, 5].Value = gender;
                row++;
            }
            workbook.SaveAs(Filename: "D:\\work\\student.xls",
                FileFormat: XlFileFormat.xlWorkbookNormal);
            app.Application.Quit();
            dbCon.Close();
        }
    }
}