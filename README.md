# SharpValidator

A simple to use validation rule builder for .NET.


Getting Started

1 - Install the nuget package (TODO: build / publish nuget package)
2 - Add a validate method in your class

```
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
```


3 - Call the Validate method
```
  var obj = new SampleClass()
  {
      Property1 = true,
      Property2 = true
  };


  var validation = obj.Validate(new ValidationResults());
```


4 - Display the results from validation to your user or bind it to an input :-)

```
[{"Message":"Two Property Validation message.","Key":"Property1","ValidationType":1}]
```
