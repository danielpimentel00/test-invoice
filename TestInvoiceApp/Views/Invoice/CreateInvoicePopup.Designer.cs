namespace TestInvoiceApp.Views.Invoice
{
    partial class CreateInvoicePopup
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
            this.customer_comboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.qty_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.price_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.qty_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.price_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // customer_comboBox
            // 
            this.customer_comboBox.FormattingEnabled = true;
            this.customer_comboBox.Location = new System.Drawing.Point(110, 131);
            this.customer_comboBox.Name = "customer_comboBox";
            this.customer_comboBox.Size = new System.Drawing.Size(300, 24);
            this.customer_comboBox.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Precio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Cantidad";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(416, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 17;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Crear Factura";
            // 
            // qty_numericUpDown
            // 
            this.qty_numericUpDown.Location = new System.Drawing.Point(110, 173);
            this.qty_numericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.qty_numericUpDown.Name = "qty_numericUpDown";
            this.qty_numericUpDown.Size = new System.Drawing.Size(120, 22);
            this.qty_numericUpDown.TabIndex = 24;
            // 
            // price_numericUpDown
            // 
            this.price_numericUpDown.DecimalPlaces = 2;
            this.price_numericUpDown.Location = new System.Drawing.Point(110, 210);
            this.price_numericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.price_numericUpDown.Name = "price_numericUpDown";
            this.price_numericUpDown.Size = new System.Drawing.Size(120, 22);
            this.price_numericUpDown.TabIndex = 25;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(416, 166);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 26;
            this.button2.Text = "Finalizar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CreateInvoicePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 341);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.price_numericUpDown);
            this.Controls.Add(this.qty_numericUpDown);
            this.Controls.Add(this.customer_comboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreateInvoicePopup";
            this.Text = "CreateInvoicePopup";
            ((System.ComponentModel.ISupportInitialize)(this.qty_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.price_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox customer_comboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown qty_numericUpDown;
        public System.Windows.Forms.NumericUpDown price_numericUpDown;
        private System.Windows.Forms.Button button2;
    }
}