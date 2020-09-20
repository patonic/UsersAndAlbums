using System.Net.Http;
using System.Threading.Tasks;

namespace UsersAndAlbums.Controllers
{
    public class WorkWithUrl
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> GetFromSource(string url)  //Функция получения данных с url
        {
            using (var result = await client.GetAsync(url))
            {
                string content = await result.Content.ReadAsStringAsync();
                return content;
            }
        }
    }
}
