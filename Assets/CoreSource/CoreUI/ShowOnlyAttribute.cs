using System;
using UnityEngine;


//[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false)]
//public class ReadOnlyAttribute : Attribute, IListAttribute, IRuntimeAttribute<bool>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false)]
public class ShowOnlyAttribute : PropertyAttribute
{
}


