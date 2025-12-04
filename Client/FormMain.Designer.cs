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
			this.groupBoxMovie = new GroupBox();
			this.labelYear = new Label();
			this.labelGenre = new Label();
			this.labelTitle = new Label();
			this.maskedTextBoxYear = new MaskedTextBox();
			this.textBoxGenre = new TextBox();
			this.textBoxTitle = new TextBox();
			this.buttonAction = new Button();
			this.statusStrip.SuspendLayout();
			this.groupBoxAction.SuspendLayout();
			this.groupBoxMovie.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new ToolStripItem[] { this.toolStripStatusLabelServerAddress });
			this.statusStrip.Location = new Point(0, 211);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new Size(330, 22);
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
			this.radioButtonUpdate.CheckedChanged += this.radioButtonUpdate_CheckedChanged;
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
			this.radioButtonGet.CheckedChanged += this.radioButtonGet_CheckedChanged;
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
			this.radioButtonDelete.CheckedChanged += this.radioButtonDelete_CheckedChanged;
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
			this.radioButtonAdd.CheckedChanged += this.radioButtonAdd_CheckedChanged;
			// 
			// buttonChangeServer
			// 
			this.buttonChangeServer.Location = new Point(9, 176);
			this.buttonChangeServer.Name = "buttonChangeServer";
			this.buttonChangeServer.Size = new Size(174, 23);
			this.buttonChangeServer.TabIndex = 2;
			this.buttonChangeServer.Text = "Изменить адрес сервера";
			this.buttonChangeServer.UseVisualStyleBackColor = true;
			this.buttonChangeServer.Click += this.buttonChangeServer_Click;
			// 
			// buttonConnectSwitch
			// 
			this.buttonConnectSwitch.Location = new Point(189, 176);
			this.buttonConnectSwitch.Name = "buttonConnectSwitch";
			this.buttonConnectSwitch.Size = new Size(129, 23);
			this.buttonConnectSwitch.TabIndex = 3;
			this.buttonConnectSwitch.Text = "Подключиться";
			this.buttonConnectSwitch.UseVisualStyleBackColor = true;
			this.buttonConnectSwitch.Click += this.buttonConnectSwitch_Click;
			// 
			// groupBoxMovie
			// 
			this.groupBoxMovie.Controls.Add(this.labelYear);
			this.groupBoxMovie.Controls.Add(this.labelGenre);
			this.groupBoxMovie.Controls.Add(this.labelTitle);
			this.groupBoxMovie.Controls.Add(this.maskedTextBoxYear);
			this.groupBoxMovie.Controls.Add(this.textBoxGenre);
			this.groupBoxMovie.Controls.Add(this.textBoxTitle);
			this.groupBoxMovie.Location = new Point(118, 12);
			this.groupBoxMovie.Name = "groupBoxMovie";
			this.groupBoxMovie.Size = new Size(200, 158);
			this.groupBoxMovie.TabIndex = 4;
			this.groupBoxMovie.TabStop = false;
			this.groupBoxMovie.Text = "Данные о фильме";
			// 
			// labelYear
			// 
			this.labelYear.AutoSize = true;
			this.labelYear.Location = new Point(6, 106);
			this.labelYear.Name = "labelYear";
			this.labelYear.Size = new Size(26, 15);
			this.labelYear.TabIndex = 5;
			this.labelYear.Text = "Год";
			// 
			// labelGenre
			// 
			this.labelGenre.AutoSize = true;
			this.labelGenre.Location = new Point(6, 62);
			this.labelGenre.Name = "labelGenre";
			this.labelGenre.Size = new Size(38, 15);
			this.labelGenre.TabIndex = 4;
			this.labelGenre.Text = "Жанр";
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Location = new Point(6, 18);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new Size(59, 15);
			this.labelTitle.TabIndex = 3;
			this.labelTitle.Text = "Название";
			// 
			// maskedTextBoxYear
			// 
			this.maskedTextBoxYear.Location = new Point(6, 124);
			this.maskedTextBoxYear.Mask = "0000";
			this.maskedTextBoxYear.Name = "maskedTextBoxYear";
			this.maskedTextBoxYear.Size = new Size(59, 23);
			this.maskedTextBoxYear.TabIndex = 2;
			this.maskedTextBoxYear.ValidatingType = typeof(int);
			// 
			// textBoxGenre
			// 
			this.textBoxGenre.Location = new Point(6, 80);
			this.textBoxGenre.Name = "textBoxGenre";
			this.textBoxGenre.Size = new Size(188, 23);
			this.textBoxGenre.TabIndex = 1;
			// 
			// textBoxTitle
			// 
			this.textBoxTitle.Location = new Point(6, 36);
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.Size = new Size(188, 23);
			this.textBoxTitle.TabIndex = 0;
			// 
			// buttonAction
			// 
			this.buttonAction.Location = new Point(9, 142);
			this.buttonAction.Name = "buttonAction";
			this.buttonAction.Size = new Size(103, 23);
			this.buttonAction.TabIndex = 7;
			this.buttonAction.Text = "Выполнить";
			this.buttonAction.UseVisualStyleBackColor = true;
			this.buttonAction.Click += this.buttonAction_Click;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new SizeF(7F, 15F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new Size(330, 233);
			this.Controls.Add(this.buttonAction);
			this.Controls.Add(this.groupBoxMovie);
			this.Controls.Add(this.buttonConnectSwitch);
			this.Controls.Add(this.buttonChangeServer);
			this.Controls.Add(this.groupBoxAction);
			this.Controls.Add(this.statusStrip);
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FormMain";
			this.Text = "Фильмы";
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.groupBoxAction.ResumeLayout(false);
			this.groupBoxAction.PerformLayout();
			this.groupBoxMovie.ResumeLayout(false);
			this.groupBoxMovie.PerformLayout();
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
		private GroupBox groupBoxMovie;
		private Label labelYear;
		private Label labelGenre;
		private Label labelTitle;
		private MaskedTextBox maskedTextBoxYear;
		private TextBox textBoxGenre;
		private TextBox textBoxTitle;
		private Button buttonAction;
	}
}
