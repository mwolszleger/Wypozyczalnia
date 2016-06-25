namespace Wypozyczalnia_samochodow
{
    partial class CarView
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxBrand = new System.Windows.Forms.TextBox();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.textBoxPojemnosc = new System.Windows.Forms.TextBox();
            this.textBoxColor = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.buttonLend = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.textBoxUserId = new System.Windows.Forms.TextBox();
            this.labelUseId = new System.Windows.Forms.Label();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxAvailaible = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxFuel = new System.Windows.Forms.ComboBox();
            this.comboBoxClima = new System.Windows.Forms.ComboBox();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marka:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Model:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rok produkcji:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Rodzaj paliwa:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Pojemność:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(184, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Kolor:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Klimatyzacja:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(184, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Cena za dobę:";
            // 
            // textBoxBrand
            // 
            this.textBoxBrand.Location = new System.Drawing.Point(58, 30);
            this.textBoxBrand.Name = "textBoxBrand";
            this.textBoxBrand.Size = new System.Drawing.Size(92, 20);
            this.textBoxBrand.TabIndex = 8;
            //this.textBoxBrand.TextChanged += new System.EventHandler(this.stringValidation);
            this.textBoxBrand.Enter += new System.EventHandler(this.textBoxBrand_Enter);
            // 
            // textBoxModel
            // 
            this.textBoxModel.Location = new System.Drawing.Point(229, 30);
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(129, 20);
            this.textBoxModel.TabIndex = 9;
            //this.textBoxModel.TextChanged += new System.EventHandler(this.stringValidation);
            this.textBoxModel.Enter += new System.EventHandler(this.textBoxBrand_Enter);
            // 
            // textBoxYear
            // 
            this.textBoxYear.Location = new System.Drawing.Point(94, 64);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(56, 20);
            this.textBoxYear.TabIndex = 10;
           // this.textBoxYear.TextChanged += new System.EventHandler(this.numberValidation);
            this.textBoxYear.Enter += new System.EventHandler(this.textBoxBrand_Enter);
            // 
            // textBoxPojemnosc
            // 
            this.textBoxPojemnosc.Location = new System.Drawing.Point(80, 97);
            this.textBoxPojemnosc.Name = "textBoxPojemnosc";
            this.textBoxPojemnosc.Size = new System.Drawing.Size(70, 20);
            this.textBoxPojemnosc.TabIndex = 12;
            //this.textBoxPojemnosc.TextChanged += new System.EventHandler(this.numberValidation);
            this.textBoxPojemnosc.Enter += new System.EventHandler(this.textBoxBrand_Enter);
            // 
            // textBoxColor
            // 
            this.textBoxColor.Location = new System.Drawing.Point(224, 97);
            this.textBoxColor.Name = "textBoxColor";
            this.textBoxColor.Size = new System.Drawing.Size(134, 20);
            this.textBoxColor.TabIndex = 13;
            //this.textBoxColor.TextChanged += new System.EventHandler(this.stringValidation);
            this.textBoxColor.Enter += new System.EventHandler(this.textBoxBrand_Enter);
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(266, 129);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(92, 20);
            this.textBoxPrice.TabIndex = 15;
           // this.textBoxPrice.TextChanged += new System.EventHandler(this.numberValidation);
            this.textBoxPrice.Enter += new System.EventHandler(this.textBoxBrand_Enter);
            // 
            // buttonLend
            // 
            this.buttonLend.Location = new System.Drawing.Point(380, 26);
            this.buttonLend.Name = "buttonLend";
            this.buttonLend.Size = new System.Drawing.Size(89, 24);
            this.buttonLend.TabIndex = 16;
            this.buttonLend.Text = "Wypożycz";
            this.buttonLend.UseVisualStyleBackColor = true;
            this.buttonLend.Click += new System.EventHandler(this.buttonLend_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(380, 61);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(89, 24);
            this.buttonEdit.TabIndex = 17;
            this.buttonEdit.Text = "Edytuj";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(380, 94);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(89, 24);
            this.buttonOK.TabIndex = 18;
            this.buttonOK.Text = "Zatwierdź";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonEnd
            // 
            this.buttonEnd.Location = new System.Drawing.Point(380, 184);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(89, 24);
            this.buttonEnd.TabIndex = 19;
            this.buttonEnd.Text = "Zakończ";
            this.buttonEnd.UseVisualStyleBackColor = true;
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(12, 223);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(0, 13);
            this.labelMessage.TabIndex = 20;
            // 
            // textBoxUserId
            // 
            this.textBoxUserId.Location = new System.Drawing.Point(118, 192);
            this.textBoxUserId.Name = "textBoxUserId";
            this.textBoxUserId.Size = new System.Drawing.Size(89, 20);
            this.textBoxUserId.TabIndex = 22;
            this.textBoxUserId.Visible = false;
           // this.textBoxUserId.TabIndexChanged += new System.EventHandler(this.numberValidation);
          // this.textBoxUserId.TextChanged += new System.EventHandler(this.numberValidation);
            this.textBoxUserId.Enter += new System.EventHandler(this.textBoxBrand_Enter);
            // 
            // labelUseId
            // 
            this.labelUseId.AutoSize = true;
            this.labelUseId.Location = new System.Drawing.Point(12, 195);
            this.labelUseId.Name = "labelUseId";
            this.labelUseId.Size = new System.Drawing.Size(103, 13);
            this.labelUseId.TabIndex = 21;
            this.labelUseId.Text = "Numer użytkownika:";
            this.labelUseId.Visible = false;
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(266, 163);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(92, 20);
            this.textBoxNumber.TabIndex = 24;
            this.textBoxNumber.TextChanged += new System.EventHandler(this.registryNumberValidation);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(184, 166);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Nr rejestracyjny:";
            // 
            // textBoxAvailaible
            // 
            this.textBoxAvailaible.Location = new System.Drawing.Point(80, 163);
            this.textBoxAvailaible.Name = "textBoxAvailaible";
            this.textBoxAvailaible.ReadOnly = true;
            this.textBoxAvailaible.Size = new System.Drawing.Size(70, 20);
            this.textBoxAvailaible.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 166);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Dostępny:";
            // 
            // comboBoxFuel
            // 
            this.comboBoxFuel.FormattingEnabled = true;
            this.comboBoxFuel.Items.AddRange(new object[] {
            "benzyna",
            "diesel",
            "benzyna+LPG"});
            this.comboBoxFuel.Location = new System.Drawing.Point(266, 59);
            this.comboBoxFuel.Name = "comboBoxFuel";
            this.comboBoxFuel.Size = new System.Drawing.Size(92, 21);
            this.comboBoxFuel.TabIndex = 27;
            this.comboBoxFuel.Enter += new System.EventHandler(this.textBoxBrand_Enter);
            // 
            // comboBoxClima
            // 
            this.comboBoxClima.FormattingEnabled = true;
            this.comboBoxClima.Items.AddRange(new object[] {
            "tak",
            "nie"});
            this.comboBoxClima.Location = new System.Drawing.Point(80, 123);
            this.comboBoxClima.Name = "comboBoxClima";
            this.comboBoxClima.Size = new System.Drawing.Size(69, 21);
            this.comboBoxClima.TabIndex = 28;
            this.comboBoxClima.Enter += new System.EventHandler(this.textBoxBrand_Enter);
            // 
            // buttonReturn
            // 
            this.buttonReturn.Location = new System.Drawing.Point(380, 125);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(89, 24);
            this.buttonReturn.TabIndex = 29;
            this.buttonReturn.Text = "Zwróć";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 24);
            this.button1.TabIndex = 30;
            this.button1.Text = "Usuń";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 252);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.comboBoxClima);
            this.Controls.Add(this.comboBoxFuel);
            this.Controls.Add(this.textBoxAvailaible);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxUserId);
            this.Controls.Add(this.labelUseId);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.buttonEnd);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonLend);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxColor);
            this.Controls.Add(this.textBoxPojemnosc);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.textBoxModel);
            this.Controls.Add(this.textBoxBrand);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(497, 291);
            this.MinimumSize = new System.Drawing.Size(497, 291);
            this.Name = "CarView";
            this.Text = "Wypożyczalnia samochodów";
            //this.Load += new System.EventHandler(this.CarView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxBrand;
        private System.Windows.Forms.TextBox textBoxModel;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.TextBox textBoxPojemnosc;
        private System.Windows.Forms.TextBox textBoxColor;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Button buttonLend;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonEnd;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.TextBox textBoxUserId;
        private System.Windows.Forms.Label labelUseId;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxAvailaible;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxFuel;
        private System.Windows.Forms.ComboBox comboBoxClima;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Button button1;
    }
}