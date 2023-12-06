using NUnit.Framework;

using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestApp.UnitTests
{
    [TestFixture]
    public class PersonTests
    {
        private Person _person;

        [SetUp]
        public void SetUp()
        {
            this._person = new Person();
        }

        [Test]
        public void Test_AddPeople_ReturnsListWithUniquePeople()
        {
            // Arrange
            string[] peopleData = { "Alice A001 25", "Bob B002 30", "Alice A001 35" };

            // Act
            List<Person> resultPeopleList = this._person.AddPeople(peopleData);

            // Assert
            Assert.That(resultPeopleList, Has.Count.EqualTo(2));
            Assert.That(resultPeopleList[0].Name, Is.EqualTo("Alice"));
            Assert.That(resultPeopleList[0].Id, Is.EqualTo("A001"));
            Assert.That(resultPeopleList[0].Age, Is.EqualTo(35));

            Assert.That(resultPeopleList[1].Name, Is.EqualTo("Bob"));
            Assert.That(resultPeopleList[1].Id, Is.EqualTo("B002"));
            Assert.That(resultPeopleList[1].Age, Is.EqualTo(30));
        }

        [Test]
        public void Test_GetByAgeAscending_SortsPeopleByAge()
        {
            // Arrange
            List<Person> people = new List<Person>
            {
                new Person { Name = "Alice", Id = "A001", Age = 25 },
                new Person { Name = "Bob", Id = "B002", Age = 30 },
                new Person { Name = "Charlie", Id = "C003", Age = 20 }
            };

            string expected = $"Charlie with ID: C003 is 20 years old.{Environment.NewLine}Alice with ID: A001 is 25 years old.{Environment.NewLine}Bob with ID: B002 is 30 years old.";

            // Act
            string result = this._person.GetByAgeAscending(people);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
