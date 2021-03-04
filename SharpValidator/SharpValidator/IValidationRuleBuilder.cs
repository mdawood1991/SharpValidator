using System;

namespace SharpValidator
{
    public interface IValidationRuleBuilder<T>
    {
        IValidationRuleBuilder<T> Given(T targetObj, ValidationResults validation);
        IValidationRuleBuilder<T> When(Func<T, bool> rule);
        IValidationRuleBuilder<T> And(Func<T, bool> rule);
        IValidationRuleBuilder<T> Then(string message, string key);
        IValidationRuleBuilder<T> ThenWarn(string message, string key);
        IValidationRuleBuilder<T> ThenInform(string message, string key);
        IValidationResult BuildValidationMessage(string message, string key, ValidationTypeEnum validationType);
    }
}
