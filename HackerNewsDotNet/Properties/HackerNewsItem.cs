using System;
using System.Collections.Generic;

/// <summary>
/// The Model namespace.
/// </summary>

namespace HackerNewsDotNet.Model
{
    /// <summary>
    /// Class HackerNewsItem.  Stories, comments, jobs, Ask HNs and even polls are just items.  Find more at
    /// https://github.com/HackerNews/API
    /// </summary>
    public class HackerNewsItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HackerNewsItem"/> class.
        /// </summary>
        public HackerNewsItem()
        {
            Parts = new List<int>();
            Kids = new List<int>();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="HackerNewsItem"/> is deleted.
        /// </summary>
        /// <value><c>true</c> if deleted; otherwise, <c>false</c>.</value>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the user that submitted the item.
        /// </summary>
        /// <value>The by.</value>
        public string By { get; set; }

        /// <summary>
        /// Gets or sets the item type.  This could be Comments, Jobs, AskHN, and Polls.
        /// </summary>
        /// <value>The type.</value>
        public HackerNewsItemType Type { get; set; }

        /// <summary>
        /// Gets or sets the UNIX time.
        /// </summary>
        /// <value>The time.</value>
        public int Time { get; set; }

        /// <summary>
        /// Gets the create time based on the Time property
        /// </summary>
        /// <value>The create time.</value>
        public DateTime CreateTime
        {
            get
            {
                System.DateTime outTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                outTime = outTime.AddSeconds(this.Time).ToLocalTime();
                return outTime;
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="HackerNewsItem"/> is dead.
        /// </summary>
        /// <value><c>true</c> if dead; otherwise, <c>false</c>.</value>
        public bool Dead { get; set; }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public int? Parent { get; set; }

        /// <summary>
        /// Gets or sets the children of this item.
        /// </summary>
        /// <value>The kids.</value>
        public IEnumerable<int> Kids { get; set; }

        /// <summary>
        /// Gets or sets the URL of the item.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the item score.
        /// </summary>
        /// <value>The score.</value>
        public int? Score { get; set; }

        /// <summary>
        /// Gets or sets the item title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the parts.
        /// </summary>
        /// <value>The parts.</value>
        public IEnumerable<int> Parts { get; set; }
    }
}