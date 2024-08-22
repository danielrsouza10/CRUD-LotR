#addin nuget:?package=Cake.Docker&version=1.3.0

var target = Argument("target", "Publish");
var configuration = Argument("configuration", "Release");
var solutionFolder = "./";
var publishFolder = "./Publish";
var publishDockerFolder = "./PublishDocker";

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(publishFolder);
});
Task("Restore")
    .Does(() =>
{
    DotNetRestore(solutionFolder);
});

Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .Does(() =>
{
    DotNetBuild(solutionFolder, new DotNetBuildSettings
    {
        NoRestore = true,
        Configuration = configuration,
    });
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetTest(solutionFolder, new DotNetTestSettings
    {
        NoRestore = true,
        NoBuild = true,
        Configuration = configuration,
    });
});

Task("Publish")
    .IsDependentOn("Test")
    .Does(() =>
    {
        DotNetPublish(solutionFolder, new DotNetPublishSettings
        {
            NoRestore = true,
            NoBuild = true,
            Configuration = configuration,
            OutputDirectory = publishFolder,
        });
    });

// Task("Docker-Build")
//  .IsDependentOn("Test")
// .Does(() =>
// {
//     var settings = new DockerImageBuildSettings { Tag = new[] { "dockerapp:latest" } };
//     DockerBuild(settings, "./");
// });

Task("ExecuteBuild")
    .IsDependentOn("Publish");



//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);