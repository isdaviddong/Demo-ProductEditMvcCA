namespace MvcProductCA.Entities
{
    // Domain/Entities/Product.cs
    //最基本的 Entity
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    // Domain/Interfaces/Services/IProductService.cs
    //定義操作Product的方式
    public interface IProductService
    {
        Product GetById(int id);
        IEnumerable<Product> GetAll();
        void Create(Product product);
        void Update(Product product);
        void Delete(int id);
    }

    // Domain/Interfaces/Repositories/IProductRepository.cs
    //定義存儲Product的方式
    public interface IProductRepository
    {
        Product GetById(int id);
        IEnumerable<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }

    // Domain/Services/ProductService.cs
    //實作操作Product的類別
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        //建立ProductService時，傳入(注入)productRepository，目的是讓productRepository可抽換
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public void Create(Product product)
        {
            // 執行業務邏輯
            _productRepository.Add(product);
        }

        public void Update(Product product)
        {
            //執行業務邏輯
            _productRepository.Update(product);
        }

        public void Delete(int id)
        {
            // 執行業務邏輯
            _productRepository.Delete(id);
        }
    }

}
