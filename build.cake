var target = Argument("target", "PublishAll");
var configuration = Argument("configuration", "Release");

var identityPublishDir = "./src/ITLab.Identity.STS.Identity/deploy";
var identityProject = "./src/ITLab.Identity.STS.Identity/ITLab.Identity.STS.Identity.csproj";


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

Task("PublishAll")
   .IsDependentOn("PublishIdentity")
   .Does(() =>
{
   
});

RunTarget(target);