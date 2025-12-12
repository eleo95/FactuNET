namespace TestLayer
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Invoice>>();

            var service = new InvoiceService(mockRepo.Object);

            var client = new Client { Id = 1 };

            var productA = new Product { Id = 10, Price = 50m };
            var productB = new Product { Id = 20, Price = 100m };

            var lines = new List<(Product product, int qty)>
        {
            (productA, 2), // total: 100
            (productB, 1)  // total: 100
        };

            decimal taxRate = 0.13m;
        }
    }
}