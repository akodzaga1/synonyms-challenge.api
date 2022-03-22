using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SynonymsChallenge;
using SynonymsChallenge.Models;

namespace SynonymsChallenge.Tests.Controllers
{
    [TestClass]
    public class AllSynonymsTest
    {
        [TestMethod]
        public void Post()
        {
            // Arrange
            AllSynonymsController controller = new AllSynonymsController();

            PostParametersAll postParametersAll = new PostParametersAll();
            #region inserted "test"
            postParametersAll.word = "test";
            postParametersAll.skip = 0;
            postParametersAll.retrievedList = new string[] { };
            postParametersAll.getAll = false;
            postParametersAll.myCollection = new string[][] { };

            // Act
            var result = controller.Post(postParametersAll);
            var expected = new SynonymsListAll();
            expected.synonyms = new string[] { "essay", "examine", "prove", "try", "exam", "examination" };
            expected.hasMore = true;
            // Assert
            Assert.AreEqual(expected.hasMore, result.hasMore);
            Assert.AreEqual(expected.synonyms.Length, result.synonyms.Length);
            for (int i = 0; i < expected.synonyms.Length; i++)
            {
                Assert.AreEqual(expected.synonyms[i], result.synonyms[i]);
            }
            #endregion

            #region inserted "word"
            postParametersAll.word = "word";
            postParametersAll.skip = 0;
            postParametersAll.retrievedList = new string[] { };
            postParametersAll.getAll = false;
            postParametersAll.myCollection = new string[][] { };

            // Act
            result = controller.Post(postParametersAll);
            expected = new SynonymsListAll();
            expected.synonyms = new string[] { "discussion", "give-and-take", "intelligence", "news", "tidings" };
            expected.hasMore = false;
            // Assert
            Assert.AreEqual(expected.hasMore, result.hasMore);
            Assert.AreEqual(expected.synonyms.Length, result.synonyms.Length);
            for (int i = 0; i < expected.synonyms.Length; i++)
            {
                Assert.AreEqual(expected.synonyms[i], result.synonyms[i]);
            }
            #endregion
        }
    }
}
