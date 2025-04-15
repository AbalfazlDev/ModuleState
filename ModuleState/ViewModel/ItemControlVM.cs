using ModuleState.Helpers;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ModuleState.ViewModel
{
    public class ItemControlVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Item> ItemControlStatus { get; set; }
        private ObservableCollection<Item> _ItemsType1 { get; set; }
        private ObservableCollection<Item> _ItemsType2 { get; set; }
        private ObservableCollection<Item> _ItemsType3 { get; set; }
        private ObservableCollection<Item> _ItemsType4 { get; set; }
        public ItemControlVM()
        {
            _ItemsType1 = new ObservableCollection<Item>();
            _ItemsType2 = new ObservableCollection<Item>();
            _ItemsType3 = new ObservableCollection<Item>();
            _ItemsType4 = new ObservableCollection<Item>();
            ItemControlStatus = new ObservableCollection<Item>();

            for (int i = 0; i < 480; i++)
            {
                _ItemsType1.Add(new Item { Index = i });
                _ItemsType2.Add(new Item { Index = i });
                _ItemsType3.Add(new Item { Index = i });
                _ItemsType4.Add(new Item { Index = i });
            }
        }

        public void SetState(DeviceType deviceType, Index index, State state)
        {
            //Set the state at the specified time with index and state (Index domain : 0 => 497 and State:Active,Inactive,Unknow) 
            switch (deviceType)
            {
                case DeviceType.Type1: setState(_ItemsType1, index, state); break;
                case DeviceType.Type2: setState(_ItemsType2, index, state); break;
                case DeviceType.Type3: setState(_ItemsType3, index, state); break;
                case DeviceType.Type4: setState(_ItemsType4, index, state); break;
            }
        }
        private void setState(ObservableCollection<Item> items, Index index, State state)
        {
            if (state == State.Active) items[index].Color = new SolidColorBrush(System.Windows.Media.Color.FromRgb(72, 232, 32));
            if (state == State.Inactive) items[index].Color = new SolidColorBrush(Colors.Red);
            if (state == State.unknown) items[index].Color = new SolidColorBrush(Colors.Yellow);
        }
        public void SetDeviceItem(DeviceType deviceType)
        {
            //You can switch between types by this method
            switch (deviceType)
            {
                case DeviceType.Type1: ItemControlStatus = _ItemsType1; break;
                case DeviceType.Type2: ItemControlStatus = _ItemsType2; break;
                case DeviceType.Type3: ItemControlStatus = _ItemsType3; break;
                case DeviceType.Type4: ItemControlStatus = _ItemsType4; break;
            }
        }

        public void ItemsControl_Loaded(object sender, RoutedEventArgs e)
        {
            //This method sets the width of the ItemsControl at startup
            setWidthItemControl(((ItemsControl)sender).ActualWidth);
        }

        public void ItemsControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //This method adjusts the ItemsControl width if the window size changes (for each separate Index)
            setWidthItemControl(e.NewSize.Width);
        }

        private void setWidthItemControl(double itemControlWidthSize)
        {
            //ItemControl width is set by this method
            itemControlWidthSize = itemControlWidthSize / 480;
            for (int i = 0; i < 480; i++)
            {
                _ItemsType1[i].ItemControlWidth = itemControlWidthSize;
                _ItemsType2[i].ItemControlWidth = itemControlWidthSize;
                _ItemsType3[i].ItemControlWidth = itemControlWidthSize;
                _ItemsType4[i].ItemControlWidth = itemControlWidthSize;
            }
        }

        public enum DeviceType
        {
            Type1 = 1,
            Type2 = 2,
            Type3 = 3,
            Type4 = 4,
        }

        public enum State
        {
            Active = 1,
            Inactive = 2,
            unknown = 3,
        }
    }
}
