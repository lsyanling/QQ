namespace QQ
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.SendMessageButton = new System.Windows.Forms.Button();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.MessagesFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.IPSettingsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.DestinationIPTextBox = new System.Windows.Forms.TextBox();
            this.DestinationPortTextBox = new System.Windows.Forms.TextBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DestinationIPTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.DestinationPortTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.LocalConfigTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.LocalConfigIPTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.LocalIPTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.LocalConfigPortTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.LocalPortTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.GapTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.ConnectLogTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.ConnectStatusTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.IPSettingsFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SendMessageButton
            // 
            resources.ApplyResources(this.SendMessageButton, "SendMessageButton");
            this.SendMessageButton.Name = "SendMessageButton";
            this.SendMessageButton.UseVisualStyleBackColor = true;
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.AcceptsReturn = true;
            this.MessageTextBox.AcceptsTab = true;
            this.MessageTextBox.AllowDrop = true;
            this.MessageTextBox.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.MessageTextBox, "MessageTextBox");
            this.MessageTextBox.Name = "MessageTextBox";
            // 
            // MessagesFlowLayoutPanel
            // 
            this.MessagesFlowLayoutPanel.BackColor = System.Drawing.SystemColors.Window;
            this.MessagesFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.MessagesFlowLayoutPanel, "MessagesFlowLayoutPanel");
            this.MessagesFlowLayoutPanel.Name = "MessagesFlowLayoutPanel";
            // 
            // IPSettingsFlowLayoutPanel
            // 
            this.IPSettingsFlowLayoutPanel.Controls.Add(this.DestinationIPTextBoxReadOnly);
            this.IPSettingsFlowLayoutPanel.Controls.Add(this.DestinationIPTextBox);
            this.IPSettingsFlowLayoutPanel.Controls.Add(this.DestinationPortTextBoxReadOnly);
            this.IPSettingsFlowLayoutPanel.Controls.Add(this.DestinationPortTextBox);
            this.IPSettingsFlowLayoutPanel.Controls.Add(this.ConnectButton);
            this.IPSettingsFlowLayoutPanel.Controls.Add(this.LocalConfigTextBoxReadOnly);
            this.IPSettingsFlowLayoutPanel.Controls.Add(this.LocalConfigIPTextBoxReadOnly);
            this.IPSettingsFlowLayoutPanel.Controls.Add(this.LocalIPTextBoxReadOnly);
            this.IPSettingsFlowLayoutPanel.Controls.Add(this.LocalConfigPortTextBoxReadOnly);
            this.IPSettingsFlowLayoutPanel.Controls.Add(this.LocalPortTextBoxReadOnly);
            this.IPSettingsFlowLayoutPanel.Controls.Add(this.GapTextBoxReadOnly);
            this.IPSettingsFlowLayoutPanel.Controls.Add(this.ConnectStatusTextBoxReadOnly);
            this.IPSettingsFlowLayoutPanel.Controls.Add(this.ConnectLogTextBoxReadOnly);
            resources.ApplyResources(this.IPSettingsFlowLayoutPanel, "IPSettingsFlowLayoutPanel");
            this.IPSettingsFlowLayoutPanel.Name = "IPSettingsFlowLayoutPanel";
            // 
            // DestinationIPTextBox
            // 
            resources.ApplyResources(this.DestinationIPTextBox, "DestinationIPTextBox");
            this.DestinationIPTextBox.Name = "DestinationIPTextBox";
            // 
            // DestinationPortTextBox
            // 
            resources.ApplyResources(this.DestinationPortTextBox, "DestinationPortTextBox");
            this.DestinationPortTextBox.Name = "DestinationPortTextBox";
            // 
            // ConnectButton
            // 
            resources.ApplyResources(this.ConnectButton, "ConnectButton");
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.UseVisualStyleBackColor = true;
            // 
            // DestinationIPTextBoxReadOnly
            // 
            this.DestinationIPTextBoxReadOnly.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.DestinationIPTextBoxReadOnly, "DestinationIPTextBoxReadOnly");
            this.DestinationIPTextBoxReadOnly.Name = "DestinationIPTextBoxReadOnly";
            this.DestinationIPTextBoxReadOnly.ReadOnly = true;
            // 
            // DestinationPortTextBoxReadOnly
            // 
            this.DestinationPortTextBoxReadOnly.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.DestinationPortTextBoxReadOnly, "DestinationPortTextBoxReadOnly");
            this.DestinationPortTextBoxReadOnly.Name = "DestinationPortTextBoxReadOnly";
            this.DestinationPortTextBoxReadOnly.ReadOnly = true;
            // 
            // LocalConfigTextBoxReadOnly
            // 
            this.LocalConfigTextBoxReadOnly.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.LocalConfigTextBoxReadOnly, "LocalConfigTextBoxReadOnly");
            this.LocalConfigTextBoxReadOnly.Name = "LocalConfigTextBoxReadOnly";
            this.LocalConfigTextBoxReadOnly.ReadOnly = true;
            // 
            // LocalConfigIPTextBoxReadOnly
            // 
            this.LocalConfigIPTextBoxReadOnly.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.LocalConfigIPTextBoxReadOnly, "LocalConfigIPTextBoxReadOnly");
            this.LocalConfigIPTextBoxReadOnly.Name = "LocalConfigIPTextBoxReadOnly";
            this.LocalConfigIPTextBoxReadOnly.ReadOnly = true;
            // 
            // LocalIPTextBoxReadOnly
            // 
            this.LocalIPTextBoxReadOnly.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.LocalIPTextBoxReadOnly, "LocalIPTextBoxReadOnly");
            this.LocalIPTextBoxReadOnly.Name = "LocalIPTextBoxReadOnly";
            this.LocalIPTextBoxReadOnly.ReadOnly = true;
            // 
            // LocalConfigPortTextBoxReadOnly
            // 
            this.LocalConfigPortTextBoxReadOnly.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.LocalConfigPortTextBoxReadOnly, "LocalConfigPortTextBoxReadOnly");
            this.LocalConfigPortTextBoxReadOnly.Name = "LocalConfigPortTextBoxReadOnly";
            this.LocalConfigPortTextBoxReadOnly.ReadOnly = true;
            // 
            // LocalPortTextBoxReadOnly
            // 
            this.LocalPortTextBoxReadOnly.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.LocalPortTextBoxReadOnly, "LocalPortTextBoxReadOnly");
            this.LocalPortTextBoxReadOnly.Name = "LocalPortTextBoxReadOnly";
            this.LocalPortTextBoxReadOnly.ReadOnly = true;
            // 
            // GapTextBoxReadOnly
            // 
            this.GapTextBoxReadOnly.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.GapTextBoxReadOnly, "GapTextBoxReadOnly");
            this.GapTextBoxReadOnly.Name = "GapTextBoxReadOnly";
            this.GapTextBoxReadOnly.ReadOnly = true;
            // 
            // ConnectLogTextBoxReadOnly
            // 
            this.ConnectLogTextBoxReadOnly.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.ConnectLogTextBoxReadOnly, "ConnectLogTextBoxReadOnly");
            this.ConnectLogTextBoxReadOnly.Name = "ConnectLogTextBoxReadOnly";
            this.ConnectLogTextBoxReadOnly.ReadOnly = true;
            // 
            // ConnectStatusTextBoxReadOnly
            // 
            this.ConnectStatusTextBoxReadOnly.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.ConnectStatusTextBoxReadOnly, "ConnectStatusTextBoxReadOnly");
            this.ConnectStatusTextBoxReadOnly.Name = "ConnectStatusTextBoxReadOnly";
            this.ConnectStatusTextBoxReadOnly.ReadOnly = true;
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.IPSettingsFlowLayoutPanel);
            this.Controls.Add(this.MessagesFlowLayoutPanel);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.SendMessageButton);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.IPSettingsFlowLayoutPanel.ResumeLayout(false);
            this.IPSettingsFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendMessageButton;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.FlowLayoutPanel MessagesFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel IPSettingsFlowLayoutPanel;
        private System.Windows.Forms.TextBox DestinationIPTextBox;
        private System.Windows.Forms.TextBox DestinationPortTextBox;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.TextBox DestinationIPTextBoxReadOnly;
        private System.Windows.Forms.TextBox DestinationPortTextBoxReadOnly;
        private System.Windows.Forms.TextBox LocalConfigTextBoxReadOnly;
        private System.Windows.Forms.TextBox LocalConfigIPTextBoxReadOnly;
        private System.Windows.Forms.TextBox LocalIPTextBoxReadOnly;
        private System.Windows.Forms.TextBox LocalConfigPortTextBoxReadOnly;
        private System.Windows.Forms.TextBox LocalPortTextBoxReadOnly;
        private System.Windows.Forms.TextBox GapTextBoxReadOnly;
        private System.Windows.Forms.TextBox ConnectLogTextBoxReadOnly;
        private System.Windows.Forms.TextBox ConnectStatusTextBoxReadOnly;
    }
}

