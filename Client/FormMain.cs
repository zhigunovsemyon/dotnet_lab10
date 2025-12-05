using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using MovieLibrary.MovieException;

namespace Client;

public partial class FormMain : Form
{
	private readonly FormIpChange _ipChange = new();

	// a d u g
	private char _activeRadio = 'g';

	/// <summary> Сокет подключения к серверу </summary>
	private Socket? _socket = null;

	public FormMain()
	{
		this.InitializeComponent();
		this.toolStripStatusLabelServerAddress.Text = $"Адрес подключения: {this._ipChange.Address}:{this._ipChange.Port}";
	}

	/// <summary> Нажатие на кнопку смены сервера </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void buttonChangeServer_Click(object sender, EventArgs e)
	{
		this._ipChange.ShowDialog();
		this.toolStripStatusLabelServerAddress.Text = $"Адрес подключения: {this._ipChange.Address}:{this._ipChange.Port}";
	}

	/// <summary> Получение IP адреса от DNS-сервера </summary>
	/// <param name="dns"> Доменное имя </param>
	/// <returns>Первый IP-адрес по запросу</returns>
	private static IPAddress? ipFromDns(string dns)
	{
		try {
			return Dns.GetHostAddresses(dns)[0];
		}
		catch (SocketException) {
			return null;
		}
	}

	/// <summary> Создание конечной точки подключения по имени и порту </summary>
	private static IPEndPoint? CreateEndPointFromServerInfo(string address, string port)
	{
		if (!IPAddress.TryParse(address, out IPAddress? addr)) {
			addr = ipFromDns(address);
		}
		if (addr == null) {
			return null;
		}

		return new IPEndPoint(addr, UInt16.Parse(port));
	}

	/// <summary> Нажатие кнопки подключения/отключения </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void buttonConnectSwitch_Click(object sender, EventArgs e)
	{
		if (this._socket is not null) {
			this.Disonnect();
		}
		else {
			this.Connect();
		}
	}

	/// <summary> Обработка отключения от сервера </summary>
	private void Disonnect()
	{
		Debug.Assert(this._socket != null);
		try {
			this._socket.Shutdown(SocketShutdown.Both);
			this._socket.Close();
		}
		catch (Exception e) {
			MessageBox.Show($"Ошибка при отключении!\r\n{e.Message}", "Ошибка",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		this._socket = null;
		this.buttonConnectSwitch.Text = "Подключиться";
	}

	/// <summary> Обработка подключения к серверу </summary>
	private void Connect()
	{
		var endPoint = CreateEndPointFromServerInfo(this._ipChange.Address, this._ipChange.Port);
		if (endPoint is null) {
			MessageBox.Show("Не удалось подключиться!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}

		try {
			var newSock = new Socket(SocketType.Stream, ProtocolType.Tcp);
			newSock.Connect(endPoint);
			this.buttonConnectSwitch.Text = "Отключиться";
			this._socket = newSock;
		}
		catch (Exception e) {
			MessageBox.Show($"Не удалось подключиться!\r\n{e.Message}", "Ошибка",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	/// <summary> Обрезка пробелов из полей </summary>
	private void TrimFields()
	{
		this.textBoxGenre.Text = this.textBoxGenre.Text.Trim();
		this.textBoxTitle.Text = this.textBoxTitle.Text.Trim();
		this.maskedTextBoxYear.Text = this.maskedTextBoxYear.Text.Trim();
	}

	/// <summary> Проверка содержимого поля названия </summary>
	private bool VerifyTitle()
	{
		if (String.IsNullOrWhiteSpace(this.textBoxTitle.Text)) {
			MessageBox.Show("Не указано название!",
				"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return true;
		}
		return false;
	}

	/// <summary> Проверка содержимого полей </summary>
	private bool VerifyFields()
	{
		if (String.IsNullOrWhiteSpace(this.textBoxGenre.Text)) {
			MessageBox.Show("Не указан жанр!",
				"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return true;
		}

		if (!UInt16.TryParse(this.maskedTextBoxYear.Text, out UInt16 year)) {
			MessageBox.Show("Не правильно указан год!",
				"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return true;
		}
		if (year < 1800 || year > 9999) {
			MessageBox.Show("Не правильно указан год!",
				"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return true;
		}

		return VerifyTitle();
	}

	/// <summary> Обработка нажатия на клавишу действия </summary>
	private void buttonAction_Click(object sender, EventArgs e)
	{
		this.TrimFields();
		if (_socket is null) {
			MessageBox.Show("Нет подключения!",
				"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}

		switch (this._activeRadio) {
		case 'a':
			if (this.VerifyFields()) {
				return;
			}
			break;
		case 'g':
			if (this.VerifyTitle()) {
				return;
			}
			break;
		case 'u':
			if (this.VerifyFields()) {
				return;
			}
			break;
		case 'd':
			if (this.VerifyTitle()) {
				return;
			}
			break;
		default:
			throw new NotImplementedException("this._activeRadio: неизвестное значение");
		}
	}

	private void radioButtonGet_CheckedChanged(object sender, EventArgs e)
	{
		this._activeRadio = 'g';
		this.textBoxGenre.ReadOnly = true;
		this.maskedTextBoxYear.ReadOnly = true;
	}

	private void radioButtonDelete_CheckedChanged(object sender, EventArgs e)
	{ 
		this.textBoxGenre.ReadOnly = true;
		this.maskedTextBoxYear.ReadOnly = true;
		this._activeRadio = 'd'; 
	}

	private void radioButtonAdd_CheckedChanged(object sender, EventArgs e)
	{ 
		this.textBoxGenre.ReadOnly = false;
		this.maskedTextBoxYear.ReadOnly = false;
		this._activeRadio = 'a'; 
	}

	private void radioButtonUpdate_CheckedChanged(object sender, EventArgs e)
	{ 
		this.maskedTextBoxYear.ReadOnly = false;
		this.textBoxGenre.ReadOnly = false;
		this._activeRadio = 'u'; 
	}
}
