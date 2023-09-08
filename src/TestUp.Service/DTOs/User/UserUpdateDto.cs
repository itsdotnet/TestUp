﻿using TestUp.Domain.Enums;

namespace TestUp.Service.DTOs.User;

public class UserUpdateDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public UserRole UserRole { get; set; }
    public long? AttachmentId { get; set; }
}