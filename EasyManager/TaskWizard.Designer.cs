namespace EasyManager
{
    partial class TaskWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskWizard));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.execEvery = new System.Windows.Forms.ComboBox();
            this.tDescBox = new System.Windows.Forms.TextBox();
            this.tNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.msgGroup = new System.Windows.Forms.GroupBox();
            this.msgTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.msgTitleBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.soundGroup = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.soundFileBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.processGroup = new System.Windows.Forms.GroupBox();
            this.procParamsBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.processFileBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.batchGroup = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.batchFileBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.msgGroup.SuspendLayout();
            this.soundGroup.SuspendLayout();
            this.processGroup.SuspendLayout();
            this.batchGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.execEvery);
            this.groupBox1.Controls.Add(this.tDescBox);
            this.groupBox1.Controls.Add(this.tNameBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 228);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Settings";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(6, 163);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(105, 19);
            this.checkBox5.TabIndex = 10;
            this.checkBox5.Text = "Execute Every:";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Execute on:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyy - hh:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(85, 196);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(149, 21);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // execEvery
            // 
            this.execEvery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.execEvery.Enabled = false;
            this.execEvery.FormattingEnabled = true;
            this.execEvery.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.execEvery.Location = new System.Drawing.Point(117, 161);
            this.execEvery.Name = "execEvery";
            this.execEvery.Size = new System.Drawing.Size(117, 23);
            this.execEvery.TabIndex = 5;
            this.execEvery.SelectedIndexChanged += new System.EventHandler(this.execEvery_SelectedIndexChanged);
            // 
            // tDescBox
            // 
            this.tDescBox.Location = new System.Drawing.Point(9, 72);
            this.tDescBox.Multiline = true;
            this.tDescBox.Name = "tDescBox";
            this.tDescBox.Size = new System.Drawing.Size(251, 79);
            this.tDescBox.TabIndex = 3;
            this.tDescBox.TextChanged += new System.EventHandler(this.tDescBox_TextChanged);
            // 
            // tNameBox
            // 
            this.tNameBox.Location = new System.Drawing.Point(85, 25);
            this.tNameBox.Name = "tNameBox";
            this.tNameBox.Size = new System.Drawing.Size(123, 21);
            this.tNameBox.TabIndex = 2;
            this.tNameBox.TextChanged += new System.EventHandler(this.tNameBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Task Details:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Task Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(296, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 157);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Task Behavior";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(16, 103);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(127, 19);
            this.checkBox4.TabIndex = 2;
            this.checkBox4.Text = "Execute Batch File";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(16, 78);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(96, 19);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "Run Process";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(16, 53);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(89, 19);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Sound Alert";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(16, 28);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 19);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Message Alert";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // msgGroup
            // 
            this.msgGroup.Controls.Add(this.msgTextBox);
            this.msgGroup.Controls.Add(this.label4);
            this.msgGroup.Controls.Add(this.msgTitleBox);
            this.msgGroup.Controls.Add(this.label3);
            this.msgGroup.Enabled = false;
            this.msgGroup.Location = new System.Drawing.Point(13, 240);
            this.msgGroup.Name = "msgGroup";
            this.msgGroup.Size = new System.Drawing.Size(243, 86);
            this.msgGroup.TabIndex = 2;
            this.msgGroup.TabStop = false;
            this.msgGroup.Text = "Message Alert";
            // 
            // msgTextBox
            // 
            this.msgTextBox.Location = new System.Drawing.Point(99, 47);
            this.msgTextBox.Name = "msgTextBox";
            this.msgTextBox.Size = new System.Drawing.Size(123, 21);
            this.msgTextBox.TabIndex = 6;
            this.msgTextBox.TextChanged += new System.EventHandler(this.msgTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Message Text:";
            // 
            // msgTitleBox
            // 
            this.msgTitleBox.Location = new System.Drawing.Point(99, 20);
            this.msgTitleBox.Name = "msgTitleBox";
            this.msgTitleBox.Size = new System.Drawing.Size(123, 21);
            this.msgTitleBox.TabIndex = 4;
            this.msgTitleBox.TextChanged += new System.EventHandler(this.msgTitleBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Message Title:";
            // 
            // soundGroup
            // 
            this.soundGroup.Controls.Add(this.button1);
            this.soundGroup.Controls.Add(this.soundFileBox);
            this.soundGroup.Controls.Add(this.label6);
            this.soundGroup.Enabled = false;
            this.soundGroup.Location = new System.Drawing.Point(282, 177);
            this.soundGroup.Name = "soundGroup";
            this.soundGroup.Size = new System.Drawing.Size(243, 102);
            this.soundGroup.TabIndex = 3;
            this.soundGroup.TabStop = false;
            this.soundGroup.Text = "Sound Alert";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(75, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Browse...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // soundFileBox
            // 
            this.soundFileBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soundFileBox.Location = new System.Drawing.Point(6, 44);
            this.soundFileBox.Name = "soundFileBox";
            this.soundFileBox.ReadOnly = true;
            this.soundFileBox.Size = new System.Drawing.Size(228, 20);
            this.soundFileBox.TabIndex = 4;
            this.soundFileBox.TextChanged += new System.EventHandler(this.soundFileBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Sound File:";
            // 
            // processGroup
            // 
            this.processGroup.Controls.Add(this.procParamsBox);
            this.processGroup.Controls.Add(this.label7);
            this.processGroup.Controls.Add(this.button2);
            this.processGroup.Controls.Add(this.processFileBox);
            this.processGroup.Controls.Add(this.label5);
            this.processGroup.Enabled = false;
            this.processGroup.Location = new System.Drawing.Point(13, 333);
            this.processGroup.Name = "processGroup";
            this.processGroup.Size = new System.Drawing.Size(243, 170);
            this.processGroup.TabIndex = 4;
            this.processGroup.TabStop = false;
            this.processGroup.Text = "Run Process";
            // 
            // procParamsBox
            // 
            this.procParamsBox.Location = new System.Drawing.Point(9, 129);
            this.procParamsBox.Name = "procParamsBox";
            this.procParamsBox.Size = new System.Drawing.Size(228, 21);
            this.procParamsBox.TabIndex = 10;
            this.procParamsBox.TextChanged += new System.EventHandler(this.procParamsBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Process Parameters:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(78, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Browse...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // processFileBox
            // 
            this.processFileBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processFileBox.Location = new System.Drawing.Point(9, 43);
            this.processFileBox.Name = "processFileBox";
            this.processFileBox.ReadOnly = true;
            this.processFileBox.Size = new System.Drawing.Size(228, 20);
            this.processFileBox.TabIndex = 7;
            this.processFileBox.TextChanged += new System.EventHandler(this.processFileBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Process File:";
            // 
            // batchGroup
            // 
            this.batchGroup.Controls.Add(this.button3);
            this.batchGroup.Controls.Add(this.batchFileBox);
            this.batchGroup.Controls.Add(this.label8);
            this.batchGroup.Enabled = false;
            this.batchGroup.Location = new System.Drawing.Point(276, 285);
            this.batchGroup.Name = "batchGroup";
            this.batchGroup.Size = new System.Drawing.Size(243, 102);
            this.batchGroup.TabIndex = 5;
            this.batchGroup.TabStop = false;
            this.batchGroup.Text = "Execute Batch File";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(75, 70);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Browse...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // batchFileBox
            // 
            this.batchFileBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.batchFileBox.Location = new System.Drawing.Point(6, 44);
            this.batchFileBox.Name = "batchFileBox";
            this.batchFileBox.ReadOnly = true;
            this.batchFileBox.Size = new System.Drawing.Size(228, 20);
            this.batchFileBox.TabIndex = 4;
            this.batchFileBox.TextChanged += new System.EventHandler(this.batchFileBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "Batch File:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(335, 460);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(135, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Save Task";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // TaskWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(531, 512);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.batchGroup);
            this.Controls.Add(this.processGroup);
            this.Controls.Add(this.soundGroup);
            this.Controls.Add(this.msgGroup);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskWizard";
            this.ShowInTaskbar = false;
            this.Text = "Easy Manager - Task Wizard";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.msgGroup.ResumeLayout(false);
            this.msgGroup.PerformLayout();
            this.soundGroup.ResumeLayout(false);
            this.soundGroup.PerformLayout();
            this.processGroup.ResumeLayout(false);
            this.processGroup.PerformLayout();
            this.batchGroup.ResumeLayout(false);
            this.batchGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tDescBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox msgGroup;
        private System.Windows.Forms.TextBox msgTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox msgTitleBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox soundGroup;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox soundFileBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox processGroup;
        private System.Windows.Forms.TextBox procParamsBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox processFileBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox batchGroup;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox batchFileBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox execEvery;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Label label9;
    }
}