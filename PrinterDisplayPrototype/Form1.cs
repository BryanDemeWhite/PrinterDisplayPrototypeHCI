namespace PrinterDisplayPrototype
{
    public partial class Form1 : Form
    {
        bool selectedNetwork = false;
        public Form1()
        {
            InitializeComponent();
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            Task.Run(() => Welcome());
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            // tabControl1.SelectTab(Copy);
            Random rnd = new Random();
            int error = rnd.Next(1, 11);
            if(error <=3)
            {
                logLine("Connection dropped. Try connecting again.",Color.Red);
            }
            else
            {
                logLine("Copying document.", Color.White);

            }
            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            //tabControl1.SelectTab(Scan);
            Random rnd = new Random();
            int error = rnd.Next(1, 11);
            if (error <= 3)
            {
                logLine("Connection dropped. Try connecting again.", Color.Red);
            }
            else
            {
                logLine("Scanning document to connected PC.", Color.White);

            }
                
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            //tabControl1.SelectTab(Setup);
            Task.Run(() => settingUP());
        }
        public void logLine(string line, Color color)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string,Color>(logLine), new object[] { line,color });
                return;
            }
            this.Invoke((MethodInvoker)delegate ()
            {
                richTextBox1.Select(0, 0);
                richTextBox1.SelectionColor = color;
                richTextBox1.SelectedText = line + "\r\n";

            });
           
        }
        public void settingUP()
        {
            if(selectedNetwork==true)
            {
                logLine("Setting up printer on selected network, this may take a minute!", Color.White);
                Task.Delay(3000).Wait();
                logLine("You're all set to start printing!", Color.Green);
            }
            else
            {
                logLine("Please select a network.", Color.White);
            }
           

            
        }
        public void Welcome()
        {
            logLine("Welcome to your new DND 6000 Series printer.", Color.White);
            Task.Delay(1000).Wait();
            logLine("Begin by connecting to a network.", Color.White);
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(Main);
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);

            }
            tabControl1.SelectTab(Setup);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                logLine("You connected to " + checkedListBox1.SelectedItem.ToString() + ". You can now begin the Setup.", Color.Green);
                checkedListBox1.SetItemChecked(checkedListBox1.SelectedIndex, true);
                tabControl1.SelectTab(Main);
                selectedNetwork = true;
            }
            catch (Exception ex)
            {
                logLine("Please select a network.", Color.White);
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(Main);
        }
    }
}