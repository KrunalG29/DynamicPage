using System;
using System.Configuration;
using System.Data;

/// <summary>
/// Repository for configuration settings
/// </summary>
public static class DAL_WebConfiguration
{
    // Caches the connection string
    private readonly static string dbConnectionString;

    // Caches the data provider name 
    private readonly static string dbProviderName;

    //Log connection string
    private readonly static string dbLogConnectionString;

    //Log Provider Name
    private readonly static string dbLogProviderName;

    // Caches the Backup connection string 
    private readonly static string dbConnectionStringBackup;

    // Caches the data AutoBackup 
    private readonly static string dbBackupAuto;

    // Initialize various properties in the constructor
    static DAL_WebConfiguration()
    {
        dbConnectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        dbProviderName = ConfigurationManager.ConnectionStrings["ConStr"].ProviderName;
    }

    // Returns the connection string for the database
    public static string DbConnectionString
    {
        get
        {
            return dbConnectionString;
        }
    }

    // Returns the data provider name
    public static string DbProviderName
    {
        get
        {
            return dbProviderName;
        }
    }
    //Returns Log database connection string
    public static string DbLogConnectionString
    {
        get
        {
            return dbLogConnectionString;
        }
    }
    //Returns Log database provider name
    public static string DbLogProviderName
    {
        get
        {
            return dbLogProviderName;
        }
    }

    // Returns the connection string for the database Backup
    public static string DbConnectionStringBackup
    {
        get
        {
            return dbConnectionStringBackup;
        }
    }

    // Returns the data AutoBbackup
    public static string DbBackupAuto
    {
        get
        {
            return dbBackupAuto;
        }
    }



}
