using LangBuddy.Accounts.Models.Request;
using LangBuddy.Accounts.Service.Account.Common;
using Microsoft.AspNetCore.Mvc;

namespace LangBuddy.Accounts.Web.Controllers
{
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            try
            {
                var res = await _accountService.GetAll();
                return Ok(res);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] AccountCreateRequest accountCreateRequest)
        {
            try
            {
                var res = await _accountService.Create(accountCreateRequest);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPatch("{id:long}")]
        public async Task<IActionResult> UpdateAccount([FromRoute] long id, [FromBody] AccountUpdateRequest accountUpdateRequest)
        {
            try
            {
                var res = await _accountService.Update(id, accountUpdateRequest);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAccount([FromRoute] long id)
        {
            try
            {
                var res = await _accountService.Delete(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpGet("password/{email}")]
        public async Task<IActionResult> GetPasswordHash([FromRoute] string email)
        {
            try
            {
                var res = await _accountService.GetPasswordHash(email);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
