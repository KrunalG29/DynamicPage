using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PROP_dynamic_form_configuration
/// </summary>
public class PROP_dynamic_form_configuration
{
    public PROP_dynamic_form_configuration()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private Int32 _id;
    public Int32 id
    {

        get { return _id; }
        set { _id = value; }
    }

    private Int32 _dfc_project_id;
    public Int32 dfc_project_id
    {

        get { return _dfc_project_id; }
        set { _dfc_project_id = value; }
    }

    private String _dfc_project_name;
    public String dfc_project_name
    {

        get { return _dfc_project_name; }
        set { _dfc_project_name = value; }
    }

    private String _dfc_table_name;
    public String dfc_table_name
    {

        get { return _dfc_table_name; }
        set { _dfc_table_name = value; }
    }

    private String _dfc_menu_name;
    public String dfc_menu_name
    {

        get { return _dfc_menu_name; }
        set { _dfc_menu_name = value; }
    }

    private String _dfc_column_name;
    public String dfc_column_name
    {

        get { return _dfc_column_name; }
        set { _dfc_column_name = value; }
    }

    private String _dfc_column_datatype;
    public String dfc_column_datatype
    {

        get { return _dfc_column_datatype; }
        set { _dfc_column_datatype = value; }
    }

    private Int32 _dfc_column_size;
    public Int32 dfc_column_size
    {

        get { return _dfc_column_size; }
        set { _dfc_column_size = value; }
    }

    private Int32 _dfc_entry_req;
    public Int32 dfc_entry_req
    {

        get { return _dfc_entry_req; }
        set { _dfc_entry_req = value; }
    }

    private Int32 _dfc_is_compulsory;
    public Int32 dfc_is_compulsory
    {

        get { return _dfc_is_compulsory; }
        set { _dfc_is_compulsory = value; }
    }

    private String _dfc_column_lable;
    public String dfc_column_lable
    {

        get { return _dfc_column_lable; }
        set { _dfc_column_lable = value; }
    }

    private Int32 _dfc_column_entry_control;
    public Int32 dfc_column_entry_control
    {

        get { return _dfc_column_entry_control; }
        set { _dfc_column_entry_control = value; }
    }

    private Int32 _dfc_column_is_enum;
    public Int32 dfc_column_is_enum
    {

        get { return _dfc_column_is_enum; }
        set { _dfc_column_is_enum = value; }
    }

    private String _dfc_enum_Value;
    public String dfc_enum_Value
    {

        get { return _dfc_enum_Value; }
        set { _dfc_enum_Value = value; }
    }

    private Int32 _dfc_is_function_exist;
    public Int32 dfc_is_function_exist
    {

        get { return _dfc_is_function_exist; }
        set { _dfc_is_function_exist = value; }
    }

    private String _dfc_function_info;
    public String dfc_function_info
    {

        get { return _dfc_function_info; }
        set { _dfc_function_info = value; }
    }

    private Int32 _dfc_order;
    public Int32 dfc_order
    {

        get { return _dfc_order; }
        set { _dfc_order = value; }
    }

    private String _dfc_action_method;
    public String dfc_action_method
    {

        get { return _dfc_action_method; }
        set { _dfc_action_method = value; }
    }

    private String _dfc_action_func_name;
    public String dfc_action_func_name
    {

        get { return _dfc_action_func_name; }
        set { _dfc_action_func_name = value; }
    }

    private String _dfc_action_url;
    public String dfc_action_url
    {

        get { return _dfc_action_url; }
        set { _dfc_action_url = value; }
    }

    private Int32 _dfc_version;
    public Int32 dfc_version
    {

        get { return _dfc_version; }
        set { _dfc_version = value; }
    }

    private Int32 _dfc_is_unique_check;
    public Int32 dfc_is_unique_check
    {

        get { return _dfc_is_unique_check; }
        set { _dfc_is_unique_check = value; }
    }
    private Int32 _dfc_is_insert_only;
    public Int32 dfc_is_insert_only
    {

        get { return _dfc_is_insert_only; }
        set { _dfc_is_insert_only = value; }
    }
    private Int32 _dfc_is_auto_generated;
    public Int32 dfc_is_auto_generated
    {

        get { return _dfc_is_auto_generated; }
        set { _dfc_is_auto_generated = value; }
    }
}