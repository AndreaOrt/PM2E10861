using System;
using SQLite;

namespace PM2E10861.Models
{
    public class Localizacion
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(100)]
        public String latitud { get; set; }

        [MaxLength(100)]
        public String longitud { get; set; }

        [MaxLength(200)]
        public String descripcion_larga { get; set; }

        [MaxLength(100)]
        public String descripcion_corta { get; set; }

        public Localizacion()
        {

        }
    }
}
