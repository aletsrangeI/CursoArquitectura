using Microsoft.AspNetCore.Mvc;
using Empresa.Ecommerce.Application.DTO;
using Empresa.Ecommerce.Aplication.Interface;
using System.Threading.Tasks;

namespace Empresa.Ecommerce.Services.WebApi.Controllers
{
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
        [HttpPost]
        public IActionResult Insert([FromBody] CustomersDTO customerDto)
        {
            if (customerDto == null) return BadRequest();

            var response = _customersApplication.Insert(customerDto);

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut]
        public IActionResult Update([FromBody] CustomersDTO customerDto)
        {
            if (customerDto == null) return BadRequest();

            var response = _customersApplication.Update(customerDto);

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("{customerId}")]
        public IActionResult Delete(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = _customersApplication.Delete(customerId);

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("{customerId}")]
        public IActionResult Get(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = _customersApplication.Get(customerId);

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet]
        public IActionResult GetAll(string customerId)
        {
            var response = _customersApplication.GetAll();

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion

        #region "Metodos Asincronos"
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] CustomersDTO customerDto)
        {
            if (customerDto == null) return BadRequest();

            var response = await _customersApplication.InsertAsync(customerDto);

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomersDTO customerDto)
        {
            if (customerDto == null) return BadRequest();

            var response = await _customersApplication.UpdateAsync(customerDto);

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = await _customersApplication.DeleteAsync(customerId);

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = await _customersApplication.GetAsync(customerId);

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string customerId)
        {
            var response = await _customersApplication.GetAllAsync();

            if (response.isSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}
