using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Linq;

namespace Assessment
{
    public partial class MapCSV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ReadCsvFile();

                //Entity Framework  LINQ and Lamda Expression
                var result = dt
                 .AsEnumerable()
                .Where(myRow => myRow.Field<int>("ID") == 1001);

                grdCSVMap.DataSource = dt;
                grdCSVMap.DataBind();
            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message;
            }
        }
        public DataTable ReadCsvFile()
        {

            DataTable dtCsv = new DataTable();
            string Fulltext;
            if (FileUpload1.HasFile)
            {
                string FileSaveWithPath = Server.MapPath("Employee.csv");
                FileUpload1.SaveAs(FileSaveWithPath);
                using (StreamReader sr = new StreamReader(FileSaveWithPath))
                {
                    while (!sr.EndOfStream)
                    {
                        Fulltext = sr.ReadToEnd().ToString(); //read full file text  
                        string[] rows = Fulltext.Split('\n'); //split full file text into rows  
                        for (int i = 0; i < rows.Length - 1; i++)
                        {
                            string[] rowValues = rows[i].Split(','); //split each row with comma to get individual values  
                            {
                                if (i == 0)
                                {
                                    for (int j = 0; j < rowValues.Length; j++)
                                    {
                                        dtCsv.Columns.Add(rowValues[j]); //add headers  
                                    }
                                }
                                else
                                {
                                    DataRow dr = dtCsv.NewRow();
                                    for (int k = 0; k < rowValues.Length; k++)
                                    {
                                        dr[k] = rowValues[k].ToString();
                                    }
                                    dtCsv.Rows.Add(dr); //add other rows  
                                }
                            }
                        }
                    }
                }
            }
            return dtCsv;
        }
    }

    //Created EmployeeValues class to Map the csv values to Business entities

    class EmployeeValues
    {
        int ID;
        string FirstName;
        string LastName;
        string Salary;
        string City;

        public static EmployeeValues FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            EmployeeValues EmployeeValues = new EmployeeValues();
            EmployeeValues.ID = Convert.ToInt32(values[0]);
            EmployeeValues.FirstName = Convert.ToString(values[1]);
            EmployeeValues.LastName = Convert.ToString(values[2]);
            EmployeeValues.City = Convert.ToString(values[3]);
            EmployeeValues.Salary = Convert.ToString(values[4]);
           return EmployeeValues;
        
    }
}
}