# SharpValidator

A simple to use validation rule builder for .NET.


## Getting Started

1 - Install the nuget package 
    Check the latest version here: https://www.nuget.org/packages/SharpValidator/

   ```
   Install-Package SharpValidator -Version 1.0.3
   ```
   or for .NET CLI
   ```
   dotnet add package SharpValidator --version 1.0.3
   ```
   

2 - Add a validate method in your class

```
    public class SampleClass
    {
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        public bool HasDriverLicense{ get; set; }
        public string DriverLicenseNumber { get; set; }

        public ValidationResults Validate(ValidationResults validation)
        {
            var builder = new ValidationRuleBuilder<SampleClass>(validation);

            builder.Given(this)
                .When(self => string.IsNullOrEmpty(LastName))
                .Then("Last name is a required field.", nameof(LastName));

            builder.Given(this)
               .When(self => self.DateOfBirth >= DateTime.Now)
               .Then("Date of Birth can't be in the future.", nameof(DateOfBirth));


            builder.Given(this)
                .When(self => self.HasDriverLicense)
                .And(self => string.IsNullOrEmpty(DriverLicenseNumber))
                .Then("Driver license number is a required field if HasDriverLicense is checked.", nameof(DriverLicenseNumber));

            return validation;
        }
    }
```


3 - Call the Validate method
```
// arrange
var obj = new SampleClass()
{
    DateOfBirth = DateTime.Now.AddMinutes(-5),
    LastName = "last name",
    DriverLicenseNumber = null,
    HasDriverLicense = true
};

// act
var validation = obj.Validate(new ValidationResults());

// assert 
Assert.AreEqual(expectError, validation.HasErrors());
Assert.AreEqual(expectError, validation.ContainsError("Driver license number is a required field if HasDriverLicense is checked."));
```


4 - Display the results from validation to your user or bind it to an input :-)

```
[{"Message":"Driver license number is a required field if HasDriverLicense is checked.","Key":"DriverLicenseNumber","ValidationType":1}]
```
