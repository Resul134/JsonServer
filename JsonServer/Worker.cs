using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using Newtonsoft.Json;

namespace JsonServer
{
    class Worker
    {
        public void Start()
        {
            TcpListener list = new TcpListener(IPAddress.Loopback, 10001);
            try
            {
                list.Start();
                Console.WriteLine("Listening");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error, server is not responding");
            }


            while (true)
            {

                TcpClient client = list.AcceptTcpClient();
                //Starter ny tråd
                Task.Run(() =>
                { //indsætter en metode (delegate)
                    TcpClient tempSocket = client;
                    DoClient(tempSocket);


                });



            }


        }


        public void DoClient(TcpClient tempclient)
        {

            using (StreamReader reader = new StreamReader(tempclient.GetStream()))
            using (StreamWriter writer = new StreamWriter(tempclient.GetStream()))
            {
                string readString = reader.ReadLine();
                Car myLine = JsonConvert.DeserializeObject<Car>(readString);
                Console.WriteLine(myLine);



            }

        }
    }
}
