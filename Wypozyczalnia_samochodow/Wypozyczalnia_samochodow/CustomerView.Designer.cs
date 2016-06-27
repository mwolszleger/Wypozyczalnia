namespace Wypozyczalnia_samochodow
{
    partial class CustomerView
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
            this.label_name = new System.Windows.Forms.Label();
            this.label_lastname = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.textLastName = new System.Windows.Forms.TextBox();
            this.button_close = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.button_rent = new System.Windows.Forms.Button();
            this.label_citycode = new System.Windows.Forms.Label();
            this.label_place = new System.Windows.Forms.Label();
            this.label_flatnr = new System.Windows.Forms.Label();
            this.label_housenr = new System.Windows.Forms.Label();
            this.label_street = new System.Windows.Forms.Label();
            this.textHouseNumber = new System.Windows.Forms.TextBox();
            this.textStreet = new System.Windows.Forms.TextBox();
            this.textPlace = new System.Windows.Forms.TextBox();
            this.textFlatNumber = new System.Windows.Forms.TextBox();
            this.label_phonenr = new System.Windows.Forms.Label();
            this.textPhoneNumber = new System.Windows.Forms.TextBox();
            this.textCodeCity = new System.Windows.Forms.TextBox();
            this.label_text = new System.Windows.Forms.Label();
            this.label_id = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label_nr = new System.Windows.Forms.Label();
            this.textBox_nr = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(12, 33);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(29, 13);
            this.label_name.TabIndex = 1;
            this.label_name.Text = "Imię:";
            // 
            // label_lastname
            // 
            this.label_lastname.AutoSize = true;
            this.label_lastname.Location = new System.Drawing.Point(184, 33);
            this.label_lastname.Name = "label_lastname";
            this.label_lastname.Size = new System.Drawing.Size(56, 13);
            this.label_lastname.TabIndex = 2;
            this.label_lastname.Text = "Nazwisko:";
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(47, 30);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(112, 20);
            this.textName.TabIndex = 9;
            // 
            // textLastName
            // 
            this.textLastName.Location = new System.Drawing.Point(246, 30);
            this.textLastName.Name = "textLastName";
            this.textLastName.Size = new System.Drawing.Size(107, 20);
            this.textLastName.TabIndex = 10;
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(380, 126);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(89, 24);
            this.button_close.TabIndex = 23;
            this.button_close.Text = "Zamknij";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(380, 94);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(89, 24);
            this.buttonOK.TabIndex = 22;
            this.buttonOK.Text = "Zatwierdź";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // button_edit
            // 
            this.button_edit.Location = new System.Drawing.Point(380, 61);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(89, 24);
            this.button_edit.TabIndex = 21;
            this.button_edit.Text = "Edytuj";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // button_rent
            // 
            this.button_rent.Location = new System.Drawing.Point(380, 26);
            this.button_rent.Name = "button_rent";
            this.button_rent.Size = new System.Drawing.Size(89, 24);
            this.button_rent.TabIndex = 20;
            this.button_rent.Text = "Wypożycz";
            this.button_rent.UseVisualStyleBackColor = true;
            this.button_rent.Click += new System.EventHandler(this.button_rent_Click);
            // 
            // label_citycode
            // 
            this.label_citycode.AutoSize = true;
            this.label_citycode.Location = new System.Drawing.Point(12, 132);
            this.label_citycode.Name = "label_citycode";
            this.label_citycode.Size = new System.Drawing.Size(29, 13);
            this.label_citycode.TabIndex = 24;
            this.label_citycode.Text = "Kod:";
            // 
            // label_place
            // 
            this.label_place.AutoSize = true;
            this.label_place.Location = new System.Drawing.Point(184, 100);
            this.label_place.Name = "label_place";
            this.label_place.Size = new System.Drawing.Size(71, 13);
            this.label_place.TabIndex = 25;
            this.label_place.Text = "Miejscowość:";
            // 
            // label_flatnr
            // 
            this.label_flatnr.AutoSize = true;
            this.label_flatnr.Location = new System.Drawing.Point(12, 100);
            this.label_flatnr.Name = "label_flatnr";
            this.label_flatnr.Size = new System.Drawing.Size(76, 13);
            this.label_flatnr.TabIndex = 26;
            this.label_flatnr.Text = "Nr mieszkania:";
            // 
            // label_housenr
            // 
            this.label_housenr.AutoSize = true;
            this.label_housenr.Location = new System.Drawing.Point(184, 67);
            this.label_housenr.Name = "label_housenr";
            this.label_housenr.Size = new System.Drawing.Size(50, 13);
            this.label_housenr.TabIndex = 27;
            this.label_housenr.Text = "Nr domu:";
            // 
            // label_street
            // 
            this.label_street.AutoSize = true;
            this.label_street.Location = new System.Drawing.Point(12, 67);
            this.label_street.Name = "label_street";
            this.label_street.Size = new System.Drawing.Size(34, 13);
            this.label_street.TabIndex = 28;
            this.label_street.Text = "Ulica:";
            // 
            // textHouseNumber
            // 
            this.textHouseNumber.Location = new System.Drawing.Point(240, 64);
            this.textHouseNumber.Name = "textHouseNumber";
            this.textHouseNumber.Size = new System.Drawing.Size(113, 20);
            this.textHouseNumber.TabIndex = 29;
            // 
            // textStreet
            // 
            this.textStreet.Location = new System.Drawing.Point(52, 64);
            this.textStreet.Name = "textStreet";
            this.textStreet.Size = new System.Drawing.Size(107, 20);
            this.textStreet.TabIndex = 30;
            // 
            // textPlace
            // 
            this.textPlace.Location = new System.Drawing.Point(261, 98);
            this.textPlace.Name = "textPlace";
            this.textPlace.Size = new System.Drawing.Size(92, 20);
            this.textPlace.TabIndex = 31;
            // 
            // textFlatNumber
            // 
            this.textFlatNumber.Location = new System.Drawing.Point(94, 97);
            this.textFlatNumber.Name = "textFlatNumber";
            this.textFlatNumber.Size = new System.Drawing.Size(65, 20);
            this.textFlatNumber.TabIndex = 32;
            // 
            // label_phonenr
            // 
            this.label_phonenr.AutoSize = true;
            this.label_phonenr.Location = new System.Drawing.Point(184, 132);
            this.label_phonenr.Name = "label_phonenr";
            this.label_phonenr.Size = new System.Drawing.Size(62, 13);
            this.label_phonenr.TabIndex = 33;
            this.label_phonenr.Text = "Nr telefonu:";
            // 
            // textPhoneNumber
            // 
            this.textPhoneNumber.Location = new System.Drawing.Point(252, 129);
            this.textPhoneNumber.Name = "textPhoneNumber";
            this.textPhoneNumber.Size = new System.Drawing.Size(101, 20);
            this.textPhoneNumber.TabIndex = 34;
            // 
            // textCodeCity
            // 
            this.textCodeCity.Location = new System.Drawing.Point(47, 129);
            this.textCodeCity.Name = "textCodeCity";
            this.textCodeCity.Size = new System.Drawing.Size(112, 20);
            this.textCodeCity.TabIndex = 35;
            // 
            // label_text
            // 
            this.label_text.AutoSize = true;
            this.label_text.Location = new System.Drawing.Point(21, 187);
            this.label_text.Name = "label_text";
            this.label_text.Size = new System.Drawing.Size(0, 13);
            this.label_text.TabIndex = 36;
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(12, 163);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(18, 13);
            this.label_id.TabIndex = 37;
            this.label_id.Text = "ID";
            // 
            // textBox_ID
            // 
            this.textBox_ID.Location = new System.Drawing.Point(45, 160);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.ReadOnly = true;
            this.textBox_ID.Size = new System.Drawing.Size(114, 20);
            this.textBox_ID.TabIndex = 38;
            // 
            // label_nr
            // 
            this.label_nr.AutoSize = true;
            this.label_nr.Location = new System.Drawing.Point(184, 163);
            this.label_nr.Name = "label_nr";
            this.label_nr.Size = new System.Drawing.Size(102, 13);
            this.label_nr.TabIndex = 39;
            this.label_nr.Text = "Numer rejestracyjny:";
            this.label_nr.Visible = false;
            // 
            // textBox_nr
            // 
            this.textBox_nr.Location = new System.Drawing.Point(292, 160);
            this.textBox_nr.Name = "textBox_nr";
            this.textBox_nr.Size = new System.Drawing.Size(61, 20);
            this.textBox_nr.TabIndex = 40;
            this.textBox_nr.Visible = false;
            // 
            // CustomerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 253);
            this.Controls.Add(this.textBox_nr);
            this.Controls.Add(this.label_nr);
            this.Controls.Add(this.textBox_ID);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.label_text);
            this.Controls.Add(this.textCodeCity);
            this.Controls.Add(this.textPhoneNumber);
            this.Controls.Add(this.label_phonenr);
            this.Controls.Add(this.textFlatNumber);
            this.Controls.Add(this.textPlace);
            this.Controls.Add(this.textStreet);
            this.Controls.Add(this.textHouseNumber);
            this.Controls.Add(this.label_street);
            this.Controls.Add(this.label_housenr);
            this.Controls.Add(this.label_flatnr);
            this.Controls.Add(this.label_place);
            this.Controls.Add(this.label_citycode);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.button_rent);
            this.Controls.Add(this.textLastName);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.label_lastname);
            this.Controls.Add(this.label_name);
            this.MaximumSize = new System.Drawing.Size(497, 291);
            this.MinimumSize = new System.Drawing.Size(497, 291);
            this.Name = "CustomerView";
            this.Text = "Wypożyczalnia samochodów";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_lastname;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.TextBox textLastName;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Button button_rent;
        private System.Windows.Forms.Label label_citycode;
        private System.Windows.Forms.Label label_place;
        private System.Windows.Forms.Label label_flatnr;
        private System.Windows.Forms.Label label_housenr;
        private System.Windows.Forms.Label label_street;
        private System.Windows.Forms.TextBox textHouseNumber;
        private System.Windows.Forms.TextBox textStreet;
        private System.Windows.Forms.TextBox textPlace;
        private System.Windows.Forms.TextBox textFlatNumber;
        private System.Windows.Forms.Label label_phonenr;
        private System.Windows.Forms.TextBox textPhoneNumber;
        private System.Windows.Forms.TextBox textCodeCity;
        private System.Windows.Forms.Label label_text;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.Label label_nr;
        private System.Windows.Forms.TextBox textBox_nr;
    }
}