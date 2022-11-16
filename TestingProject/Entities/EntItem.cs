using System;
using System.Collections.Generic;
using System.Text;

namespace TestingProject.Entities
{
    class EntItem
    {
        private string price="";
        private string description = "";
        private bool exists = false;

        public string Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public bool Exists { get => exists; set => exists = value; }
    }
}
