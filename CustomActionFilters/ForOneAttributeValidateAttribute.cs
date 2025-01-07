using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TestDotnet.CustomActionFilters;

// [ForOneAttributeValidate]
public class ForOneAttributeValidateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value?.ToString() == "tst")
        {
            return ValidationResult.Success;
        }

        string valueString = value?.ToString() ?? "null";
        return new ValidationResult($"Validation failed. Received value: {valueString}");
    }
}