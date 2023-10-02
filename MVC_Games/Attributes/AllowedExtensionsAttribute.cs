using MVC_Games.Settings;
using System.ComponentModel.DataAnnotations;

namespace MVC_Games.Attributes;

   public  class AllowedExtensionsAttribute :ValidationAttribute
{
    private readonly string _allowedExtensions;

    public AllowedExtensionsAttribute(string allowedExtensions)
    {
        _allowedExtensions = allowedExtensions;
    }
    protected override ValidationResult? IsValid
        (object? value, ValidationContext validationContext)
    {
          var file = value as FormFile;

        if (file is not  null)
        {
            var extension = Path.GetExtension(file.FileName);
            var isAllowed = FileSettings.AllowedExtensions.Split(',')
                                              .Contains(extension, StringComparer.OrdinalIgnoreCase);
            if (!isAllowed)
            {
                return new ValidationResult($"Only ${_allowedExtensions} are allowed");
            }
        }
        return ValidationResult.Success;
    }
}

 