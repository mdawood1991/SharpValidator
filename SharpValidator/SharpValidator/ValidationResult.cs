namespace SharpValidator
{
    public class ValidationResult : IValidationResult
    {
        public string Message { get; set; }
        public string Key { get; set; }
        public ValidationTypeEnum ValidationType { get; set; }
    }
}
