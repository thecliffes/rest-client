﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace rest_client
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    class restClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }
        public restClient()
        {
            endPoint = string.Empty;
            httpMethod = httpVerb.GET;
        }

        public string makeRequest()
        {
            string strResponceValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = httpMethod.ToString();

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if(response.StatusCode != HttpStatusCode.OK) 
                {
                    throw new ApplicationException("error code" + response.StatusCode);
                }

                //process the response stream... (should be JSON)

                using (Stream responseStream = response.GetResponseStream())
                {
                    if(responseStream != null) 
                    { 
                        using(StreamReader reader = new StreamReader(responseStream))
                        { 
                            strResponceValue = reader.ReadToEnd();
                        }                    
                    }
                } //end of using response stream
            }
            
            return strResponceValue;
        }
    }
}
