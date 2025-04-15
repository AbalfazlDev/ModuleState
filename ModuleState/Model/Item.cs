using System.ComponentModel;
using System.Windows.Media;

namespace ModuleState.Helpers
{
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public double ItemControlWidth { get; set; }
        public int Index { get; set; }
        public SolidColorBrush Color { get; set; }
    }
}
