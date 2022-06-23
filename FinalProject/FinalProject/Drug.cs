using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Drug
    {
        public int id { get; set; }
        private int _id { get; set; }
        public string Name { get; set; }
        public DrugType DrugType { get; set; }
        public int Count { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }

        public Drug()
        {
            id = ++_id;
        }
    }

    public enum DrugType
    {
        TABLET,
        POWDER,
        SYROP
    }
}
