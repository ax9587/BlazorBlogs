using System.Collections.Generic;

namespace BlazorBlog.Client.ViewModel
{
    public class ManageUserCategoryViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public IList<UserCategoryViewModel> UserCategories { get; set; }
    }
    public class UserCategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool Selected { get; set; }
    }
}
