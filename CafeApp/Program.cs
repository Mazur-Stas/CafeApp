using CafeApp;
using CafeApp.Core.DTOs.Inputs;


var logger = Dependency.GetLogger();

while (true)
{
    ShowMenu();
    //var context = new CafeAppContext();

    //var names = context.Set<User>().Select(x => x.FirstName);

    Console.Write("Enter number: ");
    var index = int.Parse(Console.ReadLine());

    switch (index)
    {
        case 1:
            try
            {

                var orderService = Dependency.GetOrderService();

                Console.Write("Enter address: ");
                string address = Console.ReadLine();

                var dto = new AddOrderDto()
                {
                    Address = address,
                    CustomerId = 1,
                    ProductsIds = [1]
                };
                var order = await orderService.PlaceOrderAsync(dto, default);
               
                Console.WriteLine($"Order #{order.Id} was placed. Delivery to {order.Address}");
                logger.Information("Order {0} was placed", order.Id);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"Validation error: {ex.Message}");
                logger.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.Error(ex.Message);
            }
            break;
    }
}


void ShowMenu()
{
    Console.WriteLine("1. Place order");
}