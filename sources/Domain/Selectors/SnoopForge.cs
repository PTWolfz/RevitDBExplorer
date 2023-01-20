﻿using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitDBExplorer.Domain.DataModel;
using RevitDBExplorer.Domain.Selectors.Base;

// (c) Revit Database Explorer https://github.com/NeVeSpl/RevitDBExplorer/blob/main/license.md

namespace RevitDBExplorer.Domain.Selectors
{
    internal class SnoopForge : ISelector
    {
        private readonly Selector selector;

        public SnoopForge(Selector selector)
        {
            this.selector = selector;
        }


        public IEnumerable<SnoopableObject> Snoop(UIApplication app)
        {
#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
            IList<ForgeTypeId> ids = selector switch
            {
#if R2022b
                Selector.ForgeParameterUtilsGetAllBuiltInGroups => ParameterUtils.GetAllBuiltInGroups(),
                Selector.ForgeParameterUtilsGetAllBuiltInParameters => ParameterUtils.GetAllBuiltInParameters(),
                Selector.ForgeUnitUtilsGetAllMeasurableSpecs => UnitUtils.GetAllMeasurableSpecs(),
                Selector.ForgeUnitUtilsGetAllDisciplines => UnitUtils.GetAllDisciplines(),
                Selector.ForgeSpecUtilsGetAllSpecs => SpecUtils.GetAllSpecs(),
#endif
                Selector.ForgeUnitUtilsGetAllUnits => UnitUtils.GetAllUnits(),

            };
#pragma warning restore CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
            return ids.Select(x => new SnoopableObject(app?.ActiveUIDocument?.Document, x));
        }
    }
}