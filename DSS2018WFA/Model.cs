using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Data.Common;
using System.Configuration;

namespace DSS2018WFA
{
    class Model
    {
        public delegate void viewEventHandler(object sender, string textToWrite);
        public viewEventHandler FlushText;

        public void doSomathing()
        {
            //devo flushare il testo in qualche modo
            for (int i = 0; i < 10; i++)
                FlushText(this, $"i={i}");
        }

        //sqLiteConnection è la stringa che configura la connesione a un db
        public void readClients(string sqLiteConnString)
        {
            IDbConnection conn = new SQLiteConnection(sqLiteConnString);
            conn.Open();
            IDbCommand com = conn.CreateCommand();
            string queryText = "select id,nome from clienti";
            com.CommandText = queryText;
            IDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                FlushText(this, reader["id"] + " " + reader["nome"]);
            }
            reader.Close();
            conn.Close();
        }

        public void launchParametrizedQuery(string sqLiteConnString, string factory, int id)
        {
            IDbConnection conn = new SQLiteConnection(sqLiteConnString);
            conn.Open();
            IDbCommand com = conn.CreateCommand();
            com.CommandText = "select nome from clienti where id=@id";
            IDbDataParameter param = com.CreateParameter();
            param.DbType = DbType.Int32;
            param.ParameterName = "@id";
            param.Value = id;
            com.Parameters.Add(param);
            using (IDataReader dr = com.ExecuteReader())
            {
                while (dr.Read()) { FlushText(this, "nome: " + dr["nome"]); }
                dr.Close();
            }
            conn.Close();
        }

        public void lauchParametrizedQueryTecnologyIndipendent(string connString, string factory, int id)
        {
            DataSet ds = new DataSet();
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(factory);
            using (DbConnection conn = dbFactory.CreateConnection())
            {
                try
                {
                    conn.ConnectionString = connString;
                    conn.Open();
                    DbDataAdapter dbAdapter = dbFactory.CreateDataAdapter();
                    DbCommand dbCommand = conn.CreateCommand();
                    dbCommand.CommandText = "select id,nome from clienti where id = @id";
                    DbParameter param = dbCommand.CreateParameter();
                    param.DbType = DbType.Int32;
                    param.ParameterName = "@id";
                    param.Value = id;
                    dbCommand.Parameters.Add(param);
                    dbAdapter.SelectCommand = dbCommand;
                    dbAdapter.Fill(ds);
                    ds.Tables[0].TableName = "clienti";
                    foreach (DataRow dr in ds.Tables["clienti"].Rows)
                        FlushText(this, dr["nome"].ToString());
                }
                catch (Exception ex)
                {
                    FlushText(this, "[FillDataSet] Error:" + ex);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }
        }
    }
}
