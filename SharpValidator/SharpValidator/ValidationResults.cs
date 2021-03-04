using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SharpValidator
{
    public class ValidationResults : IEnumerable<IValidationResult>
    {
        private readonly List<IValidationResult> _validationResults = new List<IValidationResult>();

        public IEnumerator<IValidationResult> GetEnumerator()
        {
            return _validationResults.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(IValidationResult validationResult)
        {
            this._validationResults.Add(validationResult);
        }

        public bool HasErrors()
        {
            return this._validationResults.Any(r => r.ValidationType == ValidationTypeEnum.Error);
        }

        public bool ContainsError(string errorMessage)
        {
            return this._validationResults.Any(y => y.Message.Equals(errorMessage));
        }
    }
}
