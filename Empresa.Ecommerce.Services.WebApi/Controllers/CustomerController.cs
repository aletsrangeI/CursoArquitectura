using Microsoft.AspNetCore.Mvc;
using Empresa.Ecommerce.Application.DTO;
using Empresa.Ecommerce.Aplication.Interface;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Empresa.Ecommerce.Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomersApplication _customersApplication;
        public CustomerController(ICustomersApplication customersApplication)
        {
            _customersApplication = customersApplication;
        }

        #region "Metodos Sincronos"
        [HttpPost, ActionName("Insert")]
        public IActionResult Insert([FromBody] CustomersDTO customerDto)
        {
            if (customerDto == null) return BadRequest();

            var response = _customersApplication.Insert(customerDto);

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut, ActionName("Update")]
        public IActionResult Update([FromBody] CustomersDTO customerDto)
        {
            if (customerDto == null) return BadRequest();

            var response = _customersApplication.Update(customerDto);

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("{customerId}"), ActionName("Delete")]
        public IActionResult Delete(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = _customersApplication.Delete(customerId);

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("{customerId}"), ActionName("Get")]
        public IActionResult Get(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = _customersApplication.Get(customerId);

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet, ActionName("GetAll")]
        public IActionResult GetAll(string customerId)
        {
            var response = _customersApplication.GetAll();

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet, ActionName("GetAllWithPagination")]
        public IActionResult GetAllWithPagination([FromQuery] int PageNumber, int PageSize)
        {
            var response = _customersApplication.GetAllWithPagination(PageNumber, PageSize);

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion

        #region "Metodos Asincronos"
        [HttpPost, ActionName("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] CustomersDTO customerDto)
        {
            if (customerDto == null) return BadRequest();

            var response = await _customersApplication.InsertAsync(customerDto);

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut, ActionName("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomersDTO customerDto)
        {
            if (customerDto == null) return BadRequest();

            var response = await _customersApplication.UpdateAsync(customerDto);

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("{customerId}"), ActionName("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = await _customersApplication.DeleteAsync(customerId);

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("{customerId}"), ActionName("GetAsync")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = await _customersApplication.GetAsync(customerId);

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet, ActionName("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync(string customerId)
        {
            var response = await _customersApplication.GetAllAsync();

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet, ActionName("GetAllWithPaginationAsync")]
        public async Task<IActionResult> GetAllWithPaginationAsync([FromQuery] int PageNumber, int PageSize)
        {
            var response = await _customersApplication.GetAllWithPaginationAsync(PageNumber, PageSize);

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}
