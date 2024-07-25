namespace CatCoffee
{
    partial class BookingForm
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

        private void InitializeComponent()
        {
            dateTimePickerBookingDate = new DateTimePicker();
            comboBoxStartTime = new ComboBox();
            comboBoxEndTime = new ComboBox();
            btnCheckAvailability = new Button();
            dataGridViewAvailableTables = new DataGridView();
            btnBooking = new Button();
            dataGridViewItems = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAvailableTables).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).BeginInit();
            SuspendLayout();
            // 
            // dateTimePickerBookingDate
            // 
            dateTimePickerBookingDate.Location = new Point(148, 34);
            dateTimePickerBookingDate.Margin = new Padding(3, 4, 3, 4);
            dateTimePickerBookingDate.Name = "dateTimePickerBookingDate";
            dateTimePickerBookingDate.Size = new Size(200, 27);
            dateTimePickerBookingDate.TabIndex = 0;
            dateTimePickerBookingDate.ValueChanged += dateTimePickerBookingDate_ValueChanged;
            // 
            // comboBoxStartTime
            // 
            comboBoxStartTime.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStartTime.FormattingEnabled = true;
            comboBoxStartTime.Items.AddRange(new object[] { "07:00 AM", "09:00 AM", "01:00 PM", "03:00 PM" });
            comboBoxStartTime.Location = new Point(12, 119);
            comboBoxStartTime.Margin = new Padding(3, 4, 3, 4);
            comboBoxStartTime.Name = "comboBoxStartTime";
            comboBoxStartTime.Size = new Size(121, 28);
            comboBoxStartTime.TabIndex = 1;
            // 
            // comboBoxEndTime
            // 
            comboBoxEndTime.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEndTime.FormattingEnabled = true;
            comboBoxEndTime.Items.AddRange(new object[] { "09:00 AM", "11:00 AM", "03:00 PM", "05:00 PM" });
            comboBoxEndTime.Location = new Point(12, 182);
            comboBoxEndTime.Margin = new Padding(3, 4, 3, 4);
            comboBoxEndTime.Name = "comboBoxEndTime";
            comboBoxEndTime.Size = new Size(121, 28);
            comboBoxEndTime.TabIndex = 2;
            // 
            // btnCheckAvailability
            // 
            btnCheckAvailability.Location = new Point(12, 247);
            btnCheckAvailability.Margin = new Padding(3, 4, 3, 4);
            btnCheckAvailability.Name = "btnCheckAvailability";
            btnCheckAvailability.Size = new Size(121, 28);
            btnCheckAvailability.TabIndex = 3;
            btnCheckAvailability.Text = "Check Availability";
            btnCheckAvailability.UseVisualStyleBackColor = true;
            btnCheckAvailability.Click += btnCheckAvailability_Click;
            // 
            // dataGridViewAvailableTables
            // 
            dataGridViewAvailableTables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAvailableTables.Location = new Point(148, 98);
            dataGridViewAvailableTables.Name = "dataGridViewAvailableTables";
            dataGridViewAvailableTables.RowHeadersWidth = 51;
            dataGridViewAvailableTables.Size = new Size(352, 195);
            dataGridViewAvailableTables.TabIndex = 4;
            dataGridViewAvailableTables.CellClick += DataGridViewAvailableTables_CellClick;
            // 
            // btnBooking
            // 
            btnBooking.Location = new Point(12, 322);
            btnBooking.Name = "btnBooking";
            btnBooking.Size = new Size(94, 29);
            btnBooking.TabIndex = 5;
            btnBooking.Text = "Booking";
            btnBooking.UseVisualStyleBackColor = true;
            btnBooking.Click += btnBook_Click;
            // 
            // dataGridViewItems
            // 
            dataGridViewItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewItems.Location = new Point(527, 98);
            dataGridViewItems.Name = "dataGridViewItems";
            dataGridViewItems.RowHeadersWidth = 51;
            dataGridViewItems.Size = new Size(348, 195);
            dataGridViewItems.TabIndex = 6;
            dataGridViewItems.CellClick += DataGridViewItem_CellClick;
            dataGridViewItems.CellContentClick += dataGridViewItems_CellContentClick;
            // 
            // BookingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(887, 375);
            Controls.Add(dataGridViewItems);
            Controls.Add(btnBooking);
            Controls.Add(dataGridViewAvailableTables);
            Controls.Add(btnCheckAvailability);
            Controls.Add(comboBoxEndTime);
            Controls.Add(comboBoxStartTime);
            Controls.Add(dateTimePickerBookingDate);
            Margin = new Padding(3, 4, 3, 4);
            Name = "BookingForm";
            Text = "Booking Form";
            Load += BookingForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAvailableTables).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DateTimePicker dateTimePickerBookingDate;
        private System.Windows.Forms.ComboBox comboBoxStartTime;
        private System.Windows.Forms.ComboBox comboBoxEndTime;
        private System.Windows.Forms.Button btnCheckAvailability;
        private DataGridView dataGridViewAvailableTables;
        private Button btnBooking;
        private DataGridView dataGridViewItems;
    }
}