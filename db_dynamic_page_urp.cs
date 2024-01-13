using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data;
using infinity;

/// <summary>
/// Summary description for db_dynamic_page
/// </summary>
public class db_dynamic_page_urp
{
    public db_dynamic_page_urp()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region GetAllTables Function
    /// <summary>
    /// This function is used to get all database tables list
    /// </summary>
    /// <returns>This function returns all tables of database</returns>
    public static DataTable GetAllTables(String ConStr)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(ConStr);
        comm.CommandText = "select [name] from sys.tables order by [name]";

        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;
    }
    #endregion


    #region GetAllTables Function
    /// <summary>
    /// This function is used to get all database tables list
    /// </summary>
    /// <returns>This function returns all tables of database</returns>
    public static DataTable GetAllTables1(String ConStr, String prefixText)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(ConStr);
        comm.CommandText = "select [name] from sys.tables where [name] like '%" + prefixText + "%' order by [name]";

        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;
    }
    #endregion

    #region GetAllProject Function
    /// <summary>
    /// This function is used to get all database tables list
    /// </summary>
    /// <returns>This function returns all tables of database</returns>
    public static DataTable GetAllProject()
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "i_Get_All_Project";

        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;
    }
    #endregion

    #region GetProjectLogDBName Function
    /// <summary>
    /// 
    /// </summary>
    /// <param name="projectName"></param>
    /// <returns></returns>
    public static string GetProjectLogDBName(string projectName)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "i_Get_Project_logDb_Name";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@project_name";
        param.Value = projectName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        // return the result table
        string val = Handle.ToString(gda.ExecuteScalar(comm));
        return val;
    }
    #endregion

    #region GetColumnsByTable Function
    /// <summary>
    /// This function is used to get all columns by table Name
    /// </summary>
    /// <param name="tableName">Pass String tableName</param>    
    /// <returns>Returns all columns of passed table</returns>
    public static DataTable GetColumnsByTable(string tableName, String ConStr)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(ConStr);
        // set the command text
        comm.CommandText = @"select 
        case charindex('char',st.name) when 0 then
	        case charindex('date',st.name) when 0 then
	         case charindex('time',st.name) when 0 then
		        case charindex('int',st.name) when 0 then 
			        case st.name when 'decimal' then 'Double'
			        when 'float' then 'Double' end 
		        else 'Int32' end
	         else 'DateTime' end	
	        else 'DateTime' end
        else 'String' end as datatype,
        case charindex('char',st.name) when 0 then
	        case charindex('date',st.name) when 0 then
	         case charindex('time',st.name) when 0 then
		        case charindex('int',st.name) when 0 then 
			        case st.name when 'decimal' then 'StringInputPara'
			        when 'float' then 'StringInputPara' end 
		        else 'IntInputPara' end
	         else 'StringInputPara' end	
	        else 'StringInputPara' end
        else 'StringInputPara' end as datatype_2,
        col.length as size,
        col.name,col.colorder
        from syscolumns col inner join 
        sysobjects sob on col.id = sob.id and sob.XType = 'U'
        inner join systypes st on col.usertype = st.usertype
        and col.xtype = st.xtype
        and col.id = object_id(@tbl_name)
        order by colorder";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@tbl_name";
        param.Value = tableName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;
    }

    #endregion

    #region CreateTrigger Function
    /// <summary>
    /// This function is used to create trigger in selected project
    /// </summary>
    /// <param name="conString"></param>
    /// <param name="tableName"></param>
    /// <returns></returns>
    public static String CreateTrigger(string conString, string tableName)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conString);
        // set the command text
        comm.CommandText = @"declare @sql nvarchar(max)
 
 declare @synForlogtbl varchar(max)
 declare @triggerName varchar(max)
 set @synForlogtbl =@tbl_name+'_log'

set @triggerName ='trg_' + @tbl_name 

set @sql='
	
CREATE TRIGGER [dbo].['+@triggerName+'] 
ON  [dbo].['+@tbl_name+'] 
For UPDATE,Delete
AS 
BEGIN
	DECLARE @event_type tinyint
	IF EXISTS(SELECT * FROM inserted)
	IF EXISTS(SELECT * FROM deleted)
	SELECT @event_type = 2
	ELSE
	SELECT @event_type = 1
	ELSE
	IF EXISTS(SELECT * FROM deleted)
	SELECT @event_type = 3
	ELSE
	--no rows affected - cannot determine event
	SELECT @event_type = 0 
	if(@event_type in (2))
	insert into '+@synForlogtbl+' select @event_type,GETDATE(),* from deleted
	else if(@event_type in (3))
	insert into '+@synForlogtbl+' select @event_type,GETDATE(),* from deleted
END	
'
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
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@tbl_name";
        param.Value = tableName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        // return the result table
        String table = gda.ExecuteScalar_ForSelectedProject(comm);
        return table;
    }

    #endregion

    #region CreateLogTable 
    /// <summary>
    /// This function is to create log table in log database if exists or same database
    /// </summary>
    /// <param name="conString"></param>
    /// <param name="tbl_name"></param>
    /// <returns></returns>
    public static String CreateLogTable(string conString, string lodDbName, string tbl_name)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();

        DbCommand comm = gda.CreateCommand(conString);

        // set the command text
        comm.CommandText = @"declare @sql varchar(max)

declare @logtable varchar(max)
set @logtable =@tbl_name+'_log'

