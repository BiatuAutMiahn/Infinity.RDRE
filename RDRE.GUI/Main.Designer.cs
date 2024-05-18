using System.Drawing.Drawing2D;
using System.Windows.Forms;

/*public class PictureBoxWithInterpolationMode : PictureBox
{
    public InterpolationMode InterpolationMode { get; set; }

    protected override void OnPaint(PaintEventArgs paintEventArgs)
    {
        paintEventArgs.Graphics.InterpolationMode = InterpolationMode;
        base.OnPaint(paintEventArgs);
    }

}
*/
namespace RDRE.GUI {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.OutputLabel = new System.Windows.Forms.Label();
            this.InputLabel = new System.Windows.Forms.Label();
            this.OutputModeLabel = new System.Windows.Forms.Label();
            this.RandDepthLabel = new System.Windows.Forms.Label();
            this.Input = new System.Windows.Forms.TextBox();
            this.SettingsGroup = new System.Windows.Forms.GroupBox();
            this.OptClearOnRet = new System.Windows.Forms.CheckBox();
            this.OptOutBase64 = new System.Windows.Forms.CheckBox();
            this.ModeDecRDR = new System.Windows.Forms.RadioButton();
            this.ModeEncRDR = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.OptOutputHex = new System.Windows.Forms.RadioButton();
            this.OptOutputDec = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.OptSecDec = new System.Windows.Forms.RadioButton();
            this.OptSecEnc = new System.Windows.Forms.RadioButton();
            this.OptSecKey = new System.Windows.Forms.TextBox();
            this.OptSecure = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InsaneDelayTicker = new System.Windows.Forms.NumericUpDown();
            this.OptRealtime = new System.Windows.Forms.CheckBox();
            this.OptSpacing = new System.Windows.Forms.CheckBox();
            this.OptInsane = new System.Windows.Forms.CheckBox();
            this.OptDepthSelect = new System.Windows.Forms.ComboBox();
            this.OptAutoDepth = new System.Windows.Forms.CheckBox();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            //this.StatsGroup = new System.Windows.Forms.GroupBox();
            //this.pictureBox1 = new PictureBoxWithInterpolationMode();
            this.Output = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.ClearOut = new System.Windows.Forms.Button();
            this.DlgNetRDR = new System.Windows.Forms.Button();
            this.CpyOut = new System.Windows.Forms.Button();
            this.DlgCharMap = new System.Windows.Forms.Button();
            this.ClearAll = new System.Windows.Forms.Button();
            this.CpyOutIn = new System.Windows.Forms.Button();
            this.SettingsGroup.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InsaneDelayTicker)).BeginInit();
