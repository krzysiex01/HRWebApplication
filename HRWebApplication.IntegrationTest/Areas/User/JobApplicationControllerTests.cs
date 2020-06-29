using HRWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HRWebApplication.IntegrationTests.Areas.User
{
    public class JobApplicationControllerTests : IClassFixture<CustomHRApplicationFactory<Startup>>
    {
        private readonly HttpClient client;
        private readonly CustomHRApplicationFactory<Startup> factory;

        public JobApplicationControllerTests(CustomHRApplicationFactory<Startup> factory)
        {
            this.factory = factory;
            client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task LoadJobApplicationsIndexPage_ReturnsSuccessAndCorrectContentType()
        {
            var response = await this.client.GetAsync("User/JobApplication/Index");

            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task GetEditJobApplicationPage_ReturnsSuccessAndCorrectContentType()
        {
            var response = await this.client.GetAsync("User/JobApplication/Edit?id=1");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
            Assert.Contains("Edit Job Application", responseString);
        }

        [Fact]
        public async Task GetEditJobApplicationPageForNonExistingApplication_ReturnsNotFound()
        {
            var response = await this.client.GetAsync("User/JobApplication/Edit/100");

            Assert.Equal(HttpStatusCode.NotFound.ToString(),
                response.StatusCode.ToString());
        }

        [Fact]
        public async Task GetEditJobApplicationPageWithoutJobApplicationId_ReturnsBadRequest()
        {
            var response = await this.client.GetAsync("User/JobApplication/Edit");

            Assert.Equal(HttpStatusCode.BadRequest.ToString(),
                response.StatusCode.ToString());
        }
        [Fact]
        public async Task GetCreateJobApplicationPageWithoutJobOfferId_ReturnsBadRequest()
        {
            var response = await this.client.GetAsync("User/JobApplication/Create");

            Assert.Equal(HttpStatusCode.BadRequest.ToString(),
                response.StatusCode.ToString());
        }

        [Fact]
        public async Task GetCreateJobApplicationPageForNonExistingJobOffer_ReturnsNotFound()
        {
            var response = await this.client.GetAsync("User/JobApplication/Create?jobOfferId=100");

            Assert.Equal(HttpStatusCode.NotFound.ToString(),
                response.StatusCode.ToString());
        }
    }
}
