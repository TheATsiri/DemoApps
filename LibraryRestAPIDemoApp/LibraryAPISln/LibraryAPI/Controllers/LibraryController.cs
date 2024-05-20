using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LibraryController : ControllerBase
{
    private readonly LibraryContext _db;
    public LibraryController(LibraryContext db)
    {
        _db = db;
    }

    // localhost:44348/api/Library so i can communicate with postman

    // create/save a book in database

    [HttpPost] // create/save a book
    public IActionResult CreateBook(BookModel book)
    {
        _db.Books.Add(book);
        _db.SaveChanges();

        return CreatedAtAction("GetBook", new { id = book.Id }, book);

    }
    [HttpGet]
    [Route("GetBooks")]
    public IActionResult GetBooks()
    {

        var allBooks = _db.Books.ToList();

        if (allBooks.Count == 0)
        {
            return Ok("No books in databse");
        }

        return Ok(allBooks);


    }

    [HttpGet]
    public IActionResult GetBook(int id)
    {
        //BookModel book = _db.Books.Find(id);

        BookModel bookFromDb = _db.Books.SingleOrDefault(b => b.Id == id);

        if (bookFromDb == null)
        {
            return NotFound();
        }

        return Ok(bookFromDb);

    }

    [HttpPut]
    public IActionResult UpdateBook(BookModel book)
    {
        BookModel bookFromDb = _db.Books.SingleOrDefault(b => b.Id == book.Id);


        if (bookFromDb == null)
        {
            return NotFound();
        }

        bookFromDb.Title = book.Title;
        bookFromDb.PageCount = book.PageCount;

        _db.SaveChanges();

        return Ok("Updated book succesfully");

    }

    [HttpDelete]
    public IActionResult DeleteBook(int id)
    {
        BookModel bookFromDb = _db.Books.SingleOrDefault(b => b.Id == id);

        if (bookFromDb == null)
        {
            return NotFound();
        }

        _db.Remove(bookFromDb);
        _db.SaveChanges();

        return Ok("Deleted book");

    }
}
