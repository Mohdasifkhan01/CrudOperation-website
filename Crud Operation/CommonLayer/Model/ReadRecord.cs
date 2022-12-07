using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Operation.CommonLayer.Model
{
    public class ReadRecordResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
      
       public List<ReadRecordData> readRecordData { get; set; }
    }
    public class  ReadRecordData
    {
        public string UserName { get; set; }
        public int Age { get; set; }
    }
}
