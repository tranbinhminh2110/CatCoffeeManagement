﻿namespace CatCoffee
{
    partial class MenusForm
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
            dataGridViewMenuItems = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMenuItems).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMenuItems
            // 
            dataGridViewMenuItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMenuItems.Location = new Point(93, 45);
            dataGridViewMenuItems.Name = "dataGridViewMenuItems";
            dataGridViewMenuItems.RowHeadersWidth = 51;
            dataGridViewMenuItems.Size = new Size(640, 302);
            dataGridViewMenuItems.TabIndex = 2;
            // 
            // MenusForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewMenuItems);
            Name = "MenusForm";
            Text = "MenusForm";
            Load += MenusForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMenuItems).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewMenuItems;
    }
}