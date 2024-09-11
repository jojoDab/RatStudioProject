namespace testing
{
    partial class log_in
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Ent_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Visible_Box = new System.Windows.Forms.PictureBox();
            this.Anvisible_Box = new System.Windows.Forms.PictureBox();
            this.Clear_Box = new System.Windows.Forms.PictureBox();
            this.Close_Box = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Visible_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Anvisible_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Clear_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(86, 191);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Small", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(84, 258);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Пароль";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(170, 188);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(186, 31);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(170, 254);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(186, 31);
            this.textBox2.TabIndex = 1;
            // 
            // Ent_button
            // 
            this.Ent_button.BackColor = System.Drawing.SystemColors.Window;
            this.Ent_button.Font = new System.Drawing.Font("Sitka Small", 10.25F);
            this.Ent_button.Location = new System.Drawing.Point(188, 325);
            this.Ent_button.Name = "Ent_button";
            this.Ent_button.Size = new System.Drawing.Size(147, 55);
            this.Ent_button.TabIndex = 2;
            this.Ent_button.Text = "Войти";
            this.Ent_button.UseVisualStyleBackColor = false;
            this.Ent_button.Click += new System.EventHandler(this.Ent_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Small", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(88, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(333, 65);
            this.label3.TabIndex = 0;
            this.label3.Text = "Авторизация";
            // 
            // Visible_Box
            // 
            this.Visible_Box.Image = global::testing.Properties.Resources._4781835_eye_on_see_show_view_icon;
            this.Visible_Box.Location = new System.Drawing.Point(362, 252);
            this.Visible_Box.Name = "Visible_Box";
            this.Visible_Box.Size = new System.Drawing.Size(40, 40);
            this.Visible_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Visible_Box.TabIndex = 6;
            this.Visible_Box.TabStop = false;
            this.Visible_Box.Click += new System.EventHandler(this.Visible_Box_Click);
            // 
            // Anvisible_Box
            // 
            this.Anvisible_Box.Image = global::testing.Properties.Resources._4781836_eye_hide_off_see_view_icon;
            this.Anvisible_Box.Location = new System.Drawing.Point(362, 252);
            this.Anvisible_Box.Name = "Anvisible_Box";
            this.Anvisible_Box.Size = new System.Drawing.Size(40, 40);
            this.Anvisible_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Anvisible_Box.TabIndex = 6;
            this.Anvisible_Box.TabStop = false;
            this.Anvisible_Box.Click += new System.EventHandler(this.Anvisible_Box_Click);
            // 
            // Clear_Box
            // 
            this.Clear_Box.Image = global::testing.Properties.Resources._7257633_erase_delete_remove_recycle_icon;
            this.Clear_Box.Location = new System.Drawing.Point(362, 185);
            this.Clear_Box.Name = "Clear_Box";
            this.Clear_Box.Size = new System.Drawing.Size(40, 40);
            this.Clear_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Clear_Box.TabIndex = 5;
            this.Clear_Box.TabStop = false;
            this.Clear_Box.Click += new System.EventHandler(this.Clear_Box_Click);
            // 
            // Close_Box
            // 
            this.Close_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Close_Box.Image = global::testing.Properties.Resources._4115230_cancel_close_delete_icon;
            this.Close_Box.Location = new System.Drawing.Point(454, 3);
            this.Close_Box.Name = "Close_Box";
            this.Close_Box.Size = new System.Drawing.Size(39, 40);
            this.Close_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Close_Box.TabIndex = 4;
            this.Close_Box.TabStop = false;
            this.Close_Box.Click += new System.EventHandler(this.Close_Box_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::testing.Properties.Resources._4092564_profile_about_mobile_ui_user_icon;
            this.pictureBox1.Location = new System.Drawing.Point(42, 105);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // log_in
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(495, 455);
            this.ControlBox = false;
            this.Controls.Add(this.Visible_Box);
            this.Controls.Add(this.Anvisible_Box);
            this.Controls.Add(this.Clear_Box);
            this.Controls.Add(this.Close_Box);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Ent_button);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "log_in";
            this.ShowIcon = false;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.log_in_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Visible_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Anvisible_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Clear_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Ent_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox Close_Box;
        private System.Windows.Forms.PictureBox Clear_Box;
        private System.Windows.Forms.PictureBox Anvisible_Box;
        private System.Windows.Forms.PictureBox Visible_Box;
    }
}

