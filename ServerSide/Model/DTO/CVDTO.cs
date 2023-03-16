
namespace Model.DTO
{
    public class CVDTO
    {
        public Guid Id { get; set; }
        public int Identifier { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string? Mobile { get; set; }
        public Guid DegreeId { get; set; }
        public string DegreeName { get; set; }
        public bool HasBlob { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
