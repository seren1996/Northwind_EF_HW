// See https://aka.ms/new-console-template for more information
using NorthWindEFExercises;
using NorthWindEFExercises.Models;
using System;
using System.Data.Entity;

var db = new NorthwindContext();

//1
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Question 1 =>");
var regionToList = db.Regions.ToList();
Console.WriteLine();


//2
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Question 2 =>");
Console.ForegroundColor = ConsoleColor.White;
regionToList.ForEach(r => Console.WriteLine(r.RegionDescription));
Console.WriteLine();


//3
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Question 3 =>");
var territoriesToList = db.Territories.ToList();
Console.WriteLine();


//4
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Question 4 =>");
Console.ForegroundColor = ConsoleColor.White;
territoriesToList.ForEach(t => Console.WriteLine(t.TerritoryDescription));
Console.WriteLine();


//5
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Question 5 =>");
var territoriesGroupedByRegion = db.Territories.Include("Regions").ToList().GroupBy((t => t.Region.RegionDescription));


foreach (var group in territoriesGroupedByRegion)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(group.Key);
    Console.ForegroundColor = ConsoleColor.White;
    foreach (var territory in group)
    {
        Console.WriteLine(territory.TerritoryDescription);
    }
}



//6
//var newOrder = new Order() { CustomerId = "HANAR", EmployeeId = 6, OrderDate = new DateTime(2022, 8, 21, 0, 0, 0), RequiredDate = new DateTime(2022, 8, 30, 0, 0, 0), ShippedDate = new DateTime(2022, 8, 24, 0, 0, 0), ShipVia = 1 };
//db.Orders.Add(newOrder);
//db.SaveChanges();


//var OrdetDetail1 = new OrderDetail { ProductId = 11, UnitPrice = 14.00M, Quantity = 3, OrderId = newOrder.OrderId };
//var OrdetDetail2 = new OrderDetail { ProductId = 35, UnitPrice = 14.44M, Quantity = 2, OrderId = newOrder.OrderId };
//var OrdetDetail3 = new OrderDetail { ProductId = 3, UnitPrice = 8.00M, Quantity = 1, OrderId = newOrder.OrderId };
//db.OrderDetails.Add(OrdetDetail1);
//db.OrderDetails.Add(OrdetDetail2);
//db.OrderDetails.Add(OrdetDetail3);
//db.SaveChanges();


//var newOrder1 = new Order
//{
//    CustomerId = "FRANK",
//    EmployeeId = 6,
//    OrderDate = new DateTime(2022, 8, 21, 0, 0, 0),
//    ShipAddress = "7 Piccadilly Road.",
//    ShipCity = "New York",
//    ShipCountry = "New York",
//};

//db.Orders.Add(newOrder1);
//db.SaveChanges();
//var orderDetail1 = new OrderDetail { ProductId = 11, UnitPrice = 95, Quantity = 3, OrderId = newOrder1.OrderId };
//var orderDetail2 = new OrderDetail { ProductId = 56, UnitPrice = 47, Quantity = 6, OrderId = newOrder1.OrderId };
//var orderDetail3 = new OrderDetail { ProductId = 74, UnitPrice = 120, Quantity = 5, OrderId = newOrder1.OrderId };
//db.OrderDetails.Add(orderDetail1);
//db.OrderDetails.Add(orderDetail2);
//db.OrderDetails.Add(orderDetail3);
//db.SaveChanges();


//7
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Question 7=>");
Console.ForegroundColor = ConsoleColor.White;

var proudcutNameAndEmploy = db.Employees.Join(db.Orders, emp => emp.EmployeeId, order => order.EmployeeId,
    (emp, order) => new { emp.EmployeeId, emp.FirstName, emp.LastName, order }).Join(db.OrderDetails,
    emp => emp.order.OrderId, OrderDetail => OrderDetail.OrderId, (emp, OrderDetail) => new
    { emp, emp.order, OrderDetail }).Join(db.Products, emp => emp.OrderDetail.ProductId, pro => pro.ProductId, (emp, pro) =>
               new { emp, emp.order, emp.OrderDetail, pro }).ToList();

proudcutNameAndEmploy.ForEach(emp => Console.WriteLine($"The name of the product is {emp.pro.ProductName}" + '\n' + $"The name of the employee is {emp.emp.emp.FirstName}" + '\n'));



//8
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Question 8>");
Console.ForegroundColor = ConsoleColor.White;

var orderDett = db.Orders.ToList();
foreach (var order in orderDett)
{
    if (order.OrderId == 11079)
    {
        order.EmployeeId = 5;
    }


}


db.SaveChanges();



//9
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Question 9 =>");
Console.ForegroundColor = ConsoleColor.White;

var orderDett1 = db.OrderDetails.ToList();
foreach (var order in orderDett1)
{
    if (order.OrderId == 11079 && order.ProductId == 56)
    {
        db.OrderDetails.Remove(order);
    }

}
db.SaveChanges();







