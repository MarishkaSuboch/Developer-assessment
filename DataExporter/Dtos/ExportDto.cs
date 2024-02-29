namespace DataExporter.Dtos
{
    public record ExportDto
    {
        public string? PolicyNumber { get; set; }
        public decimal Premium { get; set; }
        public DateTime StartDate { get; set; }

        // A list of the notes' text.
        public IList<string>? Notes { get; set; }
    }
}
