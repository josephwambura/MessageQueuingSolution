namespace MicrosoftMessageQueuing.WindowsFormsApp
{
    partial class FormMain
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
            this.labelPayTo = new System.Windows.Forms.Label();
            this.textBoxPayTo = new System.Windows.Forms.TextBox();
            this.textBoxYourName = new System.Windows.Forms.TextBox();
            this.labelYourName = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelDueDate = new System.Windows.Forms.Label();
            this.buttonSendPayment = new System.Windows.Forms.Button();
            this.buttonProcessPayment = new System.Windows.Forms.Button();
            this.dateTimePickerDueDate = new System.Windows.Forms.DateTimePicker();
            this.listBoxQueues = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelPayTo
            // 
            this.labelPayTo.AutoSize = true;
            this.labelPayTo.Location = new System.Drawing.Point(131, 73);
            this.labelPayTo.Name = "labelPayTo";
            this.labelPayTo.Size = new System.Drawing.Size(44, 13);
            this.labelPayTo.TabIndex = 0;
            this.labelPayTo.Text = "Pay To:";
            // 
            // textBoxPayTo
            // 
            this.textBoxPayTo.Location = new System.Drawing.Point(230, 70);
            this.textBoxPayTo.Name = "textBoxPayTo";
            this.textBoxPayTo.Size = new System.Drawing.Size(345, 20);
            this.textBoxPayTo.TabIndex = 1;
            // 
            // textBoxYourName
            // 
            this.textBoxYourName.Location = new System.Drawing.Point(230, 112);
            this.textBoxYourName.Name = "textBoxYourName";
            this.textBoxYourName.Size = new System.Drawing.Size(345, 20);
            this.textBoxYourName.TabIndex = 3;
            // 
            // labelYourName
            // 
            this.labelYourName.AutoSize = true;
            this.labelYourName.Location = new System.Drawing.Point(131, 115);
            this.labelYourName.Name = "labelYourName";
            this.labelYourName.Size = new System.Drawing.Size(63, 13);
            this.labelYourName.TabIndex = 2;
            this.labelYourName.Text = "Your Name:";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(230, 156);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(131, 20);
            this.textBoxAmount.TabIndex = 5;
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(131, 159);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(46, 13);
            this.labelAmount.TabIndex = 4;
            this.labelAmount.Text = "Amount:";
            // 
            // labelDueDate
            // 
            this.labelDueDate.AutoSize = true;
            this.labelDueDate.Location = new System.Drawing.Point(131, 200);
            this.labelDueDate.Name = "labelDueDate";
            this.labelDueDate.Size = new System.Drawing.Size(56, 13);
            this.labelDueDate.TabIndex = 6;
            this.labelDueDate.Text = "Due Date:";
            // 
            // buttonSendPayment
            // 
            this.buttonSendPayment.Location = new System.Drawing.Point(313, 283);
            this.buttonSendPayment.Name = "buttonSendPayment";
            this.buttonSendPayment.Size = new System.Drawing.Size(109, 23);
            this.buttonSendPayment.TabIndex = 8;
            this.buttonSendPayment.Text = "Send Payment";
            this.buttonSendPayment.UseVisualStyleBackColor = true;
            this.buttonSendPayment.Click += new System.EventHandler(this.buttonSendPayment_Click);
            // 
            // buttonProcessPayment
            // 
            this.buttonProcessPayment.Location = new System.Drawing.Point(437, 283);
            this.buttonProcessPayment.Name = "buttonProcessPayment";
            this.buttonProcessPayment.Size = new System.Drawing.Size(133, 23);
            this.buttonProcessPayment.TabIndex = 9;
            this.buttonProcessPayment.Text = "Process Payment";
            this.buttonProcessPayment.UseVisualStyleBackColor = true;
            this.buttonProcessPayment.Click += new System.EventHandler(this.buttonProcessPayment_Click);
            // 
            // dateTimePickerDueDate
            // 
            this.dateTimePickerDueDate.Location = new System.Drawing.Point(230, 194);
            this.dateTimePickerDueDate.MinDate = new System.DateTime(2022, 12, 14, 0, 0, 0, 0);
            this.dateTimePickerDueDate.Name = "dateTimePickerDueDate";
            this.dateTimePickerDueDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDueDate.TabIndex = 10;
            // 
            // listBoxQueues
            // 
            this.listBoxQueues.FormattingEnabled = true;
            this.listBoxQueues.Location = new System.Drawing.Point(581, 63);
            this.listBoxQueues.Name = "listBoxQueues";
            this.listBoxQueues.Size = new System.Drawing.Size(189, 355);
            this.listBoxQueues.TabIndex = 11;
            this.listBoxQueues.Click += new System.EventHandler(this.listBoxQueues_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxQueues);
            this.Controls.Add(this.dateTimePickerDueDate);
            this.Controls.Add(this.buttonProcessPayment);
            this.Controls.Add(this.buttonSendPayment);
            this.Controls.Add(this.labelDueDate);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.textBoxYourName);
            this.Controls.Add(this.labelYourName);
            this.Controls.Add(this.textBoxPayTo);
            this.Controls.Add(this.labelPayTo);
            this.Name = "FormMain";
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPayTo;
        private System.Windows.Forms.TextBox textBoxPayTo;
        private System.Windows.Forms.TextBox textBoxYourName;
        private System.Windows.Forms.Label labelYourName;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Label labelDueDate;
        private System.Windows.Forms.Button buttonSendPayment;
        private System.Windows.Forms.Button buttonProcessPayment;
        private System.Windows.Forms.DateTimePicker dateTimePickerDueDate;
        private System.Windows.Forms.ListBox listBoxQueues;
    }
}

