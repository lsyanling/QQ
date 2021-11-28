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
            this.SettingsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.DestinationIPTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.DestinationIPTextBox = new System.Windows.Forms.TextBox();
            this.DestinationPortTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.DestinationPortTextBox = new System.Windows.Forms.TextBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DisConnectButton = new System.Windows.Forms.Button();
            this.LocalConfigIPTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.LocalIPTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.LocalConfigPortTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.LocalPortTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.GapTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.ConnectStatusTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.ConnectLogTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.ConnectModeComboBox = new System.Windows.Forms.ComboBox();
            this.SendFileButton = new System.Windows.Forms.Button();
            this.SendVideoButton = new System.Windows.Forms.Button();
            this.SettingsFlowLayoutPanel.SuspendLayout();
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
            // SettingsFlowLayoutPanel
            // 
            this.SettingsFlowLayoutPanel.Controls.Add(this.ConnectModeComboBox);
            this.SettingsFlowLayoutPanel.Controls.Add(this.DestinationIPTextBoxReadOnly);
            this.SettingsFlowLayoutPanel.Controls.Add(this.DestinationIPTextBox);
            this.SettingsFlowLayoutPanel.Controls.Add(this.DestinationPortTextBoxReadOnly);
            this.SettingsFlowLayoutPanel.Controls.Add(this.DestinationPortTextBox);
            this.SettingsFlowLayoutPanel.Controls.Add(this.ConnectButton);
            this.SettingsFlowLayoutPanel.Controls.Add(this.DisConnectButton);
            this.SettingsFlowLayoutPanel.Controls.Add(this.LocalConfigIPTextBoxReadOnly);
            this.SettingsFlowLayoutPanel.Controls.Add(this.LocalIPTextBoxReadOnly);
            this.SettingsFlowLayoutPanel.Controls.Add(this.LocalConfigPortTextBoxReadOnly);
            this.SettingsFlowLayoutPanel.Controls.Add(this.LocalPortTextBoxReadOnly);
            this.SettingsFlowLayoutPanel.Controls.Add(this.GapTextBoxReadOnly);
            this.SettingsFlowLayoutPanel.Controls.Add(this.ConnectStatusTextBoxReadOnly);
            this.SettingsFlowLayoutPanel.Controls.Add(this.ConnectLogTextBoxReadOnly);
            resources.ApplyResources(this.SettingsFlowLayoutPanel, "SettingsFlowLayoutPanel");
            this.SettingsFlowLayoutPanel.Name = "SettingsFlowLayoutPanel";
            // 
            // DestinationIPTextBoxReadOnly
            // 
            this.DestinationIPTextBoxReadOnly.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.DestinationIPTextBoxReadOnly, "DestinationIPTextBoxReadOnly");
            this.DestinationIPTextBoxReadOnly.Name = "DestinationIPTextBoxReadOnly";
            this.DestinationIPTextBoxReadOnly.ReadOnly = true;
            // 
            // DestinationIPTextBox
            // 
            resources.ApplyResources(this.DestinationIPTextBox, "DestinationIPTextBox");
            this.DestinationIPTextBox.Name = "DestinationIPTextBox";
            // 
            // DestinationPortTextBoxReadOnly
            // 
            this.DestinationPortTextBoxReadOnly.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.DestinationPortTextBoxReadOnly, "DestinationPortTextBoxReadOnly");
            this.DestinationPortTextBoxReadOnly.Name = "DestinationPortTextBoxReadOnly";
            this.DestinationPortTextBoxReadOnly.ReadOnly = true;
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
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DisConnectButton
            // 
            resources.ApplyResources(this.DisConnectButton, "DisConnectButton");
            this.DisConnectButton.Name = "DisConnectButton";
            this.DisConnectButton.UseVisualStyleBackColor = true;
            this.DisConnectButton.Click += new System.EventHandler(this.DisConnectButton_Click);
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
            // ConnectStatusTextBoxReadOnly
            // 
            this.ConnectStatusTextBoxReadOnly.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.ConnectStatusTextBoxReadOnly, "ConnectStatusTextBoxReadOnly");
            this.ConnectStatusTextBoxReadOnly.Name = "ConnectStatusTextBoxReadOnly";
            this.ConnectStatusTextBoxReadOnly.ReadOnly = true;
            // 
            // ConnectLogTextBoxReadOnly
            // 
            this.ConnectLogTextBoxReadOnly.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.ConnectLogTextBoxReadOnly, "ConnectLogTextBoxReadOnly");
            this.ConnectLogTextBoxReadOnly.Name = "ConnectLogTextBoxReadOnly";
            this.ConnectLogTextBoxReadOnly.ReadOnly = true;
            // 
            // ConnectModeComboBox
            // 
            this.ConnectModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConnectModeComboBox.FormattingEnabled = true;
            this.ConnectModeComboBox.Items.AddRange(new object[] {
            resources.GetString("ConnectModeComboBox.Items"),
            resources.GetString("ConnectModeComboBox.Items1")});
            resources.ApplyResources(this.ConnectModeComboBox, "ConnectModeComboBox");
            this.ConnectModeComboBox.Name = "ConnectModeComboBox";
            // 
            // SendFileButton
            // 
            resources.ApplyResources(this.SendFileButton, "SendFileButton");
            this.SendFileButton.Name = "SendFileButton";
            this.SendFileButton.UseVisualStyleBackColor = true;
            // 
            // SendVideoButton
            // 
            resources.ApplyResources(this.SendVideoButton, "SendVideoButton");
            this.SendVideoButton.Name = "SendVideoButton";
            this.SendVideoButton.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SendVideoButton);
            this.Controls.Add(this.SendFileButton);
            this.Controls.Add(this.SettingsFlowLayoutPanel);
            this.Controls.Add(this.MessagesFlowLayoutPanel);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.SendMessageButton);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.SettingsFlowLayoutPanel.ResumeLayout(false);
            this.SettingsFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendMessageButton;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.FlowLayoutPanel MessagesFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel SettingsFlowLayoutPanel;
        private System.Windows.Forms.TextBox DestinationIPTextBox;
        private System.Windows.Forms.TextBox DestinationPortTextBox;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.TextBox DestinationIPTextBoxReadOnly;
        private System.Windows.Forms.TextBox DestinationPortTextBoxReadOnly;
        private System.Windows.Forms.TextBox LocalConfigIPTextBoxReadOnly;
        private System.Windows.Forms.TextBox LocalIPTextBoxReadOnly;
        private System.Windows.Forms.TextBox LocalConfigPortTextBoxReadOnly;
        private System.Windows.Forms.TextBox LocalPortTextBoxReadOnly;
        private System.Windows.Forms.TextBox GapTextBoxReadOnly;
        private System.Windows.Forms.TextBox ConnectLogTextBoxReadOnly;
        private System.Windows.Forms.TextBox ConnectStatusTextBoxReadOnly;
        private System.Windows.Forms.Button DisConnectButton;
        private System.Windows.Forms.ComboBox ConnectModeComboBox;
        private System.Windows.Forms.Button SendFileButton;
        private System.Windows.Forms.Button SendVideoButton;
    }
}

