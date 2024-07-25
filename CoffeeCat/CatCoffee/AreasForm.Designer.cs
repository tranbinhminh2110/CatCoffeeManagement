namespace CatCoffee
{
    partial class AreasForm
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
            dataGridViewAreas = new DataGridView();
            btnCat = new Button();
            btnBooking = new Button();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAreas).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewAreas
            // 
            dataGridViewAreas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAreas.Location = new Point(84, 73);
            dataGridViewAreas.Name = "dataGridViewAreas";
            dataGridViewAreas.RowHeadersWidth = 51;
            dataGridViewAreas.Size = new Size(640, 267);
            dataGridViewAreas.TabIndex = 0;
            dataGridViewAreas.CellClick += dataGridViewAreas_CellClick;
            dataGridViewAreas.CellContentClick += dataGridViewAreas_CellContentClick;
            // 
            // btnCat
            // 
            btnCat.Location = new Point(84, 376);
            btnCat.Name = "btnCat";
            btnCat.Size = new Size(94, 29);
            btnCat.TabIndex = 1;
            btnCat.Text = "cat";
            btnCat.UseVisualStyleBackColor = true;
            btnCat.Click += btnShowCats_Click;
            // 
            // btnBooking
            // 
            btnBooking.Location = new Point(630, 376);
            btnBooking.Name = "btnBooking";
            btnBooking.Size = new Size(94, 29);
            btnBooking.TabIndex = 3;
            btnBooking.Text = "booking";
            btnBooking.UseVisualStyleBackColor = true;
            btnBooking.Click += btnBook_Click;
            // 
            // button1
            // 
            button1.Location = new Point(270, 376);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "table";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnShowTables_Click;
            // 
            // button2
            // 
            button2.Location = new Point(621, 23);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 5;
            button2.Text = "logout";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnLogout_Click;
            // 
            // AreasForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnBooking);
            Controls.Add(btnCat);
            Controls.Add(dataGridViewAreas);
            Name = "AreasForm";
            Text = "AreasForm";
            Load += AreasForm_Load;
            Click += btnShowTables_Click;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAreas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewAreas;
        private Button btnCat;
        private Button btnBooking;
        private Button button1;
        private Button button2;
    }
}