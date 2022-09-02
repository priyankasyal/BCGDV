using System;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using BCGDV.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;

namespace BCGDV.Test.IntegrationTest
{
    public class CheckoutIntegrationTest
    {
        private List<string> requestWithValidIds = new List<string>{ "001", "002", "003", "004" };
        private List<string> requestWithInvalidIds = new List<string> { "005", "007", "34", "abc" };
        private List<string> requestWithValidAndInvalidIds = new List<string> { "001", "002", "003", "004", "abc", "006" };
        private List<string> requestWithOffer1Ids = new List<string> { "001", "001", "001" };
        private List<string> requestWithOffer2Ids = new List<string> { "002", "002" };
        private List<string> requestWithOffer1AndOffer2Ids =  new List<string> { "001", "001", "001", "002", "002" };
        private List<string> requestWithOffer1AppliedTwiceIds = new List<string> { "001", "001", "001", "001", "001", "001"};
        private List<string> requestWithOffer2AppliedTwiceIds = new List<string> { "002", "002", "002", "002"};
        private string baseAddress = "https://localhost:8080";
        private string controllerPath = "/api/Checkout";
        private string contentTypeHeader = "application/json";
        private MockData mockData;

        public CheckoutIntegrationTest()
        {
            mockData = new MockData();
        }

        [Fact]
        public async Task TestRequestWithValidIds()
        {
            var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();
            var json = JsonConvert.SerializeObject(requestWithValidIds);
            client.BaseAddress = new Uri(baseAddress);
            var response = await client.PostAsync(controllerPath, new StringContent(json, Encoding.UTF8, contentTypeHeader));
            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var responseDto =  JsonConvert.DeserializeObject<CheckoutDto>(responseBody);
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.Created);
            Assert.Equal(responseDto.price, mockData.michealKorsWatch.getUnitPrice() + mockData.swatchWatch.getUnitPrice() +
               mockData.casioWatch.getUnitPrice() + mockData.rolexWatch.getUnitPrice());

        }

        [Fact]
        public async Task TestRequestWithInvalidIds()
        {
            var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();
            var json = JsonConvert.SerializeObject(requestWithInvalidIds);
            client.BaseAddress = new Uri(baseAddress);
            var response = await client.PostAsync(controllerPath, new StringContent(json, Encoding.UTF8, contentTypeHeader));
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.BadRequest);

        }

        [Fact]
        public async Task TestRequestWithValidAndInvalidIds()
        {
            var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();
            var json = JsonConvert.SerializeObject(requestWithValidAndInvalidIds);
            client.BaseAddress = new Uri(baseAddress);
            var response = await client.PostAsync(controllerPath, new StringContent(json, Encoding.UTF8, contentTypeHeader));
            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var responseDto = JsonConvert.DeserializeObject<CheckoutDto>(responseBody);
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.Created);
            Assert.Equal(responseDto.price, mockData.michealKorsWatch.getUnitPrice() + mockData.swatchWatch.getUnitPrice() +
               mockData.casioWatch.getUnitPrice() + mockData.rolexWatch.getUnitPrice());

        }

        [Fact]
        public async Task TestRequestWithOffer1Ids()
        {
            var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();
            var json = JsonConvert.SerializeObject(requestWithOffer1Ids);
            client.BaseAddress = new Uri(baseAddress);
            var response = await client.PostAsync(controllerPath, new StringContent(json, Encoding.UTF8, contentTypeHeader));
            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var responseDto = JsonConvert.DeserializeObject<CheckoutDto>(responseBody);
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.Created);
            Assert.Equal(responseDto.price, mockData.rolexWatch.getUnitPrice() * mockData.offer1.discountQuantity - mockData.offer1.discountPrice);

        }

        [Fact]
        public async Task TestRequestWithOffer2Ids()
        {
            var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();
            var json = JsonConvert.SerializeObject(requestWithOffer2Ids);
            client.BaseAddress = new Uri(baseAddress);
            var response = await client.PostAsync(controllerPath, new StringContent(json, Encoding.UTF8, contentTypeHeader));
            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var responseDto = JsonConvert.DeserializeObject<CheckoutDto>(responseBody);
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.Created);
            Assert.Equal(responseDto.price, mockData.michealKorsWatch.getUnitPrice() * mockData.offer2.discountQuantity - mockData.offer2.discountPrice);

        }

        [Fact]
        public async Task TestRequestWithOffer1AndOffer2Ids()
        {
            var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();
            var json = JsonConvert.SerializeObject(requestWithOffer1AndOffer2Ids);
            client.BaseAddress = new Uri(baseAddress);
            var response = await client.PostAsync(controllerPath, new StringContent(json, Encoding.UTF8, contentTypeHeader));
            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var responseDto = JsonConvert.DeserializeObject<CheckoutDto>(responseBody);
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.Created);
            Assert.Equal(responseDto.price, (mockData.rolexWatch.getUnitPrice() * mockData.offer1.discountQuantity) +
                (mockData.michealKorsWatch.getUnitPrice() * mockData.offer2.discountQuantity) -
                mockData.offer1.discountPrice - mockData.offer2.discountPrice);

        }

        [Fact]
        public async Task TestRequestWithOffer2AppliedTwice()
        {
            var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();
            var json = JsonConvert.SerializeObject(requestWithOffer2AppliedTwiceIds);
            client.BaseAddress = new Uri(baseAddress);
            var response = await client.PostAsync(controllerPath, new StringContent(json, Encoding.UTF8, contentTypeHeader));
            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var responseDto = JsonConvert.DeserializeObject<CheckoutDto>(responseBody);
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.Created);
            Assert.Equal(responseDto.price, (mockData.michealKorsWatch.getUnitPrice() * mockData.offer2.discountQuantity * 2) -
                (2 * mockData.offer2.discountPrice));

        }

        [Fact]
        public async Task TestRequestWithOffer1AppliedTwice()
        {
            var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();
            var json = JsonConvert.SerializeObject(requestWithOffer1AppliedTwiceIds);
            client.BaseAddress = new Uri(baseAddress);
            var response = await client.PostAsync(controllerPath, new StringContent(json, Encoding.UTF8, contentTypeHeader));
            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var responseDto = JsonConvert.DeserializeObject<CheckoutDto>(responseBody);
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.Created);
            Assert.Equal(responseDto.price, (mockData.rolexWatch.getUnitPrice() * mockData.offer1.discountQuantity * 2) -
                (2 * mockData.offer1.discountPrice));

        }
    }
}

