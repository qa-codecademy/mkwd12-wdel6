using ServerTwo.Interface;

namespace ServerTwo.Core
{
    internal class ControllerFactory
    {
        private Dictionary<Type, Type> _services = new ();

        internal IController? MakeController<T>() where T : IController
        {
            var ctors = typeof(T).GetConstructors();
            if (ctors.Length != 1)
            {
                throw new QinshiftServerException("Controller must have exactly one constructor");
            }

            var ctor = ctors[0];
            var parameters = ctor.GetParameters();
            var args = new List<object?>();
            foreach (var parameter in parameters)
            {
                var parameterType = parameter.ParameterType;
                var hasService = _services.TryGetValue(parameterType, out var serviceType);
                if (!hasService)
                {
                    throw new QinshiftServerException($"No service registered for {parameterType}");
                }
                var parameterInstance = Activator.CreateInstance(serviceType!);
                args.Add(parameterInstance);
            }

            var controller = Activator.CreateInstance(typeof(T), args.ToArray());
            return controller as IController;
        }

        internal void RegisterService<TInterface, TImplementation>()
        {
            _services.Add(typeof(TInterface), typeof(TImplementation));
        }
    }
}