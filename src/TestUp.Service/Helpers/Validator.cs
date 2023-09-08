using System.Text.RegularExpressions;

namespace TestUp.Service.Helpers;

public static class Validator
{
    private const string TextRegex = @"^.{0,50}$";
    private const string DescriptionRegex = @"^.{0,100}$";
    private const string NameRegex = @"^[A-Za-z ]{2,20}$";
    private const string UsernameRegex = @"^[a-zA-Z0-9_]{3,15}$";
    private const string EmailRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,25}$";
    private const string PasswordRegex = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$";


    public static bool IsValidText(string text) =>
                    !string.IsNullOrEmpty(text) && Regex.IsMatch(text, TextRegex);

    public static bool IsValidName(string name) =>
                    !string.IsNullOrEmpty(name) && Regex.IsMatch(name, NameRegex);

    public static bool IsValidEmail(string email) =>
                    !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, EmailRegex);

    public static bool IsValidPassword(string password) =>
                    !string.IsNullOrWhiteSpace(password) && Regex.IsMatch(password, PasswordRegex);

    public static bool IsValidUsername(string username) =>
                    !string.IsNullOrEmpty(username) && Regex.IsMatch(username, UsernameRegex);

    public static bool IsValidDescription(string description) =>
                    !string.IsNullOrEmpty(description) && Regex.IsMatch(description, DescriptionRegex);
}