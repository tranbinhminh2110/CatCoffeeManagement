namespace CatCoffee
{
    partial class BookingHistoryForm
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
            dataGridViewBookingHistory = new DataGridView();
            btncancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBookingHistory).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewBookingHistory
            // 
            dataGridViewBookingHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBookingHistory.Location = new Point(139, 68);
            dataGridViewBookingHistory.Name = "dataGridViewBookingHistory";
            dataGridViewBookingHistory.RowHeadersWidth = 51;
            dataGridViewBookingHistory.Size = new Size(561, 281);
            dataGridViewBookingHistory.TabIndex = 0;
            // 
            // btncancel
            // 
            btncancel.Location = new Point(139, 385);
            btncancel.Name = "btncancel";
            btncancel.Size = new Size(94, 29);
            btncancel.TabIndex = 1;
            btncancel.Text = "Cancel";
            btncancel.UseVisualStyleBackColor = true;
            btncancel.Click += btnCancelBooking_Click;
            // 
            // BookingHistoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btncancel);
            Controls.Add(dataGridViewBookingHistory);
            Name = "BookingHistoryForm";
            Text = "BookingHistoryForm";
            Load += BookingHistoryForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewBookingHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewBookingHistory;
        private Button btncancel;
    }
}