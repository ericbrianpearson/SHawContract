using Kentico.PageBuilder.Web.Mvc;

// Registers the default page builder section used by the LearningKit project
[assembly: RegisterSection("ShawContract.Sections.DefaultSection", "Default section", customViewName: "Sections/_DefaultSection", IconClass = "icon-square")]