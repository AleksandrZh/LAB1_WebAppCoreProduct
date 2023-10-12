using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppCoreProduct.Models;

namespace WebAppCoreProduct.Pages
{
    public class ProductModel : PageModel
    {
        public string? MessageRezult { get; private set; }


        public Product Product { get; set; } // ������ ������

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
        //    MessageRezult = $"��� ������ {name} � ����� {price} ������ ��������� { result}";



        //}

        public void OnGet()
        {
            MessageRezult = "��� ������ ����� ���������� ������";
        }

        public void OnPost(string name, decimal? price)
        {
            Product = new Product();
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "�������� ������������ ������. ��������� ����";
                return;
            }
            var result = price * (decimal?)0.18;
            MessageRezult = $"��� ������ {name} � ����� {price} ������ ��������� {result}";
            Product.Price = price;
            Product.Name = name;
        }

        // �������� ProductModel - � ���������
        public void OnPostDiscont(string name, decimal? price, double discont)
        {
            Product = new Product();
            var result = price * (decimal?)discont / 100;
            MessageRezult = $"��� ������ {name} � ����� {price} � ������� {discont}��������� {result}";
            Product.Price = price;
            Product.Name = name;

        }

        public void OnPostDiscontManager(string name, decimal? price, double discontm)
        {
            Product = new Product();
            var result = price * (decimal?)discontm / 100;
            MessageRezult = $"��� ������ {name} � ����� {price} � ������� ������������� ��������� {discontm}��������� {result}";
            Product.Price = price;
            Product.Name = name;

        }

    }
}
