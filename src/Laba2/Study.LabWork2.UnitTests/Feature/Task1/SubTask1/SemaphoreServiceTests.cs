using NUnit.Framework;
using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

[TestFixture]
public sealed class SemaphoreServiceTests
{
    [Test]
    public void GetVersionName_Should_Return_Correct_String()
    {
        var service = new SemaphoreService();
        Assert.That(service.GetVersionName(), Is.EqualTo("Semaphore"));
    }
}
