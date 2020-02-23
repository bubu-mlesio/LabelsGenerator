namespace LabelsGenerator
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.amount_TxtBx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sku_lb = new System.Windows.Forms.ListBox();
            this.sku_txtBx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numberLabels = new System.Windows.Forms.TextBox();
            this.autoPrint = new System.Windows.Forms.CheckBox();
            this.smallLabel_chkBx = new System.Windows.Forms.CheckBox();
            this.chb_palette = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hc_rb = new System.Windows.Forms.RadioButton();
            this.pp_rb = new System.Windows.Forms.RadioButton();
            this.brand404_rb = new System.Windows.Forms.RadioButton();
            this.wess_rb = new System.Windows.Forms.RadioButton();
            this.blank_rb = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(53, 599);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1159, 89);
            this.button1.TabIndex = 1;
            this.button1.Text = "Generuj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(48, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(425, 55);
            this.label1.TabIndex = 2;
            this.label1.Text = "Podaj nazwę SKU:";
            // 
            // amount_TxtBx
            // 
            this.amount_TxtBx.Location = new System.Drawing.Point(53, 538);
            this.amount_TxtBx.Name = "amount_TxtBx";
            this.amount_TxtBx.Size = new System.Drawing.Size(282, 35);
            this.amount_TxtBx.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(48, 480);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 55);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ilość:";
            // 
            // sku_lb
            // 
            this.sku_lb.FormattingEnabled = true;
            this.sku_lb.HorizontalScrollbar = true;
            this.sku_lb.ItemHeight = 29;
            this.sku_lb.Location = new System.Drawing.Point(53, 137);
            this.sku_lb.Name = "sku_lb";
            this.sku_lb.Size = new System.Drawing.Size(1159, 323);
            this.sku_lb.TabIndex = 6;
            this.sku_lb.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // sku_txtBx
            // 
            this.sku_txtBx.Location = new System.Drawing.Point(53, 81);
            this.sku_txtBx.Name = "sku_txtBx";
            this.sku_txtBx.Size = new System.Drawing.Size(347, 35);
            this.sku_txtBx.TabIndex = 7;
            this.sku_txtBx.TextChanged += new System.EventHandler(this.sku_txtBx_TextChanged);
            this.sku_txtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sku_txtBx_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(955, 480);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 55);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ile etykiet:";
            // 
            // numberLabels
            // 
            this.numberLabels.Location = new System.Drawing.Point(965, 538);
            this.numberLabels.Name = "numberLabels";
            this.numberLabels.Size = new System.Drawing.Size(228, 35);
            this.numberLabels.TabIndex = 9;
            this.numberLabels.Text = "1";
            // 
            // autoPrint
            // 
            this.autoPrint.AutoSize = true;
            this.autoPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.autoPrint.Location = new System.Drawing.Point(367, 514);
            this.autoPrint.Name = "autoPrint";
            this.autoPrint.Size = new System.Drawing.Size(551, 59);
            this.autoPrint.TabIndex = 10;
            this.autoPrint.Text = "Automatyczny wydruk?";
            this.autoPrint.UseVisualStyleBackColor = true;
            // 
            // smallLabel_chkBx
            // 
            this.smallLabel_chkBx.AutoSize = true;
            this.smallLabel_chkBx.Checked = true;
            this.smallLabel_chkBx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.smallLabel_chkBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.smallLabel_chkBx.Location = new System.Drawing.Point(1057, 5);
            this.smallLabel_chkBx.Name = "smallLabel_chkBx";
            this.smallLabel_chkBx.Size = new System.Drawing.Size(187, 59);
            this.smallLabel_chkBx.TabIndex = 11;
            this.smallLabel_chkBx.Text = "Mała?";
            this.smallLabel_chkBx.UseVisualStyleBackColor = true;
            // 
            // chb_palette
            // 
            this.chb_palette.AutoSize = true;
            this.chb_palette.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chb_palette.Location = new System.Drawing.Point(1057, 62);
            this.chb_palette.Name = "chb_palette";
            this.chb_palette.Size = new System.Drawing.Size(155, 59);
            this.chb_palette.TabIndex = 12;
            this.chb_palette.Text = "QR?";
            this.chb_palette.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.blank_rb);
            this.groupBox1.Controls.Add(this.hc_rb);
            this.groupBox1.Controls.Add(this.pp_rb);
            this.groupBox1.Controls.Add(this.brand404_rb);
            this.groupBox1.Controls.Add(this.wess_rb);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox1.Location = new System.Drawing.Point(488, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 109);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // hc_rb
            // 
            this.hc_rb.AutoSize = true;
            this.hc_rb.Location = new System.Drawing.Point(175, 57);
            this.hc_rb.Name = "hc_rb";
            this.hc_rb.Size = new System.Drawing.Size(94, 33);
            this.hc_rb.TabIndex = 3;
            this.hc_rb.TabStop = true;
            this.hc_rb.Text = "H&&C";
            this.hc_rb.UseVisualStyleBackColor = true;
            // 
            // pp_rb
            // 
            this.pp_rb.AutoSize = true;
            this.pp_rb.Location = new System.Drawing.Point(175, 19);
            this.pp_rb.Name = "pp_rb";
            this.pp_rb.Size = new System.Drawing.Size(165, 33);
            this.pp_rb.TabIndex = 2;
            this.pp_rb.Text = "PurePower";
            this.pp_rb.UseVisualStyleBackColor = true;
            // 
            // brand404_rb
            // 
            this.brand404_rb.AutoSize = true;
            this.brand404_rb.Location = new System.Drawing.Point(7, 58);
            this.brand404_rb.Name = "brand404_rb";
            this.brand404_rb.Size = new System.Drawing.Size(153, 33);
            this.brand404_rb.TabIndex = 1;
            this.brand404_rb.Text = "Brand 404";
            this.brand404_rb.UseVisualStyleBackColor = true;
            // 
            // wess_rb
            // 
            this.wess_rb.AutoSize = true;
            this.wess_rb.Checked = true;
            this.wess_rb.Location = new System.Drawing.Point(7, 19);
            this.wess_rb.Name = "wess_rb";
            this.wess_rb.Size = new System.Drawing.Size(140, 33);
            this.wess_rb.TabIndex = 0;
            this.wess_rb.TabStop = true;
            this.wess_rb.Text = "Wessper";
            this.wess_rb.UseVisualStyleBackColor = true;
            // 
            // blank_rb
            // 
            this.blank_rb.AutoSize = true;
            this.blank_rb.Location = new System.Drawing.Point(347, 18);
            this.blank_rb.Name = "blank_rb";
            this.blank_rb.Size = new System.Drawing.Size(105, 33);
            this.blank_rb.TabIndex = 4;
            this.blank_rb.TabStop = true;
            this.blank_rb.Text = "Pusto";
            this.blank_rb.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 724);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chb_palette);
            this.Controls.Add(this.smallLabel_chkBx);
            this.Controls.Add(this.autoPrint);
            this.Controls.Add(this.numberLabels);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sku_txtBx);
            this.Controls.Add(this.sku_lb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.amount_TxtBx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox amount_TxtBx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox sku_lb;
        private System.Windows.Forms.TextBox sku_txtBx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox numberLabels;
        private System.Windows.Forms.CheckBox autoPrint;
        private System.Windows.Forms.CheckBox smallLabel_chkBx;
        private System.Windows.Forms.CheckBox chb_palette;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton pp_rb;
        private System.Windows.Forms.RadioButton brand404_rb;
        private System.Windows.Forms.RadioButton wess_rb;
        private System.Windows.Forms.RadioButton hc_rb;
        private System.Windows.Forms.RadioButton blank_rb;
    }
}

