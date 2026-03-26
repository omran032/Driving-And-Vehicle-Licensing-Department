using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System.Manage_Users.User_Control
{
    public partial class CtrlInfoUser : UserControl
    {

        public CtrlInfoUser( )
        {
            InitializeComponent();
        
        }
      


        Users user = new Users();

        // User عرض معلومات ال
       public void DesplaydInfoUser(Users user_)
        {
            if( user_ == null ) return;

            user = user_;
            lblUserID.Text       += user.IDUser;
            lblUserName.Text     += user.UserName;
            lblStatusAccont.Text += user.Status_Account;
            lblRole.Text         += user.Role;
            lblAuthrities.Text   += user.Authorities;
        }

    }
}
