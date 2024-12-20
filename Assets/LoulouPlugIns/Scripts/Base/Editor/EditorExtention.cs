using System.Collections;
using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class EditorExtention 
{
    public static string GetValueFromObject<T>(T obj, string propertyPath) where T : class
    {

        Type type = obj.GetType();
        PropertyInfo prop = null;

        string[] parts = propertyPath.Split('.');
        object value = obj;

        foreach (string part in parts)
        {
            prop = type.GetProperty(part);
            var x = prop.GetValue(value, null);

            if (x is IList)
            {
                value = (x as IList)[0];
                type = value.GetType();
                continue;
            }
            else
                type = prop.GetType();

            value = prop.GetValue(value, null);
        }
        return value.ToString();
    }
}
