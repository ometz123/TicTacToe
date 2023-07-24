using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Program;

namespace ConsoleApp1.Models
{
    internal class HttpServer

    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListenter;

        public HttpServer(string ipAddress, int port)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;

            this.serverListenter = new TcpListener(this.ipAddress, port);
        }

        public void Start()
        {
            Console.WriteLine($"Server started on port {port}.");
            Console.WriteLine("Listening for requests...");
            while (true)
            {
                this.serverListenter.Start();
                Console.WriteLine("Got new Message!");
                TcpClient connection = serverListenter.AcceptTcpClient();

                NetworkStream networkStream = connection.GetStream();
                byte[] data = new byte[4096];
                int bytesRead;
                Board board = new Board();
                if ((bytesRead = networkStream.Read(data, 0, data.Length)) != 0)
                {
                    string message = Encoding.UTF8.GetString(data, 0, bytesRead);

                    board = new Board(JsonConvert.DeserializeObject<List<List<string>>>(message));
                    Console.WriteLine($"Received data: {message}");
                    board = new TicTacToe().NextMove(board);

                }
                WriteResponse(networkStream, board);

                connection.Close();
            }
        }

        private void WriteResponse(NetworkStream networkStream, Board board)
        {
            string serialized = JsonConvert.SerializeObject(board);
          
            byte[] responseBytes = Encoding.UTF8.GetBytes(serialized);

            networkStream.Write(responseBytes, 0, responseBytes.Length);
            networkStream.Flush();

        }
    }
}
