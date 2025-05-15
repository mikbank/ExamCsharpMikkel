namespace ExamCsharpMikkel;
using ExamCsharpMikkel.Processing;
using ExamCsharpMikkel.Monitor;
using ExamCsharpMikkel.Events;
using Serilog;


public partial class Form1 : Form
{
    private TextBox pathTextBox;
    private Button pathButton;
    private RadioButton method1Radio;
    private RadioButton method2Radio;
    private RadioButton method3Radio;
    private Button runButton;
    private RichTextBox logTextBox;

    public Form1()
    {
        InitializeComponent();
        this.Text = "Sensor Data Analyzer";
        this.Width = 600;
        this.Height = 500;

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

        // Log TextBox - Richtext to display logging better
        logTextBox = new RichTextBox();
        logTextBox.Multiline = true;
        logTextBox.Width = 550;
        logTextBox.Height = 100;
        logTextBox.Left = 20;
        logTextBox.Top = 300;
        logTextBox.ReadOnly = true;

        // Add to form
        this.Controls.Add(pathTextBox);
        this.Controls.Add(pathButton);
        this.Controls.Add(methodsLabel);
        this.Controls.Add(methodGroup);
        this.Controls.Add(runButton);
        this.Controls.Add(logTextBox);


        //Configuring Logging using serilog
        Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.RichTextBox(logTextBox)
        .CreateLogger();

        //initialize processing Event subscriptions
        AppEvents.OnProcessingCompleted += duration =>
        {

            MessageBox.Show($"Processing completed in {duration.TotalSeconds:F2} seconds.");

        };


    }

    //Functions in the form:

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
        
        IDataProcessor processor;
        
        if (method1Radio.Checked)
        {
            processor = new Method1Processor();
        }
        else if (method2Radio.Checked)
        {
            processor = new Method2Processor();
        }
        else if (method3Radio.Checked)
        {
            processor = new Method3Processor();
        }
        else
        {
            MessageBox.Show("Please select a method.");
            return;
        }

        string inputPath = pathTextBox.Text;

        ExecutionTimer.ChronoGraph(() => processor.Run(inputPath));
    }

}