using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data;
using infinity;
using System.Net.Mail;
using System.Net;

public class db_my_functions
{

    public db_my_functions()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region SendMail Function
    public static String SendMail(string tomail, string[] Filenames, string conString)
    {
        string msg = "";
        string conSTr = "workstation id=infiprodERP.mssql.somee.com;packet size=4096;user id=Nishu2904;pwd=nishu#2904;data source=infiprodERP.mssql.somee.com;persist security info=False;initial catalog=infiprodERP";
        try
        {
            string from = "noreply.kogs@gmail.com"; // noreply.ierp@gmail.com
            string password = "lxpvbnesvzshgzjr"; //gtbrhwlvaslpnwix
            using (MailMessage mail = new MailMessage(from, tomail))
            {
                mail.Subject = "System Generated Files!";
                mail.Body = "PFA";
                //string fileName = Path.GetFileName(fileUploader.PostedFile.FileName);
                foreach (String filepath in Filenames)
                {
                    mail.Attachments.Add(new Attachment(filepath));

                }
                mail.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                NetworkCredential networkCredential = new NetworkCredential(from, password);
                smtp.Credentials = networkCredential;
                smtp.Port = 587;
                smtp.Send(mail);
            }
            msg = "Message has been sent successfully.";
        }
        catch
        {
            msg = "Some Error Occured While Send Email";
        }
        return msg;
    }

    #endregion

    #region GetBindMethodNames
    public static DataTable GetBindMethodNames(String conSTr)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conSTr);
        comm.CommandText = "i_conf_bind_methods_name_select";
        // return the result table

        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;

    }
    #endregion

    #region GetMethodDetail_ByID
    public static DataTable GetMethodDetail_ByID(String conSTr, int id)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();

        DbCommand comm = gda.CreateCommand(conSTr);

        // set the stored procedure name
        comm.CommandText = "i_conf_bind_methods_name_select_by_id";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@id";
        param.Value = id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;
    }
    #endregion

    #region Get_SP_Names Function
    public static DataTable Get_SP_Names(string conString,String tableName)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conString);
        // set the command text
        comm.CommandText = @"declare @sql nvarchar(max)

Set @sql = 'Select obj.name from sys.objects as obj 
left join sys.all_sql_modules sy on obj.object_id = sy.object_id
where sy.definition like  ''%'+@tbl_name+'%'' and sy.definition not like ''%`%'''

exec sp_executesql @sql

print @sql
declare @result int
begin try
exec @result=sp_executesql @sql
select 'Operation Successfully'
end try
begin catch
	select ERROR_MESSAGE()
end catch
";

        //        comm.CommandText = @"declare @sql nvarchar(max)

        //Set @sql = 'Select name from (
        //Select ROW_NUMBER() OVER(ORDER BY sy.object_id) as id,obj.name from sys.objects as obj 
        //left join sys.all_sql_modules sy on obj.object_id = sy.object_id
        //where sy.definition like  ''%%'' and sy.definition not like ''%`%'') as tbl where id between 0 and 100'

        //exec sp_executesql @sql

        //print @sql
        //declare @result int
        //begin try
        //exec @result=sp_executesql @sql
        //select 'Operation Successfully'
        //end try
        //begin catch
        //	select ERROR_MESSAGE()
        //end catch
        //";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@tbl_name";
        param.Value = tableName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        comm.CommandTimeout = 500;
        DataTable result = gda.ExecuteSelectCommand(comm);
        return result;
    }

    #endregion

    #region GET_STRING 
    public static DataTable GetString(string conString,String sp_names,Int32 flag)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();

        DbCommand comm = gda.CreateCommand(conString);

        // set the command text
        comm.CommandText = @"declare @sql varchar(max)

declare @tbl_SPNames table (spnames varchar(max))
declare @tbl_SPScripts table (spscripts varchar(max))

insert into @tbl_SPNames(spnames) Select * from dbo.Split(@sp_names,',')

	declare @sp_name varchar(max)
	DECLARE insertCursor CURSOR STATIC LOCAL READ_ONLY FOR
	
		Select spnames from @tbl_SPNames
		OPEN insertCursor

	FETCH NEXT FROM insertCursor INTO @sp_name
	WHILE @@FETCH_STATUS = 0 
	BEGIN
		
		insert into @tbl_SPScripts
		SELECT definition FROM sys.sql_modules WHERE object_id = object_id(''+@sp_name+'');
		--EXEC sp_helptext @sp_name;

		insert into @tbl_SPScripts values('`')

	FETCH NEXT FROM insertCursor INTO @sp_name
	END
	IF(@flag = 1)
	BEGIN
		declare @tbl_SPScripts2 table (spscripts varchar(max))
			declare @sp_name_alter varchar(max)
			DECLARE insertCursor2 CURSOR STATIC LOCAL READ_ONLY FOR
			
			Select spscripts from @tbl_SPScripts
			OPEN insertCursor2

			FETCH NEXT FROM insertCursor2 INTO @sp_name_alter
			WHILE @@FETCH_STATUS = 0 
			BEGIN
				
				insert into @tbl_SPScripts2
				Select REPLACE(@sp_name_alter,'CREATE PROCEDURE','ALTER PROCEDURE')

			FETCH NEXT FROM insertCursor2 INTO @sp_name_alter
			END

		Select spscripts as SCRIPT from @tbl_SPScripts2
	END
	ELSE
	BEGIN
		Select spscripts as SCRIPT  from @tbl_SPScripts
	END

	--Select
	--@sql=STUFF( (SELECT '' + spscripts FROM @tbl_SPScripts FOR XML PATH('')),1,1,'' )
