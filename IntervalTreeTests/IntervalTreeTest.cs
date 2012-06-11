using IntervalTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections;

namespace IntervalTreeTests
{
    
    
    /// <summary>
    ///This is a test class for IntervalTreeTest and is intended
    ///to contain all IntervalTreeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IntervalTreeTest
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
///A test for IntervalTree`1 Constructor
///</summary>
public void IntervalTreeConstructorTestHelper<T>()
    where T : struct 
{
    IntervalTree<long> target = new IntervalTree<long>();
    Assert.Inconclusive("TODO: Implement code to verify target");
}

[TestMethod()]
public void IntervalTreeConstructorTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call IntervalTreeConstructorTestHelper<T>() with appropriate type paramet" +
            "ers.");
}

/// <summary>
///A test for Add
///</summary>
public void AddTestHelper<T>()
    where T : struct 
{
    IntervalTree<long> target = new IntervalTree<long>(); // TODO: Initialize to an appropriate value
    Interval<long> interval = new Interval<long>(); // TODO: Initialize to an appropriate value
    target.Add(interval);
    Assert.Inconclusive("A method that does not return a value cannot be verified.");
}

[TestMethod()]
public void AddTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call AddTestHelper<T>() with appropriate type parameters.");
}

/// <summary>
///A test for ApplyTreeConstraints
///</summary>
public void ApplyTreeConstraintsTestHelper<T>()
    where T : struct 
{
    // Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSymbols.Assembly' failed
    Assert.Inconclusive("Creation of the private accessor for \'Microsoft.VisualStudio.TestTools.TypesAndSy" +
            "mbols.Assembly\' failed");
}

[TestMethod()]
[DeploymentItem("IntervalTree.dll")]
public void ApplyTreeConstraintsTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call ApplyTreeConstraintsTestHelper<T>() with appropriate type parameters" +
            ".");
}

/// <summary>
///A test for GetEnumerator
///</summary>
public void GetEnumeratorTestHelper<T>()
    where T : struct 
{
IntervalTree<T> target = new IntervalTree<T>(); // TODO: Initialize to an appropriate value
IEnumerator<Interval<long>> expected = null; // TODO: Initialize to an appropriate value
IEnumerator<Interval<long>> actual;
    actual = target.GetEnumerator();
    Assert.AreEqual(expected, actual);
    Assert.Inconclusive("Verify the correctness of this test method.");
}

[TestMethod()]
public void GetEnumeratorTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call GetEnumeratorTestHelper<T>() with appropriate type parameters.");
}

/// <summary>
///A test for InOrderWalk
///</summary>
public void InOrderWalkTestHelper<T>()
    where T : struct 
{
    // Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSymbols.Assembly' failed
    Assert.Inconclusive("Creation of the private accessor for \'Microsoft.VisualStudio.TestTools.TypesAndSy" +
            "mbols.Assembly\' failed");
}

[TestMethod()]
[DeploymentItem("IntervalTree.dll")]
public void InOrderWalkTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call InOrderWalkTestHelper<T>() with appropriate type parameters.");
}

/// <summary>
///A test for InsertInterval
///</summary>
public void InsertIntervalTestHelper<T>()
    where T : struct 
{
    // Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSymbols.Assembly' failed
    Assert.Inconclusive("Creation of the private accessor for \'Microsoft.VisualStudio.TestTools.TypesAndSy" +
            "mbols.Assembly\' failed");
}

[TestMethod()]
[DeploymentItem("IntervalTree.dll")]
public void InsertIntervalTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call InsertIntervalTestHelper<T>() with appropriate type parameters.");
}

/// <summary>
///A test for RotateLeft
///</summary>
public void RotateLeftTestHelper<T>()
    where T : struct 
{
    // Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSymbols.Assembly' failed
    Assert.Inconclusive("Creation of the private accessor for \'Microsoft.VisualStudio.TestTools.TypesAndSy" +
            "mbols.Assembly\' failed");
}

[TestMethod()]
[DeploymentItem("IntervalTree.dll")]
public void RotateLeftTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call RotateLeftTestHelper<T>() with appropriate type parameters.");
}

/// <summary>
///A test for RotateRight
///</summary>
public void RotateRightTestHelper<T>()
    where T : struct 
{
    // Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSymbols.Assembly' failed
    Assert.Inconclusive("Creation of the private accessor for \'Microsoft.VisualStudio.TestTools.TypesAndSy" +
            "mbols.Assembly\' failed");
}

[TestMethod()]
[DeploymentItem("IntervalTree.dll")]
public void RotateRightTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call RotateRightTestHelper<T>() with appropriate type parameters.");
}

/// <summary>
///A test for System.Collections.IEnumerable.GetEnumerator
///</summary>
public void GetEnumeratorTest1Helper<T>()
    where T : struct 
{
IEnumerable target = new IntervalTree<T>(); // TODO: Initialize to an appropriate value
IEnumerator expected = null; // TODO: Initialize to an appropriate value
    IEnumerator actual;
    actual = target.GetEnumerator();
    Assert.AreEqual(expected, actual);
    Assert.Inconclusive("Verify the correctness of this test method.");
}

[TestMethod()]
[DeploymentItem("IntervalTree.dll")]
public void GetEnumeratorTest1()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call GetEnumeratorTest1Helper<T>() with appropriate type parameters.");
}

/// <summary>
///A test for Root
///</summary>
public void RootTestHelper<T>()
    where T : struct 
{
    // Creation of the private accessor for 'Microsoft.VisualStudio.TestTools.TypesAndSymbols.Assembly' failed
    Assert.Inconclusive("Creation of the private accessor for \'Microsoft.VisualStudio.TestTools.TypesAndSy" +
            "mbols.Assembly\' failed");
}

[TestMethod()]
[DeploymentItem("IntervalTree.dll")]
public void RootTest()
{
    Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
            "Please call RootTestHelper<T>() with appropriate type parameters.");
}
    }
}
