﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PABPProjekat1.src.DB;

namespace PABPProjekat1.src.Login
{
    public partial class LoginForm : Form
    {
        // Aleksa: placeholder for username and password, reference http://stackoverflow.com/questions/11873378/adding-placeholder-text-to-textbox
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        public LoginForm()
        {
            InitializeComponent();

            // Aleksa: this can be used maybe somewhere else
            // int b = Screen.PrimaryScreen.Bounds.Height / 2;
            // int a = Screen.PrimaryScreen.Bounds.Width / 2;
            // Point displayCenterPoint = new Point(a, b);
            // this.Location = displayCenterPoint;

            // Aleksa: positioning form to the center of the display
            this.StartPosition = FormStartPosition.CenterScreen;

            // Aleksa: placeholder for username and password
            SendMessage(tbUsername.Handle, EM_SETCUEBANNER, 0, "Username");
            SendMessage(tbPassword.Handle, EM_SETCUEBANNER, 0, "Password");

            // Aleksa: password inputed characters will be displayed as *
            tbPassword.PasswordChar = '*';
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Aleksa: proceed with closing the application
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Login button clicked!");
            this.Login();
        }

        private void Login()
        {
            if(tbUsername.Text == String.Empty)
            {
                MessageBox.Show("Input your username first!");
                return;
            }
            
            if (tbPassword.Text == String.Empty)
            {
                MessageBox.Show("Input your password first!");
                return;
            }

            // Aleksa TODO: create label (*) and red frame around box if box is empty
            // if (!this.ValidateTextBoxes(tbUsername, tbPassword))
            // {
            //     MessageBox.Show("Input your credentials first!");
            //     return;
            // }

            // MessageBox.Show(tbUsername.Text);
            // MessageBox.Show(tbPassword.Text);

            try
            {
                Suppliers suppliers = new Suppliers();
                Supplier supplier = suppliers.GetSupplier(tbUsername.Text);

                if (supplier != null)
                {
                    if (string.Equals(tbPassword.Text, supplier.Password))
                    {
                        // Aleksa TODO: proceed with login
                        MessageBox.Show("Login successful!");
                    }
                    else
                    {
                        MessageBox.Show("Password is incorrect!");
                    }
                }
                else
                {
                    MessageBox.Show("Username is incorrect!");
                }
                
            }
            catch(Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
            }

        }

        private bool ValidateTextBoxes(params TextBox[] textBoxes)
        {
            bool value = true;

            foreach (var textBox in textBoxes)
            {
                if (textBox.Text.Equals(String.Empty))
                {
                    value = false;

                    Label lblHighlight = new Label();
                    Rectangle rc = new Rectangle(textBox.Left - 2, textBox.Top - 2, textBox.Width + 4, textBox.Bottom - textBox.Top + 4);
                    textBox.Parent.Controls.Add(lblHighlight);
                    lblHighlight.Bounds = rc;

                    lblHighlight.BackColor = Color.Red;

                }
            }

            return value;
        }
    }
}