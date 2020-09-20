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
    public class AlbumController : ControllerBase
    {
        private readonly SourceConfiguration sourceConfiguration;

        public AlbumController(IOptions<SourceConfiguration> sourceConfiguration)
        {
            this.sourceConfiguration = sourceConfiguration.Value;   //Необходим для пробрасывания url сайта с данными
        }

        // GET: api/<AlbumController>
        [HttpGet]
        public List<Album> Get()    //Все альбомы
        {
            var result = WorkWithUrl.GetFromSource(sourceConfiguration.url + @"/albums").Result;    //Получаем строку с данными
            var albums = JsonSerializer.Deserialize<List<Album>>(result);   //Десериализуем
            return albums;  //Возвращаем
        }

        // GET api/<AlbumController>/5
        [HttpGet("{id}")]
        public Album Get(int id)    //Альбом по id
        {
            var result = WorkWithUrl.GetFromSource(sourceConfiguration.url + @"/albums").Result;    //Получаем строку с данными
            var albums = JsonSerializer.Deserialize<List<Album>>(result);   //Десериализуем
            var album = from i in albums    //Фильтрация по id
                        where i.id == id
                        select i;
            if (album.Count() > 0)  //Если альбом есть
                return album.First();   //Возвращаем его
            else
                return null;    //Иначе возвращаем пустоту
        }

        // GET api/<AlbumController>/user/5
        [HttpGet("user/{userId}")]
        public IEnumerable<Album> GetUser(int userId)   // Альбом по userId
        {
            var result = WorkWithUrl.GetFromSource(sourceConfiguration.url + @"/albums").Result;    //Получаем строку с данными
            var albums = JsonSerializer.Deserialize<List<Album>>(result);   //Десериализуем
            var albumUser = from i in albums    //Фильтрация по userId
                            where i.userId == userId
                            select i;
            return albumUser;   //Возвращаем
        }
    }
}
