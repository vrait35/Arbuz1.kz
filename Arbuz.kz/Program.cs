using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Classes;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Arbuz.kz
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> account = new Dictionary<string, string>();
            string number;
           
            int isIn = 0;
            int status = 0;
            while (status == 0)
            {

                while (true)
                {
                    Console.WriteLine("Введите 1 для регистрации, введите 2 для входа");
                    number = Console.ReadLine();
                    if (number == "1" || number == "2") break;
                }
                int inOrReg = 0;
                if (number == "1") inOrReg = 1;
                else inOrReg = 2;

                switch (inOrReg)
                {
                    case 1:
                        Console.WriteLine("Введите логин: ");
                        string login = Console.ReadLine();
                        Console.WriteLine("Введите пароль: ");
                        string password = Console.ReadLine();
                        account.Add(login, password);

                        Console.Write("введите номер телефона  ");
                        string bufnumberPhone = Console.ReadLine();

                        // Find your Account Sid and Token at twilio.com/console
                        const string accountSid = "ACcb97c83a29ffe6aa6109a14a350e6ea7";
                        const string authToken = "0ad183c0a412d2498ac1e2b0042930cf";

                        TwilioClient.Init(accountSid, authToken);
                        Random rnd = new Random();
                        string mesage = rnd.Next(1000, 9999).ToString();
                        Console.WriteLine("Вам пришло СМС 4х код для проверки: " + mesage);
                        var message = MessageResource.Create(
                            body: mesage,
                            from: new PhoneNumber("+18507546379"),
                            to: new PhoneNumber("+77082195258")
                        );
                        Console.WriteLine(message.Sid);

                        break;

                    case 2:
                        Console.WriteLine("Введите логин: ");
                        string loginIn = Console.ReadLine();
                        Console.WriteLine("Введите пароль: ");
                        string passwordIn = Console.ReadLine();

                        foreach (KeyValuePair<string, string> keyValue in account)
                        {
                            if (keyValue.Key == loginIn)
                            {
                                if (keyValue.Value == passwordIn)
                                {
                                    isIn = 1;
                                    status = 1;
                                    
                                }
                            }
                        }
                        break;


                }//switch
            }//while status
        

            if(isIn!=1) Environment.Exit(0);
            else Console.WriteLine("вы вошли!");

            List<Product> products = new List<Product>();
            int size = 26;
            Product[] productArray = new Product[size];

             productArray[0]= new Product("велосипед", 50000, "отдых");
             productArray[1]= new Product("дорожная сумка", 5000, "отдых");
             productArray[2]= new Product("палатка", 23000, "отдых");
             productArray[3]= new Product("мангал", 2000, "отдых");
             productArray[4]= new Product("купальник", 500, "отдых");
             productArray[5]= new Product("подводные очки", 350, "отдых");
             productArray[6]= new Product("удка", 15000, "отдых");
             productArray[7]= new Product("лодка", 60, "отдых");
             productArray[8]= new Product("коньки", 250, "отдых");
             productArray[9] = new Product("штанга", 200, "отдых");


            productArray[10] = new Product("samsung x", 50000, "техника");
            productArray[11] = new Product("iphone x", 5000, "техника");
            productArray[12] = new Product("стиральная машина ", 23000, "техника");
            productArray[13] = new Product("микроволновая печь", 2000, "техника");
            productArray[14] = new Product("ноутбук", 500, "техника");
            productArray[15] = new Product("компьютер", 350, "техника");
            productArray[16] = new Product("принтер фыв", 15000, "техника");
            productArray[17] = new Product("мышка", 60, "техника");
            productArray[18] = new Product("монитор", 250, "техника");
            productArray[19] = new Product("телик", 200, "техника");


            productArray[20] = new Product("шорты", 50000, "одежда");
            productArray[21] = new Product("фтболка", 5000, "одежда");
            productArray[22] = new Product("штаны", 23000, "одежда");
            productArray[23] = new Product("джинсы", 2000, "одежда");
            productArray[24] = new Product("костюм", 500, "одежда");
            productArray[25] = new Product("шляпа", 350, "одежда");
           



            foreach (Product p in productArray)
            products.Add(p);
            //Console.WriteLine("--------------"+products[2].Name);

            Console.WriteLine("введите необходимую категорию: 1-отдых" +
                "2-техника,3-одежда"
                );
            bool isTrue = false;
            int kategory = 0;
            while (isTrue == false)
            {
                try
                {
                    Browsing.StringToInt(Console.ReadLine(), ref kategory);
                    isTrue = true;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            //Console.WriteLine("asd: "+kategory);
            isTrue = false;
            Browsing browsing;
            switch (kategory)
            {
                case 1: browsing = new Browsing("отдых", products);
                    for(int i=0;i<browsing.Count;i++)
                        Console.WriteLine(browsing.Product[i].Name+" цена: "+browsing.Product[i].Price);
                    Console.WriteLine("count:"+browsing.Count);
                    break;
                case 2: browsing = new Browsing("техника", products);
                    for (int i = 0; i < browsing.Count; i++)
                        Console.WriteLine(browsing.Product[i].Name + " цена: " + browsing.Product[i].Price);
                    break;
                case 3: browsing = new Browsing("одежда", products);
                    for (int i = 0; i < browsing.Count; i++)
                        Console.WriteLine(browsing.Product[i].Name + " цена: " + browsing.Product[i].Price);
                    break;
            }           

            int sum = 0;
            string productName;
            int isEnd = 0;
            while (isEnd==0)
            {
                Console.WriteLine("введите название продукта");
                productName = Console.ReadLine();
                for(int i = 0; i < products.Count; i++)
                {
                    if (products[i].Name == productName) sum += products[i].Price;
                }
                Console.WriteLine("введите 1 для завершение покупки");
                Browsing.StringToInt(Console.ReadLine(), ref isEnd);                
            }
            Console.WriteLine("сумма:"+sum);
            Console.ReadKey();



        }
    }
}
