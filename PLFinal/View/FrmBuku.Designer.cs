namespace PLFinal.View
{
    partial class FrmBuku
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBuku));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJudul = new System.Windows.Forms.TextBox();
            this.lvwBuku = new System.Windows.Forms.ListView();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnSelesai = new System.Windows.Forms.Button();
            this.btnC = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Menu;
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(117, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cari judul buku";
            // 
            // txtJudul
            // 
            this.txtJudul.Location = new System.Drawing.Point(296, 345);
            this.txtJudul.Name = "txtJudul";
            this.txtJudul.Size = new System.Drawing.Size(783, 31);
            this.txtJudul.TabIndex = 1;
            this.txtJudul.TextChanged += new System.EventHandler(this.txtJudul_TextChanged);
            // 
            // lvwBuku
            // 
            this.lvwBuku.HideSelection = false;
            this.lvwBuku.Location = new System.Drawing.Point(122, 426);
            this.lvwBuku.Name = "lvwBuku";
            this.lvwBuku.Size = new System.Drawing.Size(1132, 574);
            this.lvwBuku.TabIndex = 3;
            this.lvwBuku.UseCompatibleStateImageBehavior = false;
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnTambah.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnTambah.Location = new System.Drawing.Point(122, 1064);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(176, 59);
            this.btnTambah.TabIndex = 4;
            this.btnTambah.Text = "Tambah Buku";
            this.btnTambah.UseVisualStyleBackColor = false;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnEdit.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnEdit.Location = new System.Drawing.Point(331, 1066);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(176, 59);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Edit Buku";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnHapus.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnHapus.Location = new System.Drawing.Point(536, 1064);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(156, 59);
            this.btnHapus.TabIndex = 6;
            this.btnHapus.Text = "Hapus Buku";
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnSelesai
            // 
            this.btnSelesai.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSelesai.ForeColor = System.Drawing.Color.White;
            this.btnSelesai.Location = new System.Drawing.Point(1089, 1066);
            this.btnSelesai.Name = "btnSelesai";
            this.btnSelesai.Size = new System.Drawing.Size(165, 57);
            this.btnSelesai.TabIndex = 7;
            this.btnSelesai.Text = "Selesai";
            this.btnSelesai.UseVisualStyleBackColor = false;
            this.btnSelesai.Click += new System.EventHandler(this.btnSelesai_Click);
            // 
            // btnC
            // 
            this.btnC.AllowAnimations = true;
            this.btnC.AllowMouseEffects = true;
            this.btnC.AllowToggling = false;
            this.btnC.AnimationSpeed = 200;
            this.btnC.AutoGenerateColors = false;
            this.btnC.AutoRoundBorders = false;
            this.btnC.AutoSizeLeftIcon = true;
            this.btnC.AutoSizeRightIcon = true;
            this.btnC.BackColor = System.Drawing.Color.Transparent;
            this.btnC.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btnC.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnC.BackgroundImage")));
            this.btnC.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnC.ButtonText = "Cari";
            this.btnC.ButtonTextMarginLeft = 0;
            this.btnC.ColorContrastOnClick = 45;
            this.btnC.ColorContrastOnHover = 45;
            this.btnC.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnC.CustomizableEdges = borderEdges1;
            this.btnC.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnC.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnC.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnC.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnC.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnC.ForeColor = System.Drawing.Color.White;
            this.btnC.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnC.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnC.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnC.IconMarginLeft = 11;
            this.btnC.IconPadding = 10;
            this.btnC.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnC.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnC.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnC.IconSize = 25;
            this.btnC.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnC.IdleBorderRadius = 1;
            this.btnC.IdleBorderThickness = 1;
            this.btnC.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btnC.IdleIconLeftImage = null;
            this.btnC.IdleIconRightImage = null;
            this.btnC.IndicateFocus = false;
            this.btnC.Location = new System.Drawing.Point(1104, 345);
            this.btnC.Name = "btnC";
            this.btnC.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnC.OnDisabledState.BorderRadius = 1;
            this.btnC.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnC.OnDisabledState.BorderThickness = 1;
            this.btnC.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnC.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnC.OnDisabledState.IconLeftImage = null;
            this.btnC.OnDisabledState.IconRightImage = null;
            this.btnC.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnC.onHoverState.BorderRadius = 1;
            this.btnC.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnC.onHoverState.BorderThickness = 1;
            this.btnC.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnC.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnC.onHoverState.IconLeftImage = null;
            this.btnC.onHoverState.IconRightImage = null;
            this.btnC.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnC.OnIdleState.BorderRadius = 1;
            this.btnC.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnC.OnIdleState.BorderThickness = 1;
            this.btnC.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnC.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnC.OnIdleState.IconLeftImage = null;
            this.btnC.OnIdleState.IconRightImage = null;
            this.btnC.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnC.OnPressedState.BorderRadius = 1;
            this.btnC.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnC.OnPressedState.BorderThickness = 1;
            this.btnC.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnC.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnC.OnPressedState.IconLeftImage = null;
            this.btnC.OnPressedState.IconRightImage = null;
            this.btnC.Size = new System.Drawing.Size(150, 39);
            this.btnC.TabIndex = 8;
            this.btnC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnC.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnC.TextMarginLeft = 0;
            this.btnC.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnC.UseDefaultRadiusAndThickness = true;
            this.btnC.Click += new System.EventHandler(this.btnC_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(122, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(385, 293);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // FrmBuku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1398, 1272);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnSelesai);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.lvwBuku);
            this.Controls.Add(this.txtJudul);
            this.Controls.Add(this.label1);
            this.Name = "FrmBuku";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBuku";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJudul;
        private System.Windows.Forms.ListView lvwBuku;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnSelesai;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnC;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}