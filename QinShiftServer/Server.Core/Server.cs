using ServerTwo.Interface;

using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerTwo.Core
{
    public class Server
    {
        private ActualProcessor _pipelineProcessor = new ActualProcessor();
        public void RegisterProcessor(IPipelineProcessor processor)
        {
            _pipelineProcessor.AddProcessor(processor);
        }

        /// <summary>
        /// This is a blocking operation. It will start the server and wait for connections.
        /// </summary>
        public void Start()
        {
            var address = IPAddress.Any;
            var port = 668; //the neighbour of the beast

            Console.WriteLine("Starting server on {0}:{1}", address, port);

            using TcpListener listener = new TcpListener(address, port);
            listener.Start();

            Console.WriteLine("Server started. Waiting for connections...");

            while (true)
            {
                // wait for a request
                Console.WriteLine($"Waiting for tcp client");
                var client = listener.AcceptTcpClient();
                Console.WriteLine($"Accepted tcp client");

                using var stream = client.GetStream();
                byte[] buffer = new byte[8192];
                Span<byte> bytes = new(buffer);
                var byteCount = stream.Read(bytes);
                var requestString = Encoding.UTF8.GetString(bytes);

                var request = RequestProcessor.ProcessRequest(requestString);
                var response = _pipelineProcessor.Process(request);
                var output = OutputGenerator.MakeResponse(response);
                stream.Write(output);
            }
        }
    }
}


