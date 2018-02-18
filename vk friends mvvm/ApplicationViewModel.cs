using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using xNet;
using System;
using Newtonsoft.Json;
using System.Windows;

namespace vk_friends_mvvm
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private FriendModel selectedPhone;
        private string token = "6e5aacc6649fc26df37056d7427fb0ee7f18cc33be5510c7697fb0615f0d017438808685183ccc6444c5c";

        public ObservableCollection<FriendModel> friends { get; set; }

        public FriendModel SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public ApplicationViewModel()
        {
            getFriends();
        }

        public void getFriends()
        {
            string user = "144344092";
            string res = String.Empty;

            try
            {
                using (var request = new HttpRequest())
                {
                    var urlParams = new RequestParams();

                    string url = String.Format("https://api.vk.com/method/friends.get?fields=photo_100,nickname,bdate,country,status&count=10&user_id={0}&access_token={1}&v=5.73", user, token);

                    res = request.Get(url).ToString();
                }

                Data d = JsonConvert.DeserializeObject<Data>(res);
               
                friends = d.response.items;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}