using System;
using RestSharp;

namespace L02_console
{
    class Program
    {
        static void Main(string[] args)
        {
           var client = new RestClient("https://localhost:5001/students");
            int id, year;
            string name, faculty, value, option, body;
            client.Timeout = -1;
            RestRequest request;
            IRestResponse response;
            do
            {
                Console.WriteLine("1. Add student");
                Console.WriteLine("2. Show student");
                Console.WriteLine("3. Update student");
                Console.WriteLine("4. Delete student");
                Console.WriteLine("0. Exit!");
                Console.Write("Your option: ");
                option = Console.ReadLine();
                switch(option)
                {
                    case "1":   Console.Write("Id: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Name: ");
                                name = Console.ReadLine();
                                Console.Write("Faculty: ");
                                faculty = Console.ReadLine();
                                Console.Write("Year: ");
                                year = Convert.ToInt32(Console.ReadLine());
                                request = new RestRequest(Method.POST);
                                request.AddJsonBody(new { Id = id, Name = name, Faculty = faculty, Year = year });
                                response = client.Execute(request);
                                Console.WriteLine(response.Content);
                                break;
                    case "2":   Console.Write("Student Id: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                request = new RestRequest("{id}", Method.GET);
                                request.AddParameter("id", id, ParameterType.UrlSegment);    
                                response = client.Execute(request);
                                Console.WriteLine(response.Content);
                                break;
                    case "3":   Console.Write("Student Id: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Field to update (Id, Name, Facultaty, Year): ");
                                body = Console.ReadLine();
                                Console.Write("Field value: ");
                                value = Console.ReadLine();
                                request = new RestRequest(Method.PUT);
                                request.AddJsonBody(new { Id = id, Body = body, Value = value }) ;

                                response = client.Execute(request);
                                Console.WriteLine(response.Content);

                                break;
                    case "4":   Console.Write("Student Id: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                request = new RestRequest("{id}", Method.DELETE);
                                request.AddParameter("id", id, ParameterType.UrlSegment);
                                response = client.Execute(request);
                                Console.WriteLine(response.Content);

                                break;
                    case "0": break;
                    default: Console.WriteLine("Error!");
                             break;
                }
            } while (option != "0");
        }
    }
}