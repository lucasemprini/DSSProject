using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DSS2018WFA
{
    class Controller
    { Model M = new Model();
    public delegate void viewEventHandler(object sender, string textToWrite); // questo gestisce l'evento
    public event viewEventHandler FlushText; // questo genera l'evanto

        public string connString, factory;
        public Controller()
        {
            M.FlushText += controllerViewEventHandler;

            string sdb = ConfigurationManager.AppSettings["dbServer"];
            switch (sdb)
            {
                case "SQLiteConn":
                    connString = ConfigurationManager.ConnectionStrings["SQLiteConn"].ConnectionString;
                    factory = ConfigurationManager.ConnectionStrings["SQLiteConn"].ProviderName;
                    string dbPath = @"C:\Users\feden\Documents\Visual Studio 2015\Projects\DSS2018WFA\testDb.sqlite";
                    //Qui va fatto un replace
                    connString = connString.Replace("DBFILE", dbPath);
                    break;
                case "LocalSqlServConn":
                    connString =
                    ConfigurationManager.ConnectionStrings["LocalDbConn"].ConnectionString;
                    factory = "System.Data.SqlClient";
                    break;

                default:
                    connString =
                    ConfigurationManager.ConnectionStrings["LocalDbConn"].ConnectionString;
                    factory = "System.Data.SqlClient";
                    break;

            }
        }
    private void controllerViewEventHandler(object sender, string textToWrite)
    { FlushText(this, textToWrite); }
    public void doSomething()
    {
            string dbpath = @"C:\Users\feden\Documents\Visual Studio 2015\Projects\DSS2018WFA\testDb.sqlite";
            Console.WriteLine(dbpath);
            string connString = @"Data Source=" + dbpath + "; Version=3";
            M.doSomathing();
            M.readClients(connString);
    }

    public void searchClients(string dbPath)
        {
            string connString = @"Data Source=" + dbPath + "; Version=3";
            M.readClients(connString);
        }

    public void searchClientsByID(int idValue)
        {
           // M.launchParametrizedQuery(connString, factory, idValue);
           M.lauchParametrizedQueryTecnologyIndipendent(connString,factory,idValue);
        }

    }
}

