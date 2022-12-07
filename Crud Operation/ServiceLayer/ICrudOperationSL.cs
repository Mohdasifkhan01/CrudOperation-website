using Crud_Operation.CommonLayer.Model;
using Crud_Operation.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Operation.ServiceLayer
{
   public interface ICrudOperationSL
    {
       public Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request);
        public Task<ReadRecordResponse> ReadRecord();
        public Task<UpdateRecordResponse> UpdateRecord(UpdateRecordRequest request);
        public Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request);
    }
}
