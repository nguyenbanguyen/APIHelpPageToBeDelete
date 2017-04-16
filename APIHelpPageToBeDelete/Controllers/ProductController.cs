using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DemoApi.Models;


namespace DemoApi.Controllers
{
    /// <summary>
    /// Controller demo quản lý hiển thị Products
    /// </summary>
    public class ProductController : ApiController
    {
        Products[] Products = new Products[]
        {
            new Products { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Products { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Products { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M },
        };
        /// <summary>
        /// Lấy array  100 product với id , tên chạy loop 1-100
        /// </summary>
        /// <returns></returns>
        [HttpGet]
       public IEnumerable<Products> Get100Product()
        {
            Products[] LongProduct = new Models.Products[100];
            for(int i=0;i<100;i++)
            {
                LongProduct[i] = new Products { Id = i, Name = "Táo loại " + i, Category = "táo", Price = 10000 };
            }
            return LongProduct;
        }/// <summary>
         /// Trả về array Product dựa vào parameter NumberOfProduct bằng Json ,giới hạn max 9999 để tránh sử dụng tài nguyên quá nhiều
         /// </summary>
         /// <param name="NumberOfProduct"> số lượng sản phẩm</param>
         /// <returns></returns>
        [Route("api/Product/GetProductByAmount/{NumberOfProduct}")]
        [HttpGet]
        public IEnumerable<Products> GetProductByAmount(int NumberOfProduct)
        {
            if (NumberOfProduct <= 9999)
            {
                Products[] LongProduct = new Models.Products[NumberOfProduct];
                for (int i = 0; i < NumberOfProduct; i++)
                {
                    LongProduct[i] = new Products { Id = i, Name = "Cà loại " + i, Category = "Cà", Price = 10000 };
                }
                return LongProduct;
            }
            else return Products;
        }
        /// <summary>
        /// lấy thông tin cuarProduct theo Id( array product khởi tạo có 3 phần từ)
        /// </summary>
        /// <param name="Id">Id của product </param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetProduct(int Id)
        {
            var ProductFound = Products.FirstOrDefault(x => x.Id == Id);
            if (ProductFound == null)
            {
                return NotFound();
            }
            return Ok(ProductFound);
        }
      
    }
}
