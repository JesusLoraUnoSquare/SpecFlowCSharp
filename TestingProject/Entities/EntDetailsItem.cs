using System;
using System.Collections.Generic;
using System.Text;

namespace TestingProject.Entities
{
    class EntDetailsItem
    {
        private string classPriceItem = "#corePriceDisplay_desktop_feature_div>.a-section>.a-price>span";
        private string idButtonAddToCart = "#add-to-cart-button";
        private string idNoThanks = "#attachSiNoCoverage>span>input";
        private string cssSelectorViewCart = "#attach-sidesheet-view-cart-button>span>input";

        public string ClassPriceItem { get => classPriceItem; }
        public string IdButtonAddToCart { get => idButtonAddToCart;}
        public string IdNoThanks { get => idNoThanks;}
        public string CssSelectorViewCart { get => cssSelectorViewCart; }
    }
}
