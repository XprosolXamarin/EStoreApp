using EStoreApp.ViewModels;
using System;

namespace EStoreApp.Models
{
    public class clsItem:BaseViewModel
    {
        
          public clsItem()
        {
            TotalAmount = 0;
        }
      
        public int ItemId { get; set; }
        //public string ItemName { get; set; }
        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set  {
                _ItemName= value;

                OnPropertyChanged(); }
        }

        private decimal? _LineGrossValue;
        public decimal? LineGrossValue
        {
            get { return _LineGrossValue; }
            set
            {
                _LineGrossValue = value;

                OnPropertyChanged();
            }
        }



        private decimal? _TotalAmount;
        public decimal? TotalAmount
        {
            get { return _TotalAmount; }
            set
            {
                _TotalAmount = value;

                OnPropertyChanged();
            }
        }
        public string UrduName { get; set; }
        private string _Barcode;
        public string Barcode
        {
            get { return _Barcode; }
            set
            {
                _Barcode = value;

                OnPropertyChanged();
            }
        }

        public int? BrandId { get; set; }

        public string BrandName { get; set; }
        public int? CategoryId { get; set; }
        private string _CategoryName;
        public string CategoryName
        {
            get { return _CategoryName; }
            set
            {
                _CategoryName = value;

                OnPropertyChanged();
            }
        }

        public int? UnitId { get; set; }
        public string UnitName { get; set; }

        public int? Unit2Id { get; set; }
        public string Unit2Name { get; set; }
        private decimal? _CostPrice;
        public decimal? CostPrice
        {
            get { return _CostPrice; }
            set
            {
                _CostPrice = value;

                OnPropertyChanged();
            }
        }
        public decimal? SalePrice { get; set; }
        public decimal? MinLevel { get; set; }
        public decimal? MaxLevel { get; set; }
        public decimal? MinOrder { get; set; }

        public decimal? Quantity1 { get; set; }
        private decimal? _Quantity2;
        public decimal? Quantity2
        {
            get { return _Quantity2; }
            set
            {
                if (value > 1)
                    _Quantity2 = value;
                else
                    _Quantity2 = 1;
                OnPropertyChanged();
            }
        }

        public bool? Status { get; set; }
        public string StatusString { get; set; }
        public DateTime? CreatedDate { get; set; }
        public String CreatedByString { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedByString { get; set; }

        public int? DocumentId { get; set; }
        private string _ImagePath;
        public string ImagePath
        {
            get { return _ImagePath; }
            set
            {
                _ImagePath = value;

                OnPropertyChanged();
            }
        }
    }
}