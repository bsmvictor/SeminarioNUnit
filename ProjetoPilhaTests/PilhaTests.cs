using Pilha;

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
        Assert.That(ex.Message, Is.EqualTo("A pilha está vazia :(."));
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
}
