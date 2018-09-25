using System;
using LS.Shared;
using System.Data;
using System.Data.SqlClient;

namespace LS.Infra.StoreContext
{
    public class LsDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public LsDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}