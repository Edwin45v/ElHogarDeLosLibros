using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElHogar_DeLos_Libros.AccesoADatos;
using ElHogar_DeLos_Libros.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElHogar_DeLos_Libros.AccesoADatos.Tests
{
    [TestClass()]
    public class RolDALTests
    {
        private static Rol rolInicial = new Rol { Id = 2 };
        [TestMethod()]
        public void CrearAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CrearAsyncTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ModificarAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ObtenerPorIdAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ObtenerTodosAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarAsyncTest()
        {
            Assert.Fail();
        }
    }
}