using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

using System.Threading;

namespace QQ
{
    public partial class MainWindow : Form
    {
        public LocalServerConfig localConfig;
        public TCPClass tcpObject;

        public delegate void Callback();
        public delegate void CallbackString(string str);

        public MainWindow()
        {
            InitializeComponent();

            // 后端 网络层预处理
            this.localConfig = new LocalServerConfig();

            // 前端 初始化本机IP和应用程序端口号
            InitializeLocalIPConfig(localConfig);

            // 前端 初始化控件可用性
            InitializeComponentAvailable();

            // 后端 这里开始允许建立连接
            this.tcpObject = new TCPClass(localConfig);
            // 处理客户端请求
            tcpObject.ListenAndAccept(AcceptSuccessCallback);

        }

        // 初始化本机IP和应用程序端口号
        public void InitializeLocalIPConfig(LocalServerConfig localConfig)
        {
            // 控件设置
            this.LocalIPTextBoxReadOnly.Text = localConfig.LocalIP;
            this.LocalPortTextBoxReadOnly.Text = localConfig.LocalPort.ToString();
        }

        // 初始化控件可用性
        public void InitializeComponentAvailable()
        {
            // 控件可用性
            this.MessagesFlowLayoutPanel.Enabled = false;
            this.MessageTextBox.Enabled = false;
            this.SendMessageButton.Enabled = false;
            this.SendFileButton.Enabled = false;
            this.SendVideoButton.Enabled = false;
            this.DisConnectButton.Enabled = false;

            // 下拉列表默认值
            this.ConnectModeComboBox.SelectedIndex = 0;
        }

        // -----------------------------------------------------------------------------
        // 以下为控件事件

        // 关闭时释放所有资源
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Environment.Exit(0);
        }

        // 连接事件
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            // 修改控件可用性
            this.ConnectButton.Enabled = false;

            // 获取对方IP和端口
            string destinationIP = this.DestinationIPTextBox.Text;
            string destinationPort = this.DestinationPortTextBox.Text;

            // 消息提示
            MessageBox.Show("正发起连接", "提示", MessageBoxButtons.OK);

