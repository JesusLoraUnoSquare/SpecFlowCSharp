using System;
using System.Collections.Generic;
using System.Text;

namespace TestingProject.Entities
{
    class EntStorePage
    {
        private string classListResult = ".s-result-item.s-asin>.sg-col-inner>.s-widget-container>.s-card-container>.a-section>.a-section>.a-section>.a-size-mini>.a-link-normal>.a-size-base-plus";
        //private string classListResultPrice = ".s-result-item.s-asin>.sg-col-inner>.s-widget-container>.s-card-container>.a-section>.a-section>.a-section>.a-row>.a-row>.a-size-base>.a-price>.a-offscreen";
        private string classListResultPrice = ".a-price>span";
        //private string classLinkToItem = ".s-result-item.s-asin>.sg-col-inner>.s-widget-container>.rush-component>.rush-component>.s-card-container>.a-section>.a-section>.a-section>.a-size-mini>a";
        private string classLinkToItem = ".a-link-normal>.a-section>.s-image";


        public string ClassListResult { get => classListResult; }
        public string ClassListResultPrice { get => classListResultPrice; }
        public string ClassLinkToItem { get => classLinkToItem; }
    }
}
