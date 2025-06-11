using System.ComponentModel.DataAnnotations;

namespace Templater.App;

enum MainActions
{
    [Display(Name = "Generate templates")]
    GenerateTemplates,
    [Display(Name = "Manage architectures (groups of templates)")]
    ManageArchitectures,
    [Display(Name = "Manage templates")]
    ManageTemplates,
    [Display(Name = "Quit")]
    Quit
}