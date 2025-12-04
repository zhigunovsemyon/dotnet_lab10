namespace Client
{
	partial class FormIpChange
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.textBoxAddress = new TextBox();
			this.labelDestAddress = new Label();
			this.labelPort = new Label();
			this.buttonSave = new Button();
			this.maskedTextBoxPort = new MaskedTextBox();
			this.SuspendLayout();
			// 
			// textBoxAddress
			// 
			this.textBoxAddress.Location = new Point(12, 27);
			this.textBoxAddress.Name = "textBoxAddress";
			this.textBoxAddress.Size = new Size(100, 23);
			this.textBoxAddress.TabIndex = 0;
			this.textBoxAddress.Text = "127.0.0.1";
			// 
			// labelDestAddress
			// 
			this.labelDestAddress.AutoSize = true;
			this.labelDestAddress.Location = new Point(12, 9);
			this.labelDestAddress.Name = "labelDestAddress";
			this.labelDestAddress.Size = new Size(87, 15);
			this.labelDestAddress.TabIndex = 1;
			this.labelDestAddress.Text = "Адрес сервера";
			// 
			// labelPort
			// 
			this.labelPort.AutoSize = true;
			this.labelPort.Location = new Point(121, 9);
			this.labelPort.Name = "labelPort";
			this.labelPort.Size = new Size(35, 15);
			this.labelPort.TabIndex = 2;
			this.labelPort.Text = "Порт";
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new Point(99, 56);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new Size(75, 23);
			this.buttonSave.TabIndex = 4;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += this.buttonSave_Click;
			// 
			// maskedTextBox1
			// 
			this.maskedTextBoxPort.Location = new Point(118, 27);
			this.maskedTextBoxPort.Mask = "00000";
			this.maskedTextBoxPort.Name = "maskedTextBox1";
			this.maskedTextBoxPort.PromptChar = ' ';
			this.maskedTextBoxPort.Size = new Size(58, 23);
			this.maskedTextBoxPort.TabIndex = 5;
			this.maskedTextBoxPort.Text = "9876";
			this.maskedTextBoxPort.ValidatingType = typeof(int);
			// 
			// FormIpChange
			// 
			this.AutoScaleDimensions = new SizeF(7F, 15F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new Size(188, 91);
			this.Controls.Add(this.maskedTextBoxPort);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.labelPort);
			this.Controls.Add(this.labelDestAddress);
			this.Controls.Add(this.textBoxAddress);
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormIpChange";
			this.ShowIcon = false;
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Адрес сервера";
			this.FormClosed += this.FormIpChange_FormClosed;
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private TextBox textBoxAddress;
		private Label labelDestAddress;
		private Label labelPort;
		private Button buttonSave;
		private MaskedTextBox maskedTextBoxPort;
	}
}