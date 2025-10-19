
namespace Core.DTOs
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }

    }
}
