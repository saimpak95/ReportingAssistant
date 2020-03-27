namespace ReportingAssistant.ViewModel
{
    public class UserViewModel
    {
        public int UserID { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public int IsAdmin { get; set; }
    }
}