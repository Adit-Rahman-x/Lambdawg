namespace Lambdawg;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        panel3 = new Panel();
        tabControl1 = new TabControl();
        tabPage1 = new TabPage();
        panel1 = new Panel();
        menuStrip3 = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        saveToolStripMenuItem = new ToolStripMenuItem();
        openFolderToolStripMenuItem = new ToolStripMenuItem();
        openToolStripMenuItem = new ToolStripMenuItem();
        panel2 = new Panel();
        treeView1 = new TreeView();
        panel3.SuspendLayout();
        tabControl1.SuspendLayout();
        panel1.SuspendLayout();
        menuStrip3.SuspendLayout();
        panel2.SuspendLayout();
        SuspendLayout();
        // 
        // panel3
        // 
        panel3.Anchor = AnchorStyles.Right;
        panel3.Controls.Add(tabControl1);
        panel3.Location = new Point(330, 62);
        panel3.Margin = new Padding(0);
        panel3.Name = "panel3";
        panel3.Size = new Size(915, 630);
        panel3.TabIndex = 4;
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(tabPage1);
        tabControl1.Dock = DockStyle.Bottom;
        tabControl1.ItemSize = new Size(126, 25);
        tabControl1.Location = new Point(0, 3);
        tabControl1.Name = "tabControl1";
        tabControl1.Padding = new Point(20, 3);
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(915, 627);
        tabControl1.TabIndex = 1;
        // 
        // tabPage1
        // 
        tabPage1.Location = new Point(4, 29);
        tabPage1.Name = "tabPage1";
        tabPage1.Padding = new Padding(3);
        tabPage1.Size = new Size(907, 594);
        tabPage1.TabIndex = 0;
        tabPage1.Text = "unnamed_file.ldg";
        tabPage1.UseVisualStyleBackColor = true;
        tabPage1.Click += tabPage1_Click;
        // 
        // panel1
        // 
        panel1.BackColor = SystemColors.MenuHighlight;
        panel1.Controls.Add(menuStrip3);
        panel1.Location = new Point(12, 9);
        panel1.Margin = new Padding(0);
        panel1.Name = "panel1";
        panel1.Size = new Size(1233, 46);
        panel1.TabIndex = 2;
        // 
        // menuStrip3
        // 
        menuStrip3.BackColor = SystemColors.ButtonHighlight;
        menuStrip3.Dock = DockStyle.Fill;
        menuStrip3.ImageScalingSize = new Size(20, 20);
        menuStrip3.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
        menuStrip3.Location = new Point(0, 0);
        menuStrip3.Name = "menuStrip3";
        menuStrip3.Size = new Size(1233, 46);
        menuStrip3.TabIndex = 0;
        menuStrip3.Text = "menuStrip3";
        // 
        // fileToolStripMenuItem
        // 
        fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, openFolderToolStripMenuItem, openToolStripMenuItem });
        fileToolStripMenuItem.Margin = new Padding(3);
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new Size(46, 36);
        fileToolStripMenuItem.Text = "File";
        // 
        // saveToolStripMenuItem
        // 
        saveToolStripMenuItem.Name = "saveToolStripMenuItem";
        saveToolStripMenuItem.Size = new Size(174, 26);
        saveToolStripMenuItem.Text = "Save";
        saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
        // 
        // openFolderToolStripMenuItem
        // 
        openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
        openFolderToolStripMenuItem.Size = new Size(174, 26);
        openFolderToolStripMenuItem.Text = "Open Folder";
        openFolderToolStripMenuItem.Click += openFolderToolStripMenuItem_Click;
        // 
        // openToolStripMenuItem
        // 
        openToolStripMenuItem.Name = "openToolStripMenuItem";
        openToolStripMenuItem.Size = new Size(174, 26);
        openToolStripMenuItem.Text = "Open File";
        openToolStripMenuItem.Click += openToolStripMenuItem_Click;
        // 
        // panel2
        // 
        panel2.Anchor = AnchorStyles.Left;
        panel2.Controls.Add(treeView1);
        panel2.Location = new Point(12, 62);
        panel2.Name = "panel2";
        panel2.Size = new Size(310, 630);
        panel2.TabIndex = 3;
        // 
        // treeView1
        // 
        treeView1.Dock = DockStyle.Bottom;
        treeView1.Location = new Point(0, 0);
        treeView1.Name = "treeView1";
        treeView1.Size = new Size(310, 630);
        treeView1.TabIndex = 0;
        treeView1.AfterSelect += treeView1_AfterSelect;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1250, 704);
        Controls.Add(panel3);
        Controls.Add(panel2);
        Controls.Add(panel1);
        MainMenuStrip = menuStrip3;
        Name = "Form1";
        Text = "Lambdawg IDE";
        panel3.ResumeLayout(false);
        tabControl1.ResumeLayout(false);
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        menuStrip3.ResumeLayout(false);
        menuStrip3.PerformLayout();
        panel2.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion
    private Panel panel1;
    private MenuStrip menuStrip2;
    private ToolStripMenuItem fileToolStripMenuItem1;
    private ToolStripMenuItem saveToolStripMenuItem1;
    private MenuStrip menuStrip3;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem saveToolStripMenuItem;
    private ToolStripMenuItem openToolStripMenuItem;
    private Panel panel2;
    private TreeView treeView1;
    private Panel panel3;
    private ToolStripMenuItem openFolderToolStripMenuItem;
    private TabControl tabControl1;
    private TabPage tabPage1;
}
