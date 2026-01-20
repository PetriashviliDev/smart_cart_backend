namespace SmartCartBackend.Common.Extensions;

public static class TypeExtensions
{
    public static bool HasBaseType(
        this Type type,
        params Type[] baseTypes) => type.HasBaseType(out _, baseTypes);
    
    public static bool HasBaseType(
        this Type type, 
        out Type baseType, 
        params Type[] baseTypes)
    {
        baseType =  null;

        while (true)
        {
            if (type.BaseType == null)
                return false;

            if (baseTypes.Select(t => t.GUID).Contains(type.BaseType.GUID))
            {
                baseType = type.BaseType;
                return true;
            }
            
            type = type.BaseType;
        }
    }
}