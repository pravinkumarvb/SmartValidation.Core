# Custom Data Annotations for ASP.NET Core

A lightweight and extensible library of custom validation attributes for ASP.NET Core applications. Enhance model validation using custom rules for common Indian formats like PAN, Aadhar, Postal Code, and additional validations for text, email, and phone numbers.

##  Features

-  `OnlyLettersAttribute`: Allows only alphabetic characters.
-  `OnlyLettersAndSpacesAttribute`: Allows only letters and spaces.
-  `NoSpecialCharactersAttribute`: Disallows any special characters.
-  `NoSpecialCharactersOrNumbersAttribute`: Disallows both special characters and numbers.
-  `ValidEmailAttribute`: Restricts invalid email patterns (e.g. no asterisk `*` allowed).
-  `ValidPhoneAttribute`: Validates 10-digit Indian mobile numbers.
-  `ValidPANAttribute`: Validates Indian PAN card numbers (e.g. `ABCDE1234F`).
-  `ValidAadharAttribute`: Validates 12-digit Aadhar numbers with format check.
-  `ValidPostalCodeAttribute`: Validates 6-digit Indian PIN/Postal Codes.

##  Installation

This package will be published on NuGet soon. For now, clone or copy the code to your project.

```bash
git clone https://github.com/pravinkumarvb/SmartValidation.Core.git
```

##  Usage
```csharp
using SmartValidation.Core.Attributes;

public class UserDto
{
    [NoSpecialCharactersOrNumbers]
    public string? Name { get; set; }

    [NoSpecialCharacters]
    public string? CompanyName { get; set; }

    [PanNumber]
    public string? PANNumber { get; set; }

    [AadharNumber]
    public string? AadharNumber { get; set; }

    [IndianPostalCode]
    public string? PostalCode { get; set; }

    [ValidPhone]
    public string? PhoneNumber { get; set; }
}
```
## Contributing
Contributions are welcome! Feel free to fork the repo, create a feature branch, and submit a pull request.
