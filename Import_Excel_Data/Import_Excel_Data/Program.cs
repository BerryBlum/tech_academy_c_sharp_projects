using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import_Excel_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = @"C:\Users\Myuri\Desktop\Sample_Database.xlsx";
            OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.16.0;Driver={Microsoft Excel Driver(*.xls, *.xlsx, *.xlsm, *.xlsb)};Data Source='C:\Users\Myuri\Desktop\Sample_Database.xlsx';");
            connection.Open();
            DataTable sample_sheet = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
            DataSet set = new DataSet();
            DataTable table;

            for (int i = 0; i <= sample_sheet.Rows.Count; i++)
            {
                table = buildDataset(file, sample_sheet.Rows[i]["Table"].ToString());
                set.Tables.Add(table);
            }
        }
        private static DataTable buildDataset(string file, string sheet)
        {
            OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.16.0; Driver ={ Microsoft Excel Driver(*.xls, *.xlsx, *.xlsm, *.xlsb) }; DBQ =" + file + "");
            DataTable importTable = new DataTable();
            OleDbDataAdapter importCommand = new OleDbDataAdapter("Select * From[" + sheet + "$]", connection);
            importCommand.Fill(importTable);
            return importTable;
        }
    }
}
