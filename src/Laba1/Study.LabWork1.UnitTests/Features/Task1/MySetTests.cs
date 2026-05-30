using NUnit.Framework;
using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.UnitTests.Features.Task1;

[TestFixture]
internal class RgbaPixelTests
{
    [Test]
    public void Constructor_Should_Clamp_Values()
    {
        var p = new RgbaPixel(300, -50, 100, 1.5);
        Assert.That(p.Red, Is.EqualTo(255));
        Assert.That(p.Green, Is.EqualTo(0));
        Assert.That(p.Blue, Is.EqualTo(100));
        Assert.That(p.Alpha, Is.EqualTo(1.0));
    }

    [Test]
    public void Plus_Should_Add_Pixels()
    {
        var a = new RgbaPixel(100, 100, 100, 0.2);
        var b = new RgbaPixel(100, 100, 100, 0.3);
        var res = a + b;
        Assert.That(res.Red, Is.EqualTo(200));
        Assert.That(res.Alpha, Is.EqualTo(0.5).Within(0.001));
    }

    [Test]
    public void ToHex_Should_Be_Correct()
    {
        var p = new RgbaPixel(255, 0, 128, 1.0);
        Assert.That(p.ToHex(), Is.EqualTo("#FF0080FF"));
    }
}
