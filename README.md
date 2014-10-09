# HackerNewsDotNet

## Overview

Hacker News has partnered with Firebase to create a [real API](https://github.com/HackerNews/API).  This is a .NET client to that API.  With this API, you can get top stories, lookup items, and lookup profiles.  I'll add to it as the API expands.

One word of caution: if you choose to load all 100 top stories, it will take a while as it has to be done one at a time.

## Usage

### Get Top Story IDs
    HackerNewsApi client = new HackerNewsApi();
    IEnumerable<int> ids = client.TopStoryIds().Result;

### Get Top Stories (Iterative)
	HackerNewsApi client = new HackerNewsApi();
    IEnumerable<HackerNewsItem> ids = client.TopStories(2);

### Get News Item (story, poll, etc.)
    HackerNewsApi client = new HackerNewsApi();
    HackerNewsItem storyItem = client.NewsItem(12345).Result;

### Get User Profile
    HackerNewsApi client = new HackerNewsApi();
    HackerNewsUserProfile userProfile = client.UserProfile("jl").Result;

