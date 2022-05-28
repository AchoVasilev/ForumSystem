namespace Data.Models;
using Data.Models.Base;

public class Image : BaseModel<string>
{
    public Image()
    {
        this.Id = Guid.NewGuid().ToString();
    }

    public string Id { get; set; }

    public string Url { get; set; }

    public string Extension { get; set; }

    public string Name { get; set; }
}