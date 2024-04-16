using System;
using System.Net.Http.Json;
using PE.Implements;
using Newtonsoft.Json;
using System.Text;
using PE.Models.DTOs;

namespace PE.Services
{
    public class RequestService : IRequest
    {
        private  string URL_Base;
        public RequestService(String url)
        {
            this.URL_Base = url;
        }

        public async Task<HttpResponseMessage> GetMethod(string direccion, string jwtToken, dynamic cuerpo)
        {


            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(this.URL_Base);


                if (!string.IsNullOrEmpty(jwtToken))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + jwtToken);
                }

                try
                {

                    return await client.GetAsync(direccion);


                }
                catch (Exception ex)
                {

                    return null;
                }
            }



        }

        public async Task<HttpResponseMessage> PostMethod(string direccion, string? jwtToken, dynamic cuerpo)
        {
            try
            {
               


                using (HttpClient client = new HttpClient())
                {



                    

                    // Convertir el objeto a formato JSON
                    string json = JsonConvert.SerializeObject(cuerpo);




                    client.BaseAddress = new Uri(this.URL_Base);

                    if (!string.IsNullOrEmpty(jwtToken))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + jwtToken);
                    }

                    string jsonBody = JsonConvert.SerializeObject(cuerpo);

                    StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(direccion, content);

                    // Verificar si la solicitud fue exitosa
                    return response;
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra durante la solicitud
                throw new Exception(ex.Message);
            }
        }


        public async Task<HttpResponseMessage> PutMethod(string direccion, string jwtToken, dynamic cuerpo)
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.URL_Base);

                if (!string.IsNullOrEmpty(jwtToken))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + jwtToken);
                }

                try
                {

                    string jsonBody = JsonConvert.SerializeObject(cuerpo);


                    StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");


                   var respuesta = await client.PutAsync(direccion, content);
                    return respuesta;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }







      

      
















    }

}