using NUnit.Framework;
using System;

namespace TestApp.UnitTests
{
    [TestFixture]
    public class ArticleTests
    {
        private Article _article;

        [SetUp]
        public void SetUp()
        {
            this._article = new Article();
        }

        [Test]
        public void Test_AddArticles_ReturnsArticleWithCorrectData()
        {
            // Arrange
            string[] articlesData = { "Article Content1 Author1", "Title2 Content2 Author2", "Title3 Content3 Author3" };

            // Act
            Article result = this._article.AddArticles(articlesData);

            // Assert
            Assert.That(result.ArticleList, Has.Count.EqualTo(3));
            Assert.That(result.ArticleList[0].Title, Is.EqualTo("Article"));
            Assert.That(result.ArticleList[1].Content, Is.EqualTo("Content2"));
            Assert.That(result.ArticleList[2].Author, Is.EqualTo("Author3"));
        }

        [Test]
        public void Test_GetArticleList_SortsArticlesByTitle()
        {
            // Arrange
            Article article = new Article();
            article.ArticleList.Add(new Article { Title = "C", Content = "Content3", Author = "Author3" });
            article.ArticleList.Add(new Article { Title = "A", Content = "Content1", Author = "Author1" });
            article.ArticleList.Add(new Article { Title = "B", Content = "Content2", Author = "Author2" });

            string expected = $"A - Content1: Author1{Environment.NewLine}B - Content2: Author2{Environment.NewLine}C - Content3: Author3";

            // Act
            string result = this._article.GetArticleList(article, "title");

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
        {
            // Arrange
            Article article = new Article();

            // Act
            string result = this._article.GetArticleList(article, "invalidCriteria");

            // Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }
    }
}
