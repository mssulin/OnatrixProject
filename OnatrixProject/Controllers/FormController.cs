using Microsoft.AspNetCore.Mvc;
using OnatrixProject.Interfaces;
using OnatrixProject.Services;
using OnatrixProject.ViewModels;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace OnatrixProject.Controllers;

public class FormController(
    IUmbracoContextAccessor umbracoContextAccessor,
    IUmbracoDatabaseFactory databaseFactory,
    ServiceContext services,
    AppCaches appCaches,
    IProfilingLogger profilingLogger,
    IPublishedUrlProvider publishedUrlProvider,
    FormSubmissionsService formSubmissionsService,
    IEmailService emailService)
    : SurfaceController(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger,
        publishedUrlProvider)
{
    private readonly FormSubmissionsService _formSubmissionsService = formSubmissionsService;
    private readonly IEmailService _emailService = emailService;

    [HttpPost]
    public async Task <IActionResult> HandleCallbackForm(CallbackFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return CurrentUmbracoPage();
        }
        
        var result = _formSubmissionsService.SaveCallbackRequest(model);
        if (!result)
        {
            TempData["FormError"] = "Something went wrong while submitting your request. Please try again later";
            return RedirectToCurrentUmbracoPage();
        }

        // Om användaren skrivit epostaddress i formuläret
        if (!string.IsNullOrWhiteSpace(model.Email))
        {
            // Skicka detta
            var subject = "We recieved your callback request";
            var body = $@"
                    <p>Hi {model.Name},</p>
                    <p>Thank you for your request.</p>
                    <p>Best regards,<br/>Onatrix</p>";

            try
            {
                await _emailService.SendAsync(model.Email, subject, body, replyTo: model.Email);
            }
            
            
            catch
            {
                TempData["FormError"] = "Error sending confirmation email";
            }
            
            
        }
        
        TempData["FormSuccess"] = "Thank you! Your request has been received and we will get back to you soon";
        return RedirectToCurrentUmbracoPage();
    }
    
    [HttpPost]
    public async Task <IActionResult> HandleHelpForm(HelpFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return CurrentUmbracoPage();
        }
        
        var result = _formSubmissionsService.SaveHelpRequest(model);
        if (!result)
        {
            TempData["FormError"] = "Something went wrong while submitting your request. Please try again later";
            return RedirectToCurrentUmbracoPage();
        }
        
        if (!string.IsNullOrWhiteSpace(model.Email))
        {
            var subject = "We recieved your help request";
            var body = $@"
                    <p>Hi!</p>
                    <p>Thank you for your help request.</p>
                    <p>Best regards,<br/>Onatrix</p>";

            try
            {
                await _emailService.SendAsync(model.Email, subject, body, replyTo: model.Email);
            }
            catch
            {
                TempData["FormError"] = "Error sending confirmation email";
            }
        }
        
        TempData["FormSuccess"] = "Thank you! Your request has been received and we will get back to you soon";
        return RedirectToCurrentUmbracoPage();
    }
    
    [HttpPost]
    public async Task <IActionResult> HandleQuestionForm(QuestionFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return CurrentUmbracoPage();
        }
        
        var result = _formSubmissionsService.SaveQuestionRequest(model);
        if (!result)
        {
            TempData["FormError"] = "Something went wrong while submitting your request. Please try again later";
            return RedirectToCurrentUmbracoPage();
        }
        
        if (!string.IsNullOrWhiteSpace(model.Email))
        {
            var subject = "We recieved your question";
            var body = $@"
                    <p>Hi {model.Name},</p>
                    <p>Thank you for your question. We will get back as soon as we can.</p>
                    <p>Best regards,<br/>Onatrix</p>";

            try
            {
                await _emailService.SendAsync(model.Email, subject, body, replyTo: model.Email);
            }
            catch
            {
                TempData["FormError"] = "Error sending confirmation email";
            }
        }
        
        TempData["FormSuccess"] = "Thank you! Your question has been received and we will get back to you soon";
        return RedirectToCurrentUmbracoPage();
    }
}