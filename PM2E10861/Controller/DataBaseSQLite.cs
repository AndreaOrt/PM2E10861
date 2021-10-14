using System;
using System.Threading.Tasks;
using SQLite;
using PM2E10861.Models;
using System.Collections.Generic;

namespace PM2E10861.Controller
{
    public class DataBaseSQLite
    {
        readonly SQLiteAsyncConnection db;

        public DataBaseSQLite(String pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<Localizacion>().Wait();
        }

        public Task<int> GuardarLocalizacion(Localizacion localizacion)
        {
            return db.InsertAsync(localizacion);
        }

        public Task<int> EliminarLocalizacion(Localizacion localizacion)
        {
            return db.DeleteAsync(localizacion);
        }

        public Task<List<Localizacion>> ObtenerListaLocalizacion()
        {
            return db.Table<Localizacion>().ToListAsync();
        }

    }
}
