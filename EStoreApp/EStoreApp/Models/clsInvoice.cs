using Android.Hardware;
using EStoreApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EStoreApp.Models
{
    public class clsInvoice:BaseViewModel
        
    {
       public clsInvoice()
        {
            TotalAmount = 0;
          
        }
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string IsNeWOrEdit { get; set; }
        public int? AccountId { get; set; }
        public string InvoiceType { get; set; }
        public string AccountName { get; set; }

        // double total = myList.Sum(item => item.Amount);
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
        private decimal? _SRate;
        public decimal? SRate
        {
            get { return _SRate; }
            set
            {
                _SRate = value;

                OnPropertyChanged();
            }
        }
        public decimal? FRate { get; set; }


        public string DiscType { get; set; }
        public decimal? DiscRate { get; set; }
        public decimal? DiscAmount { get; set; }
        public decimal? NetAmount { get; set; }


        public int InvoiceLineNumber { get; set; }
       
        public int? ItemId { get; set; }
        private string _ItemName;
       
        public string ItemName
        {
            get { return _ItemName; }
            set
            {
                _ItemName = value;

                OnPropertyChanged();
            }
        }

        public int? WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        private decimal? _Rate;
        public decimal? Rate
        {
            get { return _Rate; }
            set
            {
                _Rate = value;

                OnPropertyChanged();
            }
        }
       


        public decimal? Quantity1 { get; set; }

        private decimal? _Quantity2;
        public decimal? Quantity2
        {
            get { return _Quantity2; }
            set
            {
                if (value > 0)
                {
                    _Quantity2 = value;
                }
                else
                {
                    _Quantity2 = 1;
                }

                OnPropertyChanged();
            }
        }

        
        public int? Unit1Id { get; set; }
        public string Unit1Name { get; set; }
        public int? Unit2Id { get; set; }
        public string Unit2Name { get; set; }
        public string LineDiscType { get; set; }
        public decimal? LineDiscRate { get; set; }
       
        public decimal? LineNetAmount { get; set; }
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
        public DateTime? CreatedDate { get; set; }
        public String CreatedByString { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedByString { get; set; }

        public List<clsInvoice> SaleLineList { get; set; }
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
    }
}