using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lambdawg
{
    public class TabControlHandler
    {
        private TabControl tabControl;

        public TabControlHandler(TabControl tabControl)
        {
            this.tabControl = tabControl;
        }

        public void InitializeTabControl()
        {
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.DrawItem += TabControl_DrawItem;
            tabControl.MouseDown += TabControl_MouseDown;
        }

        public void OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                TabPage newTab = new TabPage(Path.GetFileName(openFileDialog.FileName));
                TextBox fileTextBox = new TextBox
                {
                    Multiline = true,
                    Dock = DockStyle.Fill,
                    ScrollBars = ScrollBars.Both
                };

                try
                {
                    string fileContent = File.ReadAllText(openFileDialog.FileName);
                    fileTextBox.Text = fileContent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening file: " + ex.Message);
                }

                newTab.Controls.Add(fileTextBox);
                tabControl.TabPages.Add(newTab);
                tabControl.SelectedTab = newTab;
            }
        }

        public void SaveFileDialog()
        {
            if (tabControl.SelectedTab != null)
            {
                TextBox activeTextBox = tabControl.SelectedTab.Controls.OfType<TextBox>().FirstOrDefault();
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

        private void TabControl_DrawItem(object? sender, DrawItemEventArgs e)
        {
            TabPage tabPage = tabControl.TabPages[e.Index];
            string tabText = tabPage.Text;

            e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            e.Graphics.DrawString(tabText, e.Font, Brushes.Black, e.Bounds.Left + 10, e.Bounds.Top + 5);

            Rectangle closeButtonBounds = new Rectangle(e.Bounds.Right - 20, e.Bounds.Top + 5, 15, 15);
            e.Graphics.DrawString("x", e.Font, Brushes.Black, closeButtonBounds);
        }

        private void TabControl_MouseDown(object? sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControl.TabCount; i++)
            {
                Rectangle closeButtonBounds = new Rectangle(tabControl.GetTabRect(i).Right - 20, tabControl.GetTabRect(i).Top + 5, 15, 15);
                if (closeButtonBounds.Contains(e.Location))
                {
                    tabControl.TabPages.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
