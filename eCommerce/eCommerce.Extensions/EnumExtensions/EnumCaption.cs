namespace eCommerce.Extensions.EnumExtensions;

public class CaptionAttribute : Attribute
{
    public string Caption { get; set; }
    
    public CaptionAttribute(string caption)
    {
        Caption = caption;
    }
}