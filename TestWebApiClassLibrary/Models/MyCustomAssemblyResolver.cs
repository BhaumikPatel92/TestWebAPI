using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http.Dispatcher;

namespace TestWebApiClassLibrary.Models
{
    public class MyCustomAssemblyResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            ICollection<Assembly> baseAssemblies = base.GetAssemblies();
            List<Assembly> assemblies = new List<Assembly>(baseAssemblies);
            var controllersAssembly = Assembly.LoadFrom(@"C:\Users\bhaumik.patel\Documents\visual studio 2017\Projects\TestWebAPI\DevClassLibrary\bin\Debug\DevClassLibrary.dll");
            baseAssemblies.Add(controllersAssembly);
            return assemblies;
        }
    }
}