namespace Epam.CodingStories.Template.Tests
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Boxed.DotnetNewTest;
    using Xunit;
    using Xunit.Abstractions;

    public class CodingStoryJavaTemplateTest
    {
        private const string TemplateName = "story-java";
        private const string SolutionFileName = "pom.xml";
        private static readonly string[] DefaultArguments = new string[]
        {
            "no-open-todo=true"
        };

        public CodingStoryJavaTemplateTest(ITestOutputHelper testOutputHelper)
        {
            if (testOutputHelper is null)
            {
                throw new ArgumentNullException(nameof(testOutputHelper));
            }

            TestLogger.WriteMessage = testOutputHelper.WriteLine;
        }

        [Theory]
        [InlineData("my-coding-story")]
        public async Task CodingStoriesJavaTemplateTests(string name, params string[] arguments)
        {
            await InstallTemplateAsync().ConfigureAwait(false);
            await using var tempDirectory = TempDirectory.NewTempDirectory();
            var project = await tempDirectory
                .DotnetNewAsync(TemplateName, name, DefaultArguments.ToArguments(arguments))
                .ConfigureAwait(false);
            Assert.True(File.Exists(Path.Combine(project.DirectoryPath, "README.md")));
            Assert.True(File.Exists(Path.Combine(project.DirectoryPath, "pom.xml")));
            Assert.True(File.Exists(Path.Combine(project.DirectoryPath, ".story.md")));
        }

        private static Task InstallTemplateAsync() => DotnetNew.InstallAsync<CodingStoryTemplateTest>(SolutionFileName);
    }
}
