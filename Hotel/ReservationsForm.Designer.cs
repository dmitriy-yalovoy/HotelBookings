namespace Hotel
{
    partial class ReservationsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBoxSearchCriteria = new System.Windows.Forms.ComboBox();
            this.dataGridViewReservations = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservations)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.button1.ForeColor = System.Drawing.Color.FloralWhite;
            this.button1.Location = new System.Drawing.Point(451, 448);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 45);
            this.button1.TabIndex = 1;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.button2.ForeColor = System.Drawing.Color.FloralWhite;
            this.button2.Location = new System.Drawing.Point(630, 448);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 45);
            this.button2.TabIndex = 2;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnDeleteReservation_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DodgerBlue;
            this.button3.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.button3.ForeColor = System.Drawing.Color.FloralWhite;
            this.button3.Location = new System.Drawing.Point(806, 398);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(152, 45);
            this.button3.TabIndex = 3;
            this.button3.Text = "Добавить";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.btnAddReservation_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DodgerBlue;
            this.button4.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.button4.ForeColor = System.Drawing.Color.FloralWhite;
            this.button4.Location = new System.Drawing.Point(451, 398);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(152, 44);
            this.button4.TabIndex = 9;
            this.button4.Text = "Найти";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.Font = new System.Drawing.Font("Comic Sans MS", 10.2F);
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Location = new System.Drawing.Point(27, 406);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(395, 31);
            this.txtSearch.TabIndex = 8;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DodgerBlue;
            this.button5.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.button5.ForeColor = System.Drawing.Color.FloralWhite;
            this.button5.Location = new System.Drawing.Point(630, 398);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(152, 44);
            this.button5.TabIndex = 10;
            this.button5.Text = "Вернуться";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // comboBoxSearchCriteria
            // 
            this.comboBoxSearchCriteria.BackColor = System.Drawing.Color.White;
            this.comboBoxSearchCriteria.Font = new System.Drawing.Font("Comic Sans MS", 10.2F);
            this.comboBoxSearchCriteria.ForeColor = System.Drawing.Color.Black;
            this.comboBoxSearchCriteria.FormattingEnabled = true;
            this.comboBoxSearchCriteria.Items.AddRange(new object[] {
            "ReservationID",
            "UserID",
            "RoomID",
            "CheckInDate",
            "CheckOutDate",
            "DaysOfStay",
            "StatusID",
            "EmployeesID",
            "GuestID"});
            this.comboBoxSearchCriteria.Location = new System.Drawing.Point(27, 456);
            this.comboBoxSearchCriteria.Name = "comboBoxSearchCriteria";
            this.comboBoxSearchCriteria.Size = new System.Drawing.Size(395, 32);
            this.comboBoxSearchCriteria.TabIndex = 11;
            // 
            // dataGridViewReservations
            // 
            this.dataGridViewReservations.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewReservations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewReservations.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewReservations.Location = new System.Drawing.Point(1, 1);
            this.dataGridViewReservations.Name = "dataGridViewReservations";
            this.dataGridViewReservations.RowHeadersWidth = 51;
            this.dataGridViewReservations.RowTemplate.Height = 24;
            this.dataGridViewReservations.Size = new System.Drawing.Size(977, 391);
            this.dataGridViewReservations.TabIndex = 12;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.DodgerBlue;
            this.button6.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.button6.ForeColor = System.Drawing.Color.FloralWhite;
            this.button6.Location = new System.Drawing.Point(806, 449);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(152, 45);
            this.button6.TabIndex = 13;
            this.button6.Text = "Выйти";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.btnBackToLogin_Click);
            // 
            // ReservationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(984, 502);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dataGridViewReservations);
            this.Controls.Add(this.comboBoxSearchCriteria);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ReservationsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReservationsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBoxSearchCriteria;
        private System.Windows.Forms.DataGridView dataGridViewReservations;
        private System.Windows.Forms.Button button6;
    }
}