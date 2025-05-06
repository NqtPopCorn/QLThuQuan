using System.Windows.Forms;
using QLThuQuan.Winforms.Controls;

namespace QLThuQuan.Winforms
{
    public partial class Dashboard : Form
    {

        private Dictionary<Button, UserControl> navMap;
        private Button currentSelectedButton;
        private UCThietBi ucThietBi;
        private QLDatMuon ucDatMuon;
        private UCQuyTac ucQuyTac;
        private UCThongKe ucThongKe;
        private QLMuonTra ucMuonTra;
        private UCUser ucUser;
        private UCViPham UCViPham;

        public Dashboard(UCThietBi uCThietBi, QLDatMuon ucDatMuon, UCQuyTac uCQuyTac, UCThongKe ucThongKe, QLMuonTra ucMuonTra, UCUser ucUser, UCViPham uCViPham)
        {
            this.ucThietBi = uCThietBi;
            this.ucDatMuon = ucDatMuon;
            this.ucQuyTac = uCQuyTac;
            this.ucThongKe = ucThongKe;
            this.ucMuonTra = ucMuonTra;
            this.ucUser = ucUser;
            this.UCViPham = uCViPham;

            InitializeComponent();

            SetUpNavigations();
        }

        private void ShowControl(UserControl control)
        {
            if (control == null)
            {
                MessageBox.Show("Control is null");
                return; // Không làm gì nếu control là null
            }

            control.Dock = DockStyle.Fill;
            cardPanel.Controls.Clear();
            cardPanel.Controls.Add(control);
        }

        private void SetUpNavigations()
        {
            navMap = new Dictionary<Button, UserControl>() {
                { btnThietBi, ucThietBi },
                { btnQLDatMuon, ucDatMuon },
                { btnQLMuonTra, ucMuonTra },
                { btnTK, ucThongKe },
                { btnUser, ucUser },
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {

        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