--Select @sql
--print @sql
--exec(@sql)
";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@sp_names";
        param.Value = sp_names;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@flag";
        param.Value = flag;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);


        DataTable dt = gda.ExecuteSelectCommand(comm);
        return dt;
    }

    #endregion

    #region Execute Scripts To New DataBase
    public static String Exec_Scripts(string conString, String Script)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conString);
        // set the command text
        //        comm.CommandText = @"
        //declare @result int
        //begin try
        //exec (@Script)
        //select 'Operation Successfully'
        //end try
        //begin catch
        //	select ERROR_MESSAGE()
        //end catch

        //";

        comm.CommandText = @"
Declare @str varchar(max)

set @str='declare @result int
begin try
exec ('''+@Script+''')
select ''Operation Successfully''
end try
begin catch
	select ERROR_MESSAGE()
end catch'
			
	EXEC(@str)
";

        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Script";
        param.Value = Script;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        String result = gda.ExecuteScalar_ForSelectedProject(comm);
        return result;
    }

    #endregion

    #region Insert Function
    /// <summary>
    /// This function is insert data in to the iERP_task_log data.
    /// </summary>
    /// <param name="obj">Pass the instance object of PROP_iERP_task_log</param>
    /// <returns>PROP_db_return property value</returns>
    public static DataTable Insert(String conSTr, String Label_Name, String Method_Name, String IdByName, String IdsByName)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conSTr);
        comm.CommandText = "exec i_conf_bind_methods_name_insert '" + Label_Name + "','" + Method_Name + "','" + IdByName + "','" + IdsByName + "'";

        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;
    }
    #endregion

    #region Check Exists

    public static String Check_Exists(string conString, String tbl_name)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conString);
        // set the command text
        //        comm.CommandText = @"
        //declare @result int
        //begin try
        //exec (@Script)
        //select 'Operation Successfully'
        //end try
        //begin catch
        //	select ERROR_MESSAGE()
        //end catch

        //";

        comm.CommandText = @"
Declare @str varchar(max)

set @str='IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'''+@tbl_name+''') AND type in (N''P'', N''PC''))
BEGIN
	Select ''1''
END
ELSE
BEGIN
	Select ''0''
END'		

EXEC(@str)
";

        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@tbl_name";
        param.Value = tbl_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        String result = gda.ExecuteScalar_ForSelectedProject(comm);
        return result;
    }
    #endregion

    #region getColumns_from_table
    public static DataTable getColumns_from_table(String conERPProd,String SP_NAME,String[] strArray)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        comm.CommandText = SP_NAME;

        int rows = 0;
        String Param = "";
        String ParamType = "";
        foreach (String strSplit in strArray)
        {
            if (rows != 0)
            {
                string[] strParam = strSplit.Replace(' ', '@').Trim().Split('@');
                 Param += strParam[1] + "$"; // Param
                 ParamType += strParam[2].ToLower() +"$"; // ParamType
            }
            rows++;
        }

        String[] sp_param = Param.Split('$');
        String[] sp_param_dt = ParamType.Split('$');

        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@" + sp_param[0].ToString();
        if (sp_param_dt[0].Contains("date"))
        {
            param.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
            param.DbType = DbType.DateTime;
        }
        else if (sp_param_dt[0].Contains("int"))
        {
            param.Value = 0;
            param.DbType = DbType.Int32;
        }
        else if (sp_param_dt[0].Contains("varchar"))
        {
            param.Value = "";
            param.DbType = DbType.String;
        }
        else if (sp_param_dt[0].Contains("decimal"))
        {
            param.Value = 10.00;
            param.DbType = DbType.Decimal;
        }
        comm.Parameters.Add(param);

        for (int i=1; i<(sp_param.Length-1); i++)
        {
            param = comm.CreateParameter();
            if (sp_param_dt[i].Contains("date"))
            {
                param.ParameterName = "@" + sp_param[i].ToString();
                param.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
                param.DbType = DbType.DateTime;
            }
            else if (sp_param_dt[i].Contains("int"))
            {
                param.ParameterName = "@" + sp_param[i].ToString();
                param.Value = 0;
                param.DbType = DbType.Int32;
            }
            else if (sp_param_dt[i].Contains("varchar"))
            {
                param.ParameterName = "@" + sp_param[i].ToString();
                param.Value = "";
                param.DbType = DbType.String;
            }
            else if (sp_param_dt[i].Contains("decimal"))
            {
                param.ParameterName = "@" + sp_param[i].ToString();
                param.Value = 10.00;
                param.DbType = DbType.Decimal;
            }
            comm.Parameters.Add(param);
        }

        DataTable result = gda.ExecuteSelectCommand(comm);
        return result;
    }
    #endregion

    public static string GetIp()
    {
        string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(ip))
        {
            ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        return ip;
    }
}
