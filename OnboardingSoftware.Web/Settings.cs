using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Web
{
    public static class Settings
    {
        public static string userId = "";
        public static string jwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJmMzJiNjU0Yi02YmRhLTRmMzgtMWE1OS0wOGQ5YmZkNzMyMDAiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidGVzdCIsImp0aSI6IjFlNTUxZWZiLTczYzctNDFmYS04MDEzLTIzODYxMzRkMTUzYiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiZjMyYjY1NGItNmJkYS00ZjM4LTFhNTktMDhkOWJmZDczMjAwIiwiZXhwIjoxNjQzMDc0NDQ1LCJpc3MiOiJodHRwOi8vMTkyLjE2OC4wLjE1OjUwMDEiLCJhdWQiOiJodHRwOi8vMTkyLjE2OC4wLjE1OjUwMDEifQ.tsR_PFdNMGnwu_P2DOUyUn-SZHdpmnZN0cTfV9N3CpA";
        //public static string errorMsg = "User cannot add same link multiple times. " +
        //                    "Each link - tag relation must have a value. " +
        //                    "Link must have at least one tag associated with it. ";
        public static string errorMsg = "";
        public static string errorMsgGen = "";
    }
    public class ApiEndpoint
    {
        public string AuthEndpointUrl { get; set; }
        public string AplikantiEndpointUrl { get; set; }
        public string JobsEndpointUrl { get; set; }
        public string TestsEndpointUrl { get; set; }
        public string QuestionsEndpointUrl { get; set; }
        public string AnswersEndpointUrl { get; set; }
        public string TagsEndpointUrl { get; set; }
    }
}
