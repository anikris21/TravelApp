using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVCApplication.Controllers;

namespace MVCApplication.Model_Binding
{
    public class CVSModelBinder :  IModelBinder
    {

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            // csv = "pencil, 1, to write"
            var rawCSV = bindingContext.ValueProvider.GetValue("csv").ToString();
            var csv = rawCSV.Split(Environment.NewLine.ToCharArray());

            var createOrderList = new List<Order>();
            foreach (var csvItem in csv)
            {
                var orderValues = csvItem.Split(",");
                Order order = new Order();
                order.ProductDescription = orderValues[2];
                order.ProductName = orderValues[0];
                order.Count = orderValues[1];
                createOrderList.Add(order);
            }

            bindingContext.Result = ModelBindingResult.Success(createOrderList);

            return Task.CompletedTask;
        }
    }
}
