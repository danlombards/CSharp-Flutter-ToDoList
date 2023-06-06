namespace ToDoList.Api.Models.Options
{
    public class JWTOptions
    {
        public string Secret { get; set; }
        public List<string> ValidAudiences { get; set; }
        public string ValidIssuer { get; set; }
    }
}
