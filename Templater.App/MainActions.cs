using System.ComponentModel.DataAnnotations;

namespace Templater.App;

/// <summary>
/// Represents the main actions available in the application.
/// </summary>
enum MainActions
{
    /// <summary>
    /// Action to generate templates.
    /// </summary>
    [Display(Name = "Generate templates")] GenerateTemplates,

    /// <summary>
    /// Action to manage architectures, which are groups of templates.
    /// </summary>
    [Display(Name = "Manage architectures (groups of templates)")]
    ManageArchitectures,

    /// <summary>
    /// Action to manage individual templates.
    /// </summary>
    [Display(Name = "Manage templates")] ManageTemplates,

    /// <summary>
    /// Action to quit the application.
    /// </summary>
    [Display(Name = "Quit")] Quit
}