using System;
using System.Collections.Generic;

/// <summary>
/// The Model namespace.
/// </summary>

namespace HackerNewsDotNet.Model
{
    /// <summary>
    /// Class HackerNewsUserProfile.  Represents a HackerNews user profile/user.  Find more at 
    /// https://github.com/HackerNews/API
    /// </summary>
    public class HackerNewsUserProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HackerNewsUserProfile"/> class.
        /// </summary>
        public HackerNewsUserProfile()
        {
            Submitted = new List<int>();
        }

        /// <summary>
        /// Gets or sets the identifier.  This is the username.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the delay in minutes between a comment's creation and its visibility to other users.
        /// </summary>
        /// <value>The delay.</value>
        public int Delay { get; set; }

        /// <summary>
        /// Gets or sets the time the profile was created in UNIX time.
        /// </summary>
        /// <value>The created.</value>
        public int Created { get; set; }

        /// <summary>
        /// Gets or sets the karma.
        /// </summary>
        /// <value>The karma.</value>
        public int Karma { get; set; }

        /// <summary>
        /// Gets or sets the bio.
        /// </summary>
        /// <value>The about.</value>
        public string About { get; set; }

        /// <summary>
        /// Gets the create time based on the Time property
        /// </summary>
        /// <value>The create time.</value>
        public DateTime CreatedTime
        {
            get
            {
                System.DateTime outTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                outTime = outTime.AddSeconds(this.Created).ToLocalTime();
                return outTime;
            }
        }

        /// <summary>
        /// Gets or sets the list of submitted items.
        /// </summary>
        /// <value>The submitted.</value>
        public List<int> Submitted { get; set; }
    }
}