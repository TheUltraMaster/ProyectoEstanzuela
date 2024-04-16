using System;
namespace PE.Implements
{
	public interface IRequest
	{
      

        public Task<HttpResponseMessage> GetMethod(String direccion, string? jwtToken,dynamic cuerpo);

        public Task<HttpResponseMessage> PutMethod(String direccion, string? jwtToken ,dynamic cuerpo);

        public  Task<HttpResponseMessage> PostMethod(String direccion, string? jwtToken ,dynamic cuerpo);
        

    }
}

