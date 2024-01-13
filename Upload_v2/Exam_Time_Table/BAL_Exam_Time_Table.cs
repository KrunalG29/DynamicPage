
//This file is generated programmatically
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
//using System.Configuration;
//using System.Linq;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
//using System.Data.Common;
//using infinity;

/// <summary>
/// Summary description for BAL_Exam_Time_Table
/// </summary>
public class BAL_Exam_Time_Table
{

    #region GetBAL_Exam_Time_Table_select Function
    /// <summary>
    /// This function use to get all Exam_Time_Table table data.
    /// </summary>
    /// <returns>This function is return all Exam_Time_Table data table</returns>
    public static DataTable GetBAL_Exam_Time_Table_select(Int32 institute_id)
    {
        SqlCommand cmd = new SqlCommand();
        CreateParameter para = new CreateParameter();
        cmd.CommandText = "Exam_Time_Table_select";
        cmd.Parameters.Add(para.IntInputPara("@institute_id", institute_id));
        DataTable dt = CreateCommand.ExecuteQuery(cmd);
        return dt;
    }
    #endregion

    #region GetBAL_Exam_Time_TableLog Function
    /// <summary>
    /// This function is used to get log of BAL_Exam_Time_Table by id
    /// </summary>    
    /// <returns></returns>
    public static DataTable GetBAL_Exam_Time_TableLog(Int32 id, Int32 institute_id)
    {
        SqlCommand cmd = new SqlCommand();
        CreateParameter para = new CreateParameter();
        cmd.CommandText = "Exam_Time_Table_log_select";
        cmd.Parameters.Add(para.IntInputPara("@institute_id", institute_id));
        cmd.Parameters.Add(para.IntInputPara("@id", id));
        DataTable dt = CreateCommand.ExecuteQuery(cmd);
        return dt;
    }
    #endregion

    #region GetBAL_Exam_Time_Table_ByID Function
    /// <summary>
    /// This function is use to get Exam_Time_Table data by ett_Id
    /// </summary>
    /// <param name="ett_Id">Pass ett_Id</param>
    /// <returns>Return datatable in Exam_Time_Table data</returns>
    public static DataTable GetBAL_Exam_Time_Table_ByID(Int32 id, Int32 institute_id)
    {
        SqlCommand cmd = new SqlCommand();
        CreateParameter para = new CreateParameter();
        cmd.CommandText = "Exam_Time_Table_selectby_id";
        cmd.Parameters.Add(para.IntInputPara("@institute_id", institute_id));
        cmd.Parameters.Add(para.IntInputPara("@id", id)); // "@ett_Id"
        DataTable dt = CreateCommand.ExecuteQuery(cmd);
        return dt;
    }
    #endregion

