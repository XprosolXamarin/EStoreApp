using EStoreApp.ViewModels;


namespace EStoreApp.Models
{
  public  class TBillCount:BaseViewModel 
    {
        private decimal? _TBill;
        public decimal? TBill
        {
            get { return _TBill; }
            set
            {
                _TBill = value;

                OnPropertyChanged();
            }
        }
        private int _TCount;
        public int TCount
        {
            get { return _TCount; }
            set
            {
                _TCount = value;

                OnPropertyChanged();
            }
        }
    }
}
