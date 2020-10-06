using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pi.Store.Api.DTOs
{
    public class ActionResultDto<T>
    {
        public ErrorDto ErrorDto { get; set; }
        public T Model { get; set; }



    }
}
