using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

namespace App.Services
{
    public class ServiceResult<T>
    {
        public T? Data { get; set; }
        public List<string>? ErrorMessage { get; set; }
        [JsonIgnore]
        public HttpStatusCode Status { get; set; }

        [JsonIgnore]
        public bool IsSuccess
        {
            get
            {
                return ErrorMessage == null || ErrorMessage.Count == 0;
            }

        }
        [JsonIgnore]
        public bool IsFail
        {
            get
            {
                return !IsSuccess;
            }
        }

        [JsonIgnore]
        public string? UrlAsCreated { get; set; }
        public static ServiceResult<T> SuccessAsCreated(T data, string urlAsCreated)
        {
            return new ServiceResult<T>()
            {

                Data = data,
                Status = HttpStatusCode.Created,
                UrlAsCreated = urlAsCreated

            };
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
        [JsonIgnore]
        public HttpStatusCode Status { get; set; }
        [JsonIgnore]
        public bool IsSuccess
        {
            get
            {
                return ErrorMessage == null || ErrorMessage.Count == 0;
            }

        }
        [JsonIgnore]
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