declare @ffield varchar(100)
declare @clmn varchar(max)
select top 1 @ffield=[name] from sys.columns where  [object_id]=object_id(@tbl_name)
select @clmn=COALESCE(@clmn + ', ','') + case [name] when @ffield then 'cast(null as bigint) as '+[name] else [name] end from  sys.columns where  [object_id]=object_id(@tbl_name)




set @sql='
	begin try
	select * into '+@log_db_name+'.[dbo].'+@logtable+' 
	from (select cast(null as int) as operation_type,cast(null as datetime) as operation_dnt,'+@clmn+' from [dbo].'+@tbl_name+') as tb
	truncate table '+@log_db_name+'.[dbo].'+@logtable+'
	select ''Operation Successfully''
	end try
	begin catch
	select ERROR_MESSAGE()
	end catch
'
print @sql
exec(@sql)
";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@tbl_name";
        param.Value = tbl_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        //Log database name
        param = comm.CreateParameter();
        param.ParameterName = "@log_db_name";
        param.Value = lodDbName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        // return the result table
        String table = gda.ExecuteScalar_ForSelectedProject(comm);
        return table;
    }

    #endregion

    #region CreateSynonymOfLogTable 
    /// <summary>
    /// This function is used to create synonym for log database table 
    /// </summary>
    /// <param name="conString"></param>
    /// <param name="logDbName"></param>
    /// <param name="tbl_name"></param>
    /// <returns></returns>
    public static String CreateSynonymOfLogTable(string conString, string logDbName, string tbl_name)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conString);

        // set the command text
        comm.CommandText = @"declare @sql nvarchar(max)
                            declare @synForlogtbl varchar(max)

                            set @synForlogtbl =@tbl_name+'_log'

set @sql='CREATE synonym '+@synForlogtbl+' for ['+@log_tbl_db+'].[dbo].['+@synForlogtbl+'] '
	

declare @result int
begin try
exec @result=sp_executesql @sql
select 'Operation Successfully'
end try
begin catch
	select ERROR_MESSAGE()
end catch
";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@tbl_name";
        param.Value = tbl_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        //Log database name
        param = comm.CreateParameter();
        param.ParameterName = "@log_tbl_db";
        param.Value = logDbName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        // return the result table
        String table = gda.ExecuteScalar_ForSelectedProject(comm);
        return table;
    }

    #endregion

    #region CreateInsertProcedure Function
    /// <summary>
    /// This function is used to create insert SP in selected project
    /// </summary>
    /// <param name="conString"></param>
    /// <param name="tblName"></param>
    /// <param name="objName"></param>
    /// <returns></returns>
    public static String CreateInsertProcedure(string conString, string tblName, string objName, string uniqueCheck, string uniqueCheckLabels, string InsertOnly, string autoGenerated)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conString);

        // set the command text
        comm.CommandText = @"if(@obj_name='')
 set @obj_name='Insert_' + @tbl_name
 declare @sql nvarchar(max)
 declare @logtblnm varchar(max)

 declare @clmn_paramwdt varchar(max)
 declare @clmn_param varchar(max)
  declare @clmn_param_update varchar(max)
 declare @clmn varchar(max)
 declare @unique varchar(max)
 declare @cond_unique_1 varchar(max)
 declare @cond_unique_2 varchar(max)
 set @cond_unique_1=''
 set @cond_unique_2='' 


 select 
 @clmn_paramwdt=case when [name]='create_dnt' then @clmn_paramwdt else COALESCE(@clmn_paramwdt + ','+char(13)+' ','') +'@'+[name]+' '+ ( select 
 case st.name when 'varchar' then st.name+'('+convert(varchar,case col.length when -1 then 'MAX' else convert(varchar,col.length) end)+')'
 when 'nvarchar' then st.name+'('+convert(varchar,col.length)+')'
 when 'char' then st.name+'('+convert(varchar,col.length)+')'
 when 'decimal' then 'varchar(max)' --st.name+'('+convert(varchar,col.xprec)+','+convert(varchar,col.xscale)+')'
 when 'nchar' then st.name+'('+convert(varchar,col.length)+')' 
 when 'datetime' then 'varchar(max)'
 else st.name end
 from syscolumns col inner join
 systypes st on col.usertype = st.usertype 
 and col.xtype = st.xtype 
 where id=[object_id] and colid=column_id) end,
 @clmn_param=COALESCE(@clmn_param +char(13)+' ','') + case when isnull(@clmn_param,'')!='' then ',' else '' end +  case when [name]='create_dnt' then'GETDATE()' else '@'+ [name] end ,
   @clmn_param_update=COALESCE(@clmn_param_update +char(13)+' ','') +case when isnull(@clmn_param_update,'')!='' then ',' else '' end  +[name]+ '='+case when [name]='modify_dnt' then 'GETDATE()' else '@'+ [name] end,
 @clmn=COALESCE(@clmn +char(13)+' ','') + case when isnull(@clmn,'')!='' then ',' else '' end + [name],
 @unique=COALESCE(@unique ,'') +case when patindex('%,'+[name]+',%',','+@unique_check+',')>0 then  case when isnull(@unique,'')!='' then ' or ' else'' end + [name]+ '='+'@'+ [name] else '' end
 from  sys.columns where  [object_id]=object_id(@tbl_name) --and column_id !=1
 and [name] not like '%modify_by%' and [name] not like '%modify_ip%' and [name] not like '%modify_dnt%'
 and [name]!=@unique_check
   if(@unique_check !='')
  set @cond_unique_1='IF(ISNULL(@'+@unique_check+',0)=0)
    BEGIN'

