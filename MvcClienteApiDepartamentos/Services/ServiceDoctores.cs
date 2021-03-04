using Newtonsoft.Json;
using NuGetDoctoresModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MvcClienteApi.Services
{
    public class ServiceDoctores
    {
        private Uri UriApi;
        private MediaTypeWithQualityHeaderValue Header;

        public ServiceDoctores(String url)
        {
            this.UriApi = new Uri(url);
            this.Header = new MediaTypeWithQualityHeaderValue("application/json");
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

        public async Task<List<Doctor>> GetDoctoresAsync()
        {
            String request = "api/doctores";
            return await this.CallApi<List<Doctor>>(request);
        }

        public async Task<Doctor> GetDoctorAsync(int id)
        {
            String request = "api/doctores/" + id;
            return await this.CallApi<Doctor>(request);
        }

        private String GetDoctorJson(int id, String apellido, String especialidad
            , int hospital, int salario)
        {
            Doctor doctor = new Doctor();
            doctor.IdDoctor = id;
            doctor.Apellido = apellido;
            doctor.Especialidad = especialidad;
            doctor.Hospital = hospital;
            doctor.Salario = salario;
            return JsonConvert.SerializeObject(doctor);
        }

        public async Task InsertDoctorAsync(int id, String apellido, String especialidad
            , int hospital, int salario)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/doctores";
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                String json = this.GetDoctorJson(id, apellido, especialidad
                    , hospital, salario);
                StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                await client.PostAsync(request, content);
            }
        }

        public async Task UpdateDoctorAsync(int id, String apellido
            , String especialidad, int hospital, int salario)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/doctores";
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                String json = this.GetDoctorJson(id, apellido, especialidad
                    , hospital, salario);
                StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                await client.PutAsync(request, content);
            }
        }

        public async Task DeleteDoctorAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/doctores/" + id;
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                await client.DeleteAsync(request);
            }
        }

        public async Task IncrementarSalariosAsync(int incremento, int hospital)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/doctores/incrementarsalarios/"
                    + incremento + "/" + hospital;
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                await client.PutAsync(request, new StringContent(""));
            }
        }
    }
}
