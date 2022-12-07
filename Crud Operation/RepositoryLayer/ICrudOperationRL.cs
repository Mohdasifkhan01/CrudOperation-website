using Crud_Operation.CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Operation.RepositoryLayer
{
  public  interface ICrudOperationRL
    {
        public Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request);
        public Task<ReadRecordResponse> ReadRecord();
        public Task<UpdateRecordResponse> UpdateRecord(UpdateRecordRequest request);
        public Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request);
    }
}
