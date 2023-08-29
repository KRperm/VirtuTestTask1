namespace webapi.Dtos
{
    public class RecordRequest
    {
        public string? Name { get; set; } = default;
        public DateTime? DateOfBirth { get; set; } = default;
        public string? Phone { get; set; } = default;
    }
}
