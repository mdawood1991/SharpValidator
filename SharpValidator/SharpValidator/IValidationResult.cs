namespace SharpValidator
{
    public interface IValidationResult
    {
        string Key { get; set; }
        string Message { get; set; }
        ValidationTypeEnum ValidationType { get; set; }
    }
}