﻿using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using RevitDBExplorer.Domain.DataModel.ValueContainers.Base;

// (c) Revit Database Explorer https://github.com/NeVeSpl/RevitDBExplorer/blob/main/license.md

namespace RevitDBExplorer.Domain.DataModel.ValueContainers
{
    internal sealed class ObjectHandler : TypeHandler<object>
    {
        protected override bool CanBeSnoooped(SnoopableContext context, object @object) => @object is not null;
        protected override string ToLabel(SnoopableContext context, object @object)
        {
            string name = @object.TryGetPropertyValue(propertyThatContainsName);
            string typeName = @object.GetType()?.GetCSharpName();

            if (!string.IsNullOrEmpty(name))
            {
                return $"{typeName}: {name}";
            }
            return $"{typeName}";
        }
        protected override IEnumerable<SnoopableObject> Snooop(Document document, object @object)
        {
            yield return new SnoopableObject(document, @object);
        }


        private static readonly string[] propertyThatContainsName = new[]  { "Name", "Title", "SchemaName", "FieldName" };       
    }
}