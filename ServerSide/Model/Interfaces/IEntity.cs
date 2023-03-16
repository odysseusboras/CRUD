
namespace Model.Interface
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
