using System;
using System.IO;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = $"{Directory.GetCurrentDirectory()}\\..\\..\\..\\..\\..\\Serialization\\Serialization\\bin\\Debug\\net5.0\\Serialization.dll";
            var asm = Assembly.LoadFrom(path);

            var figureType = asm.GetType("Serialization.Figure", true, true);
            var fig1 = Activator.CreateInstance(figureType);

            var publicProperties = figureType.GetProperties(BindingFlags.Public);
            var privateProperties = figureType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var proprty in publicProperties)
            {
                proprty.SetValue(fig1, 10);
            }

            var privPropName = privateProperties[0].Name;

            var figureDisplayMethod = figureType.GetMethod("Display");
            figureDisplayMethod.Invoke(fig1, new object[] { fig1 });
        }
    }
}
