using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryAC.Data.Entities;
namespace Library.Tests
{
    [TestClass]
    public class ScoreServiceTests
    {
        public IScoreService _scoreService;

        [TestInitialize]
        public void Init()
        {
            _scoreService = new ScoreService();
        }
        [TestMethod]
        public void ComputeScore_BookTypeSFScore5UserScore1_ShouldBe51()
        {
            //Arrange
            var book = new Book()
            {
                Type = "SF",
                Score = 5
            };

            const int userScore = 1;

            //Act
            int result = _scoreService.ComputeScore(book, userScore);

            //Assert
            Assert.AreEqual(51, result);
        }


        [TestMethod]
        public void ComputeScore_BookTypeSFScore2UserScore0_ShouldBe20()
        {
            //Arrange
            var book = new Book()
            {
                Type = "SF",
                Score = 2
            };

            const int userScore = 0;

            //Act
            int result = _scoreService.ComputeScore(book, userScore);

            //Assert
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void ComputeScore_BookScore2UserScore1_ShouldBe3()
        {
            //Arrange
            var book = new Book()
            {
              
                Score = 2
            };

            const int userScore = 1;

            //Act
            int result = _scoreService.ComputeScore(book, userScore);

            //Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void ComputeScore_BookScore2UserScore0_ShouldBe2()
        {
            //Arrange
            var book = new Book()
            {

                Score = 2
            };

            const int userScore = 0;

            //Act
            int result = _scoreService.ComputeScore(book, userScore);

            //Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void ComputeScore_BookTypeKidsScore5UserScore1_ShouldBe11()
        {
            //Arrange
            var book = new Book()
            {
                Type = "Kids",
                Score = 5
            };

            const int userScore = 1;

            //Act
            int result = _scoreService.ComputeScore(book, userScore);

            //Assert
            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void ComputeScore_BookTypeKidsScore5UserScore0_ShouldBe10()
        {
            //Arrange
            var book = new Book()
            {
                Type = "Kids",
                Score = 5
            };

            const int userScore = 0;

            //Act
            int result = _scoreService.ComputeScore(book, userScore);

            //Assert
            Assert.AreEqual(10, result);
        }
    }

    internal class ScoreService : IScoreService
    {
        public int ComputeScore(Book book, int userScore)
        {
            if (book.Type == "SF")
            {
                return 10 * book.Score + userScore;
            }
            else if(book.Type=="Kids")
            {
                return 2 * book.Score + userScore;
            }
            return book.Score+userScore;
        }
    }

    public interface IScoreService
    {
        int ComputeScore(Book book, int userScore);
    }
}