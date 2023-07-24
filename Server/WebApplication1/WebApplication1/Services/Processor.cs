using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class Processor
    {
        string ipAddress = "127.0.0.1"; 
        int port = 1612; 

        public async Task<Board?> Process(List<List<string?>> board)
        {
            try
            {
                using (TcpClient client = new TcpClient(ipAddress, port))
                {
                    Console.WriteLine("Connected to the target console app.");

                    using (NetworkStream stream = client.GetStream())
                    {
                        byte[] data = ObjectToByteArray(board);
                        await stream.WriteAsync(data, 0, data.Length);
                        await stream.FlushAsync();

                        Console.WriteLine("Data sent successfully.");
                        byte[] responseData = new byte[4096]; // Adjust the buffer size as needed
                        int bytesRead = stream.Read(responseData, 0, responseData.Length);
                        string jsonResponse = Encoding.UTF8.GetString(responseData, 0, bytesRead);
                        Console.WriteLine($"Received data: {jsonResponse}");

                        Board? ticTac = JsonConvert.DeserializeObject<Board?>(jsonResponse);
                        
                        return ticTac;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        private static byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(obj);
        }
    }

}
