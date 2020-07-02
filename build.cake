var target = Argument("target", "PublishAll");
var configuration = Argument("configuration", "Release");

var identityPublishDir = "./src/ITLab.Identity.STS.Identity/deploy/Identity-build";
var identityProject = "./src/ITLab.Identity.STS.Identity/ITLab.Identity.STS.Identity.csproj";

var adminPublishDir = "./src/ITLab.Identity.Admin/deploy/Admin-build";
var adminProject = "./src/ITLab.Identity.Admin/ITLab.Identity.Admin.csproj";


Setup(ctx =>
{
   CleanDirectory(identityPublishDir);
});

Teardown(ctx =>
{
});

Task("RestoreSolution")
.Does(() => 
{
   DotNetCoreRestore("ITLab.Identity.AdminUI.sln");
});

Task("BuildIdentity")
   .IsDependentOn("RestoreSolution")
   .Does(() =>
{
   var settings = new DotNetCoreBuildSettings 
   {
      Configuration = configuration
   };
   DotNetCoreBuild(identityProject, settings);
});

Task("PublishIdentity")
   .IsDependentOn("BuildIdentity")
   .Does(() =>
{
   var settings = new DotNetCorePublishSettings 
   {
      Configuration = configuration,
      OutputDirectory = identityPublishDir
   };
   DotNetCorePublish(identityProject, settings);
});


Task("BuildAdmin")
   .IsDependentOn("RestoreSolution")
   .Does(() =>
{
   var settings = new DotNetCoreBuildSettings 
   {
      Configuration = configuration
   };
   DotNetCoreBuild(adminProject, settings);
});

Task("PublishAdmin")
   .IsDependentOn("BuildAdmin")
   .Does(() =>
{
   var settings = new DotNetCorePublishSettings 
   {
      Configuration = configuration,
      OutputDirectory = adminPublishDir
   };
   DotNetCorePublish(adminProject, settings);
});

Task("PublishAll")
   .IsDependentOn("PublishIdentity")
   .IsDependentOn("PublishAdmin")
   .Does(() =>
{
   
});

RunTarget(target);