namespace OnatrixProject.ViewModels;

public class EmailViewModel
{
    public string Host { get; set; } = "";

    public int Port { get; set; } = 587;

    public string User { get; set; } = "";

    public string Password { get; set; } = "";
    
    public string FromName { get; set; } = "";

    public string FromAddress { get; set; } = "";
    
    public bool EnableSsl { get; set; } = true;
}