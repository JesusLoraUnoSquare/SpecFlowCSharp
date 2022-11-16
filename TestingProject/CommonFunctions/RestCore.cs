using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TestingProject.Entities;
using TestingProject.Logs;
using static TestingProject.Enums.EventTypes;

namespace TestingProject.CommonFunctions
{
    class RestCore
    {
        /// <summary>
        /// Create request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public RestRequest CreateRequestWithHeaders(string method,string url)
        {
            RestRequest restRequest;

            switch (method.ToUpper())
            {
                case "GET":
                    restRequest = new RestRequest(url, Method.Get);
                    break;

                case "POST":
                    restRequest = new RestRequest(url, Method.Post);
                    break;

                case "PUT":
                    restRequest = new RestRequest(url, Method.Put);
                    break;

                case "DELETE":
                    restRequest = new RestRequest(url, Method.Delete);
                    break;

                default:
                    //An error ocurred
                    string message = $"Rest Method not valid. Must specifiy correctly. Current value: [{method}]" + $"Current valid types: Get and Post";
                    Log.AddEvent(message, LogType.ERROR);
                    throw new NotImplementedException(message);
            }
            restRequest.RequestFormat = DataFormat.Json;
            return restRequest;
        }

        public RestRequest CreateRequestBody(RestRequest restRequestParameter, string body)
        {
            restRequestParameter.AddParameter("application/json", body, ParameterType.RequestBody);

            return restRequestParameter;
        }

        /// <summary>
        /// Add request to body and execute
        /// </summary>
        /// <param name="restRequest"></param>
        /// <returns></returns>
        public EntEmployees ExecuteRequest(RestRequest restRequest)
        {
            RestResponse serviceReponse = new RestResponse();
            EntEmployees response = new EntEmployees();
            try
            {
                //restRequest.AddParameter("application/json;charset=utf-8", ParameterType.RequestBody);
                RestClient restClient = new RestClient();
                serviceReponse = restClient.Execute(restRequest);

                response = JsonConvert.DeserializeObject<EntEmployees>(serviceReponse.Content);

                //Log response
                Log.AddEvent("Method: " + restRequest.Method.ToString() + " | Response: " + (int)serviceReponse.StatusCode + " |URL: " + restRequest.Resource + " |Content: "+serviceReponse.Content, LogType.NOTIFY);
            }
            catch (Exception ex)
            {
                Log.AddEvent("An error occurred while calling API," + ex.ToString() + " | " + restRequest.ToString(), LogType.ERROR);
            }
            return response;
        }
    }
}
