using System;
using System.Collections.Generic;
using System.Text;

namespace TestingProject.Entities
{
    class EntCart
    {
        private string selectorprice = ".sc-list-item-content>.a-row>.a-column>.a-spacing-mini>span";
        private string selectorDeleteItem = ".sc-action-delete>span>input";

        public string Selectorprice { get => selectorprice;  }
        public string SelectorDeleteItem { get => selectorDeleteItem; }
    }
}
