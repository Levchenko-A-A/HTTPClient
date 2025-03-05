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
string json = JsonSerializer.Serialize(client);
JsonContent content = JsonContent.Create(client);
//StringContent content = new StringContent("{}");
content.Headers.Add("table", "client");
//using var request = new HttpRequestMessage(HttpMethod.Post, "http://127.0.0.1:8888/connection");
//request.Content = content;

using var response = await httpClient.PostAsync("http://127.0.0.1:8888/connection", content);
//using var response = await httpClient.SendAsync(request);
string responseText = await response.Content.ReadAsStringAsync();
Console.WriteLine(responseText);

class Client
{
    public string Firstname { get; set; } = null!;
    public string? Surname { get; set; }
    public string Lastname { get; set; } = null!;
    public string Compane { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string City { get; set; } = null!;
}