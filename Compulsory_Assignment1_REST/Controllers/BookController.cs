using Compulsory_Assignment1_Model_Book;
using Compulsory_Assignment1_REST.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compulsory_Assignment1_REST.Controllers
{
    public class BookController : ControllerBase
    {

        private readonly BookManager _manager = new BookManager();
        // GET: BookController
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            IEnumerable<Book> books = _manager.GetAll(null);
            if (books == null || !books.Any())
            {
                return NotFound();
            }
            return Ok(books);
        }

        // GET: BookController/Details/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{s}")]
        public ActionResult<IEnumerable<Book>> Get(string s)
        {
            IEnumerable<Book> book = _manager.GetAll(s);
            if (book == null || !book.Any())
            {
                return NotFound();
            }
            return Ok();
        }

        // POST: BookController/Add
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Book> Post([FromBody] Book value)
        {
            Book b = _manager.Add(value);
            if (b == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        // PUT: BookController/Edit
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public ActionResult<Book> Put(string isbn13, [FromBody] Book value)
        {
            Book b = _manager.Update(isbn13, value);
            if( b == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        // DELETE: BookController/Delete
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public ActionResult<Book> Delete(string isbn13)
        {
            Book b = _manager.Delete(isbn13);
            if(b==null)
            {
                return BadRequest();
            }
            return Ok();
        }

       
    }
}
