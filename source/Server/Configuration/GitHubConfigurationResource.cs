﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Octopus.Data.Resources.Attributes;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.IssueTracker.GitHub.Configuration
{
    [Description("Configure the GitHub Issue Tracker. [Learn more](https://g.octopushq.com/GitHubIssueTracker).")]
    public class GitHubConfigurationResource : ExtensionConfigurationResource
    {
        public const string GitHubBaseUrlDescription = "Set the base url for the Git repositories.";

        [DisplayName("GitHub Base Url")]
        [Description(GitHubBaseUrlDescription)]
        [Required]
        [Writeable]
        public string BaseUrl { get; set; }
    }
}