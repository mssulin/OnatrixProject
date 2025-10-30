using System.ComponentModel.DataAnnotations;

namespace OnatrixProject.ViewModels;

public class QuestionFormViewModel
{
    
    [Required(ErrorMessage = "Name is required")]
    [Display(Name = "Name")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "Email address")]
    [RegularExpression(@"^[\w\.\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z]{2,}$",
        ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; } = null!;
    
    public string Question { get; set; } = null!;
}