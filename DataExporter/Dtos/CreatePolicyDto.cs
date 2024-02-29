using System.ComponentModel.DataAnnotations;

namespace DataExporter.Dtos
{
    public record CreatePolicyDto
    {
        [Required]
        public string? PolicyNumber { get; set; }
        public decimal Premium { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
    }
}