            // 后端发起连接请求
            this.tcpObject.ConnectRequest(destinationIP, destinationPort, NoRespondCallback, RespondCallback);

        }

        // 断开连接事件
        private void DisConnectButton_Click(object sender, EventArgs e)
        {
            // 修改控件可用性
            this.ConnectButton.Enabled = false;
        }

        // -----------------------------------------------------------------------------
        // 以下为底层回调

        // 对方未响应连接请求的回调
        public void NoRespondCallback()
        {
            // 交还主线程调用
            if (this.InvokeRequired)
            {
                Callback d = new Callback(NoRespondCallback);
                this.Invoke(d);
            }
            else
            {
                // 修改控件可用性
                this.ConnectButton.Enabled = true;

                // 修改状态标签
                this.ConnectLogTextBoxReadOnly.Text = "连接失败 对方未响应";

                // 消息提示
                MessageBox.Show("对方未响应连接请求\n对方可能不在线 请稍后重试", "提示", MessageBoxButtons.OK);
            }
        }

        // 对方响应并连接成功的回调
        public void RespondCallback()
        {
            // 交还主线程调用
            if (this.InvokeRequired)
            {
                Callback d = new Callback(RespondCallback);
                this.Invoke(d);
            }
            else
            {
                // 修改控件可用性
                P2PConnectSuccessComponentAvailable();
                // 消息提示
                MessageBox.Show("连接成功\n在关闭窗口之前 应先断开连接", "提示", MessageBoxButtons.OK);
            }
        }

        // 服务器建立连接成功的回调
        public void AcceptSuccessCallback(string destinationIP)
        {
            // 交还主线程调用
            if (this.InvokeRequired)
            {
                CallbackString d = new CallbackString(AcceptSuccessCallback);
                this.Invoke(d, destinationIP);
            }
            else
            {
                // 修改控件可用性
                P2PConnectSuccessComponentAvailable();
                // 消息提示
                MessageBox.Show($"来自{destinationIP}的一个连接已建立 \n在关闭窗口之前 应先断开连接", "提示", MessageBoxButtons.OK);
            }
        }

        // P2P连接状态下的控件状态
        public void P2PConnectSuccessComponentAvailable()
        {
            // 修改控件可用性
            this.ConnectModeComboBox.Enabled = false;

            this.DestinationIPTextBox.ReadOnly = true;
            this.DestinationPortTextBox.ReadOnly = true;

            this.MessagesFlowLayoutPanel.Enabled = true;
            this.MessageTextBox.Enabled = true;
            this.SendMessageButton.Enabled = true;
            this.SendFileButton.Enabled = true;
            this.SendVideoButton.Enabled = true;
            this.ConnectButton.Enabled = false;
            this.DisConnectButton.Enabled = true;

            // 修改状态标签
            this.ConnectLogTextBoxReadOnly.Text = "连接成功 可以发送消息";
        }

    }

    // 本机服务端相关信息
    public class LocalServerConfig
    {
        public IPEndPoint LocalHost;
        public string LocalIP;
        public int LocalPort;
        public Socket LocalSocket;

        public LocalServerConfig()
        {
            // 获取所有网卡
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            // 弃用代码
            {
                //// ping
                //Ping ping = new Ping();
                //PingReply reply;

                //// 网关地址
                //string localGateWay;
                {
                    // 此方法失败 多网卡或多IP时无法获得正确的本机IP 且依赖DNS服务器

                    //// 根据DNS服务器获取本机IPv4地址 前提是DNS服务器正常
                    //string localhostName = Dns.GetHostName();
                    //IPHostEntry localhostEntry = Dns.GetHostEntry(localhostName);
                    //foreach (IPAddress ip in localhostEntry.AddressList)
                    //{
                    //    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    //    {
                    //        LocalIP = ip.ToString();
                    //    }
                    //}

                    // 此方法失败 只能获得正确的网关 无法获得本机IP

                    //// 遍历网卡
                    //foreach (var networkInterface in networkInterfaces)
                    //{
                    //    // 网卡的IP对象
                    //    IPInterfaceProperties ipObject = networkInterface.GetIPProperties();

                    //    // 获取该IP对象的网关
                    //    GatewayIPAddressInformationCollection gateWays = ipObject.GatewayAddresses;
                    //    if (gateWays.Count == 0)
                    //        continue;

                    //    foreach (var gateWay in gateWays)
                    //    {
                    //        // 是IPv4
                    //        if (gateWay.Address.AddressFamily == AddressFamily.InterNetwork)
                    //        {
                    //            // 如果能够Ping通网关
                    //            reply = ping.Send(gateWay.Address.ToString());

                    //            if (reply.Status == IPStatus.Success)
                    //            {
                    //                // 得到网关地址
                    //                localGateWay = gateWay.Address.ToString();
                    //            }                    
                    //        }
                    //    }
                    //}
                }
            }

            // 单播地址
            UnicastIPAddressInformation mostSuitableIp = null;

            foreach (var networkInterface in networkInterfaces)
            {
                // 网卡是否运行正常
                if (networkInterface.OperationalStatus != OperationalStatus.Up)
                    continue;

                IPInterfaceProperties ipObject = networkInterface.GetIPProperties();

                // 去掉无IP的网卡
                if (ipObject.GatewayAddresses.Count == 0)
                    continue;

                foreach (var unicastIP in ipObject.UnicastAddresses)
                {
                    // 是IPv4
                    if (unicastIP.Address.AddressFamily != AddressFamily.InterNetwork)
                        continue;

                    //// 环回地址
                    //if (IPAddress.IsLoopback(unicastIP.Address))
                    //    continue;

                    // 不能出现在DNS服务器 但目前没有合适的地址
                    if (!unicastIP.IsDnsEligible && mostSuitableIp == null)
                    {
                        mostSuitableIp = unicastIP;
                        continue;
                    }

                    // 来自 DHCP 服务器的IP
                    if (unicastIP.PrefixOrigin == PrefixOrigin.Dhcp)
                    {
                        if (mostSuitableIp == null || !mostSuitableIp.IsDnsEligible)
                            mostSuitableIp = unicastIP;
                    }
                }
            }

            // 设置本机信息
            if (mostSuitableIp == null)
            {
                this.LocalIP = "127.0.0.1";
                this.LocalHost = new IPEndPoint(IPAddress.Parse(LocalIP), 0);
                this.LocalSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.LocalSocket.Bind(LocalHost);
                // EndPoint是抽象类 需要强制类型转换再取Port
                this.LocalPort = ((IPEndPoint)LocalSocket.LocalEndPoint).Port;
                this.LocalHost.Port = LocalPort;
            }
            else
            {
                this.LocalIP = mostSuitableIp.Address.ToString();
                this.LocalHost = new IPEndPoint(mostSuitableIp.Address, 0);
                this.LocalSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.LocalSocket.Bind(LocalHost);
                // EndPoint是抽象类 需要强制类型转换再取Port
                this.LocalPort = ((IPEndPoint)LocalSocket.LocalEndPoint).Port;
                this.LocalHost.Port = LocalPort;
            }
        }
    }

    // 从建立连接到拆除连接均在此类完成
    public class TCPClass
    {
        // 本机服务端
        public LocalServerConfig localServerConfig;

        // -------------------------------------连接相关信息-----------------------------------
        // 本机服务端的 对方主机
        public IPEndPoint LocalServerDestinationHost;
        // 本机服务端接受请求的 对方套接字
        public Socket DestinationSocket;

        // 本机客户端的 请求连接套接字
        public Socket LocalSocket;
        // 本机客户端请求连接的 对方主机
        public IPEndPoint DestinationHost;    

        // 监听线程
        public Thread listenAndAcceptThread;
        // 请求连接线程
        public Thread ConnectRequestThread;

        // 回调委托
        public delegate void Callback();
        public Callback NoRespondCallback;
        public Callback RespondCallback;
        public delegate void CallbackString(string str);
        public CallbackString AcceptSuccessCallback;

        public TCPClass(LocalServerConfig localServerConfig_Parameter)
        {
            this.localServerConfig = localServerConfig_Parameter;
        }

        // 开启本机监听和等待连接线程
        public void ListenAndAccept(CallbackString acceptSuccessCallback)
        {
            // 监听
            this.localServerConfig.LocalSocket.Listen(1);

            // 数据转换
            this.AcceptSuccessCallback = acceptSuccessCallback;

            // 等待连接线程
            ThreadStart acceptThreadStart = AcceptThreadStart;
            this.listenAndAcceptThread = new Thread(acceptThreadStart);
            this.listenAndAcceptThread.Start();
        }

        // 等待连接线程
        public void AcceptThreadStart()
        {
            try
            {
                this.DestinationSocket = localServerConfig.LocalSocket.Accept();

                this.LocalServerDestinationHost = (IPEndPoint)this.DestinationSocket.RemoteEndPoint;
                // 回调
                this.AcceptSuccessCallback(LocalServerDestinationHost.Address.ToString());

            }
            catch
            {
                MessageBox.Show("错误代码2333", "提示", MessageBoxButtons.YesNo);
            }
        }

        // 发起连接请求
        public void ConnectRequest(string destinationIP, string destinationPort, Callback noRespondCallback, Callback respondCallback)
        {
            // 数据转换
            this.DestinationHost = new IPEndPoint(IPAddress.Parse(destinationIP), int.Parse(destinationPort));

            this.LocalSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.NoRespondCallback = noRespondCallback;
            this.RespondCallback = respondCallback;

            // 等待响应线程
            ThreadStart connectRequestThreadStart = ConnectRequestThreadStart;
            this.ConnectRequestThread = new Thread(connectRequestThreadStart);
            this.ConnectRequestThread.Start();
        }

        // 等待对方响应连接请求线程
        public void ConnectRequestThreadStart()
        {
            try
            {
                this.LocalSocket.Connect(DestinationHost.Address, DestinationHost.Port);

                // 回调
                this.RespondCallback();
            }
            catch
            {
                // 执行完catch块时 子线程停止运行

                // 回调
                this.NoRespondCallback();
            }
        }
    }

    public class UDPClass
    {
        public UDPClass()
        {
        }
    }
}
