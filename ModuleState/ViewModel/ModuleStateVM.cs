using ModuleState.Helpers;
using System.ComponentModel;

namespace ModuleState.ViewModel
{
    public class ModuleStateVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ItemControlVM ItemControl { get; set; }
        public RelayCommand BtnCommandType1 { get; set; }
        public RelayCommand BtnCommandType2 { get; set; }
        public RelayCommand BtnCommandType3 { get; set; }
        public RelayCommand BtnCommandType4 { get; set; }

        public ModuleStateVM()
        {
            ItemControl = new ItemControlVM();
            BtnCommandType1 = new RelayCommand(setDevice1);
            BtnCommandType2 = new RelayCommand(setDevice2);
            BtnCommandType3 = new RelayCommand(setDevice3);
            BtnCommandType4 = new RelayCommand(setDevice4);

            //test
            ItemControl.SetState(ItemControlVM.DeviceType.Type1, 200, ItemControlVM.State.Active);
            ItemControl.SetState(ItemControlVM.DeviceType.Type2, 0, ItemControlVM.State.Inactive);
            ItemControl.SetState(ItemControlVM.DeviceType.Type3, 20, ItemControlVM.State.unknown );
            ItemControl.SetState(ItemControlVM.DeviceType.Type4, 400, ItemControlVM.State.Active);
            //test
        }

        private void setDevice1(object obj)
        {
            ItemControl.SetDeviceItem(ItemControlVM.DeviceType.Type1);
        }
        private void setDevice2(object obj)
        {
            ItemControl.SetDeviceItem(ItemControlVM.DeviceType.Type2);
        }
        private void setDevice3(object obj)
        {
            ItemControl.SetDeviceItem(ItemControlVM.DeviceType.Type3);
        }
        private void setDevice4(object obj)
        {
            ItemControl.SetDeviceItem(ItemControlVM.DeviceType.Type4);
        }
    }
}
