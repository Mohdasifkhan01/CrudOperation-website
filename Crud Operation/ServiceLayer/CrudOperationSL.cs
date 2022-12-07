using Crud_Operation.CommonLayer.Model;
using Crud_Operation.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Operation.ServiceLayer
{
    public class CrudOperationSL : ICrudOperationSL
    {
        public readonly ICrudOperationRL _crudOperationRL;
        public CrudOperationSL(ICrudOperationRL crudOperationRL)
        {
            _crudOperationRL = crudOperationRL;
        }
        public async Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request)
        {
            return await _crudOperationRL.CreateRecord(request);
        }

        public async Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request)
        {
            return await _crudOperationRL.DeleteRecord(request);
        }

        public async Task<ReadRecordResponse> ReadRecord()
        {
            return await _crudOperationRL.ReadRecord();
        }

        public async Task<UpdateRecordResponse> UpdateRecord(UpdateRecordRequest request)
        {
            return await _crudOperationRL.UpdateRecord(request);
      }
    }
}

 