using System.Reflection;
using DataSpace;

public class InterfaceFinder
{
    public static List<Executor> executorRegistry = new List<Executor>();
    public static List<DataPersistance> dataPersistanceRegistry = new List<DataPersistance>();

    
    
    public static List<Type> GetImplementingTypes<TInterface>()
    {
        //Needs to be interface
        if (!typeof(TInterface).IsInterface)
        {
            throw new ArgumentException(typeof(TInterface).Name + " is not an interface");
        }

        // Get the current assembly (or any other specific assembly)
        Assembly assembly = Assembly.GetExecutingAssembly();

        // Find all types that implement the interface and are not abstract
        var implementingTypes = assembly.GetTypes()
                                        .Where(type => typeof(TInterface).IsAssignableFrom(type) &&
                                                       !type.IsInterface &&
                                                       !type.IsAbstract)
                                        .ToList();

        return implementingTypes;
    }
}