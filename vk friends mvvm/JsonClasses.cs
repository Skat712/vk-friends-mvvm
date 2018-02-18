using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_friends_mvvm
{
    public class Data
    {
        public Response response;
    }

    public class Response
    {
        public int count;
        public ObservableCollection<FriendModel> items;

    }

    public class Country
    {
        public int id { get; set; }
        public string title { get; set; }
    }
}

