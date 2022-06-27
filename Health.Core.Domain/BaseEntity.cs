namespace Health.Core.Domain
{
    public class BaseEntity
    {
        //   [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        // public ICollection<Tag> Tags { get; set; }
    }
}
