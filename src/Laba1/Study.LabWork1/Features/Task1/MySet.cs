using System;
using System.Globalization;

namespace Study.LabWork1.Features.Task1;

public class RgbaPixel
{
    public byte Red { get; }
    public byte Green { get; }
    public byte Blue { get; }
    public double Alpha { get; }

    public RgbaPixel(int r, int g, int b, double a)
    {
        Red = (byte)Math.Clamp(r, 0, 255);
        Green = (byte)Math.Clamp(g, 0, 255);
        Blue = (byte)Math.Clamp(b, 0, 255);
        Alpha = Math.Clamp(a, 0.0, 1.0);
    }

    public override string ToString()
    {
        return $"rgba({Red}, {Green}, {Blue}, {Alpha.ToString("0.0#", CultureInfo.InvariantCulture)})";
    }

    public string ToHex()
    {
        byte aByte = (byte)Math.Round(Alpha * 255);
        return $"#{Red:X2}{Green:X2}{Blue:X2}{aByte:X2}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is not RgbaPixel other) return false;
        return Red == other.Red &&
               Green == other.Green &&
               Blue == other.Blue &&
               Math.Abs(Alpha - other.Alpha) < 0.001;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Red, Green, Blue, Alpha);
    }

    public static RgbaPixel operator +(RgbaPixel x, RgbaPixel y)
    {
        return new RgbaPixel(x.Red + y.Red, x.Green + y.Green, x.Blue + y.Blue, x.Alpha + y.Alpha);
    }

    public static RgbaPixel operator -(RgbaPixel x, RgbaPixel y)
    {
        return new RgbaPixel(x.Red - y.Red, x.Green - y.Green, x.Blue - y.Blue, x.Alpha - y.Alpha);
    }

    public static RgbaPixel operator *(RgbaPixel x, RgbaPixel y)
    {
        return new RgbaPixel(x.Red * y.Red, x.Green * y.Green, x.Blue * y.Blue, x.Alpha * y.Alpha);
    }

    public static RgbaPixel operator *(RgbaPixel x, double num)
    {
        return new RgbaPixel((int)(x.Red * num), (int)(x.Green * num), (int)(x.Blue * num), x.Alpha * num);
    }

    public static RgbaPixel operator /(RgbaPixel x, double num)
    {
        if (Math.Abs(num) < 0.000001) throw new DivideByZeroException();
        return new RgbaPixel((int)(x.Red / num), (int)(x.Green / num), (int)(x.Blue / num), x.Alpha / num);
    }

    public static bool operator ==(RgbaPixel? x, RgbaPixel? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null || y is null) return false;
        return x.Equals(y);
    }

    public static bool operator !=(RgbaPixel? x, RgbaPixel? y)
    {
        return !(x == y);
    }
}
