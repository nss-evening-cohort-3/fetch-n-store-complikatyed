using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using fands2.DAL;
using System.Collections.Generic;
using fands2.Models;
using System.Data.Entity;
using System.Linq;




namespace fands2.Tests.DAL
{
    [TestClass]
    public class ResponseRepositoryTest
    {

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
    }
}
