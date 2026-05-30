using NUnit.Framework;
using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

[TestFixture]
public sealed class MutexServiceTests
{
    [Test]
    public void CountPrimes_Should_Return_Correct_Count()
    {
        var service = new MutexService();
        var res = service.CountPrimes(1, 1000, 2);
        Assert.That(res.PrimeCount, Is.EqualTo(168));
    }
}
