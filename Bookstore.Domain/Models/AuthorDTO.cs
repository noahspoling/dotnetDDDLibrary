//AuthorDTO.cs

/*
    Used for structuring author entity in the controller to do CRUD operations on Author objects so it can convert things like strings to the value objects
*/
namespace Bookstore.Domain.Models
{
    public class AuthorDTO
{
    //TODO: add private access to DTO objects
    public int? Id {get; set;}
    public string? FirstName {get; set;}
    public string? LastName {get; set;}

    public AuthorDTO()
    {

    }

    //Posting new author DTO
    public AuthorDTO(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    
    //For getting existing author
    public AuthorDTO(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
}
}