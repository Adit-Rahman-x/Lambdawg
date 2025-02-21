using System;
using System.IO;
using System.Windows.Forms;

namespace Lambdawg;

public partial class Form1 : Form
{
    private FileExplorer fileExplorer;
    private TabControlHandler tabControlHandler;
    public Form1()
    {
        InitializeComponent();
        fileExplorer = new FileExplorer(treeView1);
        tabControlHandler = new TabControlHandler(tabControl1);

        fileExplorer.InitializeTreeView();
        tabControlHandler.InitializeTabControl();
    }
    public void OpenFileInTab(string filePath)
    {
        // Implementation to open the file in a new tab
        TabPage newTab = new TabPage(Path.GetFileName(filePath));
        TextBox textBox = new TextBox
        {
            Multiline = true,
            Dock = DockStyle.Fill,
            Text = File.ReadAllText(filePath)
        };
        newTab.Controls.Add(textBox);
        tabControl1.TabPages.Add(newTab);
        tabControl1.SelectedTab = newTab;
    }

    private void openToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        tabControlHandler.OpenFileDialog();
    }

    private void saveToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        tabControlHandler.SaveFileDialog();
    }

    private void openFolderToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        fileExplorer.OpenFolderDialog();
    }

    // Useless stuff for now?
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        // I do nothing, I am useless. For now. 
    }

    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {

    }

    private void tabPage1_Click(object sender, EventArgs e)
    {

    }
}
