﻿// (c) Revit Database Explorer https://github.com/NeVeSpl/RevitDBExplorer/blob/main/license.md

namespace RevitDBExplorer.Domain.RevitDatabaseQuery
{
    internal enum CmdType
    {
        WithoutArgument,    
        DocumentSpecific,
        ElementId,      
        Category,
        Class,     
        Parameter,
        EnumBased,      
    }
}