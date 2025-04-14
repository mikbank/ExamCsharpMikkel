namespace ExamCsharpMikkel;

public partial class Form1 : Form
{
   private TextBox pathTextBox;
private Button pathButton;
private RadioButton method1Radio;
private RadioButton method2Radio;
private RadioButton method3Radio;
private Button runButton;

public Form1()
{
    InitializeComponent();
    this.Text = "Sensor Data Analyzer";
    this.Width = 600;
    this.Height = 400;

    // File path TextBox
    pathTextBox = new TextBox();
    pathTextBox.Width = 250;
    pathTextBox.Left = 20;
    pathTextBox.Top = 20;

    // Path Button
    pathButton = new Button();
    pathButton.Text = "Path";
    pathButton.Left = 280;
    pathButton.Top = pathTextBox.Top;
    pathButton.Click += PathButton_Click;

    // Methods Label
    Label methodsLabel = new Label();
    methodsLabel.Text = "Methods:";
    methodsLabel.Top = 70;
    methodsLabel.Left = 20;
    methodsLabel.AutoSize = true;

    // Create GroupBox
    GroupBox methodGroup = new GroupBox();
    methodGroup.Text = "Methods";
    methodGroup.Top = 70;
    methodGroup.Left = 20;
    methodGroup.Width = 350;
    methodGroup.Height = 120;

    // Radio buttons (inside the group)
    method1Radio = new RadioButton();
    method1Radio.Text = "1";
    method1Radio.Top = 25;
    method1Radio.Left = 20;

    method2Radio = new RadioButton();
    method2Radio.Text = "2";
    method2Radio.Top = 25;
    method2Radio.Left = 140;

    method3Radio = new RadioButton();
    method3Radio.Text = "3";
    method3Radio.Top = 25;
    method3Radio.Left = 250;

    // Add radio buttons to group
    methodGroup.Controls.Add(method1Radio);
    methodGroup.Controls.Add(method2Radio);
    methodGroup.Controls.Add(method3Radio);

    
    

    // Run Button
    runButton = new Button();
    runButton.Text = "Run";
    runButton.Top = 200;
    runButton.Left = 450;
    runButton.Click += RunButton_Click;

    // Add to form
    this.Controls.Add(pathTextBox);
    this.Controls.Add(pathButton);
    this.Controls.Add(methodsLabel);
    this.Controls.Add(methodGroup);
    this.Controls.Add(runButton);
}
  private void PathButton_Click(object? sender, EventArgs e)
    {
        using OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            pathTextBox.Text = openFileDialog.FileName;
        }
    }

    // run button simple function
    private void RunButton_Click(object? sender, EventArgs e)
    {
        string selectedMethod = method1Radio.Checked ? "1" :
                                method2Radio.Checked ? "2" :
                                method3Radio.Checked ? "3" : "none";

        MessageBox.Show($"File path: {pathTextBox.Text}\nSelected method: {selectedMethod}");
    }

}