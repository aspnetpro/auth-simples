﻿namespace AuthFacil.RazorPages.Models;

public record LogInFormModel
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? ReturnUrl { get; set; }
    public bool RememberMe { get; set; }
}
