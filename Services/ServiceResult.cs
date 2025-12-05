using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace App.Services
{
    public class ServiceResult<T>
    {
        public T? Data { get; set; }
        public List<string>? ErrorMessage { get; set; }
        public HttpStatusCode Status { get; set; }
        public bool IsSuccess
        {
            get
            {
                return ErrorMessage == null || ErrorMessage.Count == 0;
            }

        }
        public bool IsFail
        {
            get
            {
                return !IsSuccess;
            }
        }


    


        public static ServiceResult<T> Success(T data, HttpStatusCode status=HttpStatusCode.OK) { 
            return new ServiceResult<T>() { 

                Data = data ,
                Status=status
            
            };
        }
        public static ServiceResult<T> Fail(List<string> errorMessages, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>() { ErrorMessage = errorMessages };
        }
        public static ServiceResult<T> Fail(string errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>() { ErrorMessage = new List<string>() { errorMessage } };
        }
    }
    public class ServiceResult
    {
     
        public List<string>? ErrorMessage { get; set; }
        public HttpStatusCode Status { get; set; }
        public bool IsSuccess
        {
            get
            {
                return ErrorMessage == null || ErrorMessage.Count == 0;
            }

        }
        public bool IsFail
        {
            get
            {
                return !IsSuccess;
            }
        }





        public static ServiceResult Success( HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult() {

           
                Status = status

            };
        }
        public static ServiceResult Fail(List<string> errorMessages, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult() { ErrorMessage = errorMessages };
        }
        public static ServiceResult Fail(string errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult() { ErrorMessage = new List<string>() { errorMessage } };
        }
    }
}
