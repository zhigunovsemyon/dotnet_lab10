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
		this.maskedTextBoxId.Text = this.maskedTextBoxId.Text.Trim();
		this.maskedTextBoxYear.Text = this.maskedTextBoxYear.Text.Trim();
	}

	/// <summary> Проверка идентификатора </summary>
	private void VerifyId()
	{
		if (String.IsNullOrWhiteSpace(this.maskedTextBoxId.Text)) {
			throw new Exception("Не указан идентификатор!");
		}
	}

	/// <summary> Проверка содержимого полей  </summary>
	private void VerifyFields()
	{
		if (String.IsNullOrWhiteSpace(this.textBoxGenre.Text)) {
			throw new InvalidMovieGenre("Не указан жанр!");
		}
		if (String.IsNullOrWhiteSpace(this.textBoxTitle.Text)) {
			throw new InvalidMovieTitle("Не указано название!");
		}

		if (!UInt16.TryParse(this.maskedTextBoxYear.Text, out UInt16 year)) {
			throw new InvalidMovieYear("Не правильно указан год!");
		}
		if (year < 1800 || year > 9999) {
			throw new InvalidMovieYear("Не правильно указан год!");
		}
	}

	/// <summary> Обработка нажатия на клавишу действия </summary>
	private void buttonAction_Click(object sender, EventArgs e)
	{
		this.TrimFields();
		this.VerifyId();

		try {
			this.VerifyFields();
		}
		catch (Exception ex) {
			MessageBox.Show($"Неправильно указаны данные!\r\n{ex.Message}",
				"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}
	}

	private void radioButtonGet_CheckedChanged(object sender, EventArgs e)
		=> this._activeRadio = 'g';

	private void radioButtonDelete_CheckedChanged(object sender, EventArgs e)
		=> this._activeRadio = 'd';

	private void radioButtonAdd_CheckedChanged(object sender, EventArgs e)
		=> this._activeRadio = 'a';

	private void radioButtonUpdate_CheckedChanged(object sender, EventArgs e)
		=> this._activeRadio = 'u';
}
