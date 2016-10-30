using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using fands2.DAL;
using System.Collections.Generic;
using fands2.Models;
using System.Data.Entity;
using System.Linq;
using Moq;



namespace fands2.Tests.DAL
{
    [TestClass]
    public class ResponseRepositoryTest
    {
        Mock<ResponseContext> mock_context { get; set; }
        Mock<DbSet<Response>> mock_response_table { get; set; }
        List<Response> response_list { get; set; }
        ResponseRepository repo { get; set; }

        [TestMethod]
        public void EnsureCanCreateRepoInstance()
        {
            ResponseRepository repo = new ResponseRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void EnsureRepoHasContext()
        {
            ResponseRepository repo = new ResponseRepository();

            ResponseContext actual_context = repo.Context;

            Assert.IsInstanceOfType(actual_context, typeof(ResponseContext));

        }

        public void ConnectMocksToDatastore()
        {
            var queryable_list = response_list.AsQueryable();


            mock_response_table.As<IQueryable<Response>>().Setup(m => m.Provider).Returns(queryable_list.Provider);
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.Expression).Returns(queryable_list.Expression);
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.ElementType).Returns(queryable_list.ElementType);
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.GetEnumerator()).Returns(() => queryable_list.GetEnumerator());

            mock_context.Setup(c => c.Responses).Returns(mock_response_table.Object);

            mock_response_table.Setup(t => t.Add(It.IsAny<Response>())).Callback((Response r) => response_list.Add(r));
            mock_response_table.Setup(t => t.Remove(It.IsAny<Response>())).Callback((Response r) => response_list.Remove(r));
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<ResponseContext>();
            mock_response_table = new Mock<DbSet<Response>>();
            response_list = new List<Response>();
            repo = new ResponseRepository(mock_context.Object);

            ConnectMocksToDatastore();
        }

        [TestCleanup]
        public void TearDown()
        {
            repo = null;
        }

        [TestMethod]
        public void EnsureRepoContainsNoResponses()
        {
            
            List<Response> actual_responses = repo.GetResponses();

            int expected_responses_count = 0;
            int actual_responses_count = actual_responses.Count();

            Assert.AreEqual(expected_responses_count, actual_responses_count);

        }

        [TestMethod]
        public void EnsureRepoCanAddResponseToDatabase()
        {
            Response first_response = new Response {  RequestedMethod = "GET", RequestedUrl = "http://katyerussell.com", ResponseCode = "200", ResponseTime = 44 };
 
            repo.AddResponse(first_response);

            int actual_response_count = repo.GetResponses().Count;

            int expected_response_count = 1;

            // Assert
            Assert.AreEqual(expected_response_count, actual_response_count);
        }

        [TestMethod]
        public void EnsureCanFindResponseById()
        {
            Response first_response = new Response { ResponseId = 1, RequestedMethod = "GET", RequestedUrl = "http://katyerussell.com", ResponseCode = "200", ResponseTime = 44 };
            Response second_response = new Response { ResponseId = 2, RequestedMethod = "GET", RequestedUrl = "http://bobsbuffaloburgers", ResponseCode = "400", ResponseTime = 11 };
            Response third_response = new Response { ResponseId = 3, RequestedMethod = "GET", RequestedUrl = "http://hippyshake.com", ResponseCode = "300", ResponseTime = 22 };

            repo.AddResponse(first_response);
            repo.AddResponse(second_response);
            repo.AddResponse(third_response);

            int response_id = 2;
            Response requested_response = repo.GetResponseById(response_id);


            string expected_response_url = "http://bobsbuffaloburgers";

            string actual_response_url = requested_response.RequestedUrl;

            Assert.AreEqual(expected_response_url, actual_response_url);
        }

    }
}
