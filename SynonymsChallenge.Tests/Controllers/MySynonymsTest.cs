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
    public class MySynonymsTest
    {
        [TestMethod]
        public void Post()
        {
            // Arrange
            MySynonymsController controller = new MySynonymsController();

            PostParameters postParameters = new PostParameters();
            #region inserted "synonymA"
            postParameters.word = "synonymA";
            postParameters.myCollection = new string[][] { new string [] { "synonymA", "synonymB" }, new string[] { "synonymB", "synonymC" }, new string[] { "synonymC", "synonymD" }, new string[] { "synonymE", "synonymF" } };

            // Act
            var result = controller.Post(postParameters);
            var expected = new SynonymsList();
            expected.synonyms = new string[] { "synonymB", "synonymC", "synonymD" };
            // Assert
            Assert.AreEqual(expected.synonyms.Length, result.synonyms.Length);
            Assert.IsTrue(result.synonyms.Contains("synonymB"));
            Assert.IsTrue(result.synonyms.Contains("synonymC"));
            Assert.IsTrue(result.synonyms.Contains("synonymD"));
            #endregion

            #region inserted "synonymB"
            postParameters.word = "synonymB";
            postParameters.myCollection = new string[][] { new string[] { "synonymA", "synonymB" }, new string[] { "synonymB", "synonymC" }, new string[] { "synonymC", "synonymD" }, new string[] { "synonymE", "synonymF" } };

            // Act
            result = controller.Post(postParameters);
            expected = new SynonymsList();
            expected.synonyms = new string[] { "synonymA", "synonymC", "synonymD" };
            // Assert
            Assert.AreEqual(expected.synonyms.Length, result.synonyms.Length);
            Assert.IsTrue(result.synonyms.Contains("synonymA"));
            Assert.IsTrue(result.synonyms.Contains("synonymC"));
            Assert.IsTrue(result.synonyms.Contains("synonymD"));
            #endregion

            #region inserted "synonymC"
            postParameters.word = "synonymC";
            postParameters.myCollection = new string[][] { new string[] { "synonymA", "synonymB" }, new string[] { "synonymB", "synonymC" }, new string[] { "synonymC", "synonymD" }, new string[] { "synonymE", "synonymF" } };

            // Act
            result = controller.Post(postParameters);
            expected = new SynonymsList();
            expected.synonyms = new string[] { "synonymA", "synonymB", "synonymD" };
            // Assert
            Assert.AreEqual(expected.synonyms.Length, result.synonyms.Length);
            Assert.IsTrue(result.synonyms.Contains("synonymA"));
            Assert.IsTrue(result.synonyms.Contains("synonymB"));
            Assert.IsTrue(result.synonyms.Contains("synonymD"));
            #endregion

            #region inserted "synonymD"
            postParameters.word = "synonymD";
            postParameters.myCollection = new string[][] { new string[] { "synonymA", "synonymB" }, new string[] { "synonymB", "synonymC" }, new string[] { "synonymC", "synonymD" }, new string[] { "synonymE", "synonymF" } };

            // Act
            result = controller.Post(postParameters);
            expected = new SynonymsList();
            expected.synonyms = new string[] { "synonymA", "synonymB", "synonymC" };
            // Assert
            Assert.AreEqual(expected.synonyms.Length, result.synonyms.Length);
            Assert.IsTrue(result.synonyms.Contains("synonymA"));
            Assert.IsTrue(result.synonyms.Contains("synonymB"));
            Assert.IsTrue(result.synonyms.Contains("synonymC"));
            #endregion

            #region inserted "synonymE"
            postParameters.word = "synonymE";
            postParameters.myCollection = new string[][] { new string[] { "synonymA", "synonymB" }, new string[] { "synonymB", "synonymC" }, new string[] { "synonymC", "synonymD" }, new string[] { "synonymE", "synonymF" } };

            // Act
            result = controller.Post(postParameters);
            expected = new SynonymsList();
            expected.synonyms = new string[] { "synonymF" };
            // Assert
            Assert.AreEqual(expected.synonyms.Length, result.synonyms.Length);
            Assert.IsTrue(result.synonyms.Contains("synonymF"));
            #endregion

            #region inserted "synonymF"
            postParameters.word = "synonymF";
            postParameters.myCollection = new string[][] { new string[] { "synonymA", "synonymB" }, new string[] { "synonymB", "synonymC" }, new string[] { "synonymC", "synonymD" }, new string[] { "synonymE", "synonymF" } };

            // Act
            result = controller.Post(postParameters);
            expected = new SynonymsList();
            expected.synonyms = new string[] { "synonymE" };
            // Assert
            Assert.AreEqual(expected.synonyms.Length, result.synonyms.Length);
            Assert.IsTrue(result.synonyms.Contains("synonymE"));
            #endregion
        }
    }
}
