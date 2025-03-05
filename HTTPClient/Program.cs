using System.ComponentModel;
using System.Net.Http.Json;
using System.Text.Json;

HttpClient httpClient = new HttpClient();
Client client = new Client()
{
    City = "Липецк",
    Firstname = "Иван",
    Surname = "Иванов",
    Lastname = "Иванович",
    Compane = "Yfi ljv",
    Phone = "67-637-87"
};

SendClient(client);

//Task<List<Client>> task = getClient();
//List<Client> clients = task.Result;
//foreach(Client c in clients)
//{
//    Console.WriteLine(c.Firstname+" "+c.Lastname);
//}


async Task<List<Client>> getClient()
{
    StringContent content = new StringContent("getClients");

    using var request = new HttpRequestMessage(HttpMethod.Get, "http://127.0.0.1:8888/connection");
    request.Headers.Add("table", "client");
    request.Content = content;
    using HttpResponseMessage response = await httpClient.SendAsync(request);
    string responseText = await response.Content.ReadAsStringAsync();
    Console.WriteLine(content);
    List<Client> clients = JsonSerializer.Deserialize<List<Client>>(responseText)!;
    return clients;
}

async void SendClient(Client client)
{
    string json = JsonSerializer.Serialize(client);
    JsonContent content = JsonContent.Create(client);
    content.Headers.Add("table", "client");
    using var response = await httpClient.PostAsync("http://127.0.0.1:8888/connection", content);
    string responseText = await response.Content.ReadAsStringAsync();
    Console.WriteLine(responseText);
}

class Client
{
    public string Firstname { get; set; } = null!;
    public string? Surname { get; set; }
    public string Lastname { get; set; } = null!;
    public string Compane { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string City { get; set; } = null!;
}