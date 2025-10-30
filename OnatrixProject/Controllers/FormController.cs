using Microsoft.AspNetCore.Mvc;
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
    FormSubmissionsService formSubmissionsService)
    : SurfaceController(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger,
        publishedUrlProvider)
{
    private readonly FormSubmissionsService _formSubmissionsService = formSubmissionsService;

    public IActionResult HandleCallbackForm(CallbackFormViewModel model)
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
        
        TempData["FormSuccess"] = "Thank you! Your request has been received and we will get back to you soon";
        return RedirectToCurrentUmbracoPage();
    }
    
    public IActionResult HandleHelpForm(HelpFormViewModel model)
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
        
        TempData["FormSuccess"] = "Thank you! Your request has been received and we will get back to you soon";
        return RedirectToCurrentUmbracoPage();
    }
    
    public IActionResult HandleQuestionForm(QuestionFormViewModel model)
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
        
        TempData["FormSuccess"] = "Thank you! Your question has been received and we will get back to you soon";
        return RedirectToCurrentUmbracoPage();
    }
}