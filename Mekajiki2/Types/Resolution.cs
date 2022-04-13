namespace Mekajiki2.Types;

public struct Resolution
{
    public Resolution(uint width, uint height)
    {
        Width = width;
        Height = height;
    }
    public uint Width { get; set; }
    
    public uint Height { get; set; }
}