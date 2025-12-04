using System.Net;
using System.Net.Sockets;

namespace Client;

public partial class FormMain : Form
{
	private readonly FormIpChange _ipChange = new();

	private Socket? _socket = null;

	public FormMain ()
	{
		this.InitializeComponent();
		this.toolStripStatusLabelServerAddress.Text = $"Адрес подключения: {this._ipChange.Address}:{this._ipChange.Port}";
	}

	private void buttonChangeServer_Click (object sender, EventArgs e)
	{
		this._ipChange.ShowDialog();
		this.toolStripStatusLabelServerAddress.Text = $"Адрес подключения: {this._ipChange.Address}:{this._ipChange.Port}";
	}

	private static IPAddress? ipFromDns (string dns)
	{
		try {
			return Dns.GetHostAddresses(dns)[0];
		}
		catch (SocketException) {
			return null;
		}
	}

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

	private void buttonConnectSwitch_Click (object sender, EventArgs e)
	{
		if (this._socket is not null) {
			this.Disonnect(this._socket);
		} else {
			this.Connect();
		}
	}

	private void Disonnect (Socket sock)
	{
		try {
			sock.Shutdown(SocketShutdown.Both);
			sock.Close();
		} catch (Exception e) {
			MessageBox.Show($"Ошибка при отключении!\r\n{e.Message}", "Ошибка", 
				MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		this._socket = null;
		this.buttonConnectSwitch.Text = "Подключиться";
	}
	private void Connect ()
	{
		var endPoint = CreateEndPointFromServerInfo(this._ipChange.Address, this._ipChange.Port);
		if (endPoint is null) {
			MessageBox.Show("Не удалось подключиться!", "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
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
}
