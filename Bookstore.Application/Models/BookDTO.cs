//BookDTO.cs

/*
    Used for structuring book entitiy in the controller to do CRUD operations on Book objects so it can convert things like strings to the value objects
*/
public class BookDTO
{
    public int Id {get; set;}
    public string Title {get; set;}
    public string Author {get; set;}
    
}