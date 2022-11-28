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
            logLine("Copying document");
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            //tabControl1.SelectTab(Scan);
            logLine("Scanning document to connected PC");
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            //tabControl1.SelectTab(Setup);
            Task.Run(() => settingUP());
        }
        public void logLine(string line)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(logLine), new object[] { line });
                return;
            }
            this.Invoke((MethodInvoker)delegate ()
            {
                richTextBox1.Select(0, 0);
                richTextBox1.SelectedText = line + "\r\n";

            });
           
        }
        public void settingUP()
        {
            if(selectedNetwork==true)
            {
                logLine("Setting Up Printer on selected network, this may take a minute!");
                Task.Delay(3000).Wait();
                logLine("You're all set to start printing!");
            }
            else
            {
                logLine("Please Select a Network");
            }
           

            
        }
        public void Welcome()
        {
            logLine("Welcome to your new DND 6000 Series printer");
            Task.Delay(1000).Wait();
            logLine("Begin by connecting to a network.");
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(Main);
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(Setup);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                logLine("You Connected to " + checkedListBox1.SelectedItem.ToString() + ". You can now begin the Setup.");
                checkedListBox1.SetItemChecked(checkedListBox1.SelectedIndex, true);
                tabControl1.SelectTab(Main);
                selectedNetwork = true;
            }
            catch (Exception ex)
            {
                logLine("Please Select a Network");
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(Main);
        }
    }
}