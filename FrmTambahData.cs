using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace AddressBookBetter
{
    public partial class FrmTambahData : Form
    {
        bool _result = false;
        bool _addMode = false; 
        string _editData;
        int _row;

        public bool Run(FrmTambahData form)
        {
            form.ShowDialog();
            return _result;
        }

        private void FrmTambahData_Load(object sender, EventArgs e)
        {
            if (!_addMode) { 
            string[] arrData = _editData.Split(';');
            txtNama.Text = arrData[0];
            txtAlamat.Text = arrData[1];
            txtKota.Text = arrData[2];
            txtNoHp.Text = arrData[3];
            dtpTglLahir.Text = arrData[4];
            txtEmail.Text = arrData[5];
            }
        }

        public FrmTambahData(bool addMode, string editData, int row)
        {
            InitializeComponent();
            _addMode = addMode;
            _editData = editData;
            _row = row;
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNoHp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private bool EmailIsValid(string emailAddr)
        {
            string emailPattern1 = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex regex = new Regex(emailPattern1);
            Match match = regex.Match(emailAddr);
            return match.Success;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (this.txtEmail.Text.Trim() != "")
            {
                if (!EmailIsValid(this.txtEmail.Text))
                {
                    MessageBox.Show("Sorry, data E-mail tidak valid...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtEmail.Clear();
                    this.txtEmail.Focus();
                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            
            if (txtNama.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, nama wajib di isi.");
                txtNama.Focus();
            }
            else if (txtAlamat.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, alamat wajib di isi.");
                txtAlamat.Focus();
            }
            else if (txtKota.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, kota wajib di isi.");
                txtKota.Focus();
            }
            else if (txtNoHp.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, no.hp wajib di isi.");
                txtNoHp.Focus();
            }
            else if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, email wajib di isi.");
                txtEmail.Focus();
            }
            else if (txtEmail.Text.Trim() == "") {
                MessageBox.Show("Sorry, E-mail tidak valid.");
                txtEmail.Focus();
            }
            else
            {
                AddressBookController address = new AddressBookController();
                address.AddItem(_editData.Split(';'), _addMode, _row);
                
                this.Close();

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
