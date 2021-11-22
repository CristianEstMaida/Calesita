using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using Entidades;
using Archivos;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GuardarLeerArchivo()
        {
            List<Juego> juegos = new List<Juego>()
            {
                new Juego(10, new object())
            };
            JsonFiler<List<Juego>> json = new JsonFiler<List<Juego>>();
            string archivo = "prueba";
            List<Juego> juegosTest;

            json.Guardar(archivo, juegos);

            json.Leer(archivo, out juegosTest);

            Assert.AreEqual(juegos[0].Ubicacion, juegosTest[0].Ubicacion);
        }

        [TestMethod]
        [ExpectedException(typeof(ErrorArchivosExcepction))]
        public void GuardarLeerArchivoException()
        {
            List<Juego> juegos = new List<Juego>()
            {
                new Juego(10, new object())
            };
            JsonFiler<List<Juego>> json = new JsonFiler<List<Juego>>();
            
            json.Guardar(" ", juegos);
        }

        [TestMethod]
        public void AvanzarJuego()
        {
            Juego j = new Juego(10, new object());
            j.Velocidad = 15;
            short expexted = j.Avanzar();

            Assert.AreEqual(expexted, 25);
        }
    }
}
