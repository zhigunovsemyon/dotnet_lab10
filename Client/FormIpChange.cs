namespace Client;

/// <summary> Форма редактирования адреса подключения </summary>
public partial class FormIpChange : Form
{
	private const string DefaultPort = "9876"; 
	public string Address => this.textBoxAddress.Text;
	public string Port => this.maskedTextBoxPort.Text;

	public FormIpChange () 
	{ 
		this.InitializeComponent(); 
		this.maskedTextBoxPort.Text = DefaultPort;
	}

	/// <summary> Обработчик нажатия на клавишу сохранения </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void buttonSave_Click (object sender, EventArgs e) => this.Close();

	/// <summary> Проверка корректности полей по закрытию. При неудаче сброс до стандартных значений </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void FormIpChange_FormClosed (object sender, FormClosedEventArgs e)
	{
		try {
			this.maskedTextBoxPort.Text = UInt16.Parse(this.maskedTextBoxPort.Text.Trim()).ToString();
		}
		catch {
			this.maskedTextBoxPort.Text = DefaultPort;
		}
	}
}
