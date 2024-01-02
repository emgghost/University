using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRTaxApi.Application.Dtos
{
    public class ResultDto
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public object Data { get; set; }

        public string ErrorCode { get; set; }
        public string Error { get; set; }
        public List<string> Errors { get; set; }
    }
}
