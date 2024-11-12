using Pilha;
using NUnit.Framework;

[TestFixture]
public class PilhaTests
{
    private Pilha<int> pilha;

    [SetUp]
    public void Setup()
    {
        pilha = new Pilha<int>();
    }

    [Test]
    public void TestPush()
    {
        pilha.Push(1);
        Assert.That(pilha.Peek(), Is.EqualTo(1));
    }

    [Test]
    public void TestPop()
    {
        pilha.Push(1);
        int result = pilha.Pop();
        Assert.AreEqual(result,1);
    }

    [Test]
    public void TestPushAndPopMultipleItems()
    {
        pilha.Push(1);
        pilha.Push(2);
        pilha.Push(3);

        Assert.That(pilha.Pop(), Is.EqualTo(3));
        Assert.That(pilha.Pop(), Is.EqualTo(2));
        Assert.That(pilha.Pop(), Is.EqualTo(1));
    }

    [Test]
    public void TestPeekReturnsLastPushedItemWithoutRemoving()
    {
        pilha.Push(1);
        pilha.Push(2);

        int topItem = pilha.Peek();
        Assert.That(topItem, Is.EqualTo(2));
        Assert.That(pilha.Count, Is.EqualTo(2));
    }

    [Test]
    public void TestPopOnEmptyStackThrowsException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => pilha.Pop());
        Assert.That(ex.Message, Is.EqualTo("A pilha está vazia. :)"));
    }

    [Test]
    public void TestPeekOnEmptyStackThrowsException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => pilha.Peek());
        Assert.That(ex.Message, Is.EqualTo("A pilha está vazia."));
    }
    [Test]
    public void TestCountAfterPushAndPop()
    {
        Assert.That(pilha.Count, Is.EqualTo(0));

        pilha.Push(1);
        Assert.That(pilha.Count, Is.EqualTo(1));

        pilha.Push(2);
        Assert.That(pilha.Count, Is.EqualTo(2));

        pilha.Pop();
        Assert.That(pilha.Count, Is.EqualTo(1));

        pilha.Pop();
        Assert.That(pilha.Count, Is.EqualTo(0));
    }

    [Test]
    public void TestPushMultipleItemsWithSameValue()
    {
        pilha.Push(5);
        pilha.Push(5);
        pilha.Push(5);

        Assert.That(pilha.Pop(), Is.EqualTo(5));
        Assert.That(pilha.Pop(), Is.EqualTo(5));
        Assert.That(pilha.Pop(), Is.EqualTo(5));
        Assert.That(pilha.Count, Is.EqualTo(0));
    }

    [Test]
    public void TestStackWithDifferentDataTypes()
    {
        var stringPilha = new Pilha<string>();
        stringPilha.Push("Hello");
        stringPilha.Push("World");

        Assert.That(stringPilha.Pop(), Is.EqualTo("World"));
        Assert.That(stringPilha.Pop(), Is.EqualTo("Hello"));
    }

    [Test]
    public void TestStackConsistencyAfterMultiplePushAndPop()
    {
        pilha.Push(1);
        pilha.Push(2);
        pilha.Pop();
        pilha.Push(3);
        pilha.Push(4);
        pilha.Pop();

        Assert.That(pilha.Pop(), Is.EqualTo(3));
        Assert.That(pilha.Pop(), Is.EqualTo(1));
        Assert.That(pilha.Count, Is.EqualTo(0));
    }

    [Test]
    public void TestStackWithLargeNumberOfItems()
    {
        for (int i = 1; i <= 1000; i++)
        {
            pilha.Push(i);
        }

        Assert.That(pilha.Count, Is.EqualTo(1000));

        for (int i = 1000; i > 0; i--)
        {
            Assert.That(pilha.Pop(), Is.EqualTo(i));
        }

        Assert.That(pilha.Count, Is.EqualTo(0));
    }

    [Test]
    public void TestStackWithComplexObjects()
    {
        var objectPilha = new Pilha<TestClass>();
        var obj1 = new TestClass { Id = 1, Name = "Object 1" };
        var obj2 = new TestClass { Id = 2, Name = "Object 2" };

        objectPilha.Push(obj1);
        objectPilha.Push(obj2);

        Assert.That(objectPilha.Pop().Id, Is.EqualTo(2));
        Assert.That(objectPilha.Pop().Id, Is.EqualTo(1));
    }

    [Test]
    public void TestPeekWithComplexObjects()
    {
        var objectPilha = new Pilha<TestClass>();
        var obj = new TestClass { Id = 1, Name = "Object 1" };

        objectPilha.Push(obj);
        Assert.That(objectPilha.Peek().Id, Is.EqualTo(1));
        Assert.That(objectPilha.Count, Is.EqualTo(1));

    }

    [Test]
    public void TestCapacityWithSingleAssert()
    {
        const int maxCapacity = 100_000;

        for (int i = 0; i < maxCapacity; i++)
        {
            pilha.Push(i);
        }

        Assert.That(pilha.Count, Is.EqualTo(maxCapacity));
    }
    
    [TestCase(1, 1)] 
    [TestCase(5, 5)]  
    [TestCase(10, 10)] 
    public void TestPushPop(int valorPush, int valorPop)
    {
        
        pilha.Push(valorPush);

        Assert.That(pilha.Peek(), Is.EqualTo(valorPush));

        var resultadoPop = pilha.Pop();

        Assert.That(resultadoPop, Is.EqualTo(valorPop));
    }


    public class TestClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
