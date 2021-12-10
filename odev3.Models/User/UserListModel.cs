using System.Collections.Generic;

namespace odev3.Models.User
{
    public class UserListModel<T>
    {
        public List<T> userList { get; set; }
    }
}