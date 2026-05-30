using NUnit.Framework;
using Study.LabWork2.Feature.Task1.SubTask2;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask2;

[TestFixture]
public sealed class NumberSetProcessorTests
{
    [Test]
    public void Process_Should_Handle_Exactly_12_Sets()
    {
        var processor = new NumberSetProcessor();
        var res = processor.GetResult();
        Assert.That(res.ProcessedSetsCount, Is.EqualTo(12));
        Assert.That(res.Results.Count, Is.EqualTo(12));
    }

    [Test]
    public void Process_Should_Calculate_Total_Sum()
    {
        var processor = new NumberSetProcessor();
        var res = processor.GetResult();
        Assert.That(res.TotalSum, Is.GreaterThan(0));
    }
}
