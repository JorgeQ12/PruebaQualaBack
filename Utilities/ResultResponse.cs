using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaBackQuala.Utilities
{
    public class ResultResponse<T>
    {
        public bool IsSucces { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }
        public T DataNoList { get; set; }

        public ResultResponse(bool isSucces, string? message, List<T> data)
        {
            IsSucces = isSucces;
            Message = message;
            Data = data;
        }

        public ResultResponse(bool isSucces, string? message, T dataNoList)
        {
            IsSucces = isSucces;
            Message = message;
            DataNoList = dataNoList;
        }

        public ResultResponse(bool isSucces, string message)
        {
            IsSucces = isSucces;
            Message = message;
        }
    }
}
