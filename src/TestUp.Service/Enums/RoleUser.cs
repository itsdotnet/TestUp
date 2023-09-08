namespace TestUp.Service.Enums;

public static class RoleUser
{
    public static string Admin { get; set; } = "Admin";
    public static string Teacher { get; set; } = "Teacher";
    public static string User { get; set; } = "User";
    public static string AdminTeacher { get; set; } = "Admin, Teacher";
    public static string AdminUser { get; set; } = "Admin, User";
    public static string AllRoles { get; set; } = "Admin, User, Teacher";
    public static string CurrentRole { get; set; } = User;
}

public enum UserRolle
{
    Admin,
    Teacher,
    User,
    AdminTeacher,
    AdminUser,
    AllRoles
}