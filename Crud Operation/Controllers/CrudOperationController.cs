using Crud_Operation.CommonLayer.Model;
using Crud_Operation.RepositoryLayer;
using Crud_Operation.ServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudOperationController : ControllerBase
    {
        //injection dependency ko implement kr rhe 
        public readonly ICrudOperationSL _crudOperationSL;
        private CreateRecordResponse response;
       private readonly object await_crudOperationSL;

        public CrudOperationController (ICrudOperationSL crudOperationSL)
        {
            _crudOperationSL = crudOperationSL;
        }
        [HttpPost]
        [Route("CreateRecord")]
            public async Task<IActionResult>CreateRecord(CreateRecordRequest request)
        {
            CreateRecordResonse reponse = null;
            try
            {
                response = await _crudOperationSL.CreateRecord(request);
            }catch(Exception ex)
            {
                reponse.IsSuccess = false;
                reponse.Message = ex.Message;
            }
            return Ok(reponse);
            

        }
        [HttpGet]
        [Route("ReadRecord")]
        public async Task<IActionResult> ReadRecord()
        {
            ReadRecordResponse response = null;

            try
            {
                response = await _crudOperationSL.ReadRecord();
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
        [HttpPut]
        [Route("UpdateRecord")]
        public async Task<IActionResult> UpdateRecord(UpdateRecordRequest request)
        {
            UpdateRecordResponse response = null;

            try  
            {
                response = await _crudOperationSL.UpdateRecord(request);
            }
            catch (Exception ex)
            {
               response.IsSuccess = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }
        [HttpDelete]
        [Route("DeleteRecord")]
        public async Task<IActionResult> DeleteRecord(DeleteRecordRequest request)
        {
            DeleteRecordResponse response = null;

            try
            {
                response = await _crudOperationSL.DeleteRecord(request);
            }
            catch (Exception ex)
            {
                response.IsSucess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
    }
}

