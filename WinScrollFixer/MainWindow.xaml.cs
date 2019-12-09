using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace WinScrollFixer
{
    public partial class MainWindow : Window
    {
        [DllImport("User32.dll")]
        static extern Boolean SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, IntPtr pvParam, UInt32 fWinIni);

        [DllImport("Kernel32.dll")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("Kernel32.dll")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        const UInt32 SPI_GETWHEELSCROLLLINES = 104;
        const UInt32 SPI_SETWHEELSCROLLLINES = 105;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDCHANGE = 0x02;

        DispatcherTimer timer = new DispatcherTimer();
        UInt32 time = 0;

        UInt32 scrollValue = 10;
        UInt32 tickValue = 1;
        UInt32 endTime = 10;

        public MainWindow()
        {
            InitializeComponent();
            slider.ValueChanged += Slider_ValueChanged;
            tbxScrollValue.TextChanged += TbxScrollValue_TextChanged;
            tbxTickValue.TextChanged += TbxTickValue_TextChanged;

            INI_Handler(true);
            Set_AccessText();

            IntPtr ptr;
            ptr = Marshal.AllocCoTaskMem(4);
            SystemParametersInfo(SPI_GETWHEELSCROLLLINES, 0, ptr, 0);
            this.Title = "Scroll Speed = " + Marshal.ReadInt32(ptr).ToString();
            Marshal.FreeCoTaskMem(ptr);

            timer.Interval = TimeSpan.FromSeconds(1.0);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void INI_Handler(bool Initialize)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(path);
            string PATH_INI = path + "\\WinScrollFixer.ini";

            if (Initialize == true)
            {
                if (System.IO.File.Exists(PATH_INI) == false)
                {
                    WritePrivateProfileString("INFO", "SCRLVAL", scrollValue.ToString(), PATH_INI);
                    WritePrivateProfileString("INFO", "TICKVAL", tickValue.ToString(), PATH_INI);
                    WritePrivateProfileString("INFO", "ENDTIME", endTime.ToString(), PATH_INI);
                }
                else
                {
                    try
                    {
                        StringBuilder ret = new StringBuilder();
                        Int64 tmp = 0;

                        GetPrivateProfileString("INFO", "SCRLVAL", "(NONE)", ret, sizeof(UInt32), PATH_INI);
                        tmp = Int64.Parse(ret.ToString());

                        if (tmp < 1 || tmp > 100) tmp = 10;

                        scrollValue = (UInt32)tmp;

                        GetPrivateProfileString("INFO", "ENDTIME", "(NONE)", ret, sizeof(UInt32), PATH_INI);
                        tmp = Int64.Parse(ret.ToString());

                        if (tmp < 1 || tmp > UInt32.MaxValue) tmp = 10;

                        endTime = (UInt32)tmp;

                        GetPrivateProfileString("INFO", "TICKVAL", "(NONE)", ret, sizeof(UInt32), PATH_INI);
                        tmp = Int64.Parse(ret.ToString());

                        if (tmp < 1 || tmp > endTime) tmp = 1;

                        tickValue = (UInt32)tmp;

                        tbxScrollValue.Text = scrollValue.ToString();
                        tbxTickValue.Text = tickValue.ToString();
                        tbxEndTime.Text = endTime.ToString();

                        WritePrivateProfileString("INFO", "SCRLVAL", scrollValue.ToString(), PATH_INI);
                        WritePrivateProfileString("INFO", "TICKVAL", tickValue.ToString(), PATH_INI);
                        WritePrivateProfileString("INFO", "ENDTIME", endTime.ToString(), PATH_INI);
                    }
                    catch
                    {
                        MessageBox.Show("INI file has been corrupted, loaded with default setting.");

                        System.IO.File.Delete(PATH_INI);

                        WritePrivateProfileString("INFO", "SCRLVAL", scrollValue.ToString(), PATH_INI);
                        WritePrivateProfileString("INFO", "TICKVAL", tickValue.ToString(), PATH_INI);
                        WritePrivateProfileString("INFO", "ENDTIME", endTime.ToString(), PATH_INI);

                        slider.Value = scrollValue;
                        tbxScrollValue.Text = scrollValue.ToString();
                        tbxTickValue.Text = tickValue.ToString();
                        tbxEndTime.Text = endTime.ToString();
                    }
                }
            }
            else
            {
                WritePrivateProfileString("INFO", "SCRLVAL", scrollValue.ToString(), PATH_INI);
                WritePrivateProfileString("INFO", "TICKVAL", tickValue.ToString(), PATH_INI);
                WritePrivateProfileString("INFO", "ENDTIME", endTime.ToString(), PATH_INI);
            }
        }

        private void Set_AccessText()
        {
            String str = "_Set vertical scroll to " + scrollValue.ToString() + " every " + tickValue.ToString() + " second(s) until timer reach " + endTime.ToString() + " seconds.";
            accessText.Text = str;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time += 1;
            testLabel.Content = time.ToString();

            Set_AccessText();

            if (time % tickValue == 0)
            {
                IntPtr ptr;
                ptr = Marshal.AllocCoTaskMem(4);
                SystemParametersInfo(SPI_GETWHEELSCROLLLINES, 0, ptr, 0);
                this.Title = "Scroll Speed = " + Marshal.ReadInt32(ptr).ToString();

                ptr = IntPtr.Zero;
                bool b = false;
                b = SystemParametersInfo(SPI_SETWHEELSCROLLLINES, scrollValue, ptr, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);

                if (b == false)
                {
                    MessageBox.Show("Something wrong");
                }
                else
                {
                    IntPtr ptr2;
                    ptr2 = Marshal.AllocCoTaskMem(4);
                    SystemParametersInfo(SPI_GETWHEELSCROLLLINES, 0, ptr2, 0);
                    this.Title = "Scroll Speed = " + Marshal.ReadInt32(ptr2).ToString();
                    Marshal.FreeCoTaskMem(ptr2);
                }

                Marshal.FreeCoTaskMem(ptr);
            }

            INI_Handler(false);

            if (time > endTime)
            {
                this.Title = "Bye!";
                Environment.Exit(0);
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbxScrollValue.Text = e.NewValue.ToString();
            scrollValue = (UInt32)e.NewValue;
        }

        private void TbxScrollValue_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if ((tbxScrollValue.Text == "") || (UInt32.Parse(tbxScrollValue.Text) < 1))
            {
                tbxScrollValue.Text = "1";
            }
            else if (UInt32.Parse(tbxScrollValue.Text) > 100)
            {
                tbxScrollValue.Text = "100";
            }

            scrollValue = UInt32.Parse(tbxScrollValue.Text);
            slider.Value = scrollValue;
        }

        private void TbxTickValue_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (tbxTickValue.Text == "")
            {
                tbxTickValue.Text = "1";
            }
            else if (UInt32.Parse(tbxTickValue.Text) > endTime)
            {
                tbxTickValue.Text = (endTime - 1).ToString();
            }

            tickValue = UInt32.Parse(tbxTickValue.Text);
        }

        private void TbxEndTime_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxEndTime.Text == "")
            {
                tbxEndTime.Text = (time + 10).ToString();
            }
            else if (UInt32.Parse(tbxEndTime.Text) > UInt32.MaxValue)
            {
                tbxEndTime.Text = (UInt32.MaxValue - 1).ToString();
            }

            endTime = UInt32.Parse(tbxEndTime.Text);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}