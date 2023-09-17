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
    public class UsuarioDALTests
    {
        private static Usuario usuarioInicial = new Usuario { Id = 2, IdRol = 1, Login = "eg", Password = "22082002" };
        [TestMethod()]
        public async void T1CrearAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "edwin";
            usuario.Apellido = "galicia";
            usuario.Login = "eg";
            string password = "22082002";
            usuario.Password = password;
            usuario.Estatus = (byte)Estatus_Usuario.INACTIVO;
            int result = await UsuarioDAL.CrearAsync(usuario);
            Assert.AreNotEqual(0, result);
            usuarioInicial.Id = usuario.Id;
            usuarioInicial.Password = password;
            usuarioInicial.Login = usuario.Login;
        }

        [TestMethod()]
        public async void T2ModificarAsyncTest()
        {
            var usuario = new Usuario();
            usuario.Id = usuarioInicial.Id;
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "Edwin";
            usuario.Apellido = "Galicia";
            usuario.Login = "EdwinGalicica";
            usuario.Estatus = (byte)Estatus_Usuario.ACTIVO;
            int result = await UsuarioDAL.ModificarAsync(usuario);
            Assert.AreNotEqual(0, result);
            usuarioInicial.Login = usuario.Login;
        }

        [TestMethod()]
        public async void T3EliminarAsyncTest()
        {
            var usuario = new Usuario();
            usuario.Id = usuarioInicial.Id;
            int result = await UsuarioDAL.EliminarAsync(usuario);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async void T4ObtenerPorIdAsyncTest()
        {
            var usuario = new Usuario();
            usuario.Id = usuarioInicial.Id;
            var resultUsuario = await UsuarioDAL.ObtenerPorIdAsync(usuario);
            Assert.AreEqual(usuario.Id, resultUsuario.Id);
        }

        [TestMethod()]
        public async void T5ObtenerTodosAsyncTest()
        {
            var resultUsuarios = await UsuarioDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultUsuarios.Count);
        }

        [TestMethod()]
        public async void T6BuscarAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "A";
            usuario.Apellido = "a";
            usuario.Login = "A";
            usuario.Estatus = (byte)Estatus_Usuario.ACTIVO;
            usuario.Top_Aux = 10;
            var resultUsuarios = await UsuarioDAL.BuscarAsync(usuario);
            Assert.AreNotEqual(0, resultUsuarios.Count);
        }

        [TestMethod()]
        public async void T7BuscarIncluirRolesAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "A";
            usuario.Apellido = "a";
            usuario.Login = "A";
            usuario.Estatus = (byte)Estatus_Usuario.ACTIVO;
            usuario.Top_Aux = 10;
            var resultUsuarios = await UsuarioDAL.BuscarIncluirRolesAsync(usuario);
            Assert.AreNotEqual(0, resultUsuarios.Count);
            var ultimoUsuario = resultUsuarios.FirstOrDefault();
            Assert.IsTrue(ultimoUsuario.Rol != null && usuario.IdRol == ultimoUsuario.Rol.Id);
        }

        [TestMethod()]
        public async void T8LoginAsyncTest()
        {
            var usuario = new Usuario();
            usuario.Login = usuarioInicial.Login;
            usuario.Password = usuarioInicial.Password;
            var resultUsuario = await UsuarioDAL.LoginAsync(usuario);
            Assert.AreEqual(usuario.Login, resultUsuario.Login);
        }

        [TestMethod()]
        public async void T9CambiarPasswordAsyncTest()
        {
            var usuario = new Usuario();
            usuario.Id = usuarioInicial.Id;
            string passwordNuevo = "123456";
            usuario.Password = passwordNuevo;
            var result = await UsuarioDAL.CambiarPasswordAsync(usuario, usuarioInicial.Password);
            Assert.AreNotEqual(0, result);
            usuarioInicial.Password = passwordNuevo;
        }
    }
}