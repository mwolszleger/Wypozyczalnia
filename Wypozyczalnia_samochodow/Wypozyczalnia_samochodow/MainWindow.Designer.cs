namespace Wypozyczalnia_samochodow
{
    partial class MainWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCars = new System.Windows.Forms.Button();
            this.buttonCustomers = new System.Windows.Forms.Button();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.search = new Wypozyczalnia_samochodow.WyszukiwarkaSam();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(416, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa użytkownika";
            // 
            // buttonCars
            // 
            this.buttonCars.Location = new System.Drawing.Point(284, 75);
            this.buttonCars.Name = "buttonCars";
            this.buttonCars.Size = new System.Drawing.Size(124, 34);
            this.buttonCars.TabIndex = 1;
            this.buttonCars.Text = "Samochody";
            this.buttonCars.UseVisualStyleBackColor = true;
            this.buttonCars.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCustomers
            // 
            this.buttonCustomers.Location = new System.Drawing.Point(284, 135);
            this.buttonCustomers.Name = "buttonCustomers";
            this.buttonCustomers.Size = new System.Drawing.Size(124, 34);
            this.buttonCustomers.TabIndex = 2;
            this.buttonCustomers.Text = "Klienci";
            this.buttonCustomers.UseVisualStyleBackColor = true;
            this.buttonCustomers.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Location = new System.Drawing.Point(284, 195);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(124, 34);
            this.buttonLogOut.TabIndex = 4;
            this.buttonLogOut.Text = "Wyloguj";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.button4_Click);
            // 
            // search
            // 
            this.search.AutoScroll = true;
            this.search.Location = new System.Drawing.Point(22, 12);
            this.search.MaximumSize = new System.Drawing.Size(641, 341);
            this.search.MinimumSize = new System.Drawing.Size(641, 341);
            this.search.Name = "search";
            this.search.SearchingCars = false;
            this.search.Size = new System.Drawing.Size(641, 341);
            this.search.TabIndex = 6;
            this.search.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 367);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.buttonCustomers);
            this.Controls.Add(this.buttonCars);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.search);
            this.MaximumSize = new System.Drawing.Size(704, 406);
            this.MinimumSize = new System.Drawing.Size(704, 406);
            this.Name = "MainWindow";
            this.Text = "Wypożyczalnia samochodów";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCars;
        private System.Windows.Forms.Button buttonCustomers;
        private System.Windows.Forms.Button buttonLogOut;
        private WyszukiwarkaSam search;
    }
}