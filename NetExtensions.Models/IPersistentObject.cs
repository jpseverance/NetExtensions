using System;

namespace NetExtensions.Models
{
    public interface IPersistentObject
    {
        Key Key
        {
            get;
        }
    }
}
