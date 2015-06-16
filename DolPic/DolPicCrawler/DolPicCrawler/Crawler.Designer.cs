namespace DolPicCrawler
{
    partial class Crawler
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Crawler));
            this.btnImageLoad = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblChkTime = new System.Windows.Forms.Label();
            this.btnAuthCheck = new System.Windows.Forms.Button();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRemainTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblWatch = new System.Windows.Forms.Label();
            this.txtMatch = new System.Windows.Forms.TextBox();
            this.btnXmlLoad = new System.Windows.Forms.Button();
            this.comSite = new System.Windows.Forms.ComboBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImageLoad
            // 
            this.btnImageLoad.Enabled = false;
            this.btnImageLoad.Location = new System.Drawing.Point(702, 12);
            this.btnImageLoad.Name = "btnImageLoad";
            this.btnImageLoad.Size = new System.Drawing.Size(130, 34);
            this.btnImageLoad.TabIndex = 0;
            this.btnImageLoad.Text = "이미지 가져와";
            this.btnImageLoad.UseVisualStyleBackColor = true;
            this.btnImageLoad.Click += new System.EventHandler(this.btnImageLoad_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(819, 162);
            this.dataGridView1.TabIndex = 1;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.Control;
            this.txtLog.Location = new System.Drawing.Point(13, 220);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(819, 282);
            this.txtLog.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblChkTime);
            this.panel2.Controls.Add(this.btnAuthCheck);
            this.panel2.Controls.Add(this.txtTime);
            this.panel2.Controls.Add(this.lblCountdown);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblRemainTime);
            this.panel2.Location = new System.Drawing.Point(13, 674);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(819, 47);
            this.panel2.TabIndex = 5;
            // 
            // lblChkTime
            // 
            this.lblChkTime.AutoSize = true;
            this.lblChkTime.Location = new System.Drawing.Point(14, 14);
            this.lblChkTime.Name = "lblChkTime";
            this.lblChkTime.Size = new System.Drawing.Size(0, 12);
            this.lblChkTime.TabIndex = 3;
            // 
            // btnAuthCheck
            // 
            this.btnAuthCheck.Enabled = false;
            this.btnAuthCheck.Location = new System.Drawing.Point(686, 14);
            this.btnAuthCheck.Name = "btnAuthCheck";
            this.btnAuthCheck.Size = new System.Drawing.Size(119, 23);
            this.btnAuthCheck.TabIndex = 2;
            this.btnAuthCheck.Text = "자동 체크 시작";
            this.btnAuthCheck.UseVisualStyleBackColor = true;
            this.btnAuthCheck.Click += new System.EventHandler(this.btnAuthCheck_Click);
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(583, 14);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(45, 21);
            this.txtTime.TabIndex = 1;
            this.txtTime.Text = "360";
            // 
            // lblCountdown
            // 
            this.lblCountdown.AutoSize = true;
            this.lblCountdown.Location = new System.Drawing.Point(477, 17);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(0, 12);
            this.lblCountdown.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(634, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "분 설정";
            // 
            // lblRemainTime
            // 
            this.lblRemainTime.AutoSize = true;
            this.lblRemainTime.Location = new System.Drawing.Point(406, 17);
            this.lblRemainTime.Name = "lblRemainTime";
            this.lblRemainTime.Size = new System.Drawing.Size(65, 12);
            this.lblRemainTime.TabIndex = 0;
            this.lblRemainTime.Text = "남은시간 : ";
            this.lblRemainTime.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // lblWatch
            // 
            this.lblWatch.AutoSize = true;
            this.lblWatch.Location = new System.Drawing.Point(12, 23);
            this.lblWatch.Name = "lblWatch";
            this.lblWatch.Size = new System.Drawing.Size(0, 12);
            this.lblWatch.TabIndex = 7;
            // 
            // txtMatch
            // 
            this.txtMatch.BackColor = System.Drawing.SystemColors.Control;
            this.txtMatch.Location = new System.Drawing.Point(13, 508);
            this.txtMatch.Multiline = true;
            this.txtMatch.Name = "txtMatch";
            this.txtMatch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMatch.Size = new System.Drawing.Size(818, 145);
            this.txtMatch.TabIndex = 8;
            // 
            // btnXmlLoad
            // 
            this.btnXmlLoad.Location = new System.Drawing.Point(571, 12);
            this.btnXmlLoad.Name = "btnXmlLoad";
            this.btnXmlLoad.Size = new System.Drawing.Size(121, 34);
            this.btnXmlLoad.TabIndex = 9;
            this.btnXmlLoad.Text = "XML 로딩";
            this.btnXmlLoad.UseVisualStyleBackColor = true;
            this.btnXmlLoad.Click += new System.EventHandler(this.btnXmlLoad_Click);
            // 
            // comSite
            // 
            this.comSite.AutoCompleteCustomSource.AddRange(new string[] {
            "트위터",
            "인스타그램",
            "페이스북"});
            this.comSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSite.FormattingEnabled = true;
            this.comSite.Items.AddRange(new object[] {
            "트위터",
            "인스타그램",
            "페이스북"});
            this.comSite.Location = new System.Drawing.Point(444, 12);
            this.comSite.Name = "comSite";
            this.comSite.Size = new System.Drawing.Size(121, 20);
            this.comSite.TabIndex = 10;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "이미지 가져오기";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.열기ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 48);
            this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // 열기ToolStripMenuItem
            // 
            this.열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            this.열기ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.열기ToolStripMenuItem.Text = "열기";
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            // 
            // Crawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 722);
            this.Controls.Add(this.comSite);
            this.Controls.Add(this.btnXmlLoad);
            this.Controls.Add(this.txtMatch);
            this.Controls.Add(this.lblWatch);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnImageLoad);
            this.Name = "Crawler";
            this.Text = "돌픽 이미지 크롤러";
            this.Load += new System.EventHandler(this.Crawler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImageLoad;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRemainTime;
        private System.Windows.Forms.Button btnAuthCheck;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lblChkTime;
        private System.Windows.Forms.Label lblWatch;
        private System.Windows.Forms.TextBox txtMatch;
        private System.Windows.Forms.Button btnXmlLoad;
        private System.Windows.Forms.ComboBox comSite;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 열기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
    }
}

