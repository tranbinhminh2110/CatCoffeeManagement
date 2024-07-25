namespace CatCoffee
{
    partial class AreaManager
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
            dataGridViewAreas = new DataGridView();
            txtAreaName = new TextBox();
            btnCreateArea = new Button();
            btnUpdateArea = new Button();
            btnLogout = new Button();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAreas).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewAreas
            // 
            dataGridViewAreas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAreas.Location = new Point(16, 158);
            dataGridViewAreas.Margin = new Padding(4, 5, 4, 5);
            dataGridViewAreas.Name = "dataGridViewAreas";
            dataGridViewAreas.RowHeadersWidth = 51;
            dataGridViewAreas.Size = new Size(880, 353);
            dataGridViewAreas.TabIndex = 0;
            dataGridViewAreas.CellClick += dataGridViewAreas_CellClick;
            // 
            // txtAreaName
            // 
            txtAreaName.Location = new Point(144, 575);
            txtAreaName.Margin = new Padding(4, 5, 4, 5);
            txtAreaName.Name = "txtAreaName";
            txtAreaName.Size = new Size(291, 27);
            txtAreaName.TabIndex = 1;
            txtAreaName.TextChanged += txtAreaName_TextChanged;
            // 
            // btnCreateArea
            // 
            btnCreateArea.Location = new Point(144, 643);
            btnCreateArea.Margin = new Padding(4, 5, 4, 5);
            btnCreateArea.Name = "btnCreateArea";
            btnCreateArea.Size = new Size(100, 35);
            btnCreateArea.TabIndex = 2;
            btnCreateArea.Text = "Create";
            btnCreateArea.UseVisualStyleBackColor = true;
            btnCreateArea.Click += btnCreateArea_Click;
            // 
            // btnUpdateArea
            // 
            btnUpdateArea.Location = new Point(309, 643);
            btnUpdateArea.Margin = new Padding(4, 5, 4, 5);
            btnUpdateArea.Name = "btnUpdateArea";
            btnUpdateArea.Size = new Size(100, 35);
            btnUpdateArea.TabIndex = 3;
            btnUpdateArea.Text = "Update";
            btnUpdateArea.UseVisualStyleBackColor = true;
            btnUpdateArea.Click += btnUpdateArea_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(16, 27);
            btnLogout.Margin = new Padding(4, 5, 4, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 35);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 582);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 6;
            label1.Text = "AreaName";
            // 
            // button1
            // 
            button1.Location = new Point(458, 643);
            button1.Name = "button1";
            button1.Size = new Size(94, 38);
            button1.TabIndex = 7;
            button1.Text = "active";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnActivate_Click;
            // 
            // button2
            // 
            button2.Location = new Point(600, 649);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 8;
            button2.Text = "deactive";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnDeactivate_Click;
            // 
            // button3
            // 
            button3.Location = new Point(938, 206);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 9;
            button3.Text = "cat";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnCatManagement_Click;
            // 
            // button4
            // 
            button4.Location = new Point(938, 311);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 10;
            button4.Text = "table";
            button4.UseVisualStyleBackColor = true;
            button4.Click += btnTableManagement_Click;
            // 
            // AreaManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1076, 697);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(btnLogout);
            Controls.Add(btnUpdateArea);
            Controls.Add(btnCreateArea);
            Controls.Add(txtAreaName);
            Controls.Add(dataGridViewAreas);
            Margin = new Padding(4, 5, 4, 5);
            Name = "AreaManager";
            Text = "Area Manager";
            Load += AreaManager_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAreas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dataGridViewAreas;
        private System.Windows.Forms.TextBox txtAreaName;
        private System.Windows.Forms.Button btnCreateArea;
        private System.Windows.Forms.Button btnUpdateArea;
        private System.Windows.Forms.Button btnLogout;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}