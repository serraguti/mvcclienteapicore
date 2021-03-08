﻿using MvcClienteApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MvcClienteApi.Services
{
    public class ServiceEmpleados
    {
        private Uri UrlApi;
        private MediaTypeWithQualityHeaderValue Header;

        public ServiceEmpleados(String url)
        {
            this.UrlApi = new Uri(url);
            this.Header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<String> GetToken(String username, String password)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = this.UrlApi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                LoginModel login = new LoginModel
                {
                    UserName = username,
                    Password = password
                };
                String json = JsonConvert.SerializeObject(login);
                StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                String request = "auth/login";
                HttpResponseMessage response =
                    await client.PostAsync(request, content);
                if (response.IsSuccessStatusCode)
                {
                    String data = await response.Content.ReadAsStringAsync();
                    JObject jobject = JObject.Parse(data);
                    String token = jobject.GetValue("response").ToString();
                    return token;
                }
                else
                {
                    return null;
                }
            }
        }

        private async Task<T> CallApi<T>(String request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = this.UrlApi;
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

        private async Task<T> CallApi<T>(String request, String token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = this.UrlApi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                client.DefaultRequestHeaders.Add("Authorization"
                    , "bearer " + token);
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

        //METODO LIBRE BUSCAREMPLEADO
        public async Task<Empleado> BuscarEmpleadoAsync(int idempleado)
        {
            String request = "api/empleados/" + idempleado;
            Empleado empleado = await this.CallApi<Empleado>(request);
            return empleado;
        }

        public async Task<Empleado> GetPerfil(String token)
        {
            String request = "api/empleados/perfilempleado";
            Empleado empleado =
                await this.CallApi<Empleado>(request, token);
            return empleado;
        }

        public async Task<List<Empleado>> GetSubordinados(String token)
        {
            String request = "api/empleados/subordinados";
            List<Empleado> empleados =
                await this.CallApi<List<Empleado>>(request, token);
            return empleados;
        }
    }
}