if(@unique_check != '')
    set @cond_unique_2='END
    ELSE
    BEGIN
          Update '+@tbl_name+' set
        '+@clmn_param_update+'
         Where '+@unique_check+'=@'+@unique_check+'

         SELECT @out_id=@'+@unique_check+'
        SELECT @alert_msg = ''Updated successfully''
    END'

    --select @clmn_paramwdt
                            set @sql='    
CREATE PROCEDURE [dbo].['+@obj_name+']
 @'+@unique_check+' int,
'+@clmn_paramwdt+',
@out_id bigint output,
@alert_msg varchar(300) output
AS
BEGIN 

   '+@cond_unique_1+'
    INSERT INTO '+@tbl_name+'
    (
        '+@clmn+'
    )
    VALUES
    (
        '+@clmn_param+'
    )

     SELECT @out_id=SCOPE_IDENTITY()
     IF(@out_id>0)
     BEGIN
      SELECT @alert_msg= ''Inserted successfully with Id-''+convert(varchar(10),@out_id)
     END
     ELSE 
     BEGIN
      SELECT @alert_msg=''Error in insert.''
     END
   '+@cond_unique_2+'
 


END


'

declare @result int
begin try
exec @result=sp_executesql @sql
--select @sql
select 'Operation Successfully'
end try
begin catch
select ERROR_MESSAGE()
end catch
";
        // create a new parameter


        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@tbl_name";
        param.Value = tblName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@obj_name";
        param.Value = objName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@unique_check";
        param.Value = uniqueCheck;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@unique_check_label";
        param.Value = uniqueCheckLabels;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@insert_only";
        param.Value = InsertOnly;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@auto_generated";
        param.Value = autoGenerated;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        // return the result table
        String table = gda.ExecuteScalar_ForSelectedProject(comm);
        return table;
    }

    #endregion

    #region CreateDeleteProcedure Function
    /// <summary>
    /// This function is used to create delete sp in selected project
    /// </summary>
    /// <param name="conString"></param>
    /// <param name="tblName"></param>
    /// <param name="objName"></param>
    /// <returns></returns>
    public static String CreateDeleteProcedure(string conString, string tblName, string objName,string  is_delete_param,string unique_id)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conString);
        // set the command text
        comm.CommandText = @"if(@obj_name='')
                            set @obj_name=@tbl_name+'_selectby_id'
                            declare @sql nvarchar(max)

                            declare @prefx varchar(20)
                            set @prefx ='tbl'
                            select @prefx=substring([name],0,charindex('_',[name])) from  sys.columns where  [object_id]=object_id(@tbl_name) and column_id =10
                            
                            declare @clmn varchar(max)
							declare @unique varchar(max),
							@unique_param varchar(max)='',@unique_check varchar(max)='',@unique_update varchar(max)=''

							set @unique_check = isnull(@is_delete_param,'') 
                            declare @primary_field varchar(100)
                            select top 1 @primary_field=col.name
                            from syscolumns col inner join 
                            sysobjects sob on col.id = sob.id and sob.XType = 'U'
                            inner join systypes st on col.usertype = st.usertype
                            and col.xtype = st.xtype
                            and col.id = object_id(@tbl_name)
                            order by colorder

       --                     select 
							-- @unique=COALESCE(@unique ,'') +case when patindex('%,'+col.[name]+',%',','+@unique_check+',')>0 then  case when isnull(@unique,'')!='' and col.[name] not like '%_ip%' then ' and ' else'' end + 
							-- case  when col.[name] like '%_ip%' then '' when col.[name] like '%is_status%' then col.[name] + '=1' when col.[name] like '%is_delete%' then col.[name] + '=0' when col.[name] like '%status%' then col.[name] + '=1' when col.[name] like '%delete%' then col.[name] + '=0' else 
							-- col.[name] + '='+ '@'+ col.[name] end  else '' end
       --                     from  sys.columns col inner join
							--systypes st on col.user_type_id = st.xtype 
							--where  col.[object_id]=object_id(@tbl_name) 
							--and (col.[name] not like '%_date%' --and col.[name] not like '%_by%' and col.[name] not like '%_ip%'
							--)

							      select 
							 @unique=COALESCE(@unique ,'') +case when patindex('%,'+col.[name]+',%',','+@unique_check+',')>0 then  case when isnull(@unique,'')!='' and col.[name] not like '%_ip%' then ' and ' else'' end + 
							 case  when col.[name] like '%_ip%' then '' when col.[name] like '%is_status%' then col.[name] + '=1' when col.[name] like '%is_delete%' then col.[name] + '=0' when col.[name] like '%status%' then col.[name] + '=1' when col.[name] like '%delete%' then col.[name] + '=0' else 
							 col.[name] + '='+ '@'+ col.[name] end  else '' end
                            from  sys.columns col inner join
							systypes st on col.user_type_id = st.xtype 
							where  col.[object_id]=object_id(@tbl_name) 
							and (col.[name] not like '%_date%' and col.[name] not like '%_by%' and col.[name] not like '%_ip%' and col.[name] not like '%_delete%') 

							 select 
                             @unique_param=COALESCE(@unique_param ,'') +case when patindex('%,'+col.[name]+',%',','+@unique_check+',')>0 then  
							 case when isnull(@unique_param,'')!=''  then ' , ' else'' end 
							 + '@' + col.[name] + ' '+ case when st.name like '%char%' then st.name + '(max)' else   st.name  end
							 else '' end
                            from  sys.columns col inner join
							systypes st on col.user_type_id = st.xtype 
							where  col.[object_id]=object_id(@tbl_name) 
							and (col.[name] not like '%is_status%' and col.[name] not like '%Is_Delete%' and col.[name] not like '%_date%') 

							 select 
							 @clmn=COALESCE(@clmn +char(13)+' ','') +case when isnull(@clmn,'')!='' then ',' else '' end  +col.[name]+ '='+case when col.[name] like '%_date%' then 'GETDATE()' when col.[name] like '%_delete%' then '1' else '@'+ col.[name] end
                            from  sys.columns col inner join
							systypes st on col.user_type_id = st.xtype 
							where  col.[object_id]=object_id(@tbl_name) 
							and (col.[name] not like '%is_status%' )
							and  PATINDEX('%,'+cast(col.[name] as varchar(39))+',%',','+@is_delete_param+',')>0 
							and col.[name]!=@unique_id
