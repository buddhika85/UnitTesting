﻿namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Fundamentals.Stack<object> _stack;

        [SetUp]
        public void Setup()
        {
            _stack = new Fundamentals.Stack<object>();
        }

        [Test]
        public void Push_PassNull_ThrowsArgumentNullExceptionCountZero()
        {
            // arrange
            // was done in setup

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => _stack.Push(null));
        }

        [Test]
        [TestCase(1)]
        [TestCase(1.0)]
        [TestCase(true)]
        [TestCase('a')]
        [TestCase("A")]
        public void Push_WhenCalledWithObjs_IncreasesCount(object element)
        {
            // arrange
            var prevSize = _stack.Count;

            // act
            _stack.Push(element);

            // assert
            Assert.That(_stack.Count, Is.EqualTo(++prevSize));
        }

        [Test]
        public void Pop_CountZero_ThrowsInvalidOperationException()
        {
            // arrange
            // was done in setup


            // act and assert
            Assert.Throws<InvalidOperationException>(() => _stack.Pop());
        }


        [Test]
        public void Pop_CountOne_ReturnsIndexZeroObjCountZero()
        {
            // arrange
            var inputObj = new object();
            _stack.Push(inputObj);

            // act
            var poppedObj = _stack.Pop();

            // assert
            Assert.That(poppedObj, Is.SameAs(inputObj));
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Peek_WhenCountZero_ThrowsInvalidOperationException()
        {
            // arrange
            // was done in setup

            // act
            // assert
            Assert.Throws<InvalidOperationException>(() => _stack.Pop());
        }


        [Test]
        public void Peek_WhenCountNotZero_ReturnTopCountDoNotChange()
        {
            // arrange
            var inputObj = new object();
            _stack.Push(inputObj);
            var count = _stack.Count;

            // act
            var peekedObj = _stack.Peek();

            // assert
            Assert.That(peekedObj, Is.SameAs(inputObj));
            Assert.That(count, Is.EqualTo(count));
        }
    }
}
