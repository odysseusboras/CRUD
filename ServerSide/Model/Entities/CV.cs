using Model.Interface;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Model.Entities
{
    public class CV : IEntity
    {
        public static readonly string SchemaName = "Tool";
        public static readonly string TableName = "CV";

        public Guid Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Identifier { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string? Mobile { get; set; }
        public Guid? DegreeId { get; set; }
        public Degree Degree { get; set; }
        public string? Blob { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
