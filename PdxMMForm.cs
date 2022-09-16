using Microsoft.VisualBasic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;

namespace PdxModManager
{
    public partial class PdxMMForm : Form
    {
        public PdxMMForm()
        {
            InitializeComponent();

            PdxMMHelper.PdxGame = PdxGames.EU_IV_EGS;

            bSourceModList.DataSource = PdxMMHelper.ModList;
            bSourceQueueList.DataSource = PdxMMHelper.Queue.ModQueue;

            dataGridInstalledMods.AutoGenerateColumns = false;
            dataGridInstalledMods.DataSource = bSourceModList;

            dataGridModQueue.AutoGenerateColumns = false;
            dataGridModQueue.DataSource = bSourceQueueList;
        }

        private async void Form_Load(object sender, EventArgs e)
        {
            txtPath.Text = PdxMMHelper.GetDocumentsGamePath();

            PdxMMHelper.ImportModsFromModDirectory();
        }

        private void dataGridMods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = dataGridInstalledMods.CurrentRow.Index;

            PdxMod mod = PdxMMHelper.ModList[selectedRow];

            picBoxMod.Image = Utils.LoadBitmap(PdxMMHelper.GetDocumentsGamePath() + "/mod/" + mod.fileId + "/" + mod.picture);

            lblInfoName.Text = mod.name;
            lblInfoSize.Text = "Size: " + mod.size;
            lblInfoVersion.Text = mod.version;
            lblInfoSupportedGameVersion.Text = "Game Version: " + mod.supportedGameVersion;
            lblInfoPublishedDate.Text = "Published: " + mod.publishedDate;
        }

        private void lblLinkInfoSteamWorkshop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int selectedRow = dataGridInstalledMods.CurrentRow.Index;

            PdxMod mod = (PdxMod)PdxMMHelper.ModList[selectedRow];

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("https://www.steamcommunity.com/sharedfiles/filedetails/?id=" + mod.fileId) { UseShellExecute = true });
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Status: Refreshing ...";

            PdxMMHelper.ImportModsFromModDirectory();

            lblStatus.Text = "Status: Idle";
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Status: Updating ...";

            await PdxMMHelper.RequestUpdateAllModsAsync(prgsBar);

            lblStatus.Text = "Status: Idle";
        }

        private async void btnForceUpdate_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Status: Forcing Update ...";

            DialogResult res = MessageBox.Show("Are you sure you want to force update in all your mods?", 
                "Confirmation", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res != DialogResult.Yes) return;

            await PdxMMHelper.RequestUpdateAllModsAsync(prgsBar, true);

            lblStatus.Text = "Status: Idle";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string clipboardText = Clipboard.GetText();
            if (!clipboardText.StartsWith("https://steamcommunity.com/sharedfiles/filedetails/?id=")) clipboardText = "";

            string input = Interaction.InputBox("Copy-paste here your steam workshop item url", "Add mod", clipboardText);
            if (input.Length == 0) return;

            string id = HttpUtility.ParseQueryString(new Uri(input).Query).Get("id");
            if (id == null)
            {
                MessageBox.Show("Wrong Steam workshop URL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnAdd_Click(sender, e);

                return;
            }

            long fileId = Int64.Parse(id);
            string zipPath = PdxMMHelper.GetDocumentsGamePath() + "/mod/" + fileId + ".zip";
            var progress = new Progress<float>(value => { prgsBar.Value = (int)value; });

            await SteamWorkshop.Downloader.RequestFile(fileId, zipPath, progress);
            await SteamWorkshop.Utils.Extract(fileId, zipPath, progress);
            await SteamWorkshop.Utils.SetupDescriptor(fileId);

            prgsBar.Value = 0;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridInstalledMods.CurrentRow.Index;

            PdxMod mod = (PdxMod)PdxMMHelper.ModList[selectedRow];

            DialogResult res = MessageBox.Show("Are you sure you want to delete " + mod.name + " mod?", 
                "Confirmation", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res != DialogResult.Yes) return;

            await SteamWorkshop.Utils.Delete(mod.fileId);
        }
    }
}