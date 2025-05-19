namespace Hotel
{
    partial class PaymentForm
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
            this.checkBoxService = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDaysOfStay = new System.Windows.Forms.Label();
            this.labelRoomPrice = new System.Windows.Forms.Label();
            this.labelVAT = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxService
            // 
            this.checkBoxService.AutoSize = true;
            this.checkBoxService.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.checkBoxService.ForeColor = System.Drawing.Color.FloralWhite;
            this.checkBoxService.Location = new System.Drawing.Point(34, 200);
            this.checkBoxService.Name = "checkBoxService";
            this.checkBoxService.Size = new System.Drawing.Size(232, 32);
            this.checkBoxService.TabIndex = 0;
            this.checkBoxService.Text = "Включенный сервис";
            this.checkBoxService.UseVisualStyleBackColor = true;
            this.checkBoxService.Click += new System.EventHandler(this.checkBoxService_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(308, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Бронирование";
            // 
            // labelDaysOfStay
            // 
            this.labelDaysOfStay.AutoSize = true;
            this.labelDaysOfStay.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.labelDaysOfStay.ForeColor = System.Drawing.Color.FloralWhite;
            this.labelDaysOfStay.Location = new System.Drawing.Point(32, 73);
            this.labelDaysOfStay.Name = "labelDaysOfStay";
            this.labelDaysOfStay.Size = new System.Drawing.Size(67, 28);
            this.labelDaysOfStay.TabIndex = 2;
            this.labelDaysOfStay.Text = "label2";
            // 
            // labelRoomPrice
            // 
            this.labelRoomPrice.AutoSize = true;
            this.labelRoomPrice.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.labelRoomPrice.ForeColor = System.Drawing.Color.FloralWhite;
            this.labelRoomPrice.Location = new System.Drawing.Point(35, 145);
            this.labelRoomPrice.Name = "labelRoomPrice";
            this.labelRoomPrice.Size = new System.Drawing.Size(67, 28);
            this.labelRoomPrice.TabIndex = 3;
            this.labelRoomPrice.Text = "label3";
            // 
            // labelVAT
            // 
            this.labelVAT.AutoSize = true;
            this.labelVAT.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.labelVAT.ForeColor = System.Drawing.Color.FloralWhite;
            this.labelVAT.Location = new System.Drawing.Point(34, 264);
            this.labelVAT.Name = "labelVAT";
            this.labelVAT.Size = new System.Drawing.Size(67, 28);
            this.labelVAT.TabIndex = 4;
            this.labelVAT.Text = "label4";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.labelTotal.ForeColor = System.Drawing.Color.FloralWhite;
            this.labelTotal.Location = new System.Drawing.Point(31, 327);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(67, 28);
            this.labelTotal.TabIndex = 5;
            this.labelTotal.Text = "label5";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.button1.ForeColor = System.Drawing.Color.FloralWhite;
            this.button1.Location = new System.Drawing.Point(290, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 59);
            this.button1.TabIndex = 6;
            this.button1.Text = "Забронировать";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DodgerBlue;
            this.button3.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.button3.ForeColor = System.Drawing.Color.FloralWhite;
            this.button3.Location = new System.Drawing.Point(619, 372);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 35);
            this.button3.TabIndex = 7;
            this.button3.Text = "Выйти";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.btnBackToLogin_Click);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(732, 409);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelVAT);
            this.Controls.Add(this.labelRoomPrice);
            this.Controls.Add(this.labelDaysOfStay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxService);
            this.Name = "PaymentForm";
            this.Text = "PaymentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxService;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDaysOfStay;
        private System.Windows.Forms.Label labelRoomPrice;
        private System.Windows.Forms.Label labelVAT;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button button3;
    }
}