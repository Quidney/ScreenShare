namespace ScreenShare.UI.UserControls
{
    public partial class SizeBox : UserControl
    {
        public event EventHandler? ValueChanged;

        public Size Value
        {
            get => _value;
            set
            {
                if ((value.Width == _value.Width) && (value.Height == _value.Height))
                    return;

                _value = new Size(value.Width, value.Height);
                UpdateNumBoxes();
                UpdateText();
                ValueChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void UpdateNumBoxes()
        {
            numX.Value = _value.Width;
            numY.Value = _value.Height;
        }

        private Size _value;

        public SizeBox()
        {
            InitializeComponent();
        }

        private void X_ValueChanged(object sender, EventArgs e) => Value = new Size((int)numX.Value, _value.Height);
        private void Y_ValueChanged(object sender, EventArgs e) => Value = new Size(_value.Width, (int)numY.Value);
        private void UpdateText() => lblResult.Text = $"{{ {Value.Width}x{Value.Height} }}";
    }
}