/*            this.StatsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
*/            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Location = new System.Drawing.Point(222, 248);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(56, 14);
            this.OutputLabel.TabIndex = 23;
            this.OutputLabel.Text = "Output:";
            this.toolTips.SetToolTip(this.OutputLabel, "Displays Encoded/Decoded Output");
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Location = new System.Drawing.Point(225, 3);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(49, 14);
            this.InputLabel.TabIndex = 19;
            this.InputLabel.Text = "Input:";
            this.toolTips.SetToolTip(this.InputLabel, "Input to be Encoded/Decoded.");
            // 
            // OutputModeLabel
            // 
            this.OutputModeLabel.AutoSize = true;
            this.OutputModeLabel.Location = new System.Drawing.Point(6, 102);
            this.OutputModeLabel.Name = "OutputModeLabel";
            this.OutputModeLabel.Size = new System.Drawing.Size(91, 14);
            this.OutputModeLabel.TabIndex = 5;
            this.OutputModeLabel.Text = "Output Mode:";
            this.toolTips.SetToolTip(this.OutputModeLabel, "Set Encode Mode");
            // 
            // RandDepthLabel
            // 
            this.RandDepthLabel.AutoSize = true;
            this.RandDepthLabel.Location = new System.Drawing.Point(6, 18);
            this.RandDepthLabel.Name = "RandDepthLabel";
            this.RandDepthLabel.Size = new System.Drawing.Size(126, 14);
            this.RandDepthLabel.TabIndex = 2;
            this.RandDepthLabel.Text = "RandomPool Depth:";
            this.toolTips.SetToolTip(this.RandDepthLabel, "RandomPool Depth for Encoding");
            // 
            // Input
            // 
            this.Input.AcceptsReturn = true;
            this.Input.AcceptsTab = true;
            this.Input.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Input.Location = new System.Drawing.Point(227, 20);
            this.Input.MaxLength = 0;
            this.Input.Multiline = true;
            this.Input.Name = "Input";
            this.Input.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Input.Size = new System.Drawing.Size(548, 221);
            this.Input.TabIndex = 18;
            this.toolTips.SetToolTip(this.Input, "Input to be Encoded/Decoded.");
            this.Input.TextChanged += new System.EventHandler(this.Input_TextChanged);
            // 
            // SettingsGroup
            // 
            this.SettingsGroup.Controls.Add(this.OptClearOnRet);
            this.SettingsGroup.Controls.Add(this.OptOutBase64);
            this.SettingsGroup.Controls.Add(this.ModeDecRDR);
            this.SettingsGroup.Controls.Add(this.ModeEncRDR);
            this.SettingsGroup.Controls.Add(this.label2);
            this.SettingsGroup.Controls.Add(this.panel2);
            this.SettingsGroup.Controls.Add(this.panel1);
            this.SettingsGroup.Controls.Add(this.OptSecKey);
            this.SettingsGroup.Controls.Add(this.OptSecure);
            this.SettingsGroup.Controls.Add(this.label1);
            this.SettingsGroup.Controls.Add(this.InsaneDelayTicker);
            this.SettingsGroup.Controls.Add(this.OptRealtime);
            this.SettingsGroup.Controls.Add(this.OptSpacing);
            this.SettingsGroup.Controls.Add(this.OptInsane);
            this.SettingsGroup.Controls.Add(this.OutputModeLabel);
            this.SettingsGroup.Controls.Add(this.RandDepthLabel);
            this.SettingsGroup.Controls.Add(this.OptDepthSelect);
            this.SettingsGroup.Controls.Add(this.OptAutoDepth);
            this.SettingsGroup.Location = new System.Drawing.Point(4, 3);
            this.SettingsGroup.Name = "SettingsGroup";
            this.SettingsGroup.Size = new System.Drawing.Size(216, 315);
            this.SettingsGroup.TabIndex = 17;
            this.SettingsGroup.TabStop = false;
            this.SettingsGroup.Text = "Settings";
            this.toolTips.SetToolTip(this.SettingsGroup, "Various Encoding Parameters");
            // 
            // OptClearOnRet
            // 
            this.OptClearOnRet.AutoSize = true;
            this.OptClearOnRet.Enabled = false;
            this.OptClearOnRet.Location = new System.Drawing.Point(6, 220);
            this.OptClearOnRet.Name = "OptClearOnRet";
            this.OptClearOnRet.Size = new System.Drawing.Size(131, 18);
            this.OptClearOnRet.TabIndex = 25;
            this.OptClearOnRet.Text = "Clear on Return";
            this.OptClearOnRet.UseVisualStyleBackColor = true;
            this.OptClearOnRet.CheckedChanged += new System.EventHandler(this.OptClearOnRet_CheckedChanged);
            // 
            // OptOutBase64
            // 
            this.OptOutBase64.AutoSize = true;
            this.OptOutBase64.Location = new System.Drawing.Point(131, 116);
            this.OptOutBase64.Name = "OptOutBase64";
            this.OptOutBase64.Size = new System.Drawing.Size(68, 18);
            this.OptOutBase64.TabIndex = 24;
            this.OptOutBase64.Text = "Base64";
            this.OptOutBase64.UseVisualStyleBackColor = true;
            this.OptOutBase64.CheckedChanged += new System.EventHandler(this.OutBase64_CheckedChanged);
            // 
            // ModeDecRDR
            // 
            this.ModeDecRDR.AutoSize = true;
            this.ModeDecRDR.Location = new System.Drawing.Point(101, 77);
            this.ModeDecRDR.Name = "ModeDecRDR";
            this.ModeDecRDR.Size = new System.Drawing.Size(67, 18);
            this.ModeDecRDR.TabIndex = 22;
            this.ModeDecRDR.Text = "Decode";
            this.ModeDecRDR.UseVisualStyleBackColor = true;
            this.ModeDecRDR.CheckedChanged += new System.EventHandler(this.ModeRDR_CheckedChanged);
            // 
            // ModeEncRDR
            // 
            this.ModeEncRDR.AutoSize = true;
            this.ModeEncRDR.Checked = true;
            this.ModeEncRDR.Location = new System.Drawing.Point(9, 77);
            this.ModeEncRDR.Name = "ModeEncRDR";
            this.ModeEncRDR.Size = new System.Drawing.Size(67, 18);
            this.ModeEncRDR.TabIndex = 21;
            this.ModeEncRDR.TabStop = true;
            this.ModeEncRDR.Text = "Encode";
            this.ModeEncRDR.UseVisualStyleBackColor = true;
            this.ModeEncRDR.CheckedChanged += new System.EventHandler(this.ModeRDR_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 20;
            this.label2.Text = "RDR Mode:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.OptOutputHex);
            this.panel2.Controls.Add(this.OptOutputDec);
            this.panel2.Location = new System.Drawing.Point(23, 115);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(102, 43);
            this.panel2.TabIndex = 19;
            // 
            // OptOutputHex
            // 
            this.OptOutputHex.AutoSize = true;
            this.OptOutputHex.Checked = true;
            this.OptOutputHex.Location = new System.Drawing.Point(0, 27);
            this.OptOutputHex.Name = "OptOutputHex";
            this.OptOutputHex.Size = new System.Drawing.Size(102, 18);
            this.OptOutputHex.TabIndex = 4;
            this.OptOutputHex.TabStop = true;
            this.OptOutputHex.Text = "Hexadecimal";
            this.toolTips.SetToolTip(this.OptOutputHex, "Encode to Hexadecimal");
            this.OptOutputHex.UseVisualStyleBackColor = true;
            this.OptOutputHex.CheckedChanged += new System.EventHandler(this.OptOutMode_CheckStateChanged);
            // 
            // OptOutputDec
            // 
            this.OptOutputDec.AutoSize = true;
            this.OptOutputDec.Location = new System.Drawing.Point(0, 3);
            this.OptOutputDec.Name = "OptOutputDec";
            this.OptOutputDec.Size = new System.Drawing.Size(74, 18);
            this.OptOutputDec.TabIndex = 3;
            this.OptOutputDec.Text = "Decimal";
            this.toolTips.SetToolTip(this.OptOutputDec, "Encode to Decimal");
            this.OptOutputDec.UseVisualStyleBackColor = true;
            this.OptOutputDec.CheckedChanged += new System.EventHandler(this.OptOutMode_CheckStateChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.OptSecDec);
            this.panel1.Controls.Add(this.OptSecEnc);
            this.panel1.Location = new System.Drawing.Point(23, 258);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 23);
            this.panel1.TabIndex = 18;
            // 
            // OptSecDec
            // 
            this.OptSecDec.AutoSize = true;
            this.OptSecDec.Enabled = false;
            this.OptSecDec.Location = new System.Drawing.Point(78, 1);
            this.OptSecDec.Name = "OptSecDec";
            this.OptSecDec.Size = new System.Drawing.Size(74, 18);
            this.OptSecDec.TabIndex = 19;
            this.OptSecDec.Text = "Decrypt";
            this.OptSecDec.UseVisualStyleBackColor = true;
            this.OptSecDec.CheckedChanged += new System.EventHandler(this.OptSecEncDec_CheckChanged);
            // 
            // OptSecEnc
            // 
            this.OptSecEnc.AutoSize = true;
            this.OptSecEnc.Checked = true;
            this.OptSecEnc.Enabled = false;
            this.OptSecEnc.Location = new System.Drawing.Point(0, 1);
            this.OptSecEnc.Name = "OptSecEnc";
            this.OptSecEnc.Size = new System.Drawing.Size(74, 18);
            this.OptSecEnc.TabIndex = 18;
            this.OptSecEnc.TabStop = true;
            this.OptSecEnc.Text = "Encrypt";
            this.OptSecEnc.UseVisualStyleBackColor = true;
            this.OptSecEnc.CheckedChanged += new System.EventHandler(this.OptSecEncDec_CheckChanged);
            // 
            // OptSecKey
            // 
            this.OptSecKey.Enabled = false;
            this.OptSecKey.Location = new System.Drawing.Point(23, 283);
            this.OptSecKey.Name = "OptSecKey";
            this.OptSecKey.Size = new System.Drawing.Size(176, 22);
            this.OptSecKey.TabIndex = 17;
            this.OptSecKey.UseSystemPasswordChar = true;
            this.OptSecKey.TextChanged += new System.EventHandler(this.OptSecKey_TextChanged);
            // 
            // OptSecure
            // 
            this.OptSecure.AutoSize = true;
            this.OptSecure.Location = new System.Drawing.Point(6, 241);
            this.OptSecure.Name = "OptSecure";
            this.OptSecure.Size = new System.Drawing.Size(103, 18);
            this.OptSecure.TabIndex = 16;
            this.OptSecure.Text = "Secure Mode";
            this.OptSecure.UseVisualStyleBackColor = true;
            this.OptSecure.CheckedChanged += new System.EventHandler(this.OptSecure_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "ms";
            // 
            // InsaneDelayTicker
            // 
            this.InsaneDelayTicker.Location = new System.Drawing.Point(107, 175);
            this.InsaneDelayTicker.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.InsaneDelayTicker.Name = "InsaneDelayTicker";
            this.InsaneDelayTicker.Size = new System.Drawing.Size(48, 22);
            this.InsaneDelayTicker.TabIndex = 9;
            this.InsaneDelayTicker.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.InsaneDelayTicker.ValueChanged += new System.EventHandler(this.InsaneDelayTicker_ValueChanged);
            // 
            // OptRealtime
            // 
            this.OptRealtime.AutoSize = true;
            this.OptRealtime.Checked = true;
            this.OptRealtime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OptRealtime.Location = new System.Drawing.Point(6, 199);
            this.OptRealtime.Name = "OptRealtime";
            this.OptRealtime.Size = new System.Drawing.Size(180, 18);
            this.OptRealtime.TabIndex = 8;
            this.OptRealtime.Text = "Realtime Encode/Decode";
            this.toolTips.SetToolTip(this.OptRealtime, "Encodes/Decodes Input when it is changed.");
            this.OptRealtime.UseVisualStyleBackColor = true;
            this.OptRealtime.CheckedChanged += new System.EventHandler(this.OptRealtime_CheckedChanged);
            // 
            // OptSpacing
            // 
            this.OptSpacing.Location = new System.Drawing.Point(131, 140);
            this.OptSpacing.Name = "OptSpacing";
            this.OptSpacing.Size = new System.Drawing.Size(75, 18);
            this.OptSpacing.TabIndex = 8;
            this.OptSpacing.Text = "Spacing";
            this.toolTips.SetToolTip(this.OptSpacing, "Enable Output Spacing.");
            this.OptSpacing.UseVisualStyleBackColor = true;
            this.OptSpacing.CheckedChanged += new System.EventHandler(this.OptSpacing_CheckedChanged);
            // 
            // OptInsane
            // 
            this.OptInsane.AutoSize = true;
            this.OptInsane.Location = new System.Drawing.Point(6, 175);
            this.OptInsane.Name = "OptInsane";
            this.OptInsane.Size = new System.Drawing.Size(103, 18);
            this.OptInsane.TabIndex = 7;
            this.OptInsane.Text = "Insane Mode";
            this.OptInsane.UseVisualStyleBackColor = true;
            this.OptInsane.CheckedChanged += new System.EventHandler(this.OptInsane_CheckedChanged);
            // 
            // OptDepthSelect
            // 
            this.OptDepthSelect.Enabled = false;
            this.OptDepthSelect.Items.AddRange(new object[] {
            "4096",
            "2048",
            "1024",
            "512",
            "256",
            "128",
            "64",
            "32",
            "16",
            "8",
            "4",
            "2",
            "1"});
            this.OptDepthSelect.Location = new System.Drawing.Point(23, 35);
            this.OptDepthSelect.Name = "OptDepthSelect";
            this.OptDepthSelect.Size = new System.Drawing.Size(60, 22);
            this.OptDepthSelect.TabIndex = 0;
            this.OptDepthSelect.Text = "32";
            this.toolTips.SetToolTip(this.OptDepthSelect, "RandomPool Depth for Encoding");
            this.OptDepthSelect.SelectedIndexChanged += new System.EventHandler(this.DepthSelect_SelectedIndexChanged);
            // 
            // OptAutoDepth
            // 
            this.OptAutoDepth.AutoSize = true;
            this.OptAutoDepth.Checked = true;
            this.OptAutoDepth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OptAutoDepth.Location = new System.Drawing.Point(89, 37);
            this.OptAutoDepth.Name = "OptAutoDepth";
            this.OptAutoDepth.Size = new System.Drawing.Size(54, 18);
            this.OptAutoDepth.TabIndex = 1;
            this.OptAutoDepth.Text = "Auto";
            this.toolTips.SetToolTip(this.OptAutoDepth, "Automatically Determine the best RandomPool Depth for Encoding.");
            this.OptAutoDepth.UseVisualStyleBackColor = true;
            this.OptAutoDepth.CheckStateChanged += new System.EventHandler(this.OptAutoDepth_CheckStateChanged);
            // 
            // StatsGroup
            // 
/*            this.StatsGroup.Controls.Add(this.pictureBox1);
            this.StatsGroup.Location = new System.Drawing.Point(4, 432);
            this.StatsGroup.Name = "StatsGroup";
            this.StatsGroup.Size = new System.Drawing.Size(216, 226);
            this.StatsGroup.TabIndex = 22;
            this.StatsGroup.TabStop = false;
            this.StatsGroup.Text = "QR Code";
            this.toolTips.SetToolTip(this.StatsGroup, "Displays various statistics.");
            this.StatsGroup.Enter += new System.EventHandler(this.StatsGroup_Enter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            this.pictureBox1.Location = new System.Drawing.Point(8, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
*/            // 
            // Output
            // 
            this.Output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Output.Location = new System.Drawing.Point(227, 263);
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.Output.Size = new System.Drawing.Size(549, 393);
            this.Output.TabIndex = 24;
            this.Output.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.ClearOut);
            this.groupBox1.Controls.Add(this.DlgNetRDR);
            this.groupBox1.Controls.Add(this.CpyOut);
            this.groupBox1.Controls.Add(this.DlgCharMap);
            this.groupBox1.Controls.Add(this.ClearAll);
            this.groupBox1.Controls.Add(this.CpyOutIn);
            this.groupBox1.Location = new System.Drawing.Point(4, 324);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 102);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(12, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "FileOpn";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // ClearOut
            // 
            this.ClearOut.Enabled = false;
            this.ClearOut.Location = new System.Drawing.Point(12, 41);
            this.ClearOut.Name = "ClearOut";
            this.ClearOut.Size = new System.Drawing.Size(64, 23);
            this.ClearOut.TabIndex = 5;
            this.ClearOut.Text = "FileSav";
            this.ClearOut.UseVisualStyleBackColor = true;
            // 
            // DlgNetRDR
            // 
            this.DlgNetRDR.Enabled = false;
            this.DlgNetRDR.Location = new System.Drawing.Point(77, 41);
            this.DlgNetRDR.Name = "DlgNetRDR";
            this.DlgNetRDR.Size = new System.Drawing.Size(64, 23);
            this.DlgNetRDR.TabIndex = 4;
            this.DlgNetRDR.Text = "NetRDR";
            this.DlgNetRDR.UseVisualStyleBackColor = true;
            // 
            // CpyOut
            // 
            this.CpyOut.Location = new System.Drawing.Point(142, 41);
            this.CpyOut.Name = "CpyOut";
            this.CpyOut.Size = new System.Drawing.Size(64, 23);
            this.CpyOut.TabIndex = 3;
            this.CpyOut.Text = "OutCopy";
            this.CpyOut.UseVisualStyleBackColor = true;
            this.CpyOut.Click += new System.EventHandler(this.CpyOut_Click);
            // 
            // DlgCharMap
            // 
            this.DlgCharMap.Enabled = false;
            this.DlgCharMap.Location = new System.Drawing.Point(77, 16);
            this.DlgCharMap.Name = "DlgCharMap";
            this.DlgCharMap.Size = new System.Drawing.Size(64, 23);
            this.DlgCharMap.TabIndex = 2;
            this.DlgCharMap.Text = "CharMap";
            this.DlgCharMap.UseVisualStyleBackColor = true;
            // 
            // ClearAll
            // 
            this.ClearAll.Location = new System.Drawing.Point(142, 66);
            this.ClearAll.Name = "ClearAll";
            this.ClearAll.Size = new System.Drawing.Size(64, 23);
            this.ClearAll.TabIndex = 1;
            this.ClearAll.Text = "Clear";
            this.ClearAll.UseVisualStyleBackColor = true;
            this.ClearAll.Click += new System.EventHandler(this.ClearAll_Click);
            // 
            // CpyOutIn
            // 
            this.CpyOutIn.Location = new System.Drawing.Point(142, 16);
            this.CpyOutIn.Name = "CpyOutIn";
            this.CpyOutIn.Size = new System.Drawing.Size(64, 23);
            this.CpyOutIn.TabIndex = 0;
            this.CpyOutIn.Text = "Out->In";
            this.CpyOutIn.UseVisualStyleBackColor = true;
            this.CpyOutIn.Click += new System.EventHandler(this.CpyOutIn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 661);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.OutputLabel);
            //this.Controls.Add(this.StatsGroup);
            this.Controls.Add(this.InputLabel);
            this.Controls.Add(this.Input);
            this.Controls.Add(this.SettingsGroup);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "RDRE Encoder v3 Alpha";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.SettingsGroup.ResumeLayout(false);
            this.SettingsGroup.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InsaneDelayTicker)).EndInit();
            //this.StatsGroup.ResumeLayout(false);
            //((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox SettingsGroup;
        private System.Windows.Forms.CheckBox OptSpacing;
        private System.Windows.Forms.RadioButton OptOutputHex;
        private System.Windows.Forms.RadioButton OptOutputDec;
        private System.Windows.Forms.ComboBox OptDepthSelect;
        private System.Windows.Forms.CheckBox OptAutoDepth;
        private System.Windows.Forms.CheckBox OptInsane;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.Label OutputModeLabel;
        private System.Windows.Forms.Label RandDepthLabel;
        private System.Windows.Forms.NumericUpDown InsaneDelayTicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox Output;
        private Label OutputLabel;
        private Label InputLabel;
        public TextBox Input;
        private TextBox OptSecKey;
        private CheckBox OptSecure;
        private Panel panel1;
        private RadioButton OptSecDec;
        private RadioButton OptSecEnc;
        private RadioButton ModeDecRDR;
        private RadioButton ModeEncRDR;
        private Label label2;
        private Panel panel2;
        private GroupBox groupBox1;
        private Button DlgCharMap;
        private Button ClearAll;
        private Button CpyOutIn;
        private Button ClearOut;
        private Button DlgNetRDR;
        private Button CpyOut;
        private Button button3;
        private CheckBox OptOutBase64;
        private CheckBox OptRealtime;
        private CheckBox OptClearOnRet;
        //private GroupBox StatsGroup;
        //private PictureBoxWithInterpolationMode pictureBox1;
    }
}

