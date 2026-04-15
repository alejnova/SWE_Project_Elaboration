using System;
using Xunit;
using ADHD_Software_Engineering.Models;

namespace ADHD_Software_Engineering.Tests
{
    public class FocusSessionTests
    {
        [Fact]
        public void AddDistraction_AddsToList()
        {
            // Arrange
            var session = new FocusSession();

            // Act
            session.AddDistraction("checked phone");

            // Assert
            Assert.Single(session.Distractions);
            Assert.Equal("checked phone", session.Distractions[0].Note);
        }

        [Fact]
        public void AddDistraction_SetsTimestamp()
        {
            // Arrange
            var session = new FocusSession();
            var before = DateTime.Now;

            // Act
            session.AddDistraction("heard a noise");

            // Assert
            Assert.True(session.Distractions[0].LoggedAt >= before);
            Assert.True(session.Distractions[0].LoggedAt <= DateTime.Now);
        }

        [Fact]
        public void AddDistraction_MultipleDistractions_AllAppended()
        {
            // Arrange
            var session = new FocusSession();

            // Act
            session.AddDistraction("checked phone");
            session.AddDistraction("someone knocked");
            session.AddDistraction("got thirsty");

            // Assert
            Assert.Equal(3, session.Distractions.Count);
        }

        [Fact]
        public void AddDistraction_EmptyNote_StillAdds()
        {
            // Arrange
            var session = new FocusSession();

            // Act
            session.AddDistraction(string.Empty);

            // Assert
            Assert.Single(session.Distractions);
        }
    }
}