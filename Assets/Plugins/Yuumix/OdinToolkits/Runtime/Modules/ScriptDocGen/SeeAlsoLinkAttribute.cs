using System;

namespace Yuumix.OdinToolkits.Shared
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct, AllowMultiple = true,
        Inherited = false)]
    public class SeeAlsoLinkAttribute : Attribute
    {
        public readonly string Link;

        public SeeAlsoLinkAttribute(string link) => Link = link;
    }
}
