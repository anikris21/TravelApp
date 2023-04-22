using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVCApplication.Controllers;

namespace MVCApplication.Model_Binding
{
    public class CVSModelBinderProvider : IModelBinderProvider
    {
        private IModelBinder? _modelBinder;

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if(context.Metadata.ModelType == typeof(List<Order>))
            {
                _modelBinder = new CVSModelBinder();
            }
            return _modelBinder;
        }
    }
}
