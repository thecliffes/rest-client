using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rest_client
{
    class Program
    {
        static void Main(string[] args)
        {
            string uri= "http://localhost:8080/layout/track-detection-unit-locations";
            restClient rClient = new restClient();
            rClient.endPoint = uri;

            string strResponse = string.Empty;

            strResponse = rClient.makeRequest();

            Console.WriteLine(strResponse);

            Console.ReadKey();
        }

        //look at json.net deserialization for when i need to deserialze the json


    }
}