    #region Insert_Exam_Time_Table Function
    /// <summary>
    /// This function is use to update the Exam_Time_Table data.
    /// </summary>
    /// <param name="obj">Pass the instance object of PROP_Exam_Time_Table</param>
    /// <returns>PROP_db_return property value</returns>
    public static PROP_db_return Insert_BAL_Exam_Time_Table(PROP_Exam_Time_Table obj)
    {
        SqlCommand cmd = new SqlCommand();
        CreateParameter para = new CreateParameter();
        cmd.CommandText = "Exam_Time_Table_update";
        cmd.Parameters.Add(para.IntInputPara("ett_Id", em."ett_Id"));
        cmd.Parameters.Add(para.IntInputPara("ett_Institute_Id", em."ett_Institute_Id"));
        cmd.Parameters.Add(para.IntInputPara("ett_Faculty_Id", em."ett_Faculty_Id"));
        cmd.Parameters.Add(para.IntInputPara("ett_Program_Id", em."ett_Program_Id"));
        cmd.Parameters.Add(para.IntInputPara("ett_Semester_Id", em."ett_Semester_Id"));
        cmd.Parameters.Add(para.IntInputPara("ett_Exam_Id", em."ett_Exam_Id"));
        cmd.Parameters.Add(para.IntInputPara("ett_Gap_Day", em."ett_Gap_Day"));
        cmd.Parameters.Add(para.StringInputPara("ett_Seq_No", em."ett_Seq_No"));
        cmd.Parameters.Add(para.IntInputPara("ett_Component_Id", em."ett_Component_Id"));
        cmd.Parameters.Add(para.IntInputPara("ett_Session_Id", em."ett_Session_Id"));
        cmd.Parameters.Add(para.StringInputPara("ett_Exam_Date", em."ett_Exam_Date"));
        cmd.Parameters.Add(para.StringInputPara("ett_Exam_Start_Time", em."ett_Exam_Start_Time"));
        cmd.Parameters.Add(para.StringInputPara("ett_Exam_End_Time", em."ett_Exam_End_Time"));
        cmd.Parameters.Add(para.IntInputPara("ett_Sub_Type_Id", em."ett_Sub_Type_Id"));
        cmd.Parameters.Add(para.IntInputPara("ett_Is_Status", em."ett_Is_Status"));
        cmd.Parameters.Add(para.IntInputPara("ett_Is_Delete", em."ett_Is_Delete"));
        cmd.Parameters.Add(para.IntInputPara("ett_Created_By", em."ett_Created_By"));
        cmd.Parameters.Add(para.StringInputPara("ett_Created_Date", em."ett_Created_Date"));
        cmd.Parameters.Add(para.StringInputPara("ett_Created_Ip", em."ett_Created_Ip"));
        cmd.Parameters.Add(para.IntInputPara("ett_Modify_By", em."ett_Modify_By"));
        cmd.Parameters.Add(para.StringInputPara("ett_Modify_Date", em."ett_Modify_Date"));
        cmd.Parameters.Add(para.StringInputPara("ett_Modify_Ip", em."ett_Modify_Ip"));
        cmd.Parameters.Add(para.IntInputPara("ett_Deleted_By", em."ett_Deleted_By"));
        cmd.Parameters.Add(para.StringInputPara("ett_Deleted_Date", em."ett_Deleted_Date"));
        cmd.Parameters.Add(para.StringInputPara("ett_Deleted_Ip", em."ett_Deleted_Ip"));
        cmd.Parameters.Add(para.IntOutputPara("@OUT_ID"));
        cmd.Parameters.Add(para.IntOutputPara("@alert_msg"));
        int a = CreateCommand.NonExecuteQuery(cmd);

        PROP_db_return retObj = new PROP_db_return();
        int resultval = gda.ExecuteNonQuery(comm);
        retObj.id = Handle.ToInt32(cmd.Parameters["@OUT_ID"].Value);
        retObj.alertMessage = Handle.ToInt32(cmd.Parameters["@alert_msg"].Value);
        return retObj;
    }

    #endregion

    #region Delete Function
    /// <summary>
    /// This function is used to delete the Exam_Time_Table data by ett_Id
    /// </summary>
    /// <param name="id">Pass integer ett_Id </param>
    /// <param name="userId">Pass integer userId </param>
    /// <param name="ip">Pass string ip </param>
    /// <returns>Returns if Exam_Time_Table data is deleted then true otherwise false</returns>
    public static Boolean Delete(Int32 id, Int32 delete_by, String delete_ip)
    {
        SqlCommand cmd = new SqlCommand();
        CreateParameter para = new CreateParameter();
        cmd.CommandText = "Delete_Exam_Time_Table";
        cmd.Parameters.Add(para.IntInputPara("@id", id));
        cmd.Parameters.Add(para.IntInputPara("@delete_by", delete_by));
        cmd.Parameters.Add(para.StringInputPara("@delete_ip", delete_ip));


        int retval = gda.ExecuteNonQuery(comm);

        if (retval > 0)
            return true;
        else
            return false;
    }
    #endregion

    #region Update_Status_Exam_Time_Table Function
    /// <summary>
    /// This function is used to delete the Exam_Time_Table data by ett_Id
    /// </summary>
    /// <param name="id">Pass integer ett_Id </param>
    /// <param name="userId">Pass integer userId </param>
    /// <param name="ip">Pass string ip </param>
    /// <returns>Returns if Exam_Time_Table data is deleted then true otherwise false</returns>
    public static Boolean Update_Statusett_Id(Int32 id, Int32 status, Int32 modify_by, String modify_ip)
    {
        SqlCommand cmd = new SqlCommand();
        CreateParameter para = new CreateParameter();
        cmd.CommandText = "Delete_Exam_Time_Table";
        cmd.Parameters.Add(para.IntInputPara("@id", id));
        cmd.Parameters.Add(para.IntInputPara("@status", status));
        cmd.Parameters.Add(para.IntInputPara("@modify_by", modify_by));
        cmd.Parameters.Add(para.StringInputPara("@modify_ip", modify_ip));

        int retval = gda.ExecuteNonQuery(comm);

        if (retval > 0)
            return true;
        else
            return false;
    }
    #endregion
}