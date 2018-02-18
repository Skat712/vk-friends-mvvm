using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace vk_friends_mvvm
{
    public class FriendModel : INotifyPropertyChanged
    {
        public int id { get; set; }
        public string first_name { get; set; } 
        public string last_name { get; set; }
        public string photo_100 { get; set; }
        public int online { get; set; }
        public string status { get; set; }
        public string nickname { get; set; }
        public string bdate { get; set; }
        public Country country { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}