using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM.Also;
using MVVM.Model;

namespace MVVM.ViewModel
{
    public class Base : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        string _GetGoods;

        public string GetGoods
        {
            get => _GetGoods;
            set
            {
                _GetGoods = value;
                OnPropertyChanged("GetGoods");
            }
        }

        string _GoodWeight;

        public string GoodWeight
        {
            get => _GoodWeight;
            set { _GoodWeight = value; }
        }

        string _GoodHeight;

        public string GoodHeight
        {
            get => _GoodHeight;
            set { _GoodHeight = value; }
        }

        string _GoodWidth;

        public string GoodWidth
        {
            get => _GoodWidth;
            set { _GoodWidth = value; }
        }

        string _GoodName;

        public string GoodName
        {
            get => _GoodName;
            set { _GoodName = value; }
        }
        Command _GetGoodsCommand;
        public ICommand GetGoodsCommand
        {
            get
            {
                if (_GetGoodsCommand == null)
                    _GetGoodsCommand = new Command(ExecuteGetGoodsCommand, CanExecuteGetGoodsCommand);
                return _GetGoodsCommand;
            }
        }
        private void ExecuteGetGoodsCommand(object parameter)
        {
            Order.LoadGoods();
            List<string> Goods = Order.GetGoods();
            StringBuilder sb = new StringBuilder("");
            Goods.ForEach(item => sb.Append(item + ","));
            GetGoods = sb.ToString();
        }

        private bool CanExecuteGetGoodsCommand(object parameter)
        {
            return true;
        }
        Command _AddOrderCommand;
        public ICommand AddOrderCommand
        {
            get
            {

                if (_AddOrderCommand == null)
                    _AddOrderCommand = new Command(ExecuteAddOrderCommand, CanExecuteAddOrderCommand);
                return _AddOrderCommand;
            }
        }

        private void ExecuteAddOrderCommand(object parameter)
        {
            Order.AddOrder(GoodName);
            OnPropertyChanged("Check");
            OnPropertyChanged("All");
        }

        private bool CanExecuteAddOrderCommand(object parameter)
        {
            return true;
        }
    }
}
