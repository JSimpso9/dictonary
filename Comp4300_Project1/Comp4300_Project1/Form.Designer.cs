using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

public partial class DistanceForm : Form
{
    private TextBox inputBox;
    private ComboBox comboBoxFrom;
    private CheckedListBox checkedListBoxTo;
    private Button buttonConvert;
    private Button buttonClear;
    private TextBox outputBox;
    private DistanceConverter converter;

    /// <summary>
    /// Initializes a new instance of the <see cref="DistanceForm"/> class.
    /// </summary>
    public DistanceForm()
    {
        InitializeComponent();
        converter = new DistanceConverter();
        PopulateUnits();
    }

    //
    private void PopulateUnits()
    {
        foreach (var unit in converter.UnitToConvert.Keys)
        {
            comboBoxFrom.Items.Add(unit);
            checkedListBoxTo.Items.Add(unit);
        }
        comboBoxFrom.SelectedIndex = 3; 
    } 

    private void buttonConvert_Click(object sender, EventArgs e)
    {
        outputBox.Clear();

        if (!double.TryParse(inputBox.Text, out double inputValue))
        {
            MessageBox.Show("Please enter a valid numeric value.");
            return;
        }

        if (comboBoxFrom.SelectedItem == null || checkedListBoxTo.CheckedItems.Count == 0)
        {
            MessageBox.Show("Please select a unit to convert from and at least one to convert to.");
            return;
        }

        string fromUnit = comboBoxFrom.SelectedItem.ToString();

        foreach (var item in checkedListBoxTo.CheckedItems)
        {
            string toUnit = item.ToString();
            double converted = converter.Convert(inputValue, fromUnit, toUnit);
            outputBox.AppendText($"{inputValue} {fromUnit} = {converted:F6} {toUnit}{Environment.NewLine}");
        }
    }

    private void buttonClear_Click(object sender, EventArgs e)
    {
        inputBox.Clear();
        outputBox.Clear();
        comboBoxFrom.SelectedIndex = 3;
        for (int i = 0; i < checkedListBoxTo.Items.Count; i++)
            checkedListBoxTo.SetItemChecked(i, false);
    }

    private void InitializeComponent()
    {
        inputBox = new TextBox();
        comboBoxFrom = new ComboBox();
        checkedListBoxTo = new CheckedListBox();
        buttonConvert = new Button();
        buttonClear = new Button();
        outputBox = new TextBox();
        SuspendLayout();

        inputBox.Location = new Point(50, 50);
        inputBox.Size = new Size(200, 40);

        comboBoxFrom.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxFrom.Location = new Point(270, 50);
        comboBoxFrom.Size = new Size(250, 40);

        checkedListBoxTo.CheckOnClick = true;
        checkedListBoxTo.Location = new Point(550, 50);
        checkedListBoxTo.Size = new Size(250, 300);

        buttonConvert.Text = "Convert";
        buttonConvert.Location = new Point(830, 50);
        buttonConvert.Size = new Size(150, 50);
        buttonConvert.Click += new EventHandler(buttonConvert_Click);

        buttonClear.Text = "Clear";
        buttonClear.Location = new Point(830, 120);
        buttonClear.Size = new Size(150, 50);
        buttonClear.Click += new EventHandler(buttonClear_Click);

        outputBox.Location = new Point(50, 400);
        outputBox.Size = new Size(950, 250);
        outputBox.Multiline = true;
        outputBox.ReadOnly = true;
        outputBox.ScrollBars = ScrollBars.Vertical;

        AutoScaleDimensions = new SizeF(13F, 32F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1100, 700);
        Controls.Add(inputBox);
        Controls.Add(comboBoxFrom);
        Controls.Add(checkedListBoxTo);
        Controls.Add(buttonConvert);
        Controls.Add(buttonClear);
        Controls.Add(outputBox);
        Name = "DistanceForm";
        Text = "Distance Converter";
        ResumeLayout(false);
        PerformLayout();
    }
}
