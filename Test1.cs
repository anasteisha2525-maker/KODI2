using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestVariant7()
    {
        // Вхідні дані
        int[] array =
        {
            -5, 3, -8, 0, 7, 0, -2
        };

        // Створення об'єкта класу
        ArrayProcessor processor = new ArrayProcessor();

        // 1. Перевірка максимального за модулем елемента
        int maxAbsElement = processor.MaxAbsElement(array);

        Assert.AreEqual(-8, maxAbsElement);

        // 2. Перевірка суми елементів після останнього нульового
        bool hasZero = processor.TrySumAfterLastZero(
            array,
            out long sum
        );

        Assert.IsTrue(hasZero);

        Assert.AreEqual(-2L, sum);
    }
}