using System.Windows.Forms;

namespace QL_ThuQuan
{
    public partial class Form1 : Form
    {

        private Dictionary<Button, UserControl> navMap;
        private Button currentSelectedButton;

        public Form1()
        {
            InitializeComponent();

            SetUpNavigations();
            
        }

        private void ShowControl(UserControl control)
        {
            control.Dock = DockStyle.Fill;
            cardPanel.Controls.Clear(); 
            cardPanel.Controls.Add(control); 
        }

        private void SetUpNavigations()
        {
            navMap = new Dictionary<Button, UserControl>() {
                { button1, new UCQuyTac() },
                { button2, new UCViPham() },
                { button3, new UCThongKe() },
            };

            foreach (var entry in navMap)
            {
                Button btn = entry.Key;
                UserControl ctrl = entry.Value;

                btn.Click += (s, e) =>
                {
                    ShowControl(ctrl);
                    SetSelectedButton(btn);
                };
            }
        }

        private void SetSelectedButton(Button selectedBtn)
        {
            foreach (var btn in navMap.Keys)
            {
                btn.BackColor = SystemColors.Control; 
            }

            selectedBtn.BackColor = Color.LightBlue;
            currentSelectedButton = selectedBtn;
        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