set @sql='	
CREATE PROCEDURE [dbo].['+@obj_name+']
'+@unique_param+'
AS
BEGIN
	UPDATE  '+@tbl_name+'
	SET '+@clmn+'
	 where '+ @unique +'
END
'

declare @result int
begin try
exec @result=sp_executesql @sql
--select @sql
select 'Operation Successfully'
end try
begin catch
	select ERROR_MESSAGE()
end catch
";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@tbl_name";
        param.Value = tblName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@obj_name";
        param.Value = objName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@unique_id";
        param.Value = unique_id;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@is_delete_param";
        param.Value = is_delete_param;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        // return the result table
        String table = gda.ExecuteScalar_ForSelectedProject(comm);
        return table;
    }

    #endregion

    #region CreateUpdateProcedure Function
    /// <summary>
    /// function for create update procedure
    /// </summary>
    /// <param name="tblName">pass table name whose update procedure is needed</param>
    /// <param name="objName">pass update procedure name</param>
    /// <returns>appropriate message</returns>
    public static String CreateUpdateProcedure(string conString, string tblName, string objName, string uniqueCheck, string uniqueCheckLabels, string InsertOnly, string autoGenerated)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conString);
        // set the command text
        comm.CommandText = @"if(@obj_name='')
                            set @obj_name=@tbl_name+'_update'
                            declare @sql nvarchar(max)

                            declare @clmn_paramwdt varchar(max)
                            declare @clmn_param varchar(max)

                            declare @unique varchar(max)
                            declare @cond_unique_1 varchar(max)
                            declare @cond_unique_2 varchar(max)
                            set @cond_unique_1=''
                            set @cond_unique_2='' 


                            declare @primary_field varchar(100)
                            select top 1 @primary_field=col.name
                            from syscolumns col inner join 
                            sysobjects sob on col.id = sob.id and sob.XType = 'U'
                            inner join systypes st on col.usertype = st.usertype
                            and col.xtype = st.xtype
                            and col.id = object_id(@tbl_name)
                            order by colorder

                            select 
                            @clmn_paramwdt=case when [name]='modify_dnt' then @clmn_paramwdt else  COALESCE(@clmn_paramwdt + ','+char(13)+' ','') +'@'+[name]+' '+( select 
                            case st.name when 'varchar' then st.name+'('+convert(varchar,case col.length when -1 then 'MAX' else convert(varchar,col.length) end)+')'
                            when 'nvarchar' then st.name+'('+convert(varchar,col.length)+')'
                            when 'char' then st.name+'('+convert(varchar,col.length)+')'
                            when 'decimal' then st.name+'('+convert(varchar,col.xprec)+','+convert(varchar,col.xscale)+')'
                            when 'nchar' then st.name+'('+convert(varchar,col.length)+')' 
                            else st.name end
                            from syscolumns col inner join
                            systypes st on col.usertype = st.usertype 
                            and col.xtype = st.xtype 
                            where id=[object_id] and colid=column_id) end,
                            @clmn_param=COALESCE(@clmn_param +char(13)+' ','') +case when isnull(@clmn_param,'')!='' then ',' else '' end  +[name]+ '='+case when [name]='modify_dnt' then 'GETDATE()' else '@'+ [name] end,
                            @unique=COALESCE(@unique ,'') +case when patindex('%,'+[name]+',%',','+@unique_check+',')>0 then  case when isnull(@unique,'')!='' then ' or ' else '' end + [name]+ '='+'@'+ [name] else '' end
                            from  sys.columns where  [object_id]=object_id(@tbl_name) 
                            and column_id !=1 and [name] not like '%create_by%' and [name] not like '%create_ip%' and [name] not like '%create_dnt%'


                             if(@unique_check !='')
                             set @cond_unique_1='IF(not exists(select * from '+@tbl_name+' with(nolock) where ( '+@unique+' )  and '+@primary_field+'!=@'+@primary_field+' ))
    BEGIN'

   if(@unique_check != '')
    set @cond_unique_2='END
    ELSE
    BEGIN
        SELECT @out_id=0
        SELECT @alert_msg='' '+isnull(@unique_check_label,'')+' already exists.''
    END'




set @sql='	
CREATE PROCEDURE [dbo].['+@obj_name+']
'+@clmn_paramwdt+',
@'+@primary_field+' bigint,
@out_id bigint output,
@alert_msg varchar(300) output
AS
BEGIN
    
