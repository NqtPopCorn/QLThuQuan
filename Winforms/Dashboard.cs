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
        private QLMuonTra ucMuonTra;

        public Dashboard(UCThietBi uCThietBi, QLDatMuon ucDatMuon, QLMuonTra ucMuonTra)
        {
            this.ucThietBi = uCThietBi;
            this.ucDatMuon = ucDatMuon;
            this.ucMuonTra = ucMuonTra;

            InitializeComponent();

            SetUpNavigations();
            this.ucDatMuon = ucDatMuon;
            this.ucMuonTra = ucMuonTra;
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
                { btnThietBi, ucThietBi },
                { btnQLDatMuon, ucDatMuon },
                { btnQLMuonTra, ucMuonTra },
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
    }
}
