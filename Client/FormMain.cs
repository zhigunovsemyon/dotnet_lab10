using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using MovieLibrary;

namespace Client;

public partial class FormMain : Form
{
	/// <summary> Форма изменения адреса сервера </summary>
	private readonly FormIpChange _ipChange = new();

	/// <summary> Запрос, отправляемый на сервер </summary>
	private readonly MovieRequest _request = new();

	/// <summary> Буфер для запросов </summary>
	private byte[] _buf = new byte[1024];

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
		var oldRequestType = this._request.Request;
		//todo: отправить запрос на отключение (мб в трае)
		try {

			this._socket.Shutdown(SocketShutdown.Both);
			this._socket.Close();
		}
		catch (Exception e) {
			MessageBox.Show($"Ошибка при отключении!\r\n{e.Message}", "Ошибка",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		this._request.Request = oldRequestType;
		this._socket = null;
		this.buttonConnectSwitch.Text = "Подключиться";
		this.buttonChangeServer.Enabled = true;
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
			this.buttonChangeServer.Enabled = false;
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
	/// <returns>true при ошибке, false при успехе</returns>
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
	/// <returns>true при ошибке, false при успехе</returns>
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

	/// <summary> Добавление данных о фильме в запрос серверу </summary>
	/// <returns>true при ошибке, false при успехе</returns>
	private bool AddMovieToRequest ()
	{
		if (this.VerifyFields()) {
			return true;
		}
		var title = this.textBoxTitle.Text;
		var genre = this.textBoxGenre.Text;
		var year = Int16.Parse(this.maskedTextBoxYear.Text);
		this._request.Movie = new Movie(title, genre, year);

		return false;
	}

	/// <summary> Добавление названия фильма в запрос серверу </summary>
	/// <returns>true при ошибке, false при успехе</returns>
	private bool AddMovieTitleToRequest ()
	{
		if (this.VerifyTitle()) {
			return true;
		}
		var title = this.textBoxTitle.Text;
		this._request.Movie = new Movie(title, "", -1);

		return false;
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

		switch (this._request.Request) {
		case MovieRequest.RequestType.Add:
			if (this.AddMovieToRequest()) {
				return;
			}
			break;
		case MovieRequest.RequestType.Get:
			if (this.AddMovieTitleToRequest()) {
				return;
			}
			break;
		case MovieRequest.RequestType.Update:
			if (this.AddMovieToRequest()) {
				return;
			}
			break;
		case MovieRequest.RequestType.Delete:
			if (this.AddMovieTitleToRequest()) {
				return;
			}
			break;
		default:
			throw new NotImplementedException("this._request: неизвестное значение");
		}
		this.SendRequest();
	}

	/// <summary> Отправка запроса на сервер </summary>
	private void SendRequest()
	{
		try {
			var json = JsonSerializer.Serialize(this._request);
			this._buf = Encoding.UTF8.GetBytes(json);

			//проверка _socket на null должна быть заранее
			Debug.Assert(this._socket is not null);
			this._socket.Send(this._buf);
		}
		catch (Exception ex) {
			MessageBox.Show($"Не удалось отправить запрос!\r\n{ex.Message}", "Ошибка",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void radioButtonGet_CheckedChanged(object sender, EventArgs e)
	{
		this._request.Request = MovieRequest.RequestType.Get;
		this.textBoxGenre.Enabled = false;
		this.maskedTextBoxYear.Enabled = false;
	}

	private void radioButtonDelete_CheckedChanged(object sender, EventArgs e)
	{ 
		this.textBoxGenre.Enabled = false;
		this.maskedTextBoxYear.Enabled = false;
		this._request.Request = MovieRequest.RequestType.Delete;
	}

	private void radioButtonAdd_CheckedChanged(object sender, EventArgs e)
	{ 
		this.textBoxGenre.Enabled = true;
		this.maskedTextBoxYear.Enabled = true;
		this._request.Request = MovieRequest.RequestType.Add;
	}

	private void radioButtonUpdate_CheckedChanged(object sender, EventArgs e)
	{ 
		this.maskedTextBoxYear.Enabled = true;
		this.textBoxGenre.Enabled = true;
		this._request.Request = MovieRequest.RequestType.Update;
	}
}
