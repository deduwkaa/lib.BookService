using BLL.Abstractions;
using BLL.DTO;
using DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                var list = await _bookService.GetAllBooks();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PostBooks(BookDTO user)
        {
            try
            {
                await _bookService.AddBook( user).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutBooks(BookDTO user)
        {
            try
            {
                await _bookService.UpdateBook(user).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }

        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBooks(Guid id)
        {
            try
            {
                await _bookService.DeleteBook(id).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        private  IEnumerable<Claim> GetClaims(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            return jwtToken.Claims;
        }
    }
}

