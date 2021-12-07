using System;
using Domain_models.Entities;

namespace Domain_models.Exceptions
{
    public class DuplicateArticleException : Exception
    {
        public DuplicateArticleException(string message = "Article is already in database")
            : base(message)
        {
        }

        public DuplicateArticleException(Guid id) : this(id.ToString() + " is already in database")
        {
        }
    }
}