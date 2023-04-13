using Client.Repositories.Interface;
using Client.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace Client.Repositories;

public class GeneralRepository<Entity, Key> : IRepository<Entity, Key>
    where Entity : class
{
    private readonly HttpClient _httpClient;
    private readonly string request;

    public GeneralRepository(string request)
    {
        this.request = request;
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7005/api/")
        };
    }
    public async Task<ResponseStatusVM> Delete(Key id)
    {
        ResponseStatusVM entityVM = null;
        using (var response = _httpClient.DeleteAsync(request + id).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseStatusVM>(apiResponse);
        }
        return entityVM;
    }

    public async Task<ResponseListVM<Entity>> Get()
    {
        ResponseListVM<Entity> responseListVM = null;
        using (var response = await _httpClient.GetAsync(request))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            responseListVM = JsonConvert.DeserializeObject<ResponseListVM<Entity>>(apiResponse);
        }
        return responseListVM;
    }

    public async Task<ResponseVM<Entity>> Get(Key id)
    {
        ResponseVM<Entity> entity = null;
        using (var response = await _httpClient.GetAsync(request + id))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entity = JsonConvert.DeserializeObject<ResponseVM<Entity>>(apiResponse);
        }
        return entity;
    }

    public async Task<ResponseStatusVM> Post(Entity entity)
    {
        ResponseStatusVM entityVM = null;
        StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        using (var response = _httpClient.PostAsync(request, content).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseStatusVM>(apiResponse);
        }
        return entityVM;
    }

    public async Task<ResponseStatusVM> Put(Entity entity, Key id)
    {
        ResponseStatusVM entityVM = null;
        StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        using (var response = _httpClient.PutAsync(request, content).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseStatusVM>(apiResponse);
        }
        return entityVM;
    }
}
