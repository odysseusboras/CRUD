using Model.Interface;

namespace Model.Entities
{
    public class Degree : IEntity
    {
        public static readonly string SchemaName = "Tool";
        public static readonly string TableName = "Degree";
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }

        public ICollection<CV> CVs { get; set; }

    }
}
