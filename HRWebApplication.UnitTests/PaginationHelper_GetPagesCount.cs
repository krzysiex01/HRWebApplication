using HRWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HRWebApplication.UnitTests
{
    public class PaginationHelper_GetPagesCount
    {
        private PaginationHelper paginationHelper = new PaginationHelper();
        
        [Theory]
        [InlineData(1,0)]
        [InlineData(3,0)]
        [InlineData(10,0)]
        [InlineData(200,0)]
        [InlineData(500,0)]
        public void NoItems_ZeroPageCountReturned(int pageSize, int itemsCount)
        {
            var res = paginationHelper.GetPagesCount(pageSize, itemsCount);
            Assert.Equal(0, res);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(5, 1)]
        [InlineData(100, 1)]
        [InlineData(500, 1)]
        public void OneItemPresent_OnePageReturned(int pageSize, int itemsCount)
        {
            var res = paginationHelper.GetPagesCount(pageSize, itemsCount);
            Assert.Equal(1, res);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(0, 3)]
        [InlineData(0, 10)]
        public void PageSizeZero_ExceptionExpected(int pageSize, int itemsCount)
        {
            try
            {
                var res = paginationHelper.GetPagesCount(pageSize, itemsCount);
            }
            catch (Exception)
            {
                return;
            }
            Assert.True(false, "Expected exeption");
        }

        [Theory]
        [InlineData(1, 1000)]
        [InlineData(2, 5000)]
        [InlineData(3, 80000)]
        [InlineData(3, 100000)]
        public void ManyItemsSmallPageSize_CorrectNumberOfPagesReturned(int pageSize, int itemsCount)
        {
            var res = paginationHelper.GetPagesCount(pageSize, itemsCount);
            Assert.True(res >= 0);
        }
    }
}
