using EventHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ClipIt
{
    public partial class MainForm : Form
    {
        private BindingList<KeyValuePair<Guid, string>> Clips = new BindingList<KeyValuePair<Guid, string>>();
        private const int MenuTextLength = 50;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ClipboardWatcher.OnClipboardModified += ClipboardWatcher_OnClipboardModified;
            ClipboardWatcher.Start();

            ctxMenuStripNotify.ItemClicked += CtxMenuStripNotify_ItemClicked;
            Clips.ListChanged += Clips_ListChanged;

            dlvClips.DataSource = Clips;
            dlvClips.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void Clips_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.Reset:
                    break;
                case ListChangedType.ItemAdded:
                    Invoke((Action)(() => {
                        var item = Clips[e.NewIndex];

                        // limit the size of the menu item
                        string formattedText = item.Value.Replace(Environment.NewLine, " ");
                        if (formattedText.Length > MenuTextLength)
                            formattedText = $"{formattedText.Substring(0, MenuTextLength)}...";

                        ctxMenuStripNotify.Items.Add(new ToolStripMenuItem(formattedText) { Tag = item.Key });
                    }));
                    break;
                case ListChangedType.ItemDeleted:
                    Invoke((Action)(() => {
                        var item = Clips[e.OldIndex];

                        // remove the menu item by guid
                        var menu = ctxMenuStripNotify.Items.OfType<ToolStripMenuItem>()
                                    .Where(i => i.Tag != null && (Guid)i.Tag == item.Key)
                                    .FirstOrDefault();

                        ctxMenuStripNotify.Items.Remove(menu);
                    }));
                    break;
                case ListChangedType.ItemMoved:
                    break;
                case ListChangedType.ItemChanged:
                    break;
                case ListChangedType.PropertyDescriptorAdded:
                    break;
                case ListChangedType.PropertyDescriptorDeleted:
                    break;
                case ListChangedType.PropertyDescriptorChanged:
                    break;
                default:
                    break;
            }
        }
        
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                Hide();
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClipboardWatcher.Stop();
        }
        
        private void CtxMenuStripNotify_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem != quitToolStripMenuItem)
            {
                // get the full item
                var item = Clips.Where(c => c.Key == (Guid)e.ClickedItem.Tag).FirstOrDefault();

                ClipboardWatcher.Stop();
                Clipboard.SetText(item.Value);
                ClipboardWatcher.Start();
                
                // remove it from the current position and add to the end (latest)
                Clips.Remove(item);
                Clips.Add(item);
            }
        }

        private void ClipboardWatcher_OnClipboardModified(object sender, ClipboardEventArgs e)
        {
            Invoke((Action)(() =>
            {
                Clips.Add(new KeyValuePair<Guid, string>(Guid.NewGuid(), (string)e.Data));
            }));
        }
        
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }
    }
}
