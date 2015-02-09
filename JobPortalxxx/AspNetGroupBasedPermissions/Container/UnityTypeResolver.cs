

using Microsoft.Practices.Unity;
using System.Web.Mvc;
using Unity.Mvc4;
namespace AspNetGroupBasedPermissions.Container
{
    public class UnityTypeResolver
    {
        private static UnityTypeResolver _typeResolver;
        
        private UnityTypeResolver()
        {

        }

        public static UnityTypeResolver CurrentInstance
        {
            get
            {
                if (_typeResolver == null)
                {
                    return _typeResolver;
                }
                return _typeResolver;
            }
        }

        public IUnityContainer Initialize()
        {
            var container = new UnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
    }
}