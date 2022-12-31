using Codecoverage;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace CodeCoverage.Test
{
    [ExcludeFromCodeCoverage]
    public class MyArrayTests
    {
        [Fact]
        public void MyArray_Should_ReplaceValue_When_PositionIsValid()
        {
            var arr = new MyArray(5);
            var result = arr.Replace(2, 99);

            Assert.True(result);
            Assert.Equal(99, arr.Array[2]);
        }

        [Fact]
        public void MyArray_Should_ThrowException_When_PositionIsLessThanZero()
        {
            var arr = new MyArray(5);
            Assert.Throws<ArgumentException>(() => arr.Replace(-8, 0));
        }
    }
}
