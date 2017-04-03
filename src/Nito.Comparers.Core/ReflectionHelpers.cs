using System;
using System.Collections.Generic;
using System.Reflection;
#if !NET40
using System.Runtime.CompilerServices;
#endif

internal static class ReflectionHelpers
{
  public static Type TryGetEnumeratorType(Type source)
  {
    return TryFindInterfaceType(source, "IEnumerable`1");
  }

  public static Type TryFindInterfaceType(Type type, string name)
  {
    if (type.Name == name) { return type; }
#if NET40
    foreach (var interfaceType in type.GetInterfaces())
#else
    foreach (var interfaceType in type.GetTypeInfo().ImplementedInterfaces)
#endif
    {
      if (string.Equals(interfaceType.Name, name, StringComparison.Ordinal)) { return interfaceType; }
    }

    return null;
  }

  public static PropertyInfo TryFindDeclaredProperty(Type type, string name)
  {
    foreach (var property in type.GetDeclaredProperties())
    {
      if (string.Equals(property.Name, name, StringComparison.Ordinal)) { return property; }
    }

    return null;
  }

#if !NET40
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
  public static Type[] GetTypeGenericArguments(this Type type)
  {
#if NET40
    return type.IsGenericType && !type.IsGenericTypeDefinition ? type.GetGenericArguments() : Type.EmptyTypes;
#else
    return type.GetTypeInfo().GenericTypeArguments;
#endif
  }

#if !NET40
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
  public static IEnumerable<PropertyInfo> GetDeclaredProperties(this Type type)
  {
#if !NET40
    return type.GetTypeInfo().DeclaredProperties;
#else
    return type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly);
#endif
  }
}