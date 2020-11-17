namespace GK_Projekt2
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.maxVelocity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.changeColor = new System.Windows.Forms.CheckBox();
            this.fpsBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.minVelocity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MoveBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.apply = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.KdBox = new System.Windows.Forms.TextBox();
            this.KsBox = new System.Windows.Forms.TextBox();
            this.HeightBox = new System.Windows.Forms.TextBox();
            this.SunPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Ks = new System.Windows.Forms.Label();
            this.Kd = new System.Windows.Forms.Label();
            this.SunHeigth = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FillComboBox = new System.Windows.Forms.ComboBox();
            this.textureBox = new System.Windows.Forms.CheckBox();
            this.vertexInterpolationBox = new System.Windows.Forms.CheckBox();
            this.fillColorBox = new System.Windows.Forms.CheckBox();
            this.vertexColor = new System.Windows.Forms.Label();
            this.fillPanel = new System.Windows.Forms.Panel();
            this.VertexPanel = new System.Windows.Forms.Panel();
            this.fillColor = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.CheckBox();
            this.Delete = new System.Windows.Forms.CheckBox();
            this.Edit = new System.Windows.Forms.CheckBox();
            this.Draw = new System.Windows.Forms.CheckBox();
            this.fpsLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.fillColorDialog = new System.Windows.Forms.ColorDialog();
            this.vertexColorDialog = new System.Windows.Forms.ColorDialog();
            this.textureDialog = new System.Windows.Forms.OpenFileDialog();
            this.sunColorDialog = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.maxVelocity);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.changeColor);
            this.splitContainer1.Panel1.Controls.Add(this.fpsBox);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.minVelocity);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.MoveBox);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.vertexColor);
            this.splitContainer1.Panel1.Controls.Add(this.fillPanel);
            this.splitContainer1.Panel1.Controls.Add(this.VertexPanel);
            this.splitContainer1.Panel1.Controls.Add(this.fillColor);
            this.splitContainer1.Panel1.Controls.Add(this.Add);
            this.splitContainer1.Panel1.Controls.Add(this.Delete);
            this.splitContainer1.Panel1.Controls.Add(this.Edit);
            this.splitContainer1.Panel1.Controls.Add(this.Draw);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fpsLabel);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox);
            this.splitContainer1.Size = new System.Drawing.Size(1282, 1018);
            this.splitContainer1.SplitterDistance = 151;
            this.splitContainer1.TabIndex = 0;
            // 
            // maxVelocity
            // 
            this.maxVelocity.Location = new System.Drawing.Point(83, 819);
            this.maxVelocity.Name = "maxVelocity";
            this.maxVelocity.Size = new System.Drawing.Size(48, 22);
            this.maxVelocity.TabIndex = 21;
            this.maxVelocity.Text = "10";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(81, 785);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 43);
            this.label7.TabIndex = 20;
            this.label7.Text = "Max velocity";
            // 
            // changeColor
            // 
            this.changeColor.Appearance = System.Windows.Forms.Appearance.Button;
            this.changeColor.Location = new System.Drawing.Point(12, 132);
            this.changeColor.Name = "changeColor";
            this.changeColor.Size = new System.Drawing.Size(127, 34);
            this.changeColor.TabIndex = 19;
            this.changeColor.Text = "Change Color";
            this.changeColor.UseVisualStyleBackColor = true;
            this.changeColor.CheckedChanged += new System.EventHandler(this.CheckedChangedAction);
            // 
            // fpsBox
            // 
            this.fpsBox.Location = new System.Drawing.Point(12, 864);
            this.fpsBox.Name = "fpsBox";
            this.fpsBox.Size = new System.Drawing.Size(100, 22);
            this.fpsBox.TabIndex = 18;
            this.fpsBox.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 844);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "FPS";
            // 
            // minVelocity
            // 
            this.minVelocity.Location = new System.Drawing.Point(11, 819);
            this.minVelocity.Name = "minVelocity";
            this.minVelocity.Size = new System.Drawing.Size(48, 22);
            this.minVelocity.TabIndex = 16;
            this.minVelocity.Text = "10";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 785);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 43);
            this.label4.TabIndex = 13;
            this.label4.Text = "Min velocity";
            // 
            // MoveBox
            // 
            this.MoveBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.MoveBox.Location = new System.Drawing.Point(12, 748);
            this.MoveBox.Name = "MoveBox";
            this.MoveBox.Size = new System.Drawing.Size(127, 34);
            this.MoveBox.TabIndex = 12;
            this.MoveBox.Text = "Move";
            this.MoveBox.UseVisualStyleBackColor = true;
            this.MoveBox.CheckedChanged += new System.EventHandler(this.MoveBox_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.apply);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.KdBox);
            this.groupBox2.Controls.Add(this.KsBox);
            this.groupBox2.Controls.Add(this.HeightBox);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.SunPanel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Ks);
            this.groupBox2.Controls.Add(this.Kd);
            this.groupBox2.Controls.Add(this.SunHeigth);
            this.groupBox2.Location = new System.Drawing.Point(12, 478);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(127, 264);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Light";
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(9, 219);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(75, 25);
            this.apply.TabIndex = 12;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 12;
            // 
            // KdBox
            // 
            this.KdBox.Location = new System.Drawing.Point(9, 95);
            this.KdBox.Name = "KdBox";
            this.KdBox.Size = new System.Drawing.Size(100, 22);
            this.KdBox.TabIndex = 11;
            this.KdBox.Text = "0,5";
            // 
            // KsBox
            // 
            this.KsBox.Location = new System.Drawing.Point(9, 140);
            this.KsBox.Name = "KsBox";
            this.KsBox.Size = new System.Drawing.Size(100, 22);
            this.KsBox.TabIndex = 10;
            this.KsBox.Text = "0,5";
            // 
            // HeightBox
            // 
            this.HeightBox.Location = new System.Drawing.Point(9, 51);
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.Size = new System.Drawing.Size(100, 22);
            this.HeightBox.TabIndex = 9;
            this.HeightBox.Text = "300";
            // 
            // SunPanel
            // 
            this.SunPanel.BackColor = System.Drawing.Color.White;
            this.SunPanel.Location = new System.Drawing.Point(9, 190);
            this.SunPanel.Name = "SunPanel";
            this.SunPanel.Size = new System.Drawing.Size(100, 23);
            this.SunPanel.TabIndex = 8;
            this.SunPanel.Click += new System.EventHandler(this.SunPanel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Color";
            // 
            // Ks
            // 
            this.Ks.AutoSize = true;
            this.Ks.Location = new System.Drawing.Point(6, 120);
            this.Ks.Name = "Ks";
            this.Ks.Size = new System.Drawing.Size(24, 17);
            this.Ks.TabIndex = 5;
            this.Ks.Text = "Ks";
            // 
            // Kd
            // 
            this.Kd.AutoSize = true;
            this.Kd.Location = new System.Drawing.Point(6, 75);
            this.Kd.Name = "Kd";
            this.Kd.Size = new System.Drawing.Size(25, 17);
            this.Kd.TabIndex = 2;
            this.Kd.Text = "Kd";
            // 
            // SunHeigth
            // 
            this.SunHeigth.AutoSize = true;
            this.SunHeigth.Location = new System.Drawing.Point(6, 30);
            this.SunHeigth.Name = "SunHeigth";
            this.SunHeigth.Size = new System.Drawing.Size(49, 17);
            this.SunHeigth.TabIndex = 1;
            this.SunHeigth.Text = "Heigth";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FillComboBox);
            this.groupBox1.Controls.Add(this.textureBox);
            this.groupBox1.Controls.Add(this.vertexInterpolationBox);
            this.groupBox1.Controls.Add(this.fillColorBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 266);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(127, 206);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fill method";
            // 
            // FillComboBox
            // 
            this.FillComboBox.FormattingEnabled = true;
            this.FillComboBox.Items.AddRange(new object[] {
            "Image",
            "Height map"});
            this.FillComboBox.Location = new System.Drawing.Point(7, 150);
            this.FillComboBox.Name = "FillComboBox";
            this.FillComboBox.Size = new System.Drawing.Size(114, 24);
            this.FillComboBox.TabIndex = 5;
            this.FillComboBox.Text = "-select-";
            this.FillComboBox.SelectedIndexChanged += new System.EventHandler(this.FillComboBox_SelectedIndexChanged);
            // 
            // textureBox
            // 
            this.textureBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.textureBox.Location = new System.Drawing.Point(6, 109);
            this.textureBox.Name = "textureBox";
            this.textureBox.Size = new System.Drawing.Size(115, 34);
            this.textureBox.TabIndex = 4;
            this.textureBox.Text = "Texture";
            this.textureBox.UseVisualStyleBackColor = true;
            this.textureBox.CheckedChanged += new System.EventHandler(this.CheckedChangedFillMode);
            // 
            // vertexInterpolationBox
            // 
            this.vertexInterpolationBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.vertexInterpolationBox.Location = new System.Drawing.Point(7, 61);
            this.vertexInterpolationBox.Name = "vertexInterpolationBox";
            this.vertexInterpolationBox.Size = new System.Drawing.Size(114, 42);
            this.vertexInterpolationBox.TabIndex = 3;
            this.vertexInterpolationBox.Text = "Vertex Interpolation";
            this.vertexInterpolationBox.UseVisualStyleBackColor = true;
            this.vertexInterpolationBox.CheckedChanged += new System.EventHandler(this.CheckedChangedFillMode);
            // 
            // fillColorBox
            // 
            this.fillColorBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.fillColorBox.Checked = true;
            this.fillColorBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fillColorBox.Location = new System.Drawing.Point(7, 21);
            this.fillColorBox.Name = "fillColorBox";
            this.fillColorBox.Size = new System.Drawing.Size(114, 34);
            this.fillColorBox.TabIndex = 2;
            this.fillColorBox.Text = "Fill Color";
            this.fillColorBox.UseVisualStyleBackColor = true;
            this.fillColorBox.CheckedChanged += new System.EventHandler(this.CheckedChangedFillMode);
            // 
            // vertexColor
            // 
            this.vertexColor.Location = new System.Drawing.Point(89, 169);
            this.vertexColor.Name = "vertexColor";
            this.vertexColor.Size = new System.Drawing.Size(50, 37);
            this.vertexColor.TabIndex = 8;
            this.vertexColor.Text = "Vertex Color";
            this.vertexColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fillPanel
            // 
            this.fillPanel.BackColor = System.Drawing.Color.Black;
            this.fillPanel.Location = new System.Drawing.Point(12, 209);
            this.fillPanel.Name = "fillPanel";
            this.fillPanel.Size = new System.Drawing.Size(50, 50);
            this.fillPanel.TabIndex = 7;
            this.fillPanel.Click += new System.EventHandler(this.fillPanel_Click);
            // 
            // VertexPanel
            // 
            this.VertexPanel.BackColor = System.Drawing.Color.Black;
            this.VertexPanel.Location = new System.Drawing.Point(89, 209);
            this.VertexPanel.Name = "VertexPanel";
            this.VertexPanel.Size = new System.Drawing.Size(50, 50);
            this.VertexPanel.TabIndex = 6;
            this.VertexPanel.Click += new System.EventHandler(this.VertexPanel_Click);
            // 
            // fillColor
            // 
            this.fillColor.Location = new System.Drawing.Point(12, 169);
            this.fillColor.Name = "fillColor";
            this.fillColor.Size = new System.Drawing.Size(50, 37);
            this.fillColor.TabIndex = 4;
            this.fillColor.Text = "Fill Color";
            this.fillColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Add
            // 
            this.Add.Appearance = System.Windows.Forms.Appearance.Button;
            this.Add.Location = new System.Drawing.Point(12, 92);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(127, 34);
            this.Add.TabIndex = 3;
            this.Add.Text = "Add Vertex";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.CheckedChanged += new System.EventHandler(this.CheckedChangedAction);
            // 
            // Delete
            // 
            this.Delete.Appearance = System.Windows.Forms.Appearance.Button;
            this.Delete.Location = new System.Drawing.Point(12, 52);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(127, 34);
            this.Delete.TabIndex = 2;
            this.Delete.Text = "Delete Vertex";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.CheckedChanged += new System.EventHandler(this.CheckedChangedAction);
            // 
            // Edit
            // 
            this.Edit.Appearance = System.Windows.Forms.Appearance.Button;
            this.Edit.Location = new System.Drawing.Point(84, 12);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(55, 34);
            this.Edit.TabIndex = 1;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.CheckedChanged += new System.EventHandler(this.CheckedChangedAction);
            // 
            // Draw
            // 
            this.Draw.Appearance = System.Windows.Forms.Appearance.Button;
            this.Draw.Checked = true;
            this.Draw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Draw.Enabled = false;
            this.Draw.Location = new System.Drawing.Point(12, 12);
            this.Draw.Name = "Draw";
            this.Draw.Size = new System.Drawing.Size(55, 34);
            this.Draw.TabIndex = 0;
            this.Draw.Text = "Draw";
            this.Draw.UseVisualStyleBackColor = true;
            this.Draw.CheckedChanged += new System.EventHandler(this.CheckedChangedAction);
            // 
            // fpsLabel
            // 
            this.fpsLabel.AutoSize = true;
            this.fpsLabel.Location = new System.Drawing.Point(1057, 12);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(16, 17);
            this.fpsLabel.TabIndex = 2;
            this.fpsLabel.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(990, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Real FPS:";
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(0, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1124, 925);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // textureDialog
            // 
            this.textureDialog.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(9, 190);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 23);
            this.panel1.TabIndex = 8;
            this.panel1.Click += new System.EventHandler(this.SunPanel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 1018);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "GK_Proj2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.CheckBox Draw;
        private System.Windows.Forms.CheckBox Edit;
        private System.Windows.Forms.CheckBox Delete;
        private System.Windows.Forms.CheckBox Add;
        private System.Windows.Forms.ColorDialog fillColorDialog;
        private System.Windows.Forms.ColorDialog vertexColorDialog;
        private System.Windows.Forms.Panel fillPanel;
        private System.Windows.Forms.Panel VertexPanel;
        private System.Windows.Forms.Label fillColor;
        private System.Windows.Forms.Label vertexColor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox textureBox;
        private System.Windows.Forms.CheckBox vertexInterpolationBox;
        private System.Windows.Forms.CheckBox fillColorBox;
        private System.Windows.Forms.ComboBox FillComboBox;
        private System.Windows.Forms.OpenFileDialog textureDialog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label SunHeigth;
        private System.Windows.Forms.Label Kd;
        private System.Windows.Forms.Label Ks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel SunPanel;
        private System.Windows.Forms.ColorDialog sunColorDialog;
        private System.Windows.Forms.TextBox KdBox;
        private System.Windows.Forms.TextBox KsBox;
        private System.Windows.Forms.TextBox HeightBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.TextBox minVelocity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox MoveBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox fpsBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label fpsLabel;
        private System.Windows.Forms.CheckBox changeColor;
        private System.Windows.Forms.TextBox maxVelocity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
    }
}

