namespace univesp.almox.apae.Models.Error
{
    public class Error
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}