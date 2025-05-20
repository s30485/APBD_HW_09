using System.ComponentModel.DataAnnotations;
using APBD_HW_09.RestAPI.Interfaces;

namespace APBD_HW_09.RestAPI.Validators;

public class ValidatorService : IValidatorService
{
    public bool Validate<T>(T model, out Dictionary<string, string[]> outErrors)
    {
        var ctx     = new ValidationContext(model);
        var results = new List<ValidationResult>();

        if (Validator.TryValidateObject(model, ctx, results, true))
        {
            outErrors = null!;
            return true;
        }

        outErrors = results
            .SelectMany(r => r.MemberNames.Select(m => (Member: m, r.ErrorMessage!)))
            .GroupBy(x => x.Member)
            .ToDictionary(
                g => g.Key,
                g => g.Select(x => x.ErrorMessage).ToArray()
            );
        return false;
    }
}