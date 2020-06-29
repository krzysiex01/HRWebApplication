using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApplication.Models
{
    /// <summary>
    /// Helps to calculate correct indexes when pagination is used.
    /// </summary>
    public class PaginationHelper
    {
        public int GetPagesCount(int pageSize, int itemsCount)
        {
            if (pageSize == 0)
            {
                throw new ArgumentException();
            }
            return (int)Math.Ceiling((double)itemsCount / pageSize);
        }

        public int GetFirstIndexOnPage(int pageSize,int pageNumber)
        {
            return pageSize * (pageNumber - 1);
        }
    }
}
