using EventHook;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ClipIt
{
    public partial class MainForm : Form
    {
        private ObservableCollection<KeyValuePair<Guid, string>> Clips = new ObservableCollection<KeyValuePair<Guid,string>>();
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ClipboardWatcher.OnClipboardModified += ClipboardWatcher_OnClipboardModified;
            ClipboardWatcher.Start();
            ctxMenuStripNotify.ItemClicked += CtxMenuStripNotify_ItemClicked;
            Clips.CollectionChanged += Clips_CollectionChanged;
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

        private void Clips_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Invoke((Action)(() => {
                        var item = (KeyValuePair<Guid, string>)e.NewItems[0];

                        // limit the size of the menu item
                        string formattedText = item.Value.Replace(Environment.NewLine, " ");
                        if (formattedText.Length > 20)
                            formattedText = $"{formattedText.Substring(0, 20)}...";
                        
                        ctxMenuStripNotify.Items.Add(new ToolStripMenuItem(formattedText) { Tag = item.Key });
                    }));
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Invoke((Action)(() => {
                        var item = (KeyValuePair<Guid, string>)e.OldItems[0];
                        
                        // remove the menu item by guid
                        var menu = ctxMenuStripNotify.Items.OfType<ToolStripMenuItem>()
                                    .Where(i => i.Tag != null && (Guid)i.Tag == item.Key)
                                    .FirstOrDefault();

                        ctxMenuStripNotify.Items.Remove(menu); 
                    }));
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
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
            Clips.Add(new KeyValuePair<Guid, string>(Guid.NewGuid(), (string)e.Data));
        }
        
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Show();
            ShowInTaskbar = true;
        }
    }
}
