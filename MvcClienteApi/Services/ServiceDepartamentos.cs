using MvcClienteApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MvcClienteApi.Services
{
    public class ServiceDepartamentos
    {
        private Uri UriApi;
        private MediaTypeWithQualityHeaderValue Header;

        public ServiceDepartamentos(String url)
        {
            this.UriApi = new Uri(url);
            this.Header =
                new MediaTypeWithQualityHeaderValue("application/json");
        }

        private async Task<T> CallApi<T>(String request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response =
                    await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            String request = "api/departamentos";
            List<Departamento> departamentos = 
                await this.CallApi<List<Departamento>>(request);
            return departamentos;
        }

        public async Task<Departamento> BuscarDepartamentoAsync(int id)
        {
            String request = "api/departamentos/" + id;
            Departamento departamento = await
                this.CallApi<Departamento>(request);
            return departamento;
        }

        public async Task DeleteDepartamentoAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/departamentos/" + id;
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                await client.DeleteAsync(request);
            }
        }

        public async Task InsertDepartamentoAsync(int id, String nombre
            , String localidad)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/departamentos";
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                Departamento departamento = new Departamento();
                departamento.IdDepartamento = id;
                departamento.Nombre = nombre;
                departamento.Localidad = localidad;
                String json = JsonConvert.SerializeObject(departamento);
                //PARA ENVIAR INFORMACION AL SERVIDOR SE REALIZA
                //MEDIANTE OBJETOS CONTENT
                StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                await client.PostAsync(request, content);
            }
        }

        public async Task UpdateDepartamentoAsync(int id
            , String nombre, String localidad)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/departamentos";
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                Departamento departamento = new Departamento();
                departamento.IdDepartamento = id;
                departamento.Nombre = nombre;
                departamento.Localidad = localidad;
                String json = JsonConvert.SerializeObject(departamento);
                StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                await client.PutAsync(request, content);
            }
        }
    }
}
