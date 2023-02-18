﻿using System;
using System.Collections.Generic;
using System.Linq;
using RevitDBExplorer.WPF.Controls;

// (c) Revit Database Explorer https://github.com/NeVeSpl/RevitDBExplorer/blob/main/license.md

namespace RevitDBExplorer.Domain.RevitDatabaseQuery.Parser.Commands
{
    internal class ElementTypeCmdDefinition : ICommandDefinition
    {
        private static readonly AutocompleteItem AutocompleteItem = new AutocompleteItem("type", "type", "select element types", AutocompleteItemGroups.Commands);
              

        public IAutocompleteItem GetCommandAutocompleteItem() => AutocompleteItem;
                            

        public IEnumerable<string> GetClassifiers()
        {
            yield break;
        }
        public IEnumerable<string> GetKeywords()
        {
            yield return "type";
            yield return "types";
            yield return "element type";
            yield return "not element";           
        }
        public bool CanRecognizeArgument(string argument) => false;
        public bool CanParticipateInGenericSearch() => false;


        public ICommand Create(string cmdText, string argument)
        {
            return new ElementTypeCmd(cmdText);
        }
    }


    internal class ElementTypeCmd : Command, ICommandForVisualization
    {
        public string Label => "element type";
        public string Description => "collector.WhereElementIsElementType()";
        public CmdType Type => CmdType.WithoutArgument;


        public ElementTypeCmd(string text) : base(text, null, null)
        {
            IsBasedOnQuickFilter = true;
        }
    }
}