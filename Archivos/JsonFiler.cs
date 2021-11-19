using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Archivos
{
    public class JsonFiler<T> : IMetodosArchivos<T>
    {
        public string GenerarRutaCompleta 
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
            }
        }

        public bool ExisteArchivo(string nombreArchivo)
        {
            return File.Exists(this.GenerarRutaCompleta + nombreArchivo);
        }

        public void Guardar(string archivo, T objeto)
        {
            string path = this.GenerarRutaCompleta + archivo;
            try
            {
                string json = JsonSerializer.Serialize<T>(objeto);
                File.WriteAllText(path, json);
                //JsonSerializer.Serialize(this.GenerarRutaCompleta + archivo);
            }
            catch (Exception ex)
            {

                throw new ErrorArchivosExcepction("Fallo al guardar", ex);
            }
            
        }

        public void Leer(string archivo, out T objeto)
        {
            string path = this.GenerarRutaCompleta + archivo;
            try
            {
                string json = File.ReadAllText(path);
                objeto = JsonSerializer.Deserialize<T>(json);
                //objeto = JsonSerializer.Deserialize<T>(this.GenerarRutaCompleta + archivo);
            }
            catch (Exception ex)
            {

                throw new ErrorArchivosExcepction("Fallo al leer", ex);
            }
        }
    }
}
