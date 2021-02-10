using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //this demek class kendisi demek yani result

        public Result(bool success, string message):this(success)
        {
            Message = message;
            
        }

        public Result(bool success) //buna overloding aşırı yükleme denmektedir.
        {
            
            Success = success;
        }


        public bool Success { get; }

        public string Message { get; }
}
}
