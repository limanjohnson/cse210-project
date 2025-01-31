namespace OnlineOrdering;

public class Product
{
    private string _productName;
    private double _productPrice;
    private int _productQuantity;
    private int _productId;

    public Product(string productName, double productPrice, int productQuantity, int productId)
    {
        _productName = productName;
        _productPrice = productPrice;
        _productQuantity = productQuantity;
        _productId = productId;
    }

    public double GetTotalCost()
    {
        return _productPrice * _productQuantity;
    }

    public string GetProductLabel()
    {
        return $"{_productName} - (ID: {_productId})";
    }
    
}