using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;
using Emgu.CV.Reg;

namespace JX3QuickRedBag
{
    public partial class Form1 : Form
    {
        private CDD dd;
        private Model config = new Model();
        private bool IsLock = false;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 保存配置到Json
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            Model m = new Model();
            m.XS = textBox_X2.Text;
            m.YS = textBox_Y2.Text;
            m.Path = textBox5.Text;
            config = m;

            var path = textBox5.Text;
            if (path.ToUpper().StartsWith("PATH/"))
            {
                path = AppDomain.CurrentDomain.BaseDirectory + path.Remove(0, 5);
                m.Path = path;
                textBox5.Text = path;
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText("AppData.json", JsonConvert.SerializeObject(m));

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
        }

        private void LoadDllFile(string dllfile)
        {
            int ret = dd.Load(dllfile);
            if (ret != 1) { MessageBox.Show("Load Error"); this.Close(); }

            ret = dd.btn(0); //DD Initialize
            if (ret != 1) { MessageBox.Show("Initialize Error"); this.Close();  }

           
        }
        #region "HotKey"
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(
         IntPtr hWnd,
         int id,
         KeyModifiers modkey,
         Keys vk
        );
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(
         IntPtr hWnd,
         int id
        );

        void reg_hotkey()
        {
            RegisterHotKey(this.Handle, 80, 0, Keys.F8);
        }

        void unreg_hotkey()
        {
            UnregisterHotKey(this.Handle, 80);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    ProcessHotkey(m);
                    break;
            }
            base.WndProc(ref m);
        }

        private void ProcessHotkey(Message msg)
        {
            switch (msg.WParam.ToInt32())
            {
                case 80:
                    Fun80();
                    break;
            }
        }

        private void Fun80()
        {
            if(IsLock)
                IsLock = false; 
            else
                IsLock = true;
            Task taks = new Task(()=>{
                while (IsLock)
                {
                    Rectangle rc = new Rectangle(0, 0, int.Parse(config.XS), int.Parse(config.YS));
                    using (var img = new Bitmap(rc.Width,rc.Height))
                    using (Graphics g = Graphics.FromImage(img))
                    {
                        g.CopyFromScreen(rc.X,rc.Y,0,0,rc.Size,CopyPixelOperation.SourceCopy);
                        IntPtr s = g.GetHdc();
                        g.ReleaseHdc(s);
                        //img.Save(config.Path + $"/RedBag{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-FFF")}.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                        ImageSearch sd = new ImageSearch();
                        var p = sd.FindTemplateInImage(img, Path.Combine(AppDomain.CurrentDomain.BaseDirectory ,"Resource/RedBag.png"));
                        if (!p.IsEmpty)
                        {
                            dd.mov(p.X + 5, p.Y + 5);
                            dd.btn(1);
                            System.Threading.Thread.Sleep(10);
                            dd.btn(2);
                            System.Threading.Thread.Sleep(1000);
                            dd.mov(200, 200);
                            System.Threading.Thread.Sleep(1500);
                            dd.mov(250, 250);

                            //img.Save(config.Path + $"/RedBag{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-FFF")}.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                            Rectangle rcsave = new Rectangle(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                            using (var saveimg = new Bitmap(rcsave.Width, rcsave.Height))
                            using (Graphics gsave = Graphics.FromImage(saveimg))
                            {
                                gsave.CopyFromScreen(rcsave.X, rcsave.Y, 0, 0, rcsave.Size, CopyPixelOperation.SourceCopy);
                                IntPtr sdi = gsave.GetHdc();
                                gsave.ReleaseHdc(sdi);

                                ImageSearch sdimg = new ImageSearch();
                                saveimg.Save(config.Path + $"/RedBag{DateTime.Now.ToString("yyyyMMddHHmmssFFF")}.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                var psave = sd.FindTemplateInImage(saveimg, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resource/Close.png"));
                                if (!psave.IsEmpty)
                                {
                                    dd.mov(psave.X + 5, psave.Y + 5);
                                    dd.btn(1);
                                    System.Threading.Thread.Sleep(10);
                                    dd.btn(2);
                                    System.Threading.Thread.Sleep(1000);
                                }
                            }
                        }
                    }
                }
            });
            taks.Start();
            
        }

        #endregion

        private void Form1_Shown(object sender, EventArgs e)
        {
            //读取Json配置
            var file = File.ReadAllText("AppData.json");
            var path = "Path/抢红包截图";
            if (!string.IsNullOrEmpty(file))
            {
                try
                {
                    var m = JsonConvert.DeserializeObject<Model>(file);
                    if (m != null)
                    {
                        textBox_X2.Text = m.XS ?? "";
                        textBox_Y2.Text = m.YS ?? "";
                        textBox5.Text = m.Path ?? path;
                        path = m.Path ?? path;
                        config = m;
                    }
                }
                catch (Exception)
                {

                }

            }
            //判断路径是否生效

            if (!string.IsNullOrEmpty(path))
            {
                if (path.ToUpper().StartsWith("PATH/"))
                {
                    path = AppDomain.CurrentDomain.BaseDirectory + path.Remove(0, 5);
                }

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Resource"))
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Resource");
            }


            //读取DD驱动
            dd = new CDD();
            if (IntPtr.Size == 8)
            {
                //64
                LoadDllFile("./dd/ddx64.dll");
            }
            else if (IntPtr.Size == 4)
            {
                //32
                LoadDllFile("./dd/ddx32.dll");
            }
            else
            {
                MessageBox.Show("该处理器无法提供服务！");
            }

            reg_hotkey();                            // 注册热键
        }
    }
}
