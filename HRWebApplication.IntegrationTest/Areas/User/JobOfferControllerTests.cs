using HRWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HRWebApplication.IntegrationTests.Areas.User
{
    public class JobOfferControllerTests : IClassFixture<CustomHRApplicationFactory<Startup>>
    {
        private readonly HttpClient client;
        private readonly CustomHRApplicationFactory<Startup> factory;

        public JobOfferControllerTests(CustomHRApplicationFactory<Startup> factory)
        {
            this.factory = factory;
            client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task LoadJobOfferIndexPage_ReturnsSuccessAndCorrectContentType()
        {
            var response = await this.client.GetAsync("User/JobOffer/");

            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task GetDatailsJobOfferPage_ReturnsSuccessAndCorrectContentType()
        {
            var response = await this.client.GetAsync("User/JobOffer/Details/1");

            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task GetDeatilsJobOfferPageForNonExistingJobOffer_ReturnsNotFound()
        {
            var response = await this.client.GetAsync("User/JobOffer/Details/100");

            Assert.Equal(HttpStatusCode.NotFound.ToString(),
                response.StatusCode.ToString());
        }

        [Fact]
        public async Task GetDetailsJobOfferPageWithoutJobOfferId_ReturnsBadRequest()
        {
            var response = await this.client.GetAsync("User/JobOffer/Details");

            Assert.Equal(HttpStatusCode.BadRequest.ToString(),
                response.StatusCode.ToString());
        }
    }
}
