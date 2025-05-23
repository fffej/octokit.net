﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Octokit
{
    /// <summary>
    /// A client for GitHub's Reactions API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developer.github.com/v3/reactions/">Reactions API documentation</a> for more information.
    /// </remarks>
    public class IssueReactionsClient : ApiClient, IIssueReactionsClient
    {
        public IssueReactionsClient(IApiConnection apiConnection)
            : base(apiConnection)
        {
        }

        /// <summary>
        /// Get all reactions for a specified Issue
        /// </summary>
        /// <remarks>https://developer.github.com/v3/reactions/#list-reactions-for-an-issue</remarks>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <param name="issueNumber">The issue number</param>
        [ManualRoute("GET", "/repos/{owner}/{repo}/issues/{issue_number}/reactions")]
        public Task<IReadOnlyList<Reaction>> GetAll(string owner, string name, long issueNumber)
        {
            return GetAll(owner, name, issueNumber, ApiOptions.None);
        }

        /// <summary>
        /// Get all reactions for a specified Issue
        /// </summary>
        /// <remarks>https://developer.github.com/v3/reactions/#list-reactions-for-an-issue</remarks>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <param name="issueNumber">The issue number</param>
        /// <param name="options">Options for changing the API response</param>
        [ManualRoute("GET", "/repos/{owner}/{repo}/issues/{issue_number}/reactions")]
        public Task<IReadOnlyList<Reaction>> GetAll(string owner, string name, long issueNumber, ApiOptions options)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, nameof(owner));
            Ensure.ArgumentNotNullOrEmptyString(name, nameof(name));
            Ensure.ArgumentNotNull(options, nameof(options));

            return ApiConnection.GetAll<Reaction>(ApiUrls.IssueReactions(owner, name, issueNumber), null, options);
        }

        /// <summary>
        /// Get all reactions for a specified Issue
        /// </summary>
        /// <remarks>https://developer.github.com/v3/reactions/#list-reactions-for-an-issue</remarks>
        /// <param name="repositoryId">The Id of the repository</param>
        /// <param name="issueNumber">The issue number</param>
        [ManualRoute("GET", "/repositories/{id}/issues/{number}/reactions")]
        public Task<IReadOnlyList<Reaction>> GetAll(long repositoryId, long issueNumber)
        {
            return GetAll(repositoryId, issueNumber, ApiOptions.None);
        }

        /// <summary>
        /// Get all reactions for a specified Issue
        /// </summary>
        /// <remarks>https://developer.github.com/v3/reactions/#list-reactions-for-an-issue</remarks>
        /// <param name="repositoryId">The Id of the repository</param>
        /// <param name="issueNumber">The issue number</param>
        /// <param name="options">Options for changing the API response</param>
        [ManualRoute("GET", "/repositories/{id}/issues/{number}/reactions")]
        public Task<IReadOnlyList<Reaction>> GetAll(long repositoryId, long issueNumber, ApiOptions options)
        {
            Ensure.ArgumentNotNull(options, nameof(options));

            return ApiConnection.GetAll<Reaction>(ApiUrls.IssueReactions(repositoryId, issueNumber), null, options);
        }

        /// <summary>
        /// Creates a reaction for a specified Issue
        /// </summary>
        /// <remarks>https://developer.github.com/v3/reactions/#create-reaction-for-an-issue</remarks>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <param name="issueNumber">The issue number</param>
        /// <param name="reaction">The reaction to create</param>
        [ManualRoute("POST", "/repos/{owner}/{repo}/issues/{issue_number}/reactions")]
        public Task<Reaction> Create(string owner, string name, long issueNumber, NewReaction reaction)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, nameof(owner));
            Ensure.ArgumentNotNullOrEmptyString(name, nameof(name));
            Ensure.ArgumentNotNull(reaction, nameof(reaction));

            return ApiConnection.Post<Reaction>(ApiUrls.IssueReactions(owner, name, issueNumber), reaction);
        }

        /// <summary>
        /// Creates a reaction for a specified Issue
        /// </summary>
        /// <remarks>https://developer.github.com/v3/reactions/#create-reaction-for-an-issue</remarks>
        /// <param name="repositoryId">The Id of the repository</param>
        /// <param name="issueNumber">The issue number</param>
        /// <param name="reaction">The reaction to create</param>
        [ManualRoute("POST", "/repositories/{id}/issues/{number}/reactions")]
        public Task<Reaction> Create(long repositoryId, long issueNumber, NewReaction reaction)
        {
            Ensure.ArgumentNotNull(reaction, nameof(reaction));

            return ApiConnection.Post<Reaction>(ApiUrls.IssueReactions(repositoryId, issueNumber), reaction);
        }

        /// <summary>
        /// Deletes a reaction for a specified Issue
        /// </summary>
        /// <remarks>https://docs.github.com/rest/reactions#delete-an-issue-reaction</remarks>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <param name="issueNumber">The issue id</param>
        /// <param name="reactionId">The reaction id</param>
        /// <returns></returns>
        [ManualRoute("DELETE", "/repos/{owner}/{repo}/issues/{issue_number}/reactions/{reaction_id}")]
        public Task Delete(string owner, string name, long issueNumber, long reactionId)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, nameof(owner));
            Ensure.ArgumentNotNullOrEmptyString(name, nameof(name));

            return ApiConnection.Delete(ApiUrls.IssueReaction(owner, name, issueNumber, reactionId));
        }

        /// <summary>
        /// Deletes a reaction for a specified Issue
        /// </summary>
        /// <remarks>https://docs.github.com/rest/reactions#delete-an-issue-reaction</remarks>
        /// <param name="repositoryId">The owner of the repository</param>
        /// <param name="issueNumber">The issue id</param>
        /// <param name="reactionId">The reaction id</param>
        /// <returns></returns>
        [ManualRoute("DELETE", "/repositories/{id}/issues/{issue_number}/reactions/{reaction_id}")]
        public Task Delete(long repositoryId, long issueNumber, long reactionId)
        {
            return ApiConnection.Delete(ApiUrls.IssueReaction(repositoryId, issueNumber, reactionId));
        }
    }
}
