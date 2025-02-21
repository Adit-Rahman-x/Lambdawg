using System;
using System.IO;
using System.Windows.Forms;

namespace Lambdawg
{
    public class FileExplorer
    {
        private TreeView treeView;

        public FileExplorer(TreeView treeView)
        {
            this.treeView = treeView;
        }

        public void InitializeTreeView()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                TreeNode rootNode = new TreeNode(drive.Name);
                rootNode.Tag = drive.Name;
                treeView.Nodes.Add(rootNode);
                PopulateTreeView(drive.Name, rootNode);
            }

            treeView.NodeMouseClick += TreeView_NodeMouseClick;
        }

        public void OpenFolderDialog()
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = folderDialog.SelectedPath;
                treeView.Nodes.Clear();
                TreeNode rootNode = new TreeNode(selectedPath);
                rootNode.Tag = selectedPath;
                treeView.Nodes.Add(rootNode);
                PopulateTreeView(selectedPath, rootNode);
            }
        }

        private void PopulateTreeView(string path, TreeNode parentNode)
        {
            try
            {
                string[] directories = Directory.GetDirectories(path);
                foreach (string directory in directories)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                    TreeNode node = new TreeNode(directoryInfo.Name);
                    node.Tag = directory;
                    parentNode.Nodes.Add(node);
                    PopulateTreeView(directory, node);
                }

                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    TreeNode fileNode = new TreeNode(fileInfo.Name);
                    fileNode.Tag = file;
                    parentNode.Nodes.Add(fileNode);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Handle access issues
            }
        }

        private void TreeView_NodeMouseClick(object? sender, TreeNodeMouseClickEventArgs e)
        {
            string filePath = e.Node.Tag as string;
            if (filePath != null && File.Exists(filePath))
            {
                // Open file in the tab
                (sender as Form1)?.OpenFileInTab(filePath);
            }
        }
    }
}
