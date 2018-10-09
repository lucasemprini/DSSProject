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
        
        public void readOrdersByEF()
        {
            testDbEntities context = new testDbEntities();
            
            List<int> dati = new List<int>();
            //select...
            foreach (ordini o in context.ordini)
            {

                dati.Add(Convert.ToInt32(o.codice));
                FlushText(this, o.codice + " " + o.descr);
            }
            double media = 0;
            foreach (int num in dati)
            {
                media += num;
            }
            media = media / dati.Count;
            FlushText(this, "Media: " + media);

            double scarti = 0;
            foreach (int num in dati)
            {
                double scarto = (num - media) * (num - media);
                scarti += scarto;
            }

            FlushText(this, "Varianza: " + scarti / dati.Count);

            FlushText(this, "Deviazione Standard: " + CalculateStdDev(dati));

            FlushText(this, "Mediana: " + CalculateMedian(dati));
        }

        private double CalculateStdDev(List<int> values)
        {
            double ret = 0;
            if (values.Count() > 0)
            {
                //Compute the Average      
                double avg = values.Average();
                //Perform the Sum of (value-avg)_2_2      
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                //Put it all together      
                ret = Math.Sqrt((sum) / (values.Count() - 1));
            }
            return ret;
        }
        private double CalculateMedian(List<int> values)
        {
            int numberCount = values.Count();
            int halfIndex = values.Count() / 2;
            var sortedNumbers = values.OrderBy(n => n);
            double median;
            if ((numberCount % 2) == 0)
            {
                median = ((sortedNumbers.ElementAt(halfIndex) +
                    sortedNumbers.ElementAt(halfIndex - 1)) / 2);
                return median;
            }
            else
            {
                median = sortedNumbers.ElementAt(halfIndex);
                return median;
            }

        }
    }

}
