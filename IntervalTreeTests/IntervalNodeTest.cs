using IntervalTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IntervalTreeTests
{
    
    
    /// <summary>
    ///This is a test class for IntervalNodeTest and is intended
    ///to contain all IntervalNodeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IntervalNodeTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


/// <summary>
///A test for IntervalNode`1 Constructor
///</summary>
public void IntervalNodeConstructorTestHelper<T>()
    where T : struct 
{
    Interval<long> interval = new Interval<long>(); // TODO: Initialize to an appropriate value
    IntervalNode<long> target = new IntervalNode<long>(interval);
    Assert.Inconclusive("TODO: Implement code to verify target");
}

[TestMethod()]
public void IntervalNodeConstructorTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call IntervalNodeConstructorTestHelper<T>() with appropriate type paramet" +
            "ers.");
}

/// <summary>
///A test for CompareTo
///</summary>
public void CompareToTestHelper<T>()
    where T : struct 
{
    Interval<long> interval = new Interval<long>(); // TODO: Initialize to an appropriate value
    IntervalNode<long> target = new IntervalNode<long>(interval); // TODO: Initialize to an appropriate value
    IntervalNode<long> other = null; // TODO: Initialize to an appropriate value
int expected = 0; // TODO: Initialize to an appropriate value
    int actual;
    actual = target.CompareTo(other);
    Assert.AreEqual(expected, actual);
    Assert.Inconclusive("Verify the correctness of this test method.");
}

[TestMethod()]
public void CompareToTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call CompareToTestHelper<T>() with appropriate type parameters.");
}

/// <summary>
///A test for RecalculateMaxEnd
///</summary>
public void RecalculateMaxEndTestHelper<T>()
    where T : struct 
{
Interval<T> interval = new Interval<T>(); // TODO: Initialize to an appropriate value
IntervalNode<T> target = new IntervalNode<T>(interval); // TODO: Initialize to an appropriate value
    target.RecalculateMaxEnd();
    Assert.Inconclusive("A method that does not return a value cannot be verified.");
}

[TestMethod()]
public void RecalculateMaxEndTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call RecalculateMaxEndTestHelper<T>() with appropriate type parameters.");
}

/// <summary>
///A test for Color
///</summary>
public void ColorTestHelper<T>()
    where T : struct 
{
    Interval<long> interval = new Interval<long>(); // TODO: Initialize to an appropriate value
    IntervalNode<long> target = new IntervalNode<long>(interval); // TODO: Initialize to an appropriate value
NodeColor expected = new NodeColor(); // TODO: Initialize to an appropriate value
    NodeColor actual;
    target.Color = expected;
    actual = target.Color;
    Assert.AreEqual(expected, actual);
    Assert.Inconclusive("Verify the correctness of this test method.");
}

[TestMethod()]
public void ColorTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call ColorTestHelper<T>() with appropriate type parameters.");
}

/// <summary>
///A test for GrandParent
///</summary>
public void GrandParentTestHelper<T>()
    where T : struct 
{
    Interval<long> interval = new Interval<long>(); // TODO: Initialize to an appropriate value
    IntervalNode<long> target = new IntervalNode<long>(interval); // TODO: Initialize to an appropriate value
    IntervalNode<long> actual;
    actual = target.GrandParent;
    Assert.Inconclusive("Verify the correctness of this test method.");
}

[TestMethod()]
public void GrandParentTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call GrandParentTestHelper<T>() with appropriate type parameters.");
}

/// <summary>
///A test for IsLeaf
///</summary>
public void IsLeafTestHelper<T>()
    where T : struct 
{
    Interval<long> interval = new Interval<long>(); // TODO: Initialize to an appropriate value
    IntervalNode<long> target = new IntervalNode<long>(interval); // TODO: Initialize to an appropriate value
    bool actual;
    actual = target.IsLeaf;
    Assert.Inconclusive("Verify the correctness of this test method.");
}

[TestMethod()]
public void IsLeafTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call IsLeafTestHelper<T>() with appropriate type parameters.");
}

/// <summary>
///A test for IsRoot
///</summary>
public void IsRootTestHelper<T>()
    where T : struct 
{
    Interval<long> interval = new Interval<long>(); // TODO: Initialize to an appropriate value
    IntervalNode<long> target = new IntervalNode<long>(interval); // TODO: Initialize to an appropriate value
    bool actual;
    actual = target.IsRoot;
    Assert.Inconclusive("Verify the correctness of this test method.");
}

[TestMethod()]
public void IsRootTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call IsRootTestHelper<T>() with appropriate type parameters.");
}

