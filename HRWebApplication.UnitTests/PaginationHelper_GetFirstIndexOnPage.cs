using HRWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HRWebApplication.UnitTests
{
    public class PaginationHelper_GetFirstIndexOnPage
    {
        private PaginationHelper paginationHelper = new PaginationHelper();

        [Theory]
        [InlineData(0,0)]
        [InlineData(0,1)]
        [InlineData(0,3)]
        [InlineData(0,5)]
        [InlineData(0,20)]
        [InlineData(0,100)]
        public void PageSizeSetToZero_ZeroIndexReturned(int pageSize, int pageNumber)
        {
            var res = paginationHelper.GetFirstIndexOnPage(pageSize, pageNumber);
            Assert.Equal(0, res);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(5, 1)]
        [InlineData(20, 1)]
        [InlineData(70, 1)]
        public void GetingFirstPage_ZeroIndexReturned(int pageSize, int pageNumber)
        {
            var res = paginationHelper.GetFirstIndexOnPage(pageSize, pageNumber);
            Assert.Equal(0, res);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 3)]
        [InlineData(1, 7)]
        [InlineData(1, 20)]
        [InlineData(1, 100)]
        public void PageSizeSetToOne_PageNumberMinusOneReturned(int pageSize, int pageNumber)
        {
            var res = paginationHelper.GetFirstIndexOnPage(pageSize, pageNumber);
            Assert.Equal(pageNumber-1, res);
        }
    }
}
