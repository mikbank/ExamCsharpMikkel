namespace ExamCsharpMikkel;
using ExamCsharpMikkel.Processing;
using ExamCsharpMikkel.Monitor;
using ExamCsharpMikkel.Events;
using ExamCsharpMikkel.TestData;
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
        InitializeComponent(); // initialization of form component
        this.Text = "Sensor Data Analyzer";
        this.Width = 600;
        this.Height = 800;

        // File path TextBox object
        pathTextBox = new TextBox();
        pathTextBox.Width = 250;
        pathTextBox.Left = 20;
        pathTextBox.Top = 20;

        // Path Button object
        pathButton = new Button();
        pathButton.Text = "Path";
        pathButton.Left = 280;
        pathButton.Height = 35;
        pathButton.Top = pathTextBox.Top;
        pathButton.Click += PathButton_Click;

        // Methods Label object
        Label methodsLabel = new Label();
        methodsLabel.Text = "Methods:";
        methodsLabel.Top = 70;
        methodsLabel.Left = 20;
        methodsLabel.AutoSize = true;

        // Create GroupBox object
        GroupBox methodGroup = new GroupBox();
        methodGroup.Text = "Methods";
        methodGroup.Top = 70;
        methodGroup.Left = 20;
        methodGroup.Width = 350;
        methodGroup.Height = 120;

        // Radio button objects (inside the group)
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
        runButton.Text = "Run Method";
        runButton.Top = 175;
        runButton.Left = 450;
        runButton.Height = 75;
        runButton.Click += RunButton_Click;

         // CSV Button
        Button CsvButton = new Button();
        CsvButton.Text = "Create CSV";
        CsvButton.Top = 75;
        CsvButton.Height = 75;
        CsvButton.Left = 450;
        CsvButton.Click += CsvButton_Click;

        // Log TextBox - Richtext to display logging better
        logTextBox = new RichTextBox();
        logTextBox.Multiline = true;
        logTextBox.Width = 550;
        logTextBox.Height = 400;
        logTextBox.Left = 20;
        logTextBox.Top = 300;
        logTextBox.ReadOnly = true;

        // Here controls are Added to form!
        this.Controls.Add(pathTextBox);
        this.Controls.Add(pathButton);
        this.Controls.Add(methodsLabel);
        this.Controls.Add(methodGroup);
        this.Controls.Add(runButton);
        this.Controls.Add(CsvButton);
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

    //Fetching filepath using openfiledialog - 
    private void PathButton_Click(object? sender, EventArgs e)
    {
        using OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            pathTextBox.Text = openFileDialog.FileName;
        }
    }


    //Create CSV function
    private void CsvButton_Click(object? sender, EventArgs e)
    {
        string inputPath = pathTextBox.Text;
        ExecutionTimer.ChronoGraph(() => TestDataGenerator.CsvCreator(inputPath));

    }

    // run button using IDataProcessor interface to ligthen code and demonstrate polymorphism and of course interfaces
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
        var data = CsvParser.ParseCsv(inputPath);
        ExecutionTimer.ChronoGraph(() => processor.Run(data));
    }

}