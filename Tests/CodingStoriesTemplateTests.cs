namespace Epam.CodingStories.Template.Tests
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Boxed.DotnetNewTest;
    using Xunit;
    using Xunit.Abstractions;

    public class CodingStoryTemplateTest
    {
        private const string TemplateName = "story";
        private const string SolutionFileName = "CodingStoriesTemplate.sln";
        private static readonly string[] DefaultArguments = new string[]
        {
            "no-open-todo=true"
        };

        public CodingStoryTemplateTest(ITestOutputHelper testOutputHelper)
        {
            if (testOutputHelper is null)
            {
                throw new ArgumentNullException(nameof(testOutputHelper));
            }

            TestLogger.WriteMessage = testOutputHelper.WriteLine;
        }

        [Theory]
        [InlineData("my-coding-story")]
        public async Task CodingStoriesTemplateTests(string name, params string[] arguments)
        {
            await InstallTemplateAsync().ConfigureAwait(false);
            await using var tempDirectory = TempDirectory.NewTempDirectory();
            var project = await tempDirectory
                .DotnetNewAsync(TemplateName, name, DefaultArguments.ToArguments(arguments))
                .ConfigureAwait(false);
            await project.DotnetRestoreAsync().ConfigureAwait(false);
            await project.DotnetBuildAsync().ConfigureAwait(false);

            Assert.True(File.Exists(Path.Combine(project.DirectoryPath, "README.md")));
            Assert.True(File.Exists(Path.Combine(project.DirectoryPath, "TODO.html")));
        }

        private static Task InstallTemplateAsync() => DotnetNew.InstallAsync<CodingStoryTemplateTest>(SolutionFileName);
    }
}
