using CursoApp.Models;
using PluginAPI;

namespace CursoApp
{
    internal class Program
    {
        static bool running = true;
        static string? apikey = string.Empty;

        static void Main(string[] args)
        {
            ApiManager.Create("https://curso-dev-bmem.1.us-1.fl0.io");

            onLogin();

            while (running)
            {

            }
        }

        static async Task onLogin()
        {
            LoginModel cuenta = new LoginModel();
            cuenta.email = "avalontm@curso.com";
            cuenta.contrasena = "cinder";

            string result = await ApiManager.Post(cuenta, "/api/login");

            if(!result.GetValue<bool>("status", true))
            {
                Console.WriteLine($"Error: {result.GetValue<string>("message")}");
                return;
            }

            apikey = result.GetValue<string>("api_key");

            Console.WriteLine($"apikey: {apikey}");

            if (!string.IsNullOrEmpty(apikey))
            {
                ApiManager.CreateKey("api-key", apikey);
            }

            result = await ApiManager.Get("/api/cursos");

            Console.WriteLine($"result: {result}");
        }
    }
}
