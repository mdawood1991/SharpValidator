namespace SharpValidator.Tests
{
    public class SampleClass
    {
        public bool Property1 { get; set; }
        public bool Property2 { get; set; }
        public bool Property3 { get; set; }

        public ValidationResults Validate(ValidationResults validation)
        {
            var builder = new ValidationRuleBuilder<SampleClass>();

            builder.Given(this, validation)
                .When(self => self.Property3 == true)
                .Then("One Property Validation message.", nameof(Property3));

            builder.Given(this, validation)
                .When(self => self.Property1 == true)
                .And(self => self.Property2 == true)
                .Then("Two Property Validation message.", nameof(Property1));

            return validation;
        }
    }
}