/// <summary>
///A test for Left
///</summary>
public void LeftTestHelper<T>()
    where T : struct 
{
    Interval<long> interval = new Interval<long>(); // TODO: Initialize to an appropriate value
    IntervalNode<long> target = new IntervalNode<long>(interval); // TODO: Initialize to an appropriate value
    IntervalNode<long> expected = null; // TODO: Initialize to an appropriate value
    IntervalNode<long> actual;
    target.Left = expected;
    actual = target.Left;
    Assert.AreEqual(expected, actual);
    Assert.Inconclusive("Verify the correctness of this test method.");
}

[TestMethod()]
public void LeftTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call LeftTestHelper<T>() with appropriate type parameters.");
}

/// <summary>
///A test for MaxEnd
///</summary>
public void MaxEndTestHelper<T>()
    where T : struct 
{
Interval<T> interval = new Interval<T>(); // TODO: Initialize to an appropriate value
IntervalNode<T> target = new IntervalNode<T>(interval); // TODO: Initialize to an appropriate value
T expected = new T(); // TODO: Initialize to an appropriate value
    T actual;
    target.MaxEnd = expected;
    actual = target.MaxEnd;
    Assert.AreEqual(expected, actual);
    Assert.Inconclusive("Verify the correctness of this test method.");
}

[TestMethod()]
public void MaxEndTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call MaxEndTestHelper<T>() with appropriate type parameters.");
}

/// <summary>
///A test for Parent
///</summary>
public void ParentTestHelper<T>()
    where T : struct 
{
Interval<T> interval = new Interval<T>(); // TODO: Initialize to an appropriate value
IntervalNode<T> target = new IntervalNode<T>(interval); // TODO: Initialize to an appropriate value
IntervalNode<T> expected = null; // TODO: Initialize to an appropriate value
    IntervalNode<T> actual;
    target.Parent = expected;
    actual = target.Parent;
    Assert.AreEqual(expected, actual);
    Assert.Inconclusive("Verify the correctness of this test method.");
}

[TestMethod()]
public void ParentTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call ParentTestHelper<T>() with appropriate type parameters.");
}

/// <summary>
///A test for ParentDirection
///</summary>
public void ParentDirectionTestHelper<T>()
    where T : struct 
{
Interval<T> interval = new Interval<T>(); // TODO: Initialize to an appropriate value
IntervalNode<T> target = new IntervalNode<T>(interval); // TODO: Initialize to an appropriate value
    NodeDirection actual;
    actual = target.ParentDirection;
    Assert.Inconclusive("Verify the correctness of this test method.");
}

[TestMethod()]
public void ParentDirectionTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call ParentDirectionTestHelper<T>() with appropriate type parameters.");
}

/// <summary>
///A test for Right
///</summary>
public void RightTestHelper<T>()
    where T : struct 
{
Interval<T> interval = new Interval<T>(); // TODO: Initialize to an appropriate value
IntervalNode<T> target = new IntervalNode<T>(interval); // TODO: Initialize to an appropriate value
IntervalNode<T> expected = null; // TODO: Initialize to an appropriate value
    IntervalNode<T> actual;
    target.Right = expected;
    actual = target.Right;
    Assert.AreEqual(expected, actual);
    Assert.Inconclusive("Verify the correctness of this test method.");
}

[TestMethod()]
public void RightTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call RightTestHelper<T>() with appropriate type parameters.");
}

/// <summary>
///A test for Sibling
///</summary>
public void SiblingTestHelper<T>()
    where T : struct 
{
Interval<T> interval = new Interval<T>(); // TODO: Initialize to an appropriate value
IntervalNode<T> target = new IntervalNode<T>(interval); // TODO: Initialize to an appropriate value
    IntervalNode<T> actual;
    actual = target.Sibling;
    Assert.Inconclusive("Verify the correctness of this test method.");
}

[TestMethod()]
public void SiblingTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call SiblingTestHelper<T>() with appropriate type parameters.");
}

/// <summary>
///A test for Uncle
///</summary>
public void UncleTestHelper<T>()
    where T : struct 
{
Interval<T> interval = new Interval<T>(); // TODO: Initialize to an appropriate value
IntervalNode<T> target = new IntervalNode<T>(interval); // TODO: Initialize to an appropriate value
    IntervalNode<T> actual;
    actual = target.Uncle;
    Assert.Inconclusive("Verify the correctness of this test method.");
}

[TestMethod()]
public void UncleTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call UncleTestHelper<T>() with appropriate type parameters.");
}
    }
}
