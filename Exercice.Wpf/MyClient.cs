using Exercice.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Exercice.Wpf
{
    public class MyClient
    {
        HttpClient _myClient = new HttpClient();
        private string url = "https://localhost:7120/api/";

        // GetByIdUser
        public async Task<UserDto> GetById(string idShow)
        {
            var request = await _myClient.GetFromJsonAsync<UserDto>(url + idShow);
            return request;
        }


        // GetAllUser
        public async Task<IEnumerable<UserDto>> GetAllUser()
        {
            string urlTotal = "User";

            var request = await _myClient.GetFromJsonAsync<IEnumerable<UserDto>>(url + urlTotal);

            return request;
        }

        //Post User
        public async Task<HttpResponseMessage> PostUser(UserDto userDto)
        {
            string urlTotal = url + "User";
            var content = await _myClient.PostAsJsonAsync<UserDto>(urlTotal, userDto);
            return content;
        }

        //Delete User
        public async Task<string> DeleteUserById(string idDelete)
        {
            string urlTotal = url + "User/" + idDelete;
            var content = await _myClient.DeleteAsync(urlTotal);
            return content.ToString();
        }

        //Update User
        public async Task<string> UpdateUserById(UserDto updateDto, string idUpdate)
        {
            string urlTotal = url + "User/" + idUpdate;
            var content = await _myClient.PutAsJsonAsync<UserDto>(urlTotal, updateDto);
            return content.ToString();
        }



        // GetAllOrder
        public async Task<IEnumerable<OrderDto>> GetAllOrder()
        {
            string urlTotal = "Order";

            var request = await _myClient.GetFromJsonAsync<IEnumerable<OrderDto>>(url + urlTotal);

            return request;
        }

        // Post Order
        public async Task<HttpResponseMessage> PostOrder(OrderDto orderDto)
        {
            string urlTotal = url + "Order";
            var content = await _myClient.PostAsJsonAsync<OrderDto>(urlTotal, orderDto);
            return content;
        }


        //Delete Order
        public async Task<string> DeleteOrderById(string idDelete)
        {
            string urlTotal = url + "Order/" + idDelete;
            var content = await _myClient.DeleteAsync(urlTotal);
            return content.ToString();
        }

        //Update Order
        public async Task<string> UpdateOrderById(OrderDto updateDto, string idUpdate)
        {
            string urlTotal = url + "Order/" + idUpdate;
            var content = await _myClient.PutAsJsonAsync<OrderDto>(urlTotal, updateDto);
            return content.ToString();
        }



        // GetAllProduct
        public async Task<IEnumerable<ProductDto>> GetAllProduct()
        {
            string urlTotal = "Product";

            var request = await _myClient.GetFromJsonAsync<IEnumerable<ProductDto>>(url + urlTotal);

            return request;
        }


        //Post Product
        public async Task<HttpResponseMessage> PostProduct(ProductDto productDto)
        {
            string urlTotal = url + "Product";
            var content = await _myClient.PostAsJsonAsync<ProductDto>(urlTotal, productDto);
            return content;
        }

        //Delete Product
        public async Task<string> DeleteProductById(string idDelete)
        {
            string urlTotal = url + "Product/" + idDelete;
            var content = await _myClient.DeleteAsync(urlTotal);
            return content.ToString();
        }

        //Update Product
        public async Task<string> UpdateProductById(ProductDto updateDto, string idUpdate)
        {
            string urlTotal = url + "Product/" + idUpdate;
            var content = await _myClient.PutAsJsonAsync<ProductDto>(urlTotal, updateDto);
            return content.ToString();
        }
    }
}

