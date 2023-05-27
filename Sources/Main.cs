// Coded by Hadi Khoirudin, S.Kom.
// 
// Disclaimer :
// Cek IMEI ini menggunakan API dari repositori https://github.com/hunternblz/bulk-cek-imei-kemenperin.git
// Segala kesalahan maupun kegiatan yang berkaitan dengan pihak Kemenperin itu diluar tanggung jawab saya.
// Saya hanya sebatas menggunakan layanan yang disediakan publik oleh pihak penyedia layanan API tersebut
// Maka silahkan hubungi penyedia layanan API jika hal ini menyalahi aturan.

using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace iReverse_Check_IMEI_HadiK_IT
{
    public partial class Main : Form
    {
        WebClient wc = new WebClient();
        NameValueCollection dataToSend = new NameValueCollection();

        public Main()
        {
            InitializeComponent();
        }

        private void button_check_Click(object sender, EventArgs e)
        {
            if (textBox_imei.Text.Length == 15)
            {
                richTextBox_Log.Clear();

                dataToSend["imei"] = textBox_imei.Text;
                string GetData = Encoding.UTF8.GetString(wc.UploadValues(@"https://api.nabil.my.id/cekImeiKemenperin", dataToSend));

                richTextBox_Log.Text = GetData
                    .Replace("{", "")
                    .Replace("}", "")
                    .Replace("\"", "")
                    .Replace("status", "")
                    .Replace("success", "")
                    .Replace("failed", "")
                    .Replace("message", "")
                    .Replace(":", "")
                    .Replace(",", "")
                    .Replace("     ", "")
                    .Replace("\n", "");
            }
            else
            {
                const string message = "Silahkan Masukan 15 Digit Angka IMEI";
                const string caption = "Terjadi Kesalahan!";
                var result = MessageBox.Show(
                    message, caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            
        }
    }
}
