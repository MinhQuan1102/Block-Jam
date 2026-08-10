using System;
using UnityEngine;

namespace Core
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class CreateScriptableObjectAttribute : PropertyAttribute
    {
        public CreateScriptableObjectAttribute() { }
    }
}
