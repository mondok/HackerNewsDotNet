using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HackerNewsDotNet.Model;

/// <summary>
/// The HackerNewsDotNet namespace.
/// </summary>

namespace HackerNewsDotNet
{
    /// <summary>
    /// Class HackerNewsApi.  This is an API to use against Hacker News' new Firebase API.
    /// </summary>
    public class HackerNewsApi
    {
        /// <summary>
        /// Retrieves the top stories.  The max limit is 100.
        /// </summary>
        /// <param name="limit">The limit.</param>
        /// <returns>IEnumerable&lt;HackerNewsItem&gt;.</returns>
        public IEnumerable<HackerNewsItem> TopStories(int limit = 100)
        {
            if (limit <= 0) yield break;
            List<int> topStoryIds = TopStoryIds().Result.ToList();
            int floor = limit < topStoryIds.Count ? limit : topStoryIds.Count;
            for (int i = 0; i < floor; i++)
            {
                yield return NewsItem(topStoryIds.ElementAt(i)).Result;
            }
        }

        /// <summary>
        /// Gets a user's profile
        /// </summary>
        /// <param name="userId">The username to retrieve.</param>
        /// <returns>Task&lt;HackerNewsUserProfile&gt;.</returns>
        public async Task<HackerNewsUserProfile> UserProfile(string userId)
        {
            return await InvokeApi<HackerNewsUserProfile>(string.Format(HackerNewsConstants.HN_USER_PATH, userId));
        }

        /// <summary>
        /// Gets a news item.  This could be a story, poll, etc.
        /// </summary>
        /// <param name="itemId">The item identifier.</param>
        /// <returns>Task&lt;HackerNewsItem&gt;.</returns>
        public async Task<HackerNewsItem> NewsItem(int itemId)
        {
            return await InvokeApi<HackerNewsItem>(string.Format(HackerNewsConstants.HN_ITEM_PATH, itemId));
        }

        /// <summary>
        /// Gets a list of top story IDs
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;System.Int32&gt;&gt;.</returns>
        public async Task<IEnumerable<int>> TopStoryIds()
        {
            return await InvokeApi<IEnumerable<int>>(HackerNewsConstants.HN_TOP_STORIES_PATH);
        }

        /// <summary>
        /// Invokes the API.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">The path.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        private async Task<T> InvokeApi<T>(string path)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(HackerNewsConstants.HN_BASE_URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    List<MediaTypeFormatter> formatters = new List<MediaTypeFormatter>();
                    return await response.Content.ReadAsAsync<T>();
                }
            }
            return default(T);
        }
    }
}