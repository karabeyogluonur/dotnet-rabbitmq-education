using System;
using OrderProducer.Console.Models;

while (true)
{
    #region Create Order

    OrderModel orderModel = new OrderModel();

    Console.WriteLine("[**] The order creation process is starting. \n\n\n");

    Console.Write("[*] First Name : ");
    orderModel.FirstName = Console.ReadLine() ?? "Anonymous";

    Console.Write("[*] Last Name : ");
    orderModel.LastName = Console.ReadLine() ?? "Anonymous";

    Console.Write("[*] Email : ");
    orderModel.Email = Console.ReadLine() ?? "Anonymous";

    Console.Write("[*] Phone : ");
    orderModel.Phone = Console.ReadLine() ?? "Anonymous";

    Console.WriteLine("\n[**] Enter products information. \n");

    while (true)
    {
        ProductModel productModel = new ProductModel();

        Console.Write("[*] Product Name : ");
        productModel.Name = Console.ReadLine() ?? "Anonymous";

        Console.Write("[*] Product Quantity : ");
        productModel.Quantity = Convert.ToInt32(Console.ReadLine());

        bool newProduct;

        while (true)
        {
            Console.Write("[*] Do you want add another product?(yes/no) : ");
            string newProductAnswer = Console.ReadLine() ?? "WrongAnswer";

            if (newProductAnswer.ToLower() == "yes")
            {
                newProduct = true;
                break;
            }

            else if(newProductAnswer.ToLower() == "no")
            {
                newProduct = false;
                break;
            }

            else
            {
                Console.WriteLine("[**] Your answer is invalid.");
            }
                
        }

        orderModel.Products.Add(productModel);

        if (!newProduct)
            break;
    }

    Console.WriteLine("\n\n\n[**] The order creation process is completed.");

    #endregion


}