'+@cond_unique_1+'

   Update '+@tbl_name+' set
    '+@clmn_param+'
    Where '+@primary_field+'=@'+@primary_field+'

    SELECT @out_id=@'+@primary_field+'
    SELECT @alert_msg= ''Updated successfully with Id- ''+convert(varchar(10),@out_id)

 '+@cond_unique_2+'

END
'

declare @result int
begin try
exec @result=sp_executesql @sql
select 'Operation Successfully'
end try
begin catch
	select ERROR_MESSAGE()
end catch
";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@tbl_name";
        param.Value = tblName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@obj_name";
        param.Value = objName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        param = comm.CreateParameter();
        param.ParameterName = "@unique_check";
        param.Value = uniqueCheck;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@unique_check_label";
        param.Value = uniqueCheckLabels;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@insert_only";
        param.Value = InsertOnly;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@auto_generated";
        param.Value = autoGenerated;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        // return the result table
        String table = gda.ExecuteScalar_ForSelectedProject(comm);
        return table;
    }

    #endregion

    #region CreateSelectByIDProcedure Function
    /// <summary>
    /// This function is used to create selected record by id in selected project
    /// </summary>
    /// <param name="conString"></param>
    /// <param name="tableName"></param>
    /// <param name="objName"></param>
    /// <returns></returns>
    public static String CreateSelectByIDProcedure(string conString, string tableName, string objName,string is_delete_param, string is_status_param)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conString);
        // set the command text
        comm.CommandText = @"if(@obj_name='')
                            set @obj_name=@tbl_name+'_selectby_id'
                            declare @sql nvarchar(max)

                            declare @prefx varchar(20)
                            set @prefx ='tbl'
                            select @prefx=substring([name],0,charindex('_',[name])) from  sys.columns where  [object_id]=object_id(@tbl_name) and column_id =10
                            
                            declare @clmn varchar(max)
							declare @unique varchar(max),
							@unique_param varchar(max),@unique_check varchar(max)

							set @unique_check = isnull(@is_delete_param,'') + ',' + isnull(@is_status_param,'')
                            declare @primary_field varchar(100)
                            select top 1 @primary_field=col.name
                            from syscolumns col inner join 
                            sysobjects sob on col.id = sob.id and sob.XType = 'U'
                            inner join systypes st on col.usertype = st.usertype
                            and col.xtype = st.xtype
                            and col.id = object_id(@tbl_name)
                            order by colorder

                            select 
                            @clmn=COALESCE(@clmn + ','+char(13)+' ','') +@prefx+'.'+col.[name],
							 @unique=COALESCE(@unique ,'') +case when patindex('%,'+col.[name]+',%',','+@unique_check+',')>0 then  case when isnull(@unique,'')!='' and col.[name] not like '%_ip%' then ' and ' else'' end + 
							 case  when col.[name] like '%_ip%' then '' when col.[name] like '%is_status%' then col.[name] + '=1' when col.[name] like '%is_delete%' then col.[name] + '=0' when col.[name] like '%status%' then col.[name] + '=1' when col.[name] like '%delete%' then col.[name] + '=0' else 
							 col.[name] + '='+ '@'+ col.[name] end  else '' end
                            from  sys.columns col inner join
							systypes st on col.user_type_id = st.xtype 
							where  col.[object_id]=object_id(@tbl_name) 
							and (col.[name] not like '%_date%' and col.[name] not like '%_by%' and col.[name] not like '%_ip%')

							 select 
                             @unique_param=COALESCE(@unique_param ,'') +case when patindex('%,'+col.[name]+',%',','+@unique_check+',')>0 then  
							 case when isnull(@unique_param,'')!=''  then ' , ' else'' end 
							 + '@' + col.[name] + ' '+ case when st.name like '%char%' then st.name + '(max)' else   st.name  end
							 else '' end
                            from  sys.columns col inner join
							systypes st on col.user_type_id = st.xtype 
							where  col.[object_id]=object_id(@tbl_name) 
							and (col.[name] not like '%is_status%' and col.[name] not like '%Is_Delete%' and col.[name] not like '%_date%' and col.[name] not like '%_by%' and col.[name] not like '%_ip%')

							--select @unique
set @sql='	
CREATE PROCEDURE [dbo].['+@obj_name+']
@insitute_id bigint,
'+@unique_param+'
AS
BEGIN
	SELECT 
	'+@clmn+'
	from '+@tbl_name+' as '+@prefx+' with(nolock) where '+ @unique +'
END
'

declare @result int
begin try
exec @result=sp_executesql @sql
--select @sql
select 'Operation Successfully'
end try
begin catch
	select ERROR_MESSAGE()
end catch
";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@tbl_name";
        param.Value = tableName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@obj_name";
        param.Value = objName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@is_status_param";
        param.Value = is_status_param;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@is_delete_param";
        param.Value = is_delete_param;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        // return the result table
        String table = gda.ExecuteScalar_ForSelectedProject(comm);
        return table;
    }

    #endregion

    #region CreateSelectALLProcedure Function
    /// <summary>
    /// This function is used to create Select all sp in selected project
    /// </summary>
    /// <param name="conString"></param>
    /// <param name="tableName"></param>
    /// <param name="objName"></param>
    /// <returns></returns>
    public static String CreateSelectALLProcedure(string conString, string tableName, string objName)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conString);
        // set the command text 
        comm.CommandText = @"if(@obj_name='')
                            set @obj_name=@tbl_name+'_select_all'
                            declare @sql nvarchar(max)

                            
                            declare @clmn varchar(max)

                            declare @prefx varchar(20)
                            set @prefx ='tbl'
                            select @prefx=substring([name],0,charindex('_',[name])) from  sys.columns where  [object_id]=object_id(@tbl_name) and column_id =10

                            select 
                            @clmn=COALESCE(@clmn + ','+char(13)+' ','') +@prefx+'.'+[name]
                            from  sys.columns where  [object_id]=object_id(@tbl_name) 

