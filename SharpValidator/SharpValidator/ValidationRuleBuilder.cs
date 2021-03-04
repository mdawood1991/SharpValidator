using System;
using System.Collections.Generic;

namespace SharpValidator
{
    public class ValidationRuleBuilder<T> : IValidationRuleBuilder<T>
    {
        private T _object;
        private readonly List<Func<T, bool>> _rules = new List<Func<T, bool>>();
        private readonly ValidationResults _validation;

        public ValidationRuleBuilder(ValidationResults validation)
        {
            this._validation = validation ?? new ValidationResults();
        }

        public IValidationRuleBuilder<T> Given(T targetObj)
        {
            this._object = targetObj;
            return this;
        }

        public IValidationRuleBuilder<T> When(Func<T, bool> rule)
        {
            this._rules.Add(rule);

            return this;
        }

        public IValidationRuleBuilder<T> And(Func<T, bool> rule)
        {
            this._rules.Add(rule);

            return this;
        }

        public IValidationRuleBuilder<T> Then(string message, string key)
        {
            _Then(message, key);
            return this;
        }

        public IValidationRuleBuilder<T> ThenWarn(string message, string key)
        {
            _Then(message, key, ValidationTypeEnum.Warning);
            return this;
        }

        public IValidationRuleBuilder<T> ThenInform(string message, string key)
        {
            _Then(message, key, ValidationTypeEnum.Information);
            return this;
        }

        private void _Then(string message, string key, ValidationTypeEnum validationType = ValidationTypeEnum.Error)
        {
            var failed = true;
            foreach (var rule in this._rules)
            {
                try
                {
                    failed = failed & rule(this._object);
                    if (!failed)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    _validation.Add(BuildValidationMessage(message, key, ValidationTypeEnum.Exception));
                    failed = false;
                    break;
                }
            }

            if (failed)
            {
                _validation.Add(BuildValidationMessage(message, key, validationType));
            }

            // reset the rules for next validation rule
            _rules.Clear();
        }

        public virtual IValidationResult BuildValidationMessage(string message, string key, ValidationTypeEnum validationType)
        {
            return new ValidationResult { Message = message, Key = key, ValidationType = validationType };
        }
    }
}
