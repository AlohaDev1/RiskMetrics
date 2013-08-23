using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MetricsCorporation.EFCore
{
    public partial class MetricsCorporationUnitOfWork : IDisposable
    {
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void CloseConnection()
        {
            MySqlConnection conn = (MySqlConnection)_context.Database.Connection  ;
            if (conn.State != System.Data.ConnectionState.Broken && conn.State != System.Data.ConnectionState.Closed)
                conn.Close();
        }

        public static bool InitializeUnitOfWork(ref MetricsCorporationUnitOfWork unit)
        {
            if (unit == null)
            {
                unit = new MetricsCorporationUnitOfWork();
                return true;
            }
            else
                return false;
        }

        public bool ProxyCreation
        {
            get
            {
                return _context.ObjectContext.ContextOptions.ProxyCreationEnabled;
            }
            set
            {
                _context.ObjectContext.ContextOptions.ProxyCreationEnabled = value;
            }
        }
    }
}