set @sql='	
CREATE PROCEDURE [dbo].['+@obj_name+']
AS
BEGIN
	select 
	'+@clmn+' 
	from '+@tbl_name+' as '+@prefx+' with(nolock)
	where '+@prefx+'.status=1
END
'

declare @result int
begin try
exec @result=sp_executesql @sql
select 'Operation Successfully'
end try
begin catch
	select ERROR_MESSAGE()
end catch
";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@tbl_name";
        param.Value = tableName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@obj_name";
        param.Value = objName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        // return the result table
        String table = gda.ExecuteScalar_ForSelectedProject(comm);
        return table;

    }

    #endregion

    #region CreateSelectProcedure Function
    /// <summary>
    /// This function is used to create select sp in selected sp
    /// </summary>
    /// <param name="conString"></param>
    /// <param name="tableName"></param>
    /// <param name="objName"></param>
    /// <returns></returns>
    public static String CreateSelectProcedure(string conString, string tableName, string objName)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conString);
        // set the command text
        comm.CommandText = @"if(@obj_name='')
                            set @obj_name=@tbl_name+'_select'
                            declare @sql nvarchar(max)

                            
                            declare @clmn varchar(max)
                            declare @clmnSearch varchar(max)
                            declare @prefx varchar(20)
                            set @prefx ='tbl'
                            select @prefx=substring([name],0,charindex('_',[name])) from  sys.columns where  [object_id]=object_id(@tbl_name) and column_id =10
                            select 
                            @clmn=COALESCE(@clmn + ','+char(13)+' ','') +@prefx+'.'+[name]
                            from  sys.columns where  [object_id]=object_id(@tbl_name) 
                            and [name] not in 
                            ('comp_id',
                             'create_by',
                             'create_ip',
                             'modify_by',
                             'modify_ip')


set @sql='	
CREATE PROCEDURE [dbo].['+@obj_name+']
@insitute_id bigint
AS
BEGIN

SELECT 
'+@clmn+'
FROM '+@tbl_name+' '+@prefx+' with(nolock)


END
'
--euser.usrm_name as create_by_user,
--muser.usrm_name as modify_by_user,
--left join i_conf_user_mst euser with(nolock) on '+@prefx+'.create_by = euser.id
--left join i_conf_user_mst muser with(nolock) on '+@prefx+'.modify_by = muser.id 
--where '+@prefx+'.comp_id=@comp_id
--order by isnull('+@prefx+'.modify_dnt,'+@prefx+'.create_dnt) desc
print @sql
declare @result int
begin try
exec @result=sp_executesql @sql
--select @sql
select 'Operation Successfully'
end try
begin catch
	select ERROR_MESSAGE()
end catch
";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@tbl_name";
        param.Value = tableName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@obj_name";
        param.Value = objName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        // return the result table
        String table = gda.ExecuteScalar_ForSelectedProject(comm);
        return table;
    }

    #endregion

    #region Function for get all the fields of given table
    /// <summary>
    /// This Function used to get all the fields of given table
    /// </summary>    
    /// <param name="tbl_name">pass the table name whose fields need to fetch</param>
    /// <returns>This function is return all tables of database</returns>
    public static DataTable GetAllField(string tbl_name)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();

        DbCommand comm = gda.CreateCommand();
        // set the stored procedure name
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@tbl_name";
        param.Value = tbl_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        // set the stored procedure name
        comm.CommandText = "i_field_Select";

        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;
    }
    #endregion

    #region GetTblData Function
    /// <summary>
    /// This function is use to get all table data by table name 
    /// </summary>
    /// <param name="tbl_name">Passed table name</param>
    /// <returns>Return datatable in passed table data</returns>
    public static DataTable GetTblData(string tbl_name)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "i_table_Select";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@tbl_name";
        param.Value = tbl_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;
    }

    #endregion

    //#region function for create log table for passed table
    ///// <summary>
    ///// function for create log table for passed table
    ///// </summary>
    ///// <param name="tbl_name">pass table name whose log table is needed</param>
    ///// <returns>apropriate message</returns>
    //public static String CreateLogTable(string tbl_name)
    //{
    //    // get a configured DbCommand object
    //    DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
    //    DbCommand comm = gda.CreateCommand();
    //    // set the stored procedure name
    //    comm.CommandText = "i_create_log_table";
    //    // create a new parameter
    //    DbParameter param = comm.CreateParameter();
    //    param.ParameterName = "@tbl_name";
    //    param.Value = tbl_name;
    //    param.DbType = DbType.String;
    //    comm.Parameters.Add(param);
    //    // return the result table
    //    String table = gda.ExecuteScalar(comm);
    //    return table;
    //}

    //#endregion

    #region function for create Count procedure
    /// <summary>
    /// function for create Count procedure
    /// </summary>
    /// <param name="tbl_name">pass table name whose Count procedure is needed</param>
    /// <param name="obj_name">pass Count procedure name</param>
    /// <returns>apropriate message</returns>
    public static String CreateCountProcedure(string tbl_name, string obj_name)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "i_Create_Count_procedure";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@tbl_name";
        param.Value = tbl_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@obj_name";
        param.Value = obj_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        // return the result table
        String table = gda.ExecuteScalar(comm);
        return table;
    }

    #endregion

    #region function for create Log Select procedure
    /// <summary>
    /// This function is used to create select log sp in selected project
    /// </summary>
    /// <param name="conString"></param>
    /// <param name="tbl_name"></param>
    /// <param name="obj_name"></param>
    /// <returns></returns>
    public static String CreateLogSelectProcedure(string conString, string tbl_name, string obj_name, string unique_check)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conString);
        // set the command text
        comm.CommandText = @"if(@obj_name='')
                            set @obj_name=@tbl_name+'_log_select'
                            declare @sql nvarchar(max),
							@clmn_delete nvarchar(max)		

                            declare @prefx varchar(20)
                            declare @clmn varchar(max)
                            declare @clmnSearch varchar(max)
                            set @prefx ='tbl'
                            select @prefx=substring([name],0,charindex('_',[name])) from  sys.columns where  [object_id]=object_id(@tbl_name) and column_id =10
                            select 
                            @clmn=COALESCE(@clmn + ','+char(13)+' ','') + case when [name] like '%_by' then CONCAT('dbo.GETEMPUSERNAMEBYCONFIG(',@prefx,'.',[name],') AS ',[name]) else CONCAT(@prefx,'.',[name]) end 
                            from  sys.columns where  [object_id]=object_id(@tbl_name) 
                            and [name] not in 
                            ('comp_id',
                             'create_by',
                             'create_ip',
                             'modify_by',
                             'modify_ip')
						
							 select top 1 @clmn_delete= [name] from sys.columns where [name] like '%is_delete%'   and [object_id]=object_id(@tbl_name) 
						
							
