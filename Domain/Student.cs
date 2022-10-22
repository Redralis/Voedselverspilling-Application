﻿using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Student
{
    [Required(ErrorMessage = "Id moet meegegeven worden.")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Naam moet een waarde bevatten.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Geboortedatum moet een waarde bevatten.")]
    public string DateOfBirth { get; set; } = string.Empty;

    [Required(ErrorMessage = "Studentnummer moet meegegeven worden.")]
    public string StudentNr { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email moet een waarde bevatten.")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Stad moet een waarde bevatten.")]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = "Er moet een telefoonnummer meegegeven worden.")]
    public string PhoneNr { get; set; } = string.Empty;
}