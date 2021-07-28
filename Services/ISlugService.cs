using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HadesBlog.Services
{
    public interface ISlugService
    {
        string UrlFriendly(string Title);

        bool IsUnique(string slug);
    }
}
