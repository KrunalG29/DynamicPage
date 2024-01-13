using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tutorials.Practice
{
    public partial class T10_LinQ : COMM_SessionCheck
    {
        public DataTable Employee = new DataTable();
        public DataTable User = new DataTable();
        public string Date = "Date";
        public string Code = "Code";
        public string Name = "Name";
        public string DOB = "DOB";
        public string Department = "Department";
        public string Salary = "Salary";
        public string City = "City";
        public string State = "State";
        public string Password = "Password";
        public string id = "id";
        public string TotalSal = "Total Salary";

        protected void Page_Load(object sender, EventArgs e)
        {
            EmployeeMaster();
            UserMaster();
            GridView2.DataSource = Employee;
            GridView2.DataBind();
            GridView3.DataSource = User;
            GridView3.DataBind();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            div_getcode.Visible = true;
            GridView1.Visible = true;
            GridView3.Visible = false;
            lbl.Visible = false;
            lbl_que.Visible = true;

            if (RadioButtonList1.SelectedValue == "1")
            {
                SelectLinQAll(1); // Select All
            }
            else if (RadioButtonList1.SelectedValue == "2")
            {
                SelectLinQTop1(1); // Select Top1
            }
            else if (RadioButtonList1.SelectedValue == "3")
            {
                SelectLinQOrderBy(1); // Select Order By
            }
            else if (RadioButtonList1.SelectedValue == "4")
            {
                SelectLinQGroupBySum(1); // Select Group By One Column (Sum)
            }
            else if (RadioButtonList1.SelectedValue == "5")
            {
                SelectLinQGroupByMutipleSum(1); // Select Group By Multiple Column (Sum)
            }
            else if (RadioButtonList1.SelectedValue == "6")
            {
                SelectLinQSum(1); // Select (Sum)
            }
            else if (RadioButtonList1.SelectedValue == "7")
            {
                SelectLinQGroupByCount(1); // Select Group By One Column (Count)
            }
            else if (RadioButtonList1.SelectedValue == "8")
            {
                SelectLinQGroupByMutipleCount(1); // Select Group By Multiple Column (Count)
            }
            else if (RadioButtonList1.SelectedValue == "9")
            {
                LeftJoinLinQ(1); // Left JOin
            }

        }

        protected void btnGetCode_Click(object sender, EventArgs e)
        {
            TextBox2.Visible = true;
            lbl_que.Visible = true;
            RadioButtonList1.Enabled = false;
            if (RadioButtonList1.SelectedValue == "1")
            {
                SelectLinQAll(2); // Select Allkk
            }
            else if (RadioButtonList1.SelectedValue == "2")
            {
                SelectLinQTop1(2); // Select Top1
            }
            else if (RadioButtonList1.SelectedValue == "3")
            {
                SelectLinQOrderBy(2); // Select Order By
            }
            else if (RadioButtonList1.SelectedValue == "4")
            {
                SelectLinQGroupBySum(2); // Select Group By One Column (Sum)
            }
            else if (RadioButtonList1.SelectedValue == "5")
            {
                SelectLinQGroupByMutipleSum(2); // Select Group By Multiple Column (Sum)
            }
            else if (RadioButtonList1.SelectedValue == "6")
            {
                SelectLinQSum(2); // Select (Sum)
            }
            else if (RadioButtonList1.SelectedValue == "7")
            {
                SelectLinQGroupByCount(2); // Select Group By One Column (Count)
            }
            else if (RadioButtonList1.SelectedValue == "8")
            {
                SelectLinQGroupByMutipleCount(2); // Select Group By Multiple Column (Count)
            }
            else if (RadioButtonList1.SelectedValue == "9")
            {
                LeftJoinLinQ(2); // Left JOin
            }
        }

        // 1 To 8
        #region Select All
        public void SelectLinQAll(int flag)
        {
            lbl_que.Text = "# Get All Employee Data";
            if (flag == 1)
            {
                var querySelectLinQ = from Emp in Employee.AsEnumerable()
                                      select new
                                      {
                                          Date = Emp.Field<DateTime>("date"),
                                          Code = Emp.Field<string>("emp_code"),
                                          Name = Emp.Field<string>("emp_name"),
                                          DOB = Emp.Field<DateTime>("emp_dob"),
                                          Department = Emp.Field<String>("emp_department"),
                                          Salary = Emp.Field<Int32>("emp_salary"),
                                          City = Emp.Field<String>("emp_city"),
                                          State = Emp.Field<String>("emp_state")
                                      };
                //foreach (var Emp in querySelectLinQ)
                //{

                //    DateTime date = Convert.ToDateTime(Emp.ItemArray[0]);
                //    String empcode = Convert.ToString(Emp.ItemArray[1]);
                //    String empname = Convert.ToString(Emp.ItemArray[2]);
                //    DateTime empdob = Convert.ToDateTime(Emp.ItemArray[3]);
                //    String empdepartment = Convert.ToString(Emp.ItemArray[4]);
                //    Int32 empsalary = Convert.ToInt32(Emp.ItemArray[5]);
                //    String empcity = Convert.ToString(Emp.ItemArray[6]);
                //    String empstate = Convert.ToString(Emp.ItemArray[7]);
                //}
                GridView1.DataSource = LINQResultToDataTable(querySelectLinQ);
                GridView1.DataBind();
            }
            else if (flag == 2)
            {
                TextBox2.Text = "var querySelectLinQ = from Emp in Employee.AsEnumerable()\n"
                           + "                         select new\n"
                           + "                         {\n"
                           + "                             date = Emp.Field<DateTime>(\"date\"),\n"
                           + "                             empcode = Emp.Field<string>(\"emp_code\"),\n"
                           + "                             empname = Emp.Field<string>(\"emp_name\"),\n"
                           + "                             empdob = Emp.Field<DateTime>(\"emp_dob\"),\n"
                           + "                             empdepartment = Emp.Field<String>(\"emp_department\"),\n"
                           + "                             empsalary = Emp.Field<Int32>(\"emp_salary\"),\n"
                           + "                             emp_city = Emp.Field<String>(\"emp_city\"),\n"
                           + "                             emp_state = Emp.Field<String>(\"emp_state\")\n"
                           + "                         };\n"
                           + "     //foreach (var Emp in querySelectLinQ)\n"
                           + "     //{\n"
                           + "     \n"
                           + "     //    DateTime date = Convert.ToDateTime(Emp.ItemArray[0]);\n"
                           + "     //    String empcode = Convert.ToString(Emp.ItemArray[1]);\n"
                           + "     //    String empname = Convert.ToString(Emp.ItemArray[2]);\n"
                           + "     //    DateTime empdob = Convert.ToDateTime(Emp.ItemArray[3]);\n"
                           + "     //    String empdepartment = Convert.ToString(Emp.ItemArray[4]);\n"
                           + "     //    Int32 empsalary = Convert.ToInt32(Emp.ItemArray[5]);\n"
                           + "     //    String empcity = Convert.ToString(Emp.ItemArray[6]);\n"
                           + "     //    String empstate = Convert.ToString(Emp.ItemArray[7]);\n"
                           + "     //}\n";
            }
        }
        #endregion

        #region Select Top 1 Column
        public void SelectLinQTop1(int flag)
        {
            lbl_que.Text = "# Get Top 1 Employee Record";
            if (flag == 1)
            {
                var querySelectLinQTop1 = (from Emp in Employee.AsEnumerable()
                                           select new
                                           {
                                               Date = Emp.Field<DateTime>("date"),
                                               Code = Emp.Field<string>("emp_code"),
                                               Name = Emp.Field<string>("emp_name"),
                                               DOB = Emp.Field<DateTime>("emp_dob"),
                                               Department = Emp.Field<String>("emp_department"),
                                               Salary = Emp.Field<Int32>("emp_salary"),
                                               City = Emp.Field<String>("emp_city"),
                                               State = Emp.Field<String>("emp_state")
                                           }).Take(1);
                //foreach (var Emp in querySelectLinQTop1)
                //{
                //    String empcode = Emp.empcode.ToString();
                //    String empname = Emp.empname.ToString();
                //    Int32 empsalary = Convert.ToInt32(Emp.empsalary);
                //}
                GridView1.DataSource = LINQResultToDataTable(querySelectLinQTop1);
                GridView1.DataBind();
            }
            else if (flag == 2)
            {
                TextBox2.Text = "var querySelectLinQTop1 = (from Emp in Employee.AsEnumerable()\n"
                          + "                               select new\n"
                          + "                               {\n"
                          + "                                    date = Emp.Field<DateTime>(\"date\"),\n"
                          + "                                    empcode = Emp.Field<string>(\"emp_code\"),\n"
                          + "                                    empname = Emp.Field<string>(\"emp_name\"),\n"
                          + "                                    empdob = Emp.Field<DateTime>(\"emp_dob\"),\n"
                          + "                                    empdepartment = Emp.Field<String>(\"emp_department\"),\n"
                          + "                                    empsalary = Emp.Field<Int32>(\"emp_salary\"),\n"
                          + "                                    emp_city = Emp.Field<String>(\"emp_city\"),\n"
                          + "                                    emp_state = Emp.Field<String>(\"emp_state\")\n"
                          + "                                }).Take(1);\n"
                          + "                //foreach (var Emp in querySelectLinQTop1)\n"
                          + "                //{\n"
                          + "                //    String empcode = Emp.empcode.ToString();\n"
                          + "                //    String empname = Emp.empname.ToString();\n"
                          + "                //    Int32 empsalary = Convert.ToInt32(Emp.empsalary);\n"
                          + "                //}\n";
            }
        }
        #endregion

        #region Select Order By
        public void SelectLinQOrderBy(int flag)
        {
            lbl_que.Text = "# Get Employee Record Order BY Salary ascending";
            if (flag == 1)
            {
                var querySelectLinQOrderBy = from Emp in Employee.AsEnumerable()
                                             orderby Emp.Field<Int32>("emp_salary") ascending /*, Emp.Field<String>("emp_name") descending */
                                             select new
                                             {
                                                 Code = Emp.Field<string>("emp_code"),
                                                 Name = Emp.Field<string>("emp_name"),
                                                 Salary = Emp.Field<Int32>("emp_salary")
                                             };
                //foreach (var Emp in querySelectLinQOrderBy)
                //{
                //    String empcode = Emp.empcode.ToString();
                //    String empname = Emp.empname.ToString();
                //    Int32 empsalary = Convert.ToInt32(Emp.empsalary);
                //}
                GridView1.DataSource = LINQResultToDataTable(querySelectLinQOrderBy);
                GridView1.DataBind();
            }
            else if (flag == 2)
            {
                TextBox2.Text = " var querySelectLinQOrderBy = from Emp in Employee.AsEnumerable()\n"
                + "                              orderby Emp.Field<Int32>(\"emp_salary\") ascending /*, Emp.Field<String>(\"emp_name\") descending */\n"
                + "                              select new\n"
                + "                              {\n"
                + "                                  empcode = Emp.Field<string>(\"emp_code\"),\n"
                + "                                  empname = Emp.Field<string>(\"emp_name\"),\n"
                + "                                  empsalary = Emp.Field<Int32>(\"emp_salary\")\n"
                + "                              };\n"
                + " //foreach (var Emp in querySelectLinQOrderBy)\n"
                + " //{\n"
                + " //    String empcode = Emp.empcode.ToString();\n"
                + " //    String empname = Emp.empname.ToString();\n"
                + " //    Int32 empsalary = Convert.ToInt32(Emp.empsalary);\n"
                + " //}\n";
            }

        }
        #endregion    

        #region Select Group By  Sum
        public void SelectLinQGroupBySum(int flag)
        {
            lbl_que.Text = "# Get Employee Record Group By Employee department Wise Total Salary Sum";
            if (flag == 1)
            {
                var querySelectLinQGroupBy = (from Emp in Employee.AsEnumerable()
                                              group Emp by Emp.Field<String>("emp_department") into e
                                              select new
                                              {
                                                  Department = e.Key,
                                                  TotalSal = e.Sum((s) => decimal.Parse(s["emp_salary"].ToString()))
                                              }).ToList();
                //foreach (var Emp in querySelectLinQGroupBy)
                //{
                //    Int32 TotalSalary = Convert.ToInt32(Emp.TotalSalary);
                //}
                GridView1.DataSource = LINQResultToDataTable(querySelectLinQGroupBy);
                GridView1.DataBind();
            }
            else if (flag == 2)
            {
                TextBox2.Text = "var querySelectLinQGroupBy = (from Emp in Employee.AsEnumerable()\n"
                + "                              group Emp by Emp.Field<String>(\"emp_department\") into e\n"
                + "                              select new\n"
                + "                              {\n"
                + "                                  Department = e.Key,\n"
                + "                                  TotalSalary = e.Sum((s) => decimal.Parse(s[\"emp_salary\"].ToString()))\n"
                + "                              }).ToList();\n"
                + "//foreach (var Emp in querySelectLinQGroupBy)\n"
                + "//{\n"
                + "//    Int32 TotalSalary = Convert.ToInt32(Emp.TotalSalary);\n"
                + "//}\n";
            }
        }
        #endregion  

        #region Select Group By Mutiple Sum
        public void SelectLinQGroupByMutipleSum(int flag)
        {
            lbl_que.Text = "# Get Employee Record Group By Employee department And City Wise Total Salary Sum";
            if (flag == 1)
            {
                var querySelectLinQGroupBy = (from Emp in Employee.AsEnumerable()
                                              group Emp by new { Department = Emp.Field<String>("emp_department"), City = Emp.Field<string>("emp_city") } into e
                                              select new
                                              {
                                                  Department = e.Key.Department,
                                                  City = e.Key.City,
                                                  TotalSal = e.Sum((s) => decimal.Parse(s["emp_salary"].ToString()))
                                              }).ToList();
                //foreach (var Emp in querySelectLinQGroupBy)
                //{
                //    Int32 TotalSalary = Convert.ToInt32(Emp.TotalSalary);
                //}
                GridView1.DataSource = LINQResultToDataTable(querySelectLinQGroupBy);
                GridView1.DataBind();
            }
            else if (flag == 2)
            {
                TextBox2.Text = "var querySelectLinQGroupBy = (from Emp in Employee.AsEnumerable()\n"
                + "                              group Emp by new { Department = Emp.Field<String>(\"emp_department\"), City = Emp.Field<string>(\"emp_city\") } into e\n"
                + "                              select new\n"
                + "                              {\n"
                + "                                  Department = e.Key.Department,\n"
                + "                                  City = e.Key.City,\n"
                + "                                  TotalSalary = e.Sum((s) => decimal.Parse(s[\"emp_salary\"].ToString()))\n"
                + "                              }).ToList();\n"
                + "//foreach (var Emp in querySelectLinQGroupBy)\n"
                + "//{\n"
                + "//    Int32 TotalSalary = Convert.ToInt32(Emp.TotalSalary);\n"
                + "//}\n";
            }
        }
        #endregion

        #region Select Count
        public void SelectLinQSum(int flag)
        {
            lbl.Visible = true;
            lbl_que.Text = "# Get Employee Record Total Salary Sum";
            GridView1.Visible = false;
            if (flag == 1)
            {
                Int32 TotalAvailStock = Convert.ToInt32(Employee.Compute("SUM(emp_salary)", string.Empty));
                lbl.Text = TotalAvailStock.ToString();
            }
            else if (flag == 2)
            {
                TextBox2.Text = "Int32 TotalAvailStock = Convert.ToInt32(Employee.Compute(\"SUM(emp_salary)\", string.Empty));\n"
                    + "//Int32 TotalAvailStock = Convert.ToInt32(Employee.Compute(\"COUNT(emp_salary)\", string.Empty));";
            }
        }
        #endregion

        #region Select Group By Single Count
        public void SelectLinQGroupByCount(int flag)
        {
            lbl_que.Text = "# Get Employee Record Group By Employee city Wise Count Employee";
            if (flag == 1)
            {
                var querySelectLinQGroupByCount = from queryResult in Employee.AsEnumerable()
                                                      //where queryResult.Field<Int32>("emp_salary") >= 20000
                                                  group queryResult by queryResult.Field<String>("emp_city") into rowGroup
                                                  select new
                                                  {
                                                      City = rowGroup.Key,
                                                      Count = rowGroup.Count()
                                                  };
                //foreach (var Emp in querySelectLinQGroupByCount)
                //{
                //    String name = Convert.ToString(Emp.name);
                //    Int32 count = Convert.ToInt32(Emp.Count);
                //}
                GridView1.DataSource = LINQResultToDataTable(querySelectLinQGroupByCount);
                GridView1.DataBind();
            }
            else if (flag == 2)
            {
                TextBox2.Text = "var querySelectLinQGroupByCount = from queryResult in Employee.AsEnumerable()\n"
                + "                                      //where queryResult.Field<Int32>(\"emp_salary\") >= 20000\n"
                + "                                  group queryResult by queryResult.Field<String>(\"emp_city\") into rowGroup\n"
                + "                                  select new\n"
                + "                                  {\n"
                + "                                      CityName = rowGroup.Key,\n"
                + "                                      Count = rowGroup.Count()\n"
                + "                                  };\n"
                + "//foreach (var Emp in querySelectLinQGroupByCount)\n"
                + "//{\n"
                + "//    String name = Convert.ToString(Emp.name);\n"
                + "//    Int32 count = Convert.ToInt32(Emp.Count);\n"
                + "//}\n";
            }
        }
        #endregion  

        #region Select Group By Mutiple Count
        public void SelectLinQGroupByMutipleCount(int flag)
        {
            lbl_que.Text = "# Get Employee Record Group By Employee city and Employee State Wise Count Employee";
            if (flag == 1)
            {
                var querySelectLinQGroupByCount = (from Emp in Employee.AsEnumerable()
                                                       //where queryResult.Field<Int32>("emp_salary") >= 20000
                                                   group Emp by new { CityName = Emp.Field<String>("emp_city"), StateName = Emp.Field<String>("emp_state") } into e
                                                   select new
                                                   {
                                                       City = e.Key.CityName,
                                                       State = e.Key.StateName,
                                                       Count = e.Count()
                                                   }).ToList();

                //foreach (var Emp in querySelectLinQGroupByCount)
                //{
                //    String CityName = Convert.ToString(Emp.CityName);
                //    String StateName = Convert.ToString(Emp.StateName);
                //    Int32 count = Convert.ToInt32(Emp.Count);
                //}
                GridView1.DataSource = LINQResultToDataTable(querySelectLinQGroupByCount);
                GridView1.DataBind();
            }
            else if (flag == 2)
            {
                TextBox2.Text = "var querySelectLinQGroupByCount = (from Emp in Employee.AsEnumerable()\n"
                + "                                       //where queryResult.Field<Int32>(\"emp_salary\") >= 20000\n"
                + "                                   group Emp by new { CityName = Emp.Field<String>(\"emp_city\"), StateName = Emp.Field<String>(\"emp_state\") } into e\n"
                + "                                   select new\n"
                + "                                   {\n"
                + "                                       CityName = e.Key.CityName,\n"
                + "                                       StateName = e.Key.StateName,\n"
                + "                                       Count = e.Count()\n"
                + "                                   }).ToList();\n"
                + "\n"
                + "//foreach (var Emp in querySelectLinQGroupByCount)\n"
                + "//{\n"
                + "//    String CityName = Convert.ToString(Emp.CityName);\n"
                + "//    String StateName = Convert.ToString(Emp.StateName);\n"
                + "//    Int32 count = Convert.ToInt32(Emp.Count);\n"
                + "//}\n";
            }
        }
        #endregion

        #region Left Join LinQ
        public void LeftJoinLinQ(int flag)
        {
            lbl_que.Text = "# Get Record Employee As a User Deatil";
            if (flag == 1)
            {
                var queryLeftJoinLinQ = from dtUser in User.AsEnumerable()
                                        join dtEmp in Employee.AsEnumerable()
                                        on dtUser.Field<Int32>("id") equals dtEmp.Field<Int32>("id") into evente
                                        from ab in evente.DefaultIfEmpty()
                                        select new
                                        {
                                            UserCode = dtUser.Field<String>("user_code"),
                                            UserName = dtUser.Field<String>("user_name"),
                                            EmpCode = ab.Field<String>("emp_code"),
                                            EmpSalary = ab.Field<Int32>("emp_salary"),
                                        };
                //foreach (var Emp in queryLeftJoinLinQ)
                //{
                //}
                GridView1.DataSource = LINQResultToDataTable(queryLeftJoinLinQ);
                GridView1.DataBind();
            }
            else if (flag == 2)
            {
                TextBox2.Text = "var queryLeftJoinLinQ = from dtUser in User.AsEnumerable()\n"
                + "                        join dtEmp in Employee.AsEnumerable()\n"
                + "                        on dtUser.Field<Int32>(\"id\") equals dtEmp.Field<Int32>(\"id\") into evente\n"
                + "                        from ab in evente.DefaultIfEmpty()\n"
                + "                        select new\n"
                + "                        {\n"
                + "                            UserCode = dtUser.Field<String>(\"user_code\"),\n"
                + "                            UserName = dtUser.Field<String>(\"user_name\"),\n"
                + "                            EmpCode = ab.Field<String>(\"emp_code\"),\n"
                + "                            EmpSalary = ab.Field<Int32>(\"emp_salary\"),\n"
                + "                        };\n"
                + "//foreach (var Emp in queryLeftJoinLinQ)\n"
                + "//{\n"
                + "//}\n";
            }

        }
        #endregion
        // 1 To 8

        #region Employee And UserTable 
        public void EmployeeMaster()
        {
            Employee.Columns.Add("id", typeof(int));
            Employee.Columns.Add("date", typeof(DateTime));
            Employee.Columns.Add("emp_code", typeof(String));
            Employee.Columns.Add("emp_name", typeof(String));
            Employee.Columns.Add("emp_dob", typeof(DateTime));
            Employee.Columns.Add("emp_department", typeof(string));
            Employee.Columns.Add("emp_salary", typeof(Int32));
            Employee.Columns.Add("emp_city", typeof(string));
            Employee.Columns.Add("emp_state", typeof(string));

            Employee.Rows.Add(1, "01-06-2022", "EMP0001", "Rakesh Kumar", "01-06-2010", "A", 20000, "Rajkot", "Gujarat");
            Employee.Rows.Add(2, "15-07-2022", "EMP0002", "Harshit Kumar", "01-06-2002", "B", 25000, "Ahemadabad", "Gujarat");
            Employee.Rows.Add(3, "11-09-2022", "EMP0003", "Keval Kumar", "01-06-2000", "D", 60500, "Rajkot", "Gujarat");
            Employee.Rows.Add(4, "17-06-2022", "EMP0004", "Vinit Kumar", "01-06-2002", "A", 18000, "Surat", "Gujarat");
            Employee.Rows.Add(5, "01-09-2022", "EMP0005", "Hitesh Kumar", "01-06-2003", "A", 20000, "Rajkot", "Gujarat");
            Employee.Rows.Add(6, "18-11-2022", "EMP0006", "Gautam Kumar", "01-06-2008", "B", 19500, "Vadodara", "Gujarat");
            Employee.Rows.Add(7, "21-06-2022", "EMP0007", "Raviraj Kumar", "01-06-2012", "B", 20000, "Junagadh", "Gujarat");
            Employee.Rows.Add(8, "30-10-2022", "EMP0008", "Ravi Kumar", "01-06-2018", "D", 26500, "Rajkot", "Gujarat");
        }
        public void UserMaster()
        {
            User.Columns.Add("id", typeof(int));
            User.Columns.Add("user_code", typeof(String));
            User.Columns.Add("user_name", typeof(String));
            User.Columns.Add("user_pass", typeof(String));

            User.Rows.Add(1, "USER0001", "Rakesh Kumar", "01A2Rajaat");
            User.Rows.Add(2, "USER0002", "Harshit Kumar", "01BAhemGuj");
            User.Rows.Add(3, "USER0003", "Keval Kumar", "620D500ajkjarat");
            User.Rows.Add(4, "USER0004", "Vinit Kumar", "2002A80Suarat");
        }
        #endregion

        #region LinQ To DataTable
        public DataTable LINQResultToDataTable<T>(IEnumerable<T> Linqlist)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] columns = null;

            if (Linqlist == null) return dt;

            foreach (T Record in Linqlist)
            {

                if (columns == null)
                {
                    columns = ((Type)Record.GetType()).GetProperties();
                    foreach (PropertyInfo GetProperty in columns)
                    {
                        Type colType = GetProperty.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dt.Columns.Add(new DataColumn(GetProperty.Name, colType));
                    }
                }

                DataRow dr = dt.NewRow();

                foreach (PropertyInfo pinfo in columns)
                {
                    dr[pinfo.Name] = pinfo.GetValue(Record, null) == null ? DBNull.Value : pinfo.GetValue
                    (Record, null);
                }

                dt.Rows.Add(dr);
            }
            return dt;
        }
        #endregion


    }
}