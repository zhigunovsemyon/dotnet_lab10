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
		private void InitializeComponent()
		{
			statusStrip = new StatusStrip();
			toolStripStatusLabelServerAddress = new ToolStripStatusLabel();
			groupBoxAction = new GroupBox();
			radioButtonUpdate = new RadioButton();
			radioButtonGet = new RadioButton();
			radioButtonDelete = new RadioButton();
			radioButtonAdd = new RadioButton();
			buttonChangeServer = new Button();
			buttonConnectSwitch = new Button();
			groupBoxMovie = new GroupBox();
			labelYear = new Label();
			labelGenre = new Label();
			labelTitle = new Label();
			maskedTextBoxYear = new MaskedTextBox();
			textBoxGenre = new TextBox();
			textBoxTitle = new TextBox();
			maskedTextBoxId = new MaskedTextBox();
			labelid = new Label();
			buttonAction = new Button();
			statusStrip.SuspendLayout();
			groupBoxAction.SuspendLayout();
			groupBoxMovie.SuspendLayout();
			SuspendLayout();
			// 
			// statusStrip
			// 
			statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelServerAddress });
			statusStrip.Location = new Point(0, 257);
			statusStrip.Name = "statusStrip";
			statusStrip.Size = new Size(535, 22);
			statusStrip.TabIndex = 0;
			statusStrip.Text = "statusStrip1";
			// 
			// toolStripStatusLabelServerAddress
			// 
			toolStripStatusLabelServerAddress.Name = "toolStripStatusLabelServerAddress";
			toolStripStatusLabelServerAddress.Size = new Size(148, 17);
			toolStripStatusLabelServerAddress.Text = "Сервер для подключения";
			// 
			// groupBoxAction
			// 
			groupBoxAction.Controls.Add(radioButtonUpdate);
			groupBoxAction.Controls.Add(radioButtonGet);
			groupBoxAction.Controls.Add(radioButtonDelete);
			groupBoxAction.Controls.Add(radioButtonAdd);
			groupBoxAction.Location = new Point(12, 12);
			groupBoxAction.Name = "groupBoxAction";
			groupBoxAction.Size = new Size(100, 124);
			groupBoxAction.TabIndex = 1;
			groupBoxAction.TabStop = false;
			groupBoxAction.Text = "Действие";
			// 
			// radioButtonUpdate
			// 
			radioButtonUpdate.AutoSize = true;
			radioButtonUpdate.Location = new Point(6, 97);
			radioButtonUpdate.Name = "radioButtonUpdate";
			radioButtonUpdate.Size = new Size(79, 19);
			radioButtonUpdate.TabIndex = 5;
			radioButtonUpdate.TabStop = true;
			radioButtonUpdate.Text = "Обновить";
			radioButtonUpdate.UseVisualStyleBackColor = true;
			radioButtonUpdate.CheckedChanged += radioButtonUpdate_CheckedChanged;
			// 
			// radioButtonGet
			// 
			radioButtonGet.AutoSize = true;
			radioButtonGet.Location = new Point(6, 22);
			radioButtonGet.Name = "radioButtonGet";
			radioButtonGet.Size = new Size(79, 19);
			radioButtonGet.TabIndex = 2;
			radioButtonGet.TabStop = true;
			radioButtonGet.Text = "Получить";
			radioButtonGet.UseVisualStyleBackColor = true;
			radioButtonGet.CheckedChanged += radioButtonGet_CheckedChanged;
			// 
			// radioButtonDelete
			// 
			radioButtonDelete.AutoSize = true;
			radioButtonDelete.Location = new Point(6, 47);
			radioButtonDelete.Name = "radioButtonDelete";
			radioButtonDelete.Size = new Size(69, 19);
			radioButtonDelete.TabIndex = 3;
			radioButtonDelete.TabStop = true;
			radioButtonDelete.Text = "Удалить";
			radioButtonDelete.UseVisualStyleBackColor = true;
			radioButtonDelete.CheckedChanged += radioButtonDelete_CheckedChanged;
			// 
			// radioButtonAdd
			// 
			radioButtonAdd.AutoSize = true;
			radioButtonAdd.Location = new Point(6, 72);
			radioButtonAdd.Name = "radioButtonAdd";
			radioButtonAdd.Size = new Size(77, 19);
			radioButtonAdd.TabIndex = 4;
			radioButtonAdd.TabStop = true;
			radioButtonAdd.Text = "Добавить";
			radioButtonAdd.UseVisualStyleBackColor = true;
			radioButtonAdd.CheckedChanged += radioButtonAdd_CheckedChanged;
			// 
			// buttonChangeServer
			// 
			buttonChangeServer.Location = new Point(118, 30);
			buttonChangeServer.Name = "buttonChangeServer";
			buttonChangeServer.Size = new Size(186, 23);
			buttonChangeServer.TabIndex = 2;
			buttonChangeServer.Text = "Изменить адрес сервера";
			buttonChangeServer.UseVisualStyleBackColor = true;
			buttonChangeServer.Click += buttonChangeServer_Click;
			// 
			// buttonConnectSwitch
			// 
			buttonConnectSwitch.Location = new Point(118, 59);
			buttonConnectSwitch.Name = "buttonConnectSwitch";
			buttonConnectSwitch.Size = new Size(186, 23);
			buttonConnectSwitch.TabIndex = 3;
			buttonConnectSwitch.Text = "Подключиться";
			buttonConnectSwitch.UseVisualStyleBackColor = true;
			buttonConnectSwitch.Click += buttonConnectSwitch_Click;
			// 
			// groupBoxMovie
			// 
			groupBoxMovie.Controls.Add(labelYear);
			groupBoxMovie.Controls.Add(labelGenre);
			groupBoxMovie.Controls.Add(labelTitle);
			groupBoxMovie.Controls.Add(maskedTextBoxYear);
			groupBoxMovie.Controls.Add(textBoxGenre);
			groupBoxMovie.Controls.Add(textBoxTitle);
			groupBoxMovie.Location = new Point(310, 12);
			groupBoxMovie.Name = "groupBoxMovie";
			groupBoxMovie.Size = new Size(200, 158);
			groupBoxMovie.TabIndex = 4;
			groupBoxMovie.TabStop = false;
			groupBoxMovie.Text = "Данные о фильме";
			// 
			// labelYear
			// 
			labelYear.AutoSize = true;
			labelYear.Location = new Point(6, 106);
			labelYear.Name = "labelYear";
			labelYear.Size = new Size(26, 15);
			labelYear.TabIndex = 5;
			labelYear.Text = "Год";
			// 
			// labelGenre
			// 
			labelGenre.AutoSize = true;
			labelGenre.Location = new Point(6, 62);
			labelGenre.Name = "labelGenre";
			labelGenre.Size = new Size(38, 15);
			labelGenre.TabIndex = 4;
			labelGenre.Text = "Жанр";
			// 
			// labelTitle
			// 
			labelTitle.AutoSize = true;
			labelTitle.Location = new Point(6, 18);
			labelTitle.Name = "labelTitle";
			labelTitle.Size = new Size(59, 15);
			labelTitle.TabIndex = 3;
			labelTitle.Text = "Название";
			// 
			// maskedTextBoxYear
			// 
			maskedTextBoxYear.Location = new Point(6, 124);
			maskedTextBoxYear.Mask = "0000";
			maskedTextBoxYear.Name = "maskedTextBoxYear";
			maskedTextBoxYear.Size = new Size(59, 23);
			maskedTextBoxYear.TabIndex = 2;
			maskedTextBoxYear.ValidatingType = typeof(int);
			// 
			// textBoxGenre
			// 
			textBoxGenre.Location = new Point(6, 80);
			textBoxGenre.Name = "textBoxGenre";
			textBoxGenre.Size = new Size(188, 23);
			textBoxGenre.TabIndex = 1;
			// 
			// textBoxTitle
			// 
			textBoxTitle.Location = new Point(6, 36);
			textBoxTitle.Name = "textBoxTitle";
			textBoxTitle.Size = new Size(188, 23);
			textBoxTitle.TabIndex = 0;
			// 
			// maskedTextBoxId
			// 
			maskedTextBoxId.Location = new Point(118, 110);
			maskedTextBoxId.Mask = "00000";
			maskedTextBoxId.Name = "maskedTextBoxId";
			maskedTextBoxId.Size = new Size(94, 23);
			maskedTextBoxId.TabIndex = 5;
			maskedTextBoxId.ValidatingType = typeof(int);
			// 
			// labelid
			// 
			labelid.AutoSize = true;
			labelid.Location = new Point(118, 92);
			labelid.Name = "labelid";
			labelid.Size = new Size(94, 15);
			labelid.TabIndex = 6;
			labelid.Text = "Идентификатор";
			// 
			// buttonAction
			// 
			buttonAction.Location = new Point(218, 110);
			buttonAction.Name = "buttonAction";
			buttonAction.Size = new Size(86, 23);
			buttonAction.TabIndex = 7;
			buttonAction.Text = "Выполнить";
			buttonAction.UseVisualStyleBackColor = true;
			buttonAction.Click += buttonAction_Click;
			// 
			// FormMain
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(535, 279);
			Controls.Add(buttonAction);
			Controls.Add(labelid);
			Controls.Add(maskedTextBoxId);
			Controls.Add(groupBoxMovie);
			Controls.Add(buttonConnectSwitch);
			Controls.Add(buttonChangeServer);
			Controls.Add(groupBoxAction);
			Controls.Add(statusStrip);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			Name = "FormMain";
			Text = "Фильмы";
			statusStrip.ResumeLayout(false);
			statusStrip.PerformLayout();
			groupBoxAction.ResumeLayout(false);
			groupBoxAction.PerformLayout();
			groupBoxMovie.ResumeLayout(false);
			groupBoxMovie.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
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
		private MaskedTextBox maskedTextBoxId;
		private Label labelid;
		private Button buttonAction;
	}
}
