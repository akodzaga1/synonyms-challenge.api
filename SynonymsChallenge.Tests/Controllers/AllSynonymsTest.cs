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
            #region inserted "synonymA"
            postParametersAll.word = "synonymA";
            postParametersAll.skip = 0;
            postParametersAll.retrievedList = new string[] { };
            postParametersAll.getAll = false;
            postParametersAll.myCollection = new string[][] { new string [] { "synonymA", "synonymB" }, new string[] { "synonymB", "synonymC" }, new string[] { "synonymC", "synonymD" }, new string[] { "synonymE", "synonymF" } };

            // Act
            var result = controller.Post(postParametersAll);
            var expected = new SynonymsListAll();
            expected.synonyms = new string[] { "synonymB" };
            expected.hasMore = true;
            // Assert
            Assert.AreEqual(expected.hasMore, result.hasMore);
            Assert.AreEqual(expected.synonyms.Length, result.synonyms.Length);
            Assert.IsTrue(result.synonyms.Contains("synonymB"));
            #endregion

            #region inserted "synonymB"
            postParametersAll.word = "synonymB";
            postParametersAll.skip = 0;
            postParametersAll.retrievedList = new string[] { };
            postParametersAll.getAll = false;
            postParametersAll.myCollection = new string[][] { new string[] { "synonymA", "synonymB" }, new string[] { "synonymB", "synonymC" }, new string[] { "synonymC", "synonymD" }, new string[] { "synonymE", "synonymF" } };

            // Act
            result = controller.Post(postParametersAll);
            expected = new SynonymsListAll();
            expected.synonyms = new string[] { "synonymA", "synonymC" };
            expected.hasMore = true;
            // Assert
            Assert.AreEqual(expected.hasMore, result.hasMore);
            Assert.AreEqual(expected.synonyms.Length, result.synonyms.Length);
            Assert.IsTrue(result.synonyms.Contains("synonymA"));
            Assert.IsTrue(result.synonyms.Contains("synonymC"));
            #endregion

            #region inserted "synonymC"
            postParametersAll.word = "synonymC";
            postParametersAll.skip = 0;
            postParametersAll.retrievedList = new string[] { };
            postParametersAll.getAll = false;
            postParametersAll.myCollection = new string[][] { new string[] { "synonymA", "synonymB" }, new string[] { "synonymB", "synonymC" }, new string[] { "synonymC", "synonymD" }, new string[] { "synonymE", "synonymF" } };

            // Act
            result = controller.Post(postParametersAll);
            expected = new SynonymsListAll();
            expected.synonyms = new string[] { "synonymB", "synonymD" };
            expected.hasMore = true;
            // Assert
            Assert.AreEqual(expected.hasMore, result.hasMore);
            Assert.AreEqual(expected.synonyms.Length, result.synonyms.Length);
            Assert.IsTrue(result.synonyms.Contains("synonymB"));
            Assert.IsTrue(result.synonyms.Contains("synonymD"));
            #endregion

            #region inserted "synonymD"
            postParametersAll.word = "synonymD";
            postParametersAll.skip = 0;
            postParametersAll.retrievedList = new string[] { };
            postParametersAll.getAll = false;
            postParametersAll.myCollection = new string[][] { new string[] { "synonymA", "synonymB" }, new string[] { "synonymB", "synonymC" }, new string[] { "synonymC", "synonymD" }, new string[] { "synonymE", "synonymF" } };

            // Act
            result = controller.Post(postParametersAll);
            expected = new SynonymsListAll();
            expected.synonyms = new string[] { "synonymC" };
            expected.hasMore = true;
            // Assert
            Assert.AreEqual(expected.hasMore, result.hasMore);
            Assert.AreEqual(expected.synonyms.Length, result.synonyms.Length);
            Assert.IsTrue(result.synonyms.Contains("synonymC"));
            #endregion

            #region inserted "synonymE"
            postParametersAll.word = "synonymE";
            postParametersAll.skip = 0;
            postParametersAll.retrievedList = new string[] { };
            postParametersAll.getAll = false;
            postParametersAll.myCollection = new string[][] { new string[] { "synonymA", "synonymB" }, new string[] { "synonymB", "synonymC" }, new string[] { "synonymC", "synonymD" }, new string[] { "synonymE", "synonymF" } };

            // Act
            result = controller.Post(postParametersAll);
            expected = new SynonymsListAll();
            expected.synonyms = new string[] { "synonymF" };
            expected.hasMore = false;
            // Assert
            Assert.AreEqual(expected.hasMore, result.hasMore);
            Assert.AreEqual(expected.synonyms.Length, result.synonyms.Length);
            Assert.IsTrue(result.synonyms.Contains("synonymF"));
            #endregion

            #region inserted "synonymF"
            postParametersAll.word = "synonymF";
            postParametersAll.skip = 0;
            postParametersAll.retrievedList = new string[] { };
            postParametersAll.getAll = false;
            postParametersAll.myCollection = new string[][] { new string[] { "synonymA", "synonymB" }, new string[] { "synonymB", "synonymC" }, new string[] { "synonymC", "synonymD" }, new string[] { "synonymE", "synonymF" } };

            // Act
            result = controller.Post(postParametersAll);
            expected = new SynonymsListAll();
            expected.synonyms = new string[] { "synonymE" };
            expected.hasMore = false;
            // Assert
            Assert.AreEqual(expected.hasMore, result.hasMore);
            Assert.AreEqual(expected.synonyms.Length, result.synonyms.Length);
            Assert.IsTrue(result.synonyms.Contains("synonymE"));
            #endregion

            #region show more level 1 "synonymA"
            postParametersAll.word = "synonymA";
            postParametersAll.skip = 0;
            postParametersAll.retrievedList = new string[] { "synonymB" };
            postParametersAll.getAll = false;
            postParametersAll.myCollection = new string[][] { new string[] { "synonymA", "synonymB" }, new string[] { "synonymB", "synonymC" }, new string[] { "synonymC", "synonymD" }, new string[] { "synonymE", "synonymF" } };

            // Act
            result = controller.Post(postParametersAll);
            expected = new SynonymsListAll();
            expected.synonyms = new string[] { "synonymB", "synonymC" };
            expected.hasMore = true;
            // Assert
            Assert.AreEqual(expected.hasMore, result.hasMore);
            Assert.AreEqual(expected.synonyms.Length, result.synonyms.Length);
            Assert.IsTrue(result.synonyms.Contains("synonymB"));
            Assert.IsTrue(result.synonyms.Contains("synonymC"));
            #endregion

            #region show more level 2 "synonymA"
            postParametersAll.word = "synonymA";
            postParametersAll.skip = 1;
            postParametersAll.retrievedList = new string[] { "synonymB", "synonymC" };
            postParametersAll.getAll = false;
            postParametersAll.myCollection = new string[][] { new string[] { "synonymA", "synonymB" }, new string[] { "synonymB", "synonymC" }, new string[] { "synonymC", "synonymD" }, new string[] { "synonymE", "synonymF" } };

            // Act
            result = controller.Post(postParametersAll);
            expected = new SynonymsListAll();
            expected.synonyms = new string[] { "synonymB", "synonymC", "synonymD" };
            expected.hasMore = false;
            // Assert
            Assert.AreEqual(expected.hasMore, result.hasMore);
            Assert.AreEqual(expected.synonyms.Length, result.synonyms.Length);
            Assert.IsTrue(result.synonyms.Contains("synonymB"));
            Assert.IsTrue(result.synonyms.Contains("synonymC"));
            Assert.IsTrue(result.synonyms.Contains("synonymD"));
            #endregion

            #region show all level 1 "synonymA"
            postParametersAll.word = "synonymA";
            postParametersAll.skip = 0;
            postParametersAll.retrievedList = new string[] { "synonymB" };
            postParametersAll.getAll = true;
            postParametersAll.myCollection = new string[][] { new string[] { "synonymA", "synonymB" }, new string[] { "synonymB", "synonymC" }, new string[] { "synonymC", "synonymD" }, new string[] { "synonymE", "synonymF" } };

            // Act
            result = controller.Post(postParametersAll);
            expected = new SynonymsListAll();
            expected.synonyms = new string[] { "synonymB", "synonymC", "synonymD" };
            expected.hasMore = false;
            // Assert
            Assert.AreEqual(expected.hasMore, result.hasMore);
            Assert.AreEqual(expected.synonyms.Length, result.synonyms.Length);
            Assert.IsTrue(result.synonyms.Contains("synonymB"));
            Assert.IsTrue(result.synonyms.Contains("synonymC"));
            Assert.IsTrue(result.synonyms.Contains("synonymD"));
            #endregion

            #region show more level 2 "synonymA"
            postParametersAll.word = "synonymA";
            postParametersAll.skip = 1;
            postParametersAll.retrievedList = new string[] { "synonymB", "synonymC" };
            postParametersAll.getAll = false;
            postParametersAll.myCollection = new string[][] { new string[] { "synonymA", "synonymB" }, new string[] { "synonymB", "synonymC" }, new string[] { "synonymC", "synonymD" }, new string[] { "synonymE", "synonymF" } };

            // Act
            result = controller.Post(postParametersAll);
            expected = new SynonymsListAll();
            expected.synonyms = new string[] { "synonymB", "synonymC", "synonymD" };
            expected.hasMore = false;
            // Assert
            Assert.AreEqual(expected.hasMore, result.hasMore);
            Assert.AreEqual(expected.synonyms.Length, result.synonyms.Length);
            Assert.IsTrue(result.synonyms.Contains("synonymB"));
            Assert.IsTrue(result.synonyms.Contains("synonymC"));
            Assert.IsTrue(result.synonyms.Contains("synonymD"));
            #endregion

            #region show more "synonymB"
            postParametersAll.word = "synonymB";
            postParametersAll.skip = 0;
            postParametersAll.retrievedList = new string[] { "synonymA", "synonymC" };
            postParametersAll.getAll = false;
            postParametersAll.myCollection = new string[][] { new string[] { "synonymA", "synonymB" }, new string[] { "synonymB", "synonymC" }, new string[] { "synonymC", "synonymD" }, new string[] { "synonymE", "synonymF" } };

            // Act
            result = controller.Post(postParametersAll);
            expected = new SynonymsListAll();
            expected.synonyms = new string[] { "synonymA", "synonymC", "synonymD" };
            expected.hasMore = false;
            // Assert
            Assert.AreEqual(expected.hasMore, result.hasMore);
            Assert.AreEqual(expected.synonyms.Length, result.synonyms.Length);
            Assert.IsTrue(result.synonyms.Contains("synonymA"));
            Assert.IsTrue(result.synonyms.Contains("synonymC"));
            Assert.IsTrue(result.synonyms.Contains("synonymD"));
            #endregion

            #region show all "synonymB"
            postParametersAll.word = "synonymB";
            postParametersAll.skip = 0;
            postParametersAll.retrievedList = new string[] { "synonymA", "synonymC" };
            postParametersAll.getAll = true;
            postParametersAll.myCollection = new string[][] { new string[] { "synonymA", "synonymB" }, new string[] { "synonymB", "synonymC" }, new string[] { "synonymC", "synonymD" }, new string[] { "synonymE", "synonymF" } };

            // Act
            result = controller.Post(postParametersAll);
            expected = new SynonymsListAll();
            expected.synonyms = new string[] { "synonymA", "synonymC", "synonymD" };
            expected.hasMore = false;
            // Assert
            Assert.AreEqual(expected.hasMore, result.hasMore);
            Assert.AreEqual(expected.synonyms.Length, result.synonyms.Length);
            Assert.IsTrue(result.synonyms.Contains("synonymA"));
            Assert.IsTrue(result.synonyms.Contains("synonymC"));
            Assert.IsTrue(result.synonyms.Contains("synonymD"));
            #endregion
        }
    }
}
