using ElHogar_DeLos_Libros.EntidadesDeNegocio;

namespace ElHogar_DeLos_Libros.WebAPI.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(Usuario pUsuario);
    }
}
