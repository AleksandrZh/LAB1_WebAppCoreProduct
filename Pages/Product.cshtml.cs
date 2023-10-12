using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppCoreProduct.Models;

namespace WebAppCoreProduct.Pages
{
    public class ProductModel : PageModel
    {
        public string? MessageRezult { get; private set; }


        public Product Product { get; set; } // Задать вопрос

        //public void OnGet(string name, decimal? price)
        //{
        //    Product = new Product();

        //    if (price == null || price < 0 || string.IsNullOrEmpty(name))
        //    {
        //        IsCorrect = false;
        //        return;
        //    }
        //    Product.Price = price;
        //    Product.Name = name;

        //    var result = price * (decimal?)0.18;
        //    MessageRezult = $"Для товара {name} с ценой {price} скидка получится { result}";



        //}

        public void OnGet()
        {
            MessageRezult = "Для товара можно определить скидку";
        }

        public void OnPost(string name, decimal? price)
        {
            Product = new Product();
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "Переданы некорректные данные. Повторите ввод";
                return;
            }
            var result = price * (decimal?)0.18;
            MessageRezult = $"Для товара {name} с ценой {price} скидка получится {result}";
            Product.Price = price;
            Product.Name = name;
        }

        // Опечатка ProductModel - в методичке
        public void OnPostDiscont(string name, decimal? price, double discont)
        {
            Product = new Product();
            var result = price * (decimal?)discont / 100;
            MessageRezult = $"Для товара {name} с ценой {price} и скидкой {discont}получится {result}";
            Product.Price = price;
            Product.Name = name;

        }

        public void OnPostDiscontManager(string name, decimal? price, double discontm)
        {
            Product = new Product();
            var result = price * (decimal?)discontm / 100;
            MessageRezult = $"Для товара {name} с ценой {price} и скидкой персонального менеджера {discontm}получится {result}";
            Product.Price = price;
            Product.Name = name;

        }

    }
}
