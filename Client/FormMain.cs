using System.Net;

namespace Client;

public partial class FormMain : Form
{
	private readonly FormIpChange _ipChange = new();
	

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
}
