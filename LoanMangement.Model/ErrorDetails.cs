using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.Model
{
    public class ErrorDetails
    {
        public ErrorDetails(int code, string message) {
            StatusCode = code;
            Message = message;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
