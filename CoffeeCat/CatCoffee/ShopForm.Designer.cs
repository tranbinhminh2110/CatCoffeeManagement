namespace CatCoffee
{
    partial class ShopForm
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
            txtSearch = new TextBox();
            dataGridViewShops = new DataGridView();
            btnSearch = new Button();
            btnShowAreas = new Button();
            btnShowMenus = new Button();
            btnHistory = new Button();
            lblWelcome = new Label();
            btnLogout = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewShops).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(169, 52);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(240, 27);
            txtSearch.TabIndex = 1;
            // 
            // dataGridViewShops
            // 
            dataGridViewShops.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewShops.Location = new Point(34, 97);
            dataGridViewShops.Name = "dataGridViewShops";
            dataGridViewShops.RowHeadersWidth = 51;
            dataGridViewShops.Size = new Size(719, 262);
            dataGridViewShops.TabIndex = 3;
            dataGridViewShops.CellClick += dataGridViewShops_CellClick;
            dataGridViewShops.CellContentClick += dataGridViewShops_CellContentClick;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(34, 52);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnShowAreas
            // 
            btnShowAreas.Location = new Point(34, 384);
            btnShowAreas.Name = "btnShowAreas";
            btnShowAreas.Size = new Size(94, 29);
            btnShowAreas.TabIndex = 6;
            btnShowAreas.Text = "Area";
            btnShowAreas.UseVisualStyleBackColor = true;
            btnShowAreas.Click += btnShowAreas_Click;
            // 
            // btnShowMenus
            // 
            btnShowMenus.Location = new Point(228, 384);
            btnShowMenus.Name = "btnShowMenus";
            btnShowMenus.Size = new Size(94, 29);
            btnShowMenus.TabIndex = 7;
            btnShowMenus.Text = "Menu";
            btnShowMenus.UseVisualStyleBackColor = true;
            btnShowMenus.Click += btnShowMenus_Click;
            // 
            // btnHistory
            // 
            btnHistory.Location = new Point(392, 384);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(175, 29);
            btnHistory.TabIndex = 8;
            btnHistory.Text = "BookingHistory";
            btnHistory.UseVisualStyleBackColor = true;
            btnHistory.Click += btnShowbookingHistory_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(34, 9);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(71, 20);
            lblWelcome.TabIndex = 9;
            lblWelcome.Text = "Welcome";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(659, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 10;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // ShopForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogout);
            Controls.Add(lblWelcome);
            Controls.Add(btnHistory);
            Controls.Add(btnShowMenus);
            Controls.Add(btnShowAreas);
            Controls.Add(btnSearch);
            Controls.Add(dataGridViewShops);
            Controls.Add(txtSearch);
            Name = "ShopForm";
            Text = "ShopForm";
            Load += ShopForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewShops).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private DataGridView dataGridViewShops;
        private Button btnSearch;
        private Button btnShowCats;
        private Button btnShowAreas;
        private Button btnShowMenus;
        private Button btnHistory;
        private Label lblWelcome;
        private Button btnLogout;
    }
}