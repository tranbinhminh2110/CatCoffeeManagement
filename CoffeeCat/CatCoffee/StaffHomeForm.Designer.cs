namespace CatCoffee
{
    partial class StaffHomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewBookings;
        private System.Windows.Forms.Button btnConfirmBooking;
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
            dataGridViewBookings = new DataGridView();
            btnConfirmBooking = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBookings).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewBookings
            // 
            dataGridViewBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBookings.Location = new Point(23, 42);
            dataGridViewBookings.Name = "dataGridViewBookings";
            dataGridViewBookings.RowHeadersWidth = 51;
            dataGridViewBookings.Size = new Size(716, 260);
            dataGridViewBookings.TabIndex = 0;
            dataGridViewBookings.CellContentClick += dataGridViewBookings_CellContentClick;
            // 
            // btnConfirmBooking
            // 
            btnConfirmBooking.Location = new Point(296, 308);
            btnConfirmBooking.Name = "btnConfirmBooking";
            btnConfirmBooking.Size = new Size(120, 40);
            btnConfirmBooking.TabIndex = 1;
            btnConfirmBooking.Text = "Confirm Booking";
            btnConfirmBooking.UseVisualStyleBackColor = true;
            btnConfirmBooking.Click += btnConfirmBooking_Click;
            // 
            // button1
            // 
            button1.Location = new Point(658, 7);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "logout";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnLogout_Click;
            // 
            // StaffHomeForm
            // 
            ClientSize = new Size(764, 376);
            Controls.Add(button1);
            Controls.Add(btnConfirmBooking);
            Controls.Add(dataGridViewBookings);
            Name = "StaffHomeForm";
            Text = "Staff Home";
            Load += StaffHomeForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewBookings).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private Button button1;
    }
}
