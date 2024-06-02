using STKDotNetCore.Shared;

namespace STKDotNetCore.WinFormsAppSqlInjection
{
    public partial class Form1 : Form
    {
        private readonly DapperService _dapperService;
        public Form1()
        {
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //string query = $"select * from tbl_user where email='{txtEmail.Text.Trim()}' and password='{txtPassword.Text.Trim()}'"; // 123456' or 1=1 + '
            string query = $"select * from tbl_user where email = @Email and password = @Password"; 
            var model = _dapperService.QueryFirstOrDefault<UserModel>(query, new
            {
                Email = txtEmail.Text.Trim(),
                Password = txtPassword.Text.Trim()
            });

            if (model is null)
            {
                MessageBox.Show("User doesn't exist.");
                return;
            }

            //MessageBox.Show("Is Admin : " + model.Email);
            MessageBox.Show($"Is Admin : {model.Email}");
        }
    }

    public class UserModel
    {
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
