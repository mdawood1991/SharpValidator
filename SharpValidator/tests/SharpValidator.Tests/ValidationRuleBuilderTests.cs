using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpValidator.Tests
{
    public class ValidationRuleBuilderTests
    {
        [SetUp]
        public void Setup() { }

        [TearDown]
        public void TearDown() { }


        [TestCase(true, false, false)]
        [TestCase(false, true, false)]
        [TestCase(false, false, false)]
        [TestCase(true, true, true)]
        public void ValidationRuleBuilder_TwoProperty(bool property1, bool property2, bool expectError)
        {
            // arrange
            var obj = new SampleClass()
            {
                Property1 = property1,
                Property2 = property2
            };

            // act
            var validation = obj.Validate(new ValidationResults());

            // assert 
            Assert.AreEqual(expectError, validation.HasErrors());
            Assert.AreEqual(expectError, validation.ContainsError("Two Property Validation message."));
        }


        [TestCase(true, true)]
        [TestCase(false, false)]
        public void ValidationRuleBuilder_SingleProperty(bool property3, bool expectError)
        {
            // arrange
            var obj = new SampleClass()
            {
                Property3 = property3,
            };

            // act
            var validation = obj.Validate(new ValidationResults());

            // assert 
            Assert.AreEqual(expectError, validation.HasErrors());
            Assert.AreEqual(expectError, validation.ContainsError("One Property Validation message."));
        }
    }
}
