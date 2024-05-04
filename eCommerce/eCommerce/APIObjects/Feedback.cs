namespace eCommerce.APIObjects;

public class ApiFeedback
{
    public int ProductId { get; set; }
    public string? FeedbackText { get; set; }
    public double Mark { get; set; }
}