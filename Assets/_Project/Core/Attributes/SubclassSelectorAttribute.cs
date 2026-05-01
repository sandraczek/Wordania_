using System;
using UnityEngine;

namespace Wordania.Core.Attributes
{
    /// <summary>
    /// Attribute used to display a dropdown of derived types for a field serialized with [SerializeReference].
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class SubclassSelectorAttribute : PropertyAttribute
    {
    }
}