using System;
using System.Collections.Generic;
using System.Text;

namespace Pi.Core.Models
{
   public class ErrorModel<T>
    {

        public ErrorModel()
        {
            Errors = new List<string>();
        }

        public T Model { get; set; }
        public List<String> Errors { get; set; }
        public int Status { get; set; }
        public bool IsOk { get; set; }


    }


}
