namespace ClipIt
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxMenuStripNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dlvClips = new BrightIdeasSoftware.DataListView();
            this.olvColValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ctxMenuStripNotify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlvClips)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipTitle = "ClipIt";
            this.notifyIcon.ContextMenuStrip = this.ctxMenuStripNotify;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "ClipIt";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // ctxMenuStripNotify
            // 
            this.ctxMenuStripNotify.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.ctxMenuStripNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem,
            this.toolStripSeparator1});
            this.ctxMenuStripNotify.Name = "ctxMenuStripNotify";
            this.ctxMenuStripNotify.Size = new System.Drawing.Size(191, 56);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(327, 46);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(324, 6);
            // 
            // dlvClips
            // 
            this.dlvClips.AllColumns.Add(this.olvColValue);
            this.dlvClips.AutoGenerateColumns = false;
            this.dlvClips.CellEditUseWholeCell = false;
            this.dlvClips.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColValue});
            this.dlvClips.DataSource = null;
            this.dlvClips.FullRowSelect = true;
            this.dlvClips.GridLines = true;
            this.dlvClips.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.dlvClips.Location = new System.Drawing.Point(13, 13);
            this.dlvClips.Name = "dlvClips";
            this.dlvClips.SelectAllOnControlA = false;
            this.dlvClips.ShowGroups = false;
            this.dlvClips.ShowSortIndicators = false;
            this.dlvClips.Size = new System.Drawing.Size(1018, 747);
            this.dlvClips.TabIndex = 1;
            this.dlvClips.UseCompatibleStateImageBehavior = false;
            this.dlvClips.View = System.Windows.Forms.View.Details;
            // 
            // olvColValue
            // 
            this.olvColValue.AspectName = "Value";
            this.olvColValue.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1043, 772);
            this.Controls.Add(this.dlvClips);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClipIt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ctxMenuStripNotify.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dlvClips)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip ctxMenuStripNotify;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private BrightIdeasSoftware.DataListView dlvClips;
        private BrightIdeasSoftware.OLVColumn olvColValue;
    }
}

