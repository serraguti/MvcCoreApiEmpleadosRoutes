using MvcCoreApiEmpleadosRoutes.Models;
using System.Net.Http.Headers;

namespace MvcCoreApiEmpleadosRoutes.Services
{
    public class ServiceEmpleados
    {
        private string UrlApi;

        private MediaTypeWithQualityHeaderValue header;

        public ServiceEmpleados(string url)
        {
            this.UrlApi = url;
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        //METODO INTERMEDIO PARA LEER LOS DATOS DEL API
        //INDEPENDIENTEMENTE DE LO QUE LEAMOS
        //1) OBJETO QUE DEVUELVE: T
        //2) PETICION REQUEST
        private async Task<T> GetDatosApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response =
                    await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T datos = await response.Content.ReadAsAsync<T>();
                    return datos;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            string request = "/api/empleados";
            List<Empleado> empleados = await this.GetDatosApiAsync<List<Empleado>>(request);
            return empleados;
        }

        public async Task<List<string>> GetOficiosAsync()
        {
            string request = "/api/empleados/oficios";
            List<string> oficios = await this.GetDatosApiAsync<List<string>>(request);
            return oficios;
        }

        public async Task<Empleado> FindEmpleadoAsync(int idempleado)
        {
            string request = "/api/empleados/" + idempleado;
            Empleado empleado = await this.GetDatosApiAsync<Empleado>(request);
            return empleado;
        }

        public async Task<List<Empleado>> GetEmpleadosOficioAsync(string oficio)
        {
            string request = "/api/empleados/empleadosoficio/" + oficio;
            List<Empleado> empleados = await this.GetDatosApiAsync<List<Empleado>>(request);
            return empleados;
        }

        public async Task<List<Empleado>> GetEmpleadosSalarioAsync(int salario)
        {
            string request = "/api/empleados/empleadossalario/" + salario;
            List<Empleado> empleados = await this.GetDatosApiAsync<List<Empleado>>(request);
            return empleados;
        }
    }
}
