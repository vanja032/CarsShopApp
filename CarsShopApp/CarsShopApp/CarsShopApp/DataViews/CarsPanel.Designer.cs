
namespace CarsShopApp.DataViews
{
    partial class CarsPanel
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
            this.lbCars = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMarks = new System.Windows.Forms.ComboBox();
            this.cbModels = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbGearboxes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTypes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbFuels = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.manufacturingDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.tbEngineVolume = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbCars
            // 
            this.lbCars.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCars.FormattingEnabled = true;
            this.lbCars.ItemHeight = 18;
            this.lbCars.Location = new System.Drawing.Point(430, 43);
            this.lbCars.Name = "lbCars";
            this.lbCars.Size = new System.Drawing.Size(1012, 364);
            this.lbCars.TabIndex = 0;
            this.lbCars.SelectedIndexChanged += new System.EventHandler(this.lbCars_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Car name:";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(64, 71);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(290, 24);
            this.tbName.TabIndex = 2;
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(430, 453);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(1012, 41);
            this.btnInsert.TabIndex = 3;
            this.btnInsert.Text = "Insert car";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(430, 512);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(1012, 41);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update car";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(430, 573);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(1012, 41);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete car";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mark name:";
            // 
            // cbMarks
            // 
            this.cbMarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMarks.FormattingEnabled = true;
            this.cbMarks.Location = new System.Drawing.Point(64, 140);
            this.cbMarks.Name = "cbMarks";
            this.cbMarks.Size = new System.Drawing.Size(290, 26);
            this.cbMarks.TabIndex = 7;
            this.cbMarks.SelectedIndexChanged += new System.EventHandler(this.cbMarks_SelectedIndexChanged);
            // 
            // cbModels
            // 
            this.cbModels.Enabled = false;
            this.cbModels.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbModels.FormattingEnabled = true;
            this.cbModels.Location = new System.Drawing.Point(64, 211);
            this.cbModels.Name = "cbModels";
            this.cbModels.Size = new System.Drawing.Size(290, 26);
            this.cbModels.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(61, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Model name:";
            // 
            // cbGearboxes
            // 
            this.cbGearboxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGearboxes.FormattingEnabled = true;
            this.cbGearboxes.Location = new System.Drawing.Point(64, 284);
            this.cbGearboxes.Name = "cbGearboxes";
            this.cbGearboxes.Size = new System.Drawing.Size(290, 26);
            this.cbGearboxes.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(61, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Gearbox name:";
            // 
            // cbTypes
            // 
            this.cbTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTypes.FormattingEnabled = true;
            this.cbTypes.Location = new System.Drawing.Point(64, 357);
            this.cbTypes.Name = "cbTypes";
            this.cbTypes.Size = new System.Drawing.Size(290, 26);
            this.cbTypes.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(61, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Type name:";
            // 
            // cbFuels
            // 
            this.cbFuels.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFuels.FormattingEnabled = true;
            this.cbFuels.Location = new System.Drawing.Point(64, 431);
            this.cbFuels.Name = "cbFuels";
            this.cbFuels.Size = new System.Drawing.Size(290, 26);
            this.cbFuels.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(61, 401);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "Fuel:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(61, 476);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "Manufacturing date:";
            // 
            // manufacturingDate
            // 
            this.manufacturingDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manufacturingDate.Location = new System.Drawing.Point(64, 510);
            this.manufacturingDate.Name = "manufacturingDate";
            this.manufacturingDate.Size = new System.Drawing.Size(290, 24);
            this.manufacturingDate.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(61, 553);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 18);
            this.label8.TabIndex = 19;
            this.label8.Text = "Engine volume (cm3):";
            // 
            // tbEngineVolume
            // 
            this.tbEngineVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEngineVolume.Location = new System.Drawing.Point(64, 590);
            this.tbEngineVolume.Name = "tbEngineVolume";
            this.tbEngineVolume.Size = new System.Drawing.Size(290, 24);
            this.tbEngineVolume.TabIndex = 20;
            // 
            // CarsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1505, 660);
            this.Controls.Add(this.tbEngineVolume);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.manufacturingDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbFuels);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbTypes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbGearboxes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbModels);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbMarks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbCars);
            this.Name = "CarsPanel";
            this.Text = "Cars Panel";
            this.Load += new System.EventHandler(this.CarModelsPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbCars;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMarks;
        private System.Windows.Forms.ComboBox cbModels;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbGearboxes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTypes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbFuels;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker manufacturingDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbEngineVolume;
    }
}