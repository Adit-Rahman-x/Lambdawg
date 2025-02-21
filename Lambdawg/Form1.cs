using System;
using System.IO;
using System.Windows.Forms;

namespace Lambdawg;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        InitializeTreeView();
    }

    private void InitializeTreeView()
    {
        DriveInfo[] drives = DriveInfo.GetDrives(); // Set root node to show drives
        foreach (var drive in drives)
        {
            TreeNode rootNode = new TreeNode(drive.Name);
            rootNode.Tag = drive.Name; // Store drive path in Tag
            treeView1.Nodes.Add(rootNode);
            PopulateTreeView(drive.Name, rootNode);  // Add folders to the drive
        }

        // Event to handle when a node is clicked
        treeView1.NodeMouseClick += TreeView1_NodeMouseClick;
    }

    // Top of the Page Menu
    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            // Create a new TabPage for the file
            TabPage newTab = new TabPage(Path.GetFileName(openFileDialog.FileName));
            TextBox fileTextBox = new TextBox();
            fileTextBox.Multiline = true;
            fileTextBox.Dock = DockStyle.Fill; // Fill the tab with the TextBox
            fileTextBox.ScrollBars = ScrollBars.Both;

            try // Read the file content and set it in the TextBox
            {
                string fileContent = File.ReadAllText(openFileDialog.FileName);
                fileTextBox.Text = fileContent;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening file: " + ex.Message);
            }

            newTab.Controls.Add(fileTextBox); // Add the TextBox to the new TabPage

            tabControl1.TabPages.Add(newTab); // Add the new TabPage to the TabControl
            tabControl1.SelectedTab = newTab; // Switch to the newly opened tab
        }
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    { // heavily nested :( 
        if (tabControl1.SelectedTab != null) 
        {
            TextBox activeTextBox = tabControl1.SelectedTab.Controls.OfType<TextBox>().FirstOrDefault();
            if (activeTextBox != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(saveFileDialog.FileName, activeTextBox.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving file: " + ex.Message);
                    }
                }
            }
        }
    }


    // Tree Stuff for File Explorer
    private void PopulateTreeView(string path, TreeNode parentNode)
    {
        try
        {
            string[] directories = Directory.GetDirectories(path);
            foreach (string directory in directories)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                TreeNode node = new TreeNode(directoryInfo.Name);
                node.Tag = directory; // Store folder path in Tag
                parentNode.Nodes.Add(node);
                PopulateTreeView(directory, node); // Recursively add subdirectories
            }

            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                TreeNode fileNode = new TreeNode(fileInfo.Name);
                fileNode.Tag = file;
                parentNode.Nodes.Add(fileNode);  // Add file node
            }
        }
        catch (UnauthorizedAccessException)
        {
            // Handle cases where access is denied to a directory
            // I don't know what do for now
        }
    }
    private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Open FolderBrowserDialog to let the user select a directory
        FolderBrowserDialog folderDialog = new FolderBrowserDialog();
        if (folderDialog.ShowDialog() == DialogResult.OK)
        {
            string selectedPath = folderDialog.SelectedPath;
            treeView1.Nodes.Clear();  // Clear existing nodes
            TreeNode rootNode = new TreeNode(selectedPath);
            rootNode.Tag = selectedPath;
            treeView1.Nodes.Add(rootNode);
            PopulateTreeView(selectedPath, rootNode);
        }
    }

    private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        string filePath = e.Node.Tag as string;
        if (filePath != null && File.Exists(filePath))  // Check if it's a file
        {
            // Open the file here (e.g., in a TextBox or external editor)
            OpenFileInTab(filePath);
        }
    }

    // Open the selected file
    private void OpenFileInTab(string filePath)
    {
        // Create a new TabPage
        TabPage newTab = new TabPage(Path.GetFileName(filePath));
        TextBox fileTextBox = new TextBox();
        fileTextBox.Multiline = true;
        fileTextBox.Dock = DockStyle.Fill;  // Fill the tab with the TextBox
        fileTextBox.ScrollBars = ScrollBars.Both;
        newTab.Controls.Add(fileTextBox);  // Add TextBox to the TabPage

        // Read file contents and set it in the TextBox
        try
        {
            string fileContent = File.ReadAllText(filePath);
            fileTextBox.Text = fileContent;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error opening file: " + ex.Message);
        }

        // Add the new TabPage to the TabControl
        tabControl1.TabPages.Add(newTab);
        tabControl1.SelectedTab = newTab;  // Switch to the newly opened tab
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
