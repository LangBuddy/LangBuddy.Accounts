using LangBuddy.Accounts.Models.Request;
using LangBuddy.Accounts.Service.Account.Common;
using Microsoft.AspNetCore.Mvc;

namespace LangBuddy.Accounts.Web.Controllers
{
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService _accountService;

        public AccountsController(IAccountsService accountService)
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
                return NotFound(new Models.Responses.HttpResponse(
                    false, $"Found Error. {ex.Message}", null
                )); ;
            }
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetAccountByEmail([FromRoute] string email)
        {
            try
            {
                var res = await _accountService.GetByEmail(email);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return NotFound(new Models.Responses.HttpResponse(
                    false, $"Error Get Account. {ex.Message}", null
                ));
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
                return UnprocessableEntity(new Models.Responses.HttpResponse(
                    false, $"Creation error. {ex.Message}", null
                ));
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
                return UnprocessableEntity(new Models.Responses.HttpResponse(
                    false, $"Update error. {ex.Message}", null
                ));
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
                return UnprocessableEntity(new Models.Responses.HttpResponse(
                    false, $"Deleting error. {ex.Message}", null
                ));
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
                return NotFound(new Models.Responses.HttpResponse(
                    false, $"Get PasswordHash error. {ex.Message}", null
                ));
            }
        }
    }
}
