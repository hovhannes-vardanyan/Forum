using ForumDAL.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL.Repositories
{
    public class SearchRepository
    {
        ForumContext context = new ForumContext();
        public List<string> KeyWords = new List<string>();
        public ConcurrentDictionary<Post, int> SearchResult = new ConcurrentDictionary<Post, int>();
        public SearchRepository(ForumContext context)
        {
            this.context = context;
        }
        public SearchRepository()
        {

        }

        /// <summary>
        /// Returns ordered IOrderedEnumerable<KeyValuePair<Post, int>> 
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns>IOrderedEnumerable<KeyValuePair<Post, int>> </returns>
        public IOrderedEnumerable<KeyValuePair<Post, int>> Search(string searchString)
        {
            KeyWords = searchString.Split(' ').Where(x => x != " " && x != "").ToList();

            Parallel.ForEach(context.Posts, post =>
             {
                 Parallel.ForEach(KeyWords, key =>
                  {
                      if (post.Title.Contains(key))
                      {
                          UpdateResultList(post);
                      }

                  });

             });

            return SearchResult.OrderByDescending(x => x.Value);
        }

        /// <summary>
        /// Add posts in resultlist or update exsisting items
        /// </summary>
        /// <param name="post"></param>
        void UpdateResultList(Post post)
        {
            try
            {
                int tempRating;
                if (SearchResult.TryGetValue(post, out tempRating))
                {
                    SearchResult.TryUpdate(post, tempRating + 1, tempRating);
                }
                else
                {
                    SearchResult.TryAdd(post, 0);
                }
            }
            catch (NullReferenceException)
            {
                throw;
            }

        }


       



    }
}
