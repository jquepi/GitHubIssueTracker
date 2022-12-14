using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Octopus.Client.Extensibility.Attributes;
using Octopus.Client.Extensibility.Extensions.Infrastructure.Configuration;
using Octopus.Client.Model;

namespace Octopus.Client.Extensibility.IssueTracker.GitHub
{
    public class GitHubConfigurationResource : ExtensionConfigurationResource
    {
        public const string GitHubBaseUrlDescription = "Set the base url for the GitHub repositories.";

        public GitHubConfigurationResource()
        {
            Id = "issuetracker-github";
            BaseUrl = "https://github.com";
        }

        [DisplayName("GitHub Base Url")]
        [Description(GitHubBaseUrlDescription)]
        [Required]
        [Writeable]
        public string BaseUrl { get; set; }

        public ReleaseNoteOptionsResource ReleaseNoteOptions { get; set; } = new ReleaseNoteOptionsResource();
    }

    public class ReleaseNoteOptionsResource
    {
        public const string UsernameDescription = "Set the username to authenticate with against GitHub. Leave blank if using a Personal Access Token for authentication.";
        public const string PasswordDescription = "Set the password or Personal Access Token to authenticate with against GitHub.";
        public const string ReleaseNotePrefixDescription = "Set the prefix to look for when finding release notes for GitHub issues. For example `Release note:`.";

        [DisplayName("Username")]
        [Description(UsernameDescription)]
        [Writeable]
        public string Username { get; set; }

        [DisplayName("Password")]
        [Description(PasswordDescription)]
        [Writeable]
        public SensitiveValue Password { get; set; }

        [DisplayName("Release note prefix")]
        [Description(ReleaseNotePrefixDescription)]
        [Writeable]
        public string ReleaseNotePrefix { get; set; }
    }
}