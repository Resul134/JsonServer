using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using ModelLib;
using Newtonsoft.Json;

namespace JsonClient
{
    public class Worker
    {
        public void Start()
        {

            Car car = new Car("Audi", "Red", "AR62989");
            while (true)
            {
                using (TcpClient clientSocket = new TcpClient("localhost", 10001))
                using (StreamReader reader = new StreamReader(clientSocket.GetStream()))
                using (StreamWriter writer = new StreamWriter(clientSocket.GetStream()))
                {
                    while (true)
                    {
                        string str = Console.ReadLine();
                        
                        writer.WriteLine(JsonConvert.SerializeObject(car));

                        writer.Flush();

                        string stringReader = reader.ReadLine();
                        Console.WriteLine(stringReader);


                    }






                }
            }
        }
    }
    
}
