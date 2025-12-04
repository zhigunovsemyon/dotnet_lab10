namespace Client
{
	partial class FormMain
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.statusStrip = new StatusStrip();
			this.toolStripStatusLabelServerAddress = new ToolStripStatusLabel();
			this.groupBoxAction = new GroupBox();
			this.radioButtonUpdate = new RadioButton();
			this.radioButtonGet = new RadioButton();
			this.radioButtonDelete = new RadioButton();
			this.radioButtonAdd = new RadioButton();
			this.buttonChangeServer = new Button();
			this.buttonConnectSwitch = new Button();
			this.statusStrip.SuspendLayout();
			this.groupBoxAction.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new ToolStripItem[] { this.toolStripStatusLabelServerAddress });
			this.statusStrip.Location = new Point(0, 428);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new Size(800, 22);
			this.statusStrip.TabIndex = 0;
			this.statusStrip.Text = "statusStrip1";
			// 
			// toolStripStatusLabelServerAddress
			// 
			this.toolStripStatusLabelServerAddress.Name = "toolStripStatusLabelServerAddress";
			this.toolStripStatusLabelServerAddress.Size = new Size(148, 17);
			this.toolStripStatusLabelServerAddress.Text = "Сервер для подключения";
			// 
			// groupBoxAction
			// 
			this.groupBoxAction.Controls.Add(this.radioButtonUpdate);
			this.groupBoxAction.Controls.Add(this.radioButtonGet);
			this.groupBoxAction.Controls.Add(this.radioButtonDelete);
			this.groupBoxAction.Controls.Add(this.radioButtonAdd);
			this.groupBoxAction.Location = new Point(12, 12);
			this.groupBoxAction.Name = "groupBoxAction";
			this.groupBoxAction.Size = new Size(100, 124);
			this.groupBoxAction.TabIndex = 1;
			this.groupBoxAction.TabStop = false;
			this.groupBoxAction.Text = "Действие";
			// 
			// radioButtonUpdate
			// 
			this.radioButtonUpdate.AutoSize = true;
			this.radioButtonUpdate.Location = new Point(6, 97);
			this.radioButtonUpdate.Name = "radioButtonUpdate";
			this.radioButtonUpdate.Size = new Size(79, 19);
			this.radioButtonUpdate.TabIndex = 5;
			this.radioButtonUpdate.TabStop = true;
			this.radioButtonUpdate.Text = "Обновить";
			this.radioButtonUpdate.UseVisualStyleBackColor = true;
			// 
			// radioButtonGet
			// 
			this.radioButtonGet.AutoSize = true;
			this.radioButtonGet.Location = new Point(6, 22);
			this.radioButtonGet.Name = "radioButtonGet";
			this.radioButtonGet.Size = new Size(79, 19);
			this.radioButtonGet.TabIndex = 2;
			this.radioButtonGet.TabStop = true;
			this.radioButtonGet.Text = "Получить";
			this.radioButtonGet.UseVisualStyleBackColor = true;
			// 
			// radioButtonDelete
			// 
			this.radioButtonDelete.AutoSize = true;
			this.radioButtonDelete.Location = new Point(6, 47);
			this.radioButtonDelete.Name = "radioButtonDelete";
			this.radioButtonDelete.Size = new Size(69, 19);
			this.radioButtonDelete.TabIndex = 3;
			this.radioButtonDelete.TabStop = true;
			this.radioButtonDelete.Text = "Удалить";
			this.radioButtonDelete.UseVisualStyleBackColor = true;
			// 
			// radioButtonAdd
			// 
			this.radioButtonAdd.AutoSize = true;
			this.radioButtonAdd.Location = new Point(6, 72);
			this.radioButtonAdd.Name = "radioButtonAdd";
			this.radioButtonAdd.Size = new Size(77, 19);
			this.radioButtonAdd.TabIndex = 4;
			this.radioButtonAdd.TabStop = true;
			this.radioButtonAdd.Text = "Добавить";
			this.radioButtonAdd.UseVisualStyleBackColor = true;
			// 
			// buttonChangeServer
			// 
			this.buttonChangeServer.Location = new Point(118, 30);
			this.buttonChangeServer.Name = "buttonChangeServer";
			this.buttonChangeServer.Size = new Size(166, 23);
			this.buttonChangeServer.TabIndex = 2;
			this.buttonChangeServer.Text = "Изменить адрес сервера";
			this.buttonChangeServer.UseVisualStyleBackColor = true;
			this.buttonChangeServer.Click += this.buttonChangeServer_Click;
			// 
			// buttonConnectSwitch
			// 
			this.buttonConnectSwitch.Location = new Point(118, 59);
			this.buttonConnectSwitch.Name = "buttonConnectSwitch";
			this.buttonConnectSwitch.Size = new Size(166, 23);
			this.buttonConnectSwitch.TabIndex = 3;
			this.buttonConnectSwitch.Text = "Подключиться";
			this.buttonConnectSwitch.UseVisualStyleBackColor = true;
			this.buttonConnectSwitch.Click += this.buttonConnectSwitch_Click;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new SizeF(7F, 15F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new Size(800, 450);
			this.Controls.Add(this.buttonConnectSwitch);
			this.Controls.Add(this.buttonChangeServer);
			this.Controls.Add(this.groupBoxAction);
			this.Controls.Add(this.statusStrip);
			this.Name = "FormMain";
			this.Text = "Фильмы";
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.groupBoxAction.ResumeLayout(false);
			this.groupBoxAction.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private StatusStrip statusStrip;
		private GroupBox groupBoxAction;
		private RadioButton radioButtonAdd;
		private RadioButton radioButtonUpdate;
		private RadioButton radioButtonGet;
		private RadioButton radioButtonDelete;
		private ToolStripStatusLabel toolStripStatusLabelServerAddress;
		private Button buttonChangeServer;
		private Button buttonConnectSwitch;
	}
}
