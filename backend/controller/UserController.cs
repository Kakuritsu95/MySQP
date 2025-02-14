
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController:Controller {
    private readonly ApplicationDbContext _dbContext;

    public UserController(ApplicationDbContext dbContext){
        _dbContext = dbContext;
    }

    [HttpPost]
    public ActionResult<User> CreateUser([FromBody] string username){
        User newUser = new User();
        newUser.Username = username;
        newUser.Password = "123";
        newUser.Email = "darorick@hotmail.com";
        _dbContext.Users.Add(newUser);
        _dbContext.SaveChanges();
        return Ok(newUser);
       
    }


}