set @sql='	
CREATE PROCEDURE [dbo].['+@obj_name+']
@'+@unique_check+' bigint,
@institue_id bigint
AS
BEGIN

SELECT 
case '+@prefx+'.operation_type when 1 then ''Insert'' when 2 then ''Update'' when 3 then ''Delete'' else '''' end as operation_type, 
'+@prefx+'.operation_dnt,
'+@clmn+'
FROM '+@tbl_name+'_log '+@prefx+' with(nolock)
where  '+@prefx+'.'+@unique_check+'=@'+@unique_check +'
AND '+@prefx+'.'+@unique_check+'= case when @'+@unique_check+'=0 then '+@prefx+'.'+@unique_check+' else @'+@unique_check+' end 
and isnull('+@prefx+'.'+@clmn_delete+',0)=0
order by '+@prefx+'.operation_dnt desc



END
'
print @sql
declare @result int
begin try
exec @result=sp_executesql @sql
--select @sql
select 'Operation Successfully'
end try
begin catch
	select ERROR_MESSAGE()
end catch
";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@tbl_name";
        param.Value = tbl_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@obj_name";
        param.Value = obj_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@unique_check";
        param.Value = unique_check;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        // return the result table
        String table = gda.ExecuteScalar_ForSelectedProject(comm);
        return table;
    }

    #endregion

    #region function for create Log Count procedure
    /// <summary>
    /// function for create Log Count procedure
    /// </summary>
    /// <param name="tbl_name">pass table name whose Log Count procedure is needed</param>
    /// <param name="obj_name">pass Log Count procedure name</param>
    /// <returns>apropriate message</returns>
    public static String CreateLogCountProcedure(string tbl_name, string obj_name)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "i_Create_Log_Count_procedure";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@tbl_name";
        param.Value = tbl_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@obj_name";
        param.Value = obj_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        // return the result table
        String table = gda.ExecuteScalar(comm);
        return table;
    }

    #endregion

    #region function for create Deleted Log Select procedure
    /// <summary>
    /// This function is used to create selected deleted log in select project
    /// </summary>
    /// <param name="conString"></param>
    /// <param name="tbl_name"></param>
    /// <param name="obj_name"></param>
    /// <returns></returns>
    public static String CreateDeletedLogSelectProcedure(string conString, string tbl_name, string obj_name)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conString);
        // set the command text
        comm.CommandText = @"if(@obj_name='')
                            set @obj_name=@tbl_name+'_del_log_select'
                            declare @sql nvarchar(max)

                            declare @prefx varchar(20)
                            declare @clmn varchar(max)
                            declare @clmnSearch varchar(max)
                            set @prefx ='tbl'
                            select @prefx=substring([name],0,charindex('_',[name])) from  sys.columns where  [object_id]=object_id(@tbl_name) and column_id =10
                            select 
                            @clmn=COALESCE(@clmn + ','+char(13)+' ','') +@prefx+'.'+[name]
                            from  sys.columns where  [object_id]=object_id(@tbl_name) 
                            and [name] not in 
                            ('comp_id',
                             'create_by',
                             'create_ip',
                             'modify_by',
                             'modify_ip')


set @sql='	
CREATE PROCEDURE [dbo].['+@obj_name+']
@user_id bigint,
@comp_id bigint
AS
BEGIN

SELECT 
case '+@prefx+'.operation_type when 1 then ''Insert'' when 2 then ''Update'' when 3 then ''Delete'' else '''' end as operation_type, 
'+@prefx+'.operation_dnt,
euser.usrm_name as create_by_user,
muser.usrm_name as modify_by_user,
'+@clmn+'
FROM '+@tbl_name+'_log '+@prefx+' with(nolock)
left join i_conf_user_mst euser with(nolock) on '+@prefx+'.create_by = euser.id
left join i_conf_user_mst muser with(nolock) on '+@prefx+'.modify_by = muser.id
where  '+@prefx+'.operation_type=3 and '+@prefx+'.comp_id=@comp_id
order by '+@prefx+'.operation_dnt desc

