using System.Collections.Generic;
using Octopus.Data.Model;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;
using Octopus.Server.Extensibility.HostServices.Mapping;

namespace Octopus.Server.Extensibility.IssueTracker.GitHub.Configuration
{
    class GitHubConfigurationSettings : ExtensionConfigurationSettings<GitHubConfiguration, GitHubConfigurationResource, IGitHubConfigurationStore>, IGitHubConfigurationSettings
    {
        public GitHubConfigurationSettings(IGitHubConfigurationStore configurationDocumentStore) : base(configurationDocumentStore)
        {
        }

        public override string Id => GitHubConfigurationStore.SingletonId;

        public override string ConfigurationSetName => "GitHub Issue Tracker";

        public override string Description => "GitHub Issue Tracker settings";

        public override IEnumerable<IConfigurationValue> GetConfigurationValues()
        {
            var isEnabled = ConfigurationDocumentStore.GetIsEnabled();

            yield return new ConfigurationValue<bool>("Octopus.IssueTracker.GitHubIssueTracker", isEnabled, isEnabled, "Is Enabled");
            yield return new ConfigurationValue<string?>("Octopus.IssueTracker.GitHubBaseUrl", ConfigurationDocumentStore.GetBaseUrl(), isEnabled && !string.IsNullOrWhiteSpace(ConfigurationDocumentStore.GetBaseUrl()), "GitHub Base Url");
            yield return new ConfigurationValue<string?>("Octopus.IssueTracker.GitHubUsername", ConfigurationDocumentStore.GetUsername(), isEnabled && !string.IsNullOrWhiteSpace(ConfigurationDocumentStore.GetUsername()), "GitHub Username");
            yield return new ConfigurationValue<SensitiveString?>("Octopus.IssueTracker.GitHubPassword", ConfigurationDocumentStore.GetPassword(), isEnabled && !string.IsNullOrWhiteSpace(ConfigurationDocumentStore.GetPassword()?.Value), "GitHub Password");
            yield return new ConfigurationValue<string?>("Octopus.IssueTracker.GitHubReleaseNotePrefix", ConfigurationDocumentStore.GetReleaseNotePrefix(), isEnabled && !string.IsNullOrWhiteSpace(ConfigurationDocumentStore.GetReleaseNotePrefix()), "GitHub Release Note Prefix");
        }

        public override void BuildMappings(IResourceMappingsBuilder builder)
        {
            builder.Map<GitHubConfigurationResource, GitHubConfiguration>();
            builder.Map<ReleaseNoteOptionsResource, ReleaseNoteOptions>();
        }
    }
}