using BCGDV.Product;
using BCGDV.Service;

namespace BCGDV.Test.ServiceTest;

public class ProductServiceTest
{
    private readonly ProductService productService;
    private MockData mockData;

    public ProductServiceTest()
    {
        productService = new ProductService();
        mockData = new MockData();
    }

    [Fact]
    public void TestgetProductByIdWithRolexWatchId()
    {
        IProduct product = productService.getProductById(mockData.rolexWatch.getId());

        Assert.Equal(product, mockData.rolexWatch);
    }

    [Fact]
    public void TestgetProductByIdWithMichealKorsWatchId()
    {
        IProduct product = productService.getProductById(mockData.michealKorsWatch.getId());

        Assert.Equal(product, mockData.michealKorsWatch);
    }

    [Fact]
    public void TestgetProductByIdWithSwatchWatchId()
    {
        IProduct product = productService.getProductById(mockData.swatchWatch.getId());

        Assert.Equal(product, mockData.swatchWatch);
    }

    [Fact]
    public void TestgetProductByIdWithCasioWatchId()
    {
        IProduct product = productService.getProductById(mockData.casioWatch.getId());

        Assert.Equal(product, mockData.casioWatch);
    }

    [Theory]
    [InlineData("005")]
    [InlineData("006")]
    [InlineData("007")]
    public void TestgetProductByIdWithInvalidIds(string value)
    {
        Assert.Throws<NotSupportedException>(() => productService.getProductById(value));

    }
}
