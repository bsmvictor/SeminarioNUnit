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

    /// Verifica se o método Push adiciona um item corretamente no topo da pilha.
    [Test]
    public void TestPush()
    {
        pilha.Push(1);
        Assert.That(pilha.Peek(), Is.EqualTo(1));
    }

    /// Verifica se o método Pop remove e retorna o item do topo da pilha corretamente.
    [Test]
    public void TestPop()
    {
        pilha.Push(1);
        int result = pilha.Pop();
        Assert.That(result, Is.EqualTo(1));
    }

    /// Testa a adição e remoção de múltiplos itens, garantindo que eles saem na ordem inversa da inserção.
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

    /// Verifica se o método Peek retorna o item do topo sem removê-lo da pilha.
    [Test]
    public void TestPeekReturnsLastPushedItemWithoutRemoving()
    {
        pilha.Push(1);
        pilha.Push(2);

        int topItem = pilha.Peek();
        Assert.That(topItem, Is.EqualTo(2));
        Assert.That(pilha.Count, Is.EqualTo(2)); // Verifica que o item não foi removido
    }

    /// Garante que o método Pop lança uma exceção quando a pilha está vazia.
    [Test]
    public void TestPopOnEmptyStackThrowsException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => pilha.Pop());
        Assert.That(ex.Message, Is.EqualTo("A pilha está vazia."));
    }

    [Test]
    public void TestPeekOnEmptyStackThrowsException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => pilha.Peek());
        Assert.That(ex.Message, Is.EqualTo("A pilha está vazia."));
    }

    /// Testa se a propriedade Count atualiza corretamente após operações de Push e Pop
    [Test]
    public void TestCountAfterPushAndPop()
    {
        Assert.That(pilha.Count, Is.EqualTo(0)); // Pilha vazia inicialmente

        pilha.Push(1);
        Assert.That(pilha.Count, Is.EqualTo(1));

        pilha.Push(2);
        Assert.That(pilha.Count, Is.EqualTo(2));

        pilha.Pop();
        Assert.That(pilha.Count, Is.EqualTo(1));

        pilha.Pop();
        Assert.That(pilha.Count, Is.EqualTo(0));
    }

    /// Testa a adição de múltiplos itens do mesmo valor
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

    /// Testa o comportamento da pilha com tipos de dados diferentes
    [Test]
    public void TestStackWithDifferentDataTypes()
    {
        var stringPilha = new Pilha<string>();
        stringPilha.Push("Hello");
        stringPilha.Push("World");

        Assert.That(stringPilha.Pop(), Is.EqualTo("World"));
        Assert.That(stringPilha.Pop(), Is.EqualTo("Hello"));
    }

    /// Testa se a pilha permanece consistente após várias operações intercaladas de Push e Pop
    [Test]
    public void TestStackConsistencyAfterMultiplePushAndPop()
    {
        pilha.Push(1);
        pilha.Push(2);
        pilha.Pop();      // Remove 2
        pilha.Push(3);
        pilha.Push(4);
        pilha.Pop();      // Remove 4

        Assert.That(pilha.Pop(), Is.EqualTo(3));
        Assert.That(pilha.Pop(), Is.EqualTo(1));
        Assert.That(pilha.Count, Is.EqualTo(0));
    }

    /// Testa a consistência do estado da pilha quando inserido e removido um grande número de itens
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

    /// Testa o comportamento do Pop com itens complexos (objetos)
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

    /// Testa o comportamento do Peek com objetos sem removê-los
    [Test]
    public void TestPeekWithComplexObjects()
    {
        var objectPilha = new Pilha<TestClass>();
        var obj = new TestClass { Id = 1, Name = "Object 1" };

        objectPilha.Push(obj);
        Assert.That(objectPilha.Peek().Id, Is.EqualTo(1));
        Assert.That(objectPilha.Count, Is.EqualTo(1));  // Garante que o item não foi removido
    }

    /// Classe de teste auxiliar
    public class TestClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