END
'
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
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@tbl_name";
        param.Value = tbl_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@obj_name";
        param.Value = obj_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        // return the result table
        String table = gda.ExecuteScalar_ForSelectedProject(comm);
        return table;
    }

    #endregion

    #region function for create Deleted Log Count procedure
    /// <summary>
    /// function for create Deleted Log Count procedure
    /// </summary>
    /// <param name="tbl_name">pass table name whose Deleted Log Count procedure is needed</param>
    /// <param name="obj_name">pass Deleted Log Count procedure name</param>
    /// <returns>apropriate message</returns>
    public static String CreateDeletedLogCountProcedure(string tbl_name, string obj_name)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "i_Create_Del_Log_Count_procedure";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@tbl_name";
        param.Value = tbl_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@obj_name";
        param.Value = obj_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        // return the result table
        String table = gda.ExecuteScalar(comm);
        return table;
    }

    #endregion

    #region CreateCustomSP Function
    /// <summary>
    /// 
    /// </summary>
    /// <param name="conString"></param>
    /// <param name="spName"></param>
    /// <param name="spText"></param>
    /// <returns></returns>
    public static String CreateCustomSP(string conString, string spText)
    {
        // get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand(conString);
        // set the command text 
        comm.CommandText = @"  
declare @sql nvarchar(max)

set @sql='	
'+@sp_text+'
'

declare @result int
begin try
exec @result=sp_executesql @sql
select 'Operation Successfully'
end try
begin catch
	select ERROR_MESSAGE()
end catch
";
        // create a new parameter
        DbParameter param = comm.CreateParameter();

        param = comm.CreateParameter();
        param.ParameterName = "@sp_text";
        param.Value = spText;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        // return the result table
        String table = gda.ExecuteScalar_ForSelectedProject(comm);
        return table;

    }

    #endregion

    #region Insert Function
    /// <summary>
    /// This function is insert data in to the entt_customer_mst data.
    /// </summary>
    /// <param name="obj">Pass the instance object of PROP_entt_customer_mst</param>
    /// <returns>Return if entt_customer_mst is inserted then id otherwise 0</returns>
    public static Int32 Insert(PROP_dynamic_form_configuration obj)
    {
        /// get a configured DbCommand object
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        /// set the stored procedure name
        comm.CommandText = "i_conf_dynamic_form_configuration_insert";

        /// create a new parameter
        DbParameter param = comm.CreateParameter();
        param = comm.CreateParameter();
        param.ParameterName = "@dfc_project_id";
        param.Value = obj.dfc_project_id;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@dfc_project_name";
        param.Value = obj.dfc_project_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@dfc_table_name";
        param.Value = obj.dfc_table_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@dfc_menu_name";
        param.Value = obj.dfc_menu_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@dfc_column_name";
        param.Value = obj.dfc_column_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@dfc_column_datatype";
        param.Value = obj.dfc_column_datatype;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@dfc_column_size";
        param.Value = obj.dfc_column_size;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@dfc_entry_req";
        param.Value = obj.dfc_entry_req;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "dfc_is_compulsory";
        param.Value = obj.dfc_is_compulsory;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@dfc_column_lable";
        param.Value = obj.dfc_column_lable;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@dfc_column_entry_control";
        param.Value = obj.dfc_column_entry_control;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@dfc_column_is_enum";
        param.Value = obj.dfc_column_is_enum;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@dfc_enum_Value";
        param.Value = obj.dfc_enum_Value;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@dfc_is_function_exist";
        param.Value = obj.dfc_is_function_exist;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@dfc_function_info";
        param.Value = obj.dfc_function_info;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@dfc_order";
        param.Value = obj.dfc_order;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@dfc_action_method";
        param.Value = obj.dfc_action_method;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@dfc_action_func_name";
        param.Value = obj.dfc_action_func_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@dfc_action_url";
        param.Value = obj.dfc_action_url;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@dfc_version";
        param.Value = obj.dfc_version;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@dfc_is_unique_check";
        param.Value = obj.dfc_is_unique_check;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@dfc_is_insert_only";
        param.Value = obj.dfc_is_insert_only;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@dfc_is_auto_generated";
        param.Value = obj.dfc_is_auto_generated;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int ret_id = gda.ExecuteNonQuery(comm);

        //PROP_db_return retObj = new PROP_db_return();
        //int resultval = gda.ExecuteNonQuery(comm);
        //retObj.id = Handle.ToInt32(comm.Parameters["@out_id"].Value);
        //retObj.alertMessage = Handle.ToString(comm.Parameters["@alert_msg"].Value);
        return ret_id;
    }
    #endregion

    #region GetMaximumVersion Function
    /// <summary>
    /// This function is use to get maximum version
    /// </summary>
    public static int GetMaximumVersion(string db_name, string tbl)
    {
        DAL_GenericDataAccess gda = new DAL_GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@db_name";
        param.Value = db_name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@tbl";
        param.Value = tbl;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        comm.CommandText = "i_Get_Maximum_Version";
        // return the result table
        int maxversion = Handle.ToInt32(gda.ExecuteScalar(comm));
        return maxversion;
    }
    #endregion

}