using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace HyperCasual.Runner
{
    public class AdderTest
    {
        private Adder adder;

        [Test]
        public void Add_TwoNumber_ReturnsSumOfThem()
        {
            // Arrange
            adder = new Adder();
            float x = 5.0f;
            float y = 3.3f;
            float expectedSum = 8.3f;

            // Act
            float actualSum = adder.Add(x, y);

            // Assert
            Assert.AreEqual(expectedSum, actualSum);
        }

    }

}
