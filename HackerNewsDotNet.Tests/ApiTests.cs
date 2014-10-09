using System.Collections.Generic;
using System.Linq;
using HackerNewsDotNet.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsDotNet.Tests
{
    [TestClass]
    public class ApiTests
    {
        private const string GOOD_USER_ID = "jl";
        private const int GOOD_STORY_ID = 8863;

        [TestMethod]
        public void CanGetUserProfile()
        {
            HackerNewsApi client = new HackerNewsApi();
            HackerNewsUserProfile userProfile = client.UserProfile(GOOD_USER_ID).Result;
            Assert.IsNotNull(userProfile);
        }

        [TestMethod]
        public void CanGetStory()
        {
            HackerNewsApi client = new HackerNewsApi();
            HackerNewsItem storyItem = client.NewsItem(GOOD_STORY_ID).Result;
            Assert.IsNotNull(storyItem);
        }

        [TestMethod]
        public void CanGetTopStoryIds()
        {
            HackerNewsApi client = new HackerNewsApi();
            IEnumerable<int> ids = client.TopStoryIds().Result;
            Assert.IsTrue(ids.Any());
        }

        [TestMethod]
        public void CanGetTopStories()
        {
            HackerNewsApi client = new HackerNewsApi();
            IEnumerable<HackerNewsItem> ids = client.TopStories(2);
            Assert.IsTrue(ids.Count() == 2);
            Assert.IsTrue(ids.ElementAt(0) != null);
            Assert.IsTrue(ids.ElementAt(1) != null);
        }

        [TestMethod]
        public void CanGetMaxTopStories()
        {
            HackerNewsApi client = new HackerNewsApi();
            IEnumerable<HackerNewsItem> ids = client.TopStories(105);
            Assert.IsTrue(ids.Count() == 100);
        }

        [TestMethod]
        public void CanNotPassNegativeToTopStories()
        {
            HackerNewsApi client = new HackerNewsApi();
            IEnumerable<HackerNewsItem> ids = client.TopStories(-1);
            Assert.IsTrue(ids.Count() == 0);
        }

        [TestMethod]
        public void CanAskForInvalidItem()
        {
            HackerNewsApi client = new HackerNewsApi();
            HackerNewsItem item = client.NewsItem(int.MaxValue).Result;
            Assert.IsTrue(item == null);
        }
    }
}