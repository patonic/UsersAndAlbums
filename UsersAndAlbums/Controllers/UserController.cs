using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using UsersAndAlbums.Models;

namespace UsersAndAlbums.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SourceConfiguration sourceConfiguration;

        public UserController(IOptions<SourceConfiguration> sourceConfiguration)
        {
            this.sourceConfiguration = sourceConfiguration.Value;   //Необходим для пробрасывания url сайта с данными
        }

        // GET: api/<UserController>
        [HttpGet]
        public List<User> Get() //Все пользователи
        {
            var result = WorkWithUrl.GetFromSource(sourceConfiguration.url + @"/users").Result;  //Получаем строку с данными
            var users = JsonSerializer.Deserialize<List<User>>(result); //Десериализуем
            return users;   //Возвращаем
        }

        // GET: api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id) //Пользователь по id
        {
            var result = WorkWithUrl.GetFromSource(sourceConfiguration.url + @"/users").Result;  //Получаем строку с данными
            var users = JsonSerializer.Deserialize<List<User>>(result); //Десериализуем
            var user = from i in users  //Фильтрация по id
                       where i.id == id
                       select i;
            if (user.Count() > 0)   //Если пользователь есть
                return user.First();    //Возвращаем его
            else
                return null;    //Иначе возвращаем пустоту
        }
    }
}
