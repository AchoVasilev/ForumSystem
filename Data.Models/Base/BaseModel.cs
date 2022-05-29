namespace Data.Models.Base;

public class BaseModel<T>
{
    public T Id { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public DateTime? ModifiedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    public bool IsDeleted { get; set; } = false;
}