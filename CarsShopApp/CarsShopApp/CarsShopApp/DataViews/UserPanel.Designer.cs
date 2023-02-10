
namespace CarsShopApp.DataViews
{
    partial class UserPanel
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuPanels = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMarks = new System.Windows.Forms.ToolStripMenuItem();
            this.panelModels = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.panelGearboxes = new System.Windows.Forms.ToolStripMenuItem();
            this.panelFuels = new System.Windows.Forms.ToolStripMenuItem();
            this.panelCars = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminDashboard = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminUsersPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.myAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbProfilePicture = new System.Windows.Forms.PictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPanels,
            this.AdminDashboard,
            this.myAccountToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(936, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuPanels
            // 
            this.menuPanels.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.panelMarks,
            this.panelModels,
            this.panelTypes,
            this.panelGearboxes,
            this.panelFuels,
            this.panelCars});
            this.menuPanels.Name = "menuPanels";
            this.menuPanels.Size = new System.Drawing.Size(62, 24);
            this.menuPanels.Text = "Panels";
            // 
            // panelMarks
            // 
            this.panelMarks.Name = "panelMarks";
            this.panelMarks.Size = new System.Drawing.Size(174, 24);
            this.panelMarks.Text = "Car Marks";
            this.panelMarks.Click += new System.EventHandler(this.panelMarks_Click);
            // 
            // panelModels
            // 
            this.panelModels.Name = "panelModels";
            this.panelModels.Size = new System.Drawing.Size(174, 24);
            this.panelModels.Text = "Car Models";
            this.panelModels.Click += new System.EventHandler(this.panelModels_Click);
            // 
            // panelTypes
            // 
            this.panelTypes.Name = "panelTypes";
            this.panelTypes.Size = new System.Drawing.Size(174, 24);
            this.panelTypes.Text = "Car Types";
            this.panelTypes.Click += new System.EventHandler(this.panelTypes_Click);
            // 
            // panelGearboxes
            // 
            this.panelGearboxes.Name = "panelGearboxes";
            this.panelGearboxes.Size = new System.Drawing.Size(174, 24);
            this.panelGearboxes.Text = "Car Gearboxes";
            this.panelGearboxes.Click += new System.EventHandler(this.panelGearboxes_Click);
            // 
            // panelFuels
            // 
            this.panelFuels.Name = "panelFuels";
            this.panelFuels.Size = new System.Drawing.Size(174, 24);
            this.panelFuels.Text = "Fuels";
            this.panelFuels.Click += new System.EventHandler(this.panelFuels_Click);
            // 
            // panelCars
            // 
            this.panelCars.Name = "panelCars";
            this.panelCars.Size = new System.Drawing.Size(174, 24);
            this.panelCars.Text = "Cars";
            this.panelCars.Click += new System.EventHandler(this.panelCars_Click);
            // 
            // AdminDashboard
            // 
            this.AdminDashboard.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AdminUsersPanel});
            this.AdminDashboard.Name = "AdminDashboard";
            this.AdminDashboard.Size = new System.Drawing.Size(142, 24);
            this.AdminDashboard.Text = "Admin Dashboard";
            this.AdminDashboard.Visible = false;
            // 
            // AdminUsersPanel
            // 
            this.AdminUsersPanel.Name = "AdminUsersPanel";
            this.AdminUsersPanel.Size = new System.Drawing.Size(113, 24);
            this.AdminUsersPanel.Text = "Users";
            this.AdminUsersPanel.Click += new System.EventHandler(this.AdminUsersPanel_Click);
            // 
            // myAccountToolStripMenuItem
            // 
            this.myAccountToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.myAccountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem});
            this.myAccountToolStripMenuItem.Name = "myAccountToolStripMenuItem";
            this.myAccountToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.myAccountToolStripMenuItem.Text = "My account";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // pbProfilePicture
            // 
            this.pbProfilePicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbProfilePicture.Location = new System.Drawing.Point(95, 90);
            this.pbProfilePicture.Name = "pbProfilePicture";
            this.pbProfilePicture.Size = new System.Drawing.Size(120, 120);
            this.pbProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProfilePicture.TabIndex = 1;
            this.pbProfilePicture.TabStop = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(92, 246);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(0, 24);
            this.lblWelcome.TabIndex = 2;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(274, 123);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 18);
            this.lblUsername.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(274, 162);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(0, 18);
            this.lblEmail.TabIndex = 4;
            // 
            // UserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 541);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.pbProfilePicture);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UserPanel";
            this.Text = "User Panel";
            this.Load += new System.EventHandler(this.UserPanel_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuPanels;
        private System.Windows.Forms.ToolStripMenuItem panelMarks;
        private System.Windows.Forms.ToolStripMenuItem panelModels;
        private System.Windows.Forms.ToolStripMenuItem panelTypes;
        private System.Windows.Forms.ToolStripMenuItem panelGearboxes;
        private System.Windows.Forms.ToolStripMenuItem panelFuels;
        private System.Windows.Forms.ToolStripMenuItem panelCars;
        private System.Windows.Forms.ToolStripMenuItem AdminDashboard;
        private System.Windows.Forms.ToolStripMenuItem myAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminUsersPanel;
        private System.Windows.Forms.PictureBox pbProfilePicture;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblEmail;
    }
}