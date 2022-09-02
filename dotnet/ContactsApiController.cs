using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
/*removed*/
using System;
using System.Collections.Generic;

namespace /*removed*/.Web.Api.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactsApiController : BaseApiController
    {
        private IContactsService _service = null;
        private IAuthenticationService<int> _authService = null;

        public ContactsApiController(IContactsService service
            , IAuthenticationService<int> authService
            , ILogger<ExamplesApiController> logger) : base(logger)
        {
            _service = service;
            _authService = authService;
        }

        [HttpPost]
        public ActionResult<ItemResponse<int>> CreateContact(ContactAddRequest model)
        {
            ObjectResult result = null;

            try
            {
                int userId = _authService.GetCurrentUserId();
                int id = _service.Add(model, userId);
                ItemResponse<int> response = new ItemResponse<int>() { Item = id };

                result = Created201(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                ErrorResponse response = new ErrorResponse(ex.Message);

                result = StatusCode(500, response);
            }

            return result;
        }

        [HttpPut("{id:int}")]
        public ActionResult<SuccessResponse> UpdateContactById(ContactUpdateRequest model)
        {

            int iCode = 200;
            BaseResponse response = null;

            try
            {
                int userId = _authService.GetCurrentUserId();
                _service.Update(model, userId);
                response = new SuccessResponse();
            }
            catch (Exception ex)
            {
                iCode = 500;
                response = new ErrorResponse(ex.Message);
            }

            return StatusCode(iCode, response);
        }

        [HttpGet("paginate")] 
        public ActionResult<ItemsResponse<Contact>> GetContactsByCreatedBy(int pageIndex, int pageSize)
        {
            int iCode = 200;
            BaseResponse response = null;

            try
            {
                int userId = _authService.GetCurrentUserId();
                Paged<Contact> page = _service.Get(userId, pageIndex, pageSize);

                if (page == null)
                {
                    iCode = 404;
                    response = new ErrorResponse("App resources not found.");
                }
                else
                {
                    response = new ItemResponse<Paged<Contact>> { Item = page };
                }
            }
            catch (Exception ex)
            {
                iCode = 500;
                Logger.LogError(ex.ToString());
                response = new ErrorResponse(ex.Message);
            }

            return StatusCode(iCode, response);
        }

        [HttpGet("search")]
        public ActionResult<ItemsResponse<Contact>> SearchContactsByCreatedBy(string query, int pageIndex, int pageSize)
        {
            int iCode = 200;
            BaseResponse response = null;

            try
            {
                int userId = _authService.GetCurrentUserId();
                Paged<Contact> page = _service.Search(userId, query, pageIndex, pageSize);

                if (page == null)
                {
                    iCode = 404;
                    response = new ErrorResponse("App resources not found.");
                }
                else
                {
                    response = new ItemResponse<Paged<Contact>> { Item = page };
                }
            }
            catch (Exception ex)
            {
                iCode = 500;
                Logger.LogError(ex.ToString());
                response = new ErrorResponse(ex.Message);
            }

            return StatusCode(iCode, response);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<SuccessResponse> DeleteContactById(int id)
        {
            int iCode = 200;
            BaseResponse response = null;

            try
            {
                _service.Delete(id);

                response = new SuccessResponse();
            }
            catch (Exception ex)
            {
                iCode =500;
                response = new ErrorResponse(ex.Message);
            }
            return StatusCode(iCode, response);
        }
    }
}
