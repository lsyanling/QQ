﻿using System;
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

        // -----------------------------------------------------------------------------
        // 以下为构造方法和初始化方法

        public MainWindow()
        {
            InitializeComponent();

            // 后端 网络层预处理
            this.localConfig = new LocalServerConfig();

            // 前端 初始化本机IP和应用程序端口号
            InitializeLocalIPConfig(localConfig);

            // 前端 初始化控件可用性
            InitializeComponentAvailable();

            // 后端 这里开始允许启动服务器
            this.tcpObject = new TCPClass(localConfig);
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

            this.MessageTextBox.Enabled = false;

            this.SendMessageButton.Enabled = false;
            this.SendFileButton.Enabled = false;
            this.SendVideoButton.Enabled = false;
            this.DisConnectButton.Enabled = false;
            this.StopServerButton.Enabled = false;
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
            this.RunServerButton.Enabled = false;

            // 获取对方IP和端口
            string destinationIP = this.DestinationIPTextBox.Text;
            string destinationPort = this.DestinationPortTextBox.Text;

            // 消息提示
            MessageBox.Show("正发起连接", "提示", MessageBoxButtons.OK);

            // 后端发起连接请求
            this.tcpObject.ConnectRequest(destinationIP, destinationPort, NoRespondCallback, RespondCallback, BroadcastMessageReceiveCallback);
        }

        // 断开连接事件
        private void DisConnectButton_Click(object sender, EventArgs e)
        {
            // 修改控件可用性
            this.ConnectButton.Enabled = true;
            this.DisConnectButton.Enabled = false;
        }

        // 启动本机服务器事件
        private void RunServerButton_Click(object sender, EventArgs e)
        {
            // 修改控件可用性
            this.DestinationIPTextBox.Enabled = false;
            this.DestinationPortTextBox.Enabled = false;

            this.ConnectButton.Enabled = false;
            this.RunServerButton.Enabled = false;
            this.StopServerButton.Enabled = true;

            // 修改状态标签
            this.ConnectLogTextBoxReadOnly.Text = "本机服务器已在运行";
            this.ServerLogTextBoxReadOnly.Text = "服务器已启动 等待连接";

            // 消息提示
            MessageBox.Show("已启动本机服务器", "提示", MessageBoxButtons.OK);

            // 后端启动本机服务器监听 这里暂用客户端收到广播消息的回调代替服务端收到消息的同步回调
            this.tcpObject.ListenAndAccept(AcceptSuccessCallback, BroadcastMessageReceiveCallback);
        }

        // 关闭本机服务器事件
        private void StopServerButton_Click(object sender, EventArgs e)
        {
            // 修改控件可用性
            this.DestinationIPTextBox.Enabled = true;
            this.DestinationPortTextBox.Enabled = true;

            this.ConnectButton.Enabled = true;
            this.RunServerButton.Enabled = true;
            this.StopServerButton.Enabled = false;

            // 后端关闭本机服务器

        }

        // 发送消息事件
        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            string message = this.MessageTextBox.Text;

            // 后端发送消息
            this.tcpObject.MessageSend(message);
        }

        // -----------------------------------------------------------------------------
        // 以下为控件状态

        // 请求连接成功的控件状态
        public void RespondSuccessComponentAvailable()
        {
            // 修改控件可用性
            this.DestinationIPTextBox.ReadOnly = true;
            this.DestinationPortTextBox.ReadOnly = true;


            this.MessageTextBox.Enabled = true;
            this.SendMessageButton.Enabled = true;
            this.SendFileButton.Enabled = true;
            this.SendVideoButton.Enabled = true;
            this.ConnectButton.Enabled = false;
            this.DisConnectButton.Enabled = true;

            // 修改状态标签
            this.ConnectLogTextBoxReadOnly.Text = "连接成功 可以发送消息";
            this.ServerLogTextBoxReadOnly.Text = "已与目标服务器建立连接";
        }

        // 断开连接后的控件状态
        public void DisConnectComponentAvailable()
        {

        }

        // 本机服务器建立连接的控件状态
        public void AcceptSuccessComponentAvailable()
        {
            // 修改控件可用性

            this.MessageTextBox.Enabled = true;
            this.SendMessageButton.Enabled = true;
            this.SendFileButton.Enabled = true;
            this.SendVideoButton.Enabled = true;

            // 修改状态标签
            this.ServerLogTextBoxReadOnly.Text = "一个客户端已连接";
        }

        // -----------------------------------------------------------------------------
        // 以下为客户端相关的底层回调

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
                this.RunServerButton.Enabled = true;

                // 修改状态标签
                this.ConnectLogTextBoxReadOnly.Text = "连接失败 对方未响应";

                // 消息提示
                MessageBox.Show("对方未响应连接请求\r\n对方可能不在线 请稍后重试", "提示", MessageBoxButtons.OK);
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
                RespondSuccessComponentAvailable();
                // 消息提示
                MessageBox.Show("连接成功\r\n在关闭窗口之前 应先断开连接", "提示", MessageBoxButtons.OK);
            }
        }

        // 接收到服务端广播消息的回调
        public void BroadcastMessageReceiveCallback(string data)
        {
            // 交还主线程调用
            if (this.InvokeRequired)
            {
                CallbackString d = new CallbackString(BroadcastMessageReceiveCallback);
                this.Invoke(d, data);
            }
            else
            {
                //// 向流盒子中添加TextBox
                //TextBox textbox = new TextBox();
                //textbox.Text = data;
                //textbox.Multiline = true;   // 允许换行
                //textbox.ScrollBars = ScrollBars.Vertical;
                //textbox.ReadOnly = true;    // 消息记录只读
                //textbox.Size = new Size(this.MessagesFlowLayoutPanel.Width, 300);
                //this.MessagesFlowLayoutPanel.Controls.Add(textbox);

                this.HistoryMessageRichTextBox.Text += data;
            }
        }

        // -----------------------------------------------------------------------------
        // 以下为本机服务器相关的底层回调

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
                AcceptSuccessComponentAvailable();
                // 消息提示
                MessageBox.Show($"来自{destinationIP}的一个连接已建立 \r\n在关闭窗口之前 应先断开连接", "提示", MessageBoxButtons.OK);
            }
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

    // 从本机监听到拆除连接均在此类完成
    public class TCPClass
    {
        // 本机服务端
        public LocalServerConfig localServerConfig;

        // -----------------------------------------------------------------------------
        // 以下为连接相关信息

        // 本机服务端的 对方主机
        public Dictionary<string, IPEndPoint> AllServerDestinationHost;
        // 本机服务端接受请求的 对方套接字
        public Dictionary<string, Socket> AllServerDestinationSocket;

        // 本机客户端的 请求连接套接字
        public Socket LocalSocket;
        // 本机客户端请求连接的 对方主机
        public IPEndPoint DestinationHost;

        public const int DATA_HEAD = 9;

        // -----------------------------------------------------------------------------
        // 以下为唯一线程

        // 监听线程
        public Thread ListenAndAcceptThread;
        // 请求连接线程
        public Thread ConnectRequestThread;

        // -----------------------------------------------------------------------------
        // 以下为上层回调

        // 回调委托 这里的实例都是确保唯一的
        public delegate void Callback();
        public Callback NoRespondCallback;
        public Callback RespondCallback;
        public delegate void CallbackString(string str);
        public CallbackString AcceptSuccessCallback;
        public CallbackString ServerMessageSyncCallback;
        public CallbackString BroadcastMessageReceiveCallback;

        public TCPClass(LocalServerConfig localServerConfig_Parameter)
        {
            // 引用本机服务器信息
            this.localServerConfig = localServerConfig_Parameter;

            // 初始化字典
            this.AllServerDestinationHost = new Dictionary<string, IPEndPoint>();
            this.AllServerDestinationSocket = new Dictionary<string, Socket>();
        }

        // -----------------------------------------------------------------------------
        // 以下为本机客户端线程相关

        // 发起连接请求
        public void ConnectRequest(string destinationIP, string destinationPort,
            Callback noRespondCallback, Callback respondCallback, CallbackString broadcastMessageReceiveCallback)
        {
            // 数据迁移
            this.DestinationHost = new IPEndPoint(IPAddress.Parse(destinationIP), int.Parse(destinationPort));

            this.LocalSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.NoRespondCallback = noRespondCallback;
            this.RespondCallback = respondCallback;
            this.BroadcastMessageReceiveCallback = broadcastMessageReceiveCallback;

            // 等待响应线程
            ThreadStart connectRequestThreadStart = ConnectRequestThreadStart;
            this.ConnectRequestThread = new Thread(connectRequestThreadStart);
            this.ConnectRequestThread.Start();
        }

        // 等待对方响应连接请求线程
        public void ConnectRequestThreadStart()
        {
            // 设置超时间隔
            new Thread(() =>
            {
                Thread.Sleep(5000);
                if (!this.LocalSocket.Connected)
                    this.LocalSocket.Close();
            }).Start();

            try
            {
                this.LocalSocket.Connect(DestinationHost.Address, DestinationHost.Port);

                // 广播消息接收线程
                ThreadStart broadcastMessageReceiveThreadStart = BroadcastMessageReceiveThreadStart;
                new Thread(broadcastMessageReceiveThreadStart).Start();

                // 回调
                this.RespondCallback();
            }
            catch
            {
                // 回调 超时或连接失败
                this.NoRespondCallback();
            }
        }

        // 服务器广播消息接收线程
        public void BroadcastMessageReceiveThreadStart()
        {
            byte[] receiveBuffer = new byte[1024];
            try
            {
                while (true)
                {
                    // 缓冲区长度
                    int bytes = 0;
                    while (bytes == 0)
                    {
                        bytes = this.LocalSocket.Receive(receiveBuffer, SocketFlags.None);
                    }

                    // 解码
                    string dataHead = Encoding.UTF8.GetString(receiveBuffer, 0, DATA_HEAD);
                    int dataLength = int.Parse(dataHead) / 10;

                    // 是消息
                    if (dataHead[DATA_HEAD - 1] == '0')
                    {
                        // 接收的数据
                        string data;
                        int nowDataLength;
                        // 缓冲区未清空
                        if (bytes > DATA_HEAD)
                        {
                            data = Encoding.UTF8.GetString(receiveBuffer, DATA_HEAD, bytes - DATA_HEAD);
                            nowDataLength = bytes - DATA_HEAD;
                        }
                        else
                        {
                            data = "";
                            nowDataLength = 0;
                        }
                        while (nowDataLength < dataLength)
                        {
                            bytes = LocalSocket.Receive(receiveBuffer, SocketFlags.None);
                            // 是本包数据
                            if (nowDataLength + bytes <= dataLength)
                            {
                                data += Encoding.UTF8.GetString(receiveBuffer, 0, bytes);
                                nowDataLength += bytes;
                            }
                            else
                            {
                                data += Encoding.UTF8.GetString(receiveBuffer, 0, dataLength - nowDataLength);
                                nowDataLength = dataLength;
                                // 还原缓冲区 看测试情况做
                            }
                        }

                        // 回调 消息上交客户端的前端
                        this.BroadcastMessageReceiveCallback(data);
                    }
                    // 是文件
                    else if (dataHead[DATA_HEAD - 1] == '1')
                    {

                    }
                }
            }
            catch
            {

            }
        }

        // 发送消息 这里定义客户端应用层协议
        public void MessageSend(string data)
        {
            // 编码
            int dataLength = data.Length;
            string dataLengthString = dataLength.ToString();
            int needZero = DATA_HEAD - dataLengthString.Length - 1;
            string zero = "";
            while (needZero > 0)
            {
                zero += "0";
                needZero--;
            }
            data = zero + dataLength.ToString() + "0" + data;

            // 消息发送线程
            ParameterizedThreadStart messageSendThreadStart = MessageSendThreadStart;
            new Thread(messageSendThreadStart).Start(data);
        }

        // 消息发送线程
        public void MessageSendThreadStart(object data)
        {
            byte[] sendBuffer = Encoding.UTF8.GetBytes((string)data);
            // 发送数据
            try
            {
                this.LocalSocket.Send(sendBuffer);
            }
            catch
            {
                // 连接已被关闭 此处应有回调 通知上层某个客户端已断开连接
                // 还有该连接及所属线程的善后工作
            }
        }

        // -----------------------------------------------------------------------------
        // 以下为本机服务端线程相关

        // 开启本机监听和等待连接线程
        public void ListenAndAccept(CallbackString acceptSuccessCallback, CallbackString serverMessageSyncCallback)
        {
            // 监听
            this.localServerConfig.LocalSocket.Listen(1);

            // 数据迁移
            this.AcceptSuccessCallback = acceptSuccessCallback;
            this.ServerMessageSyncCallback = serverMessageSyncCallback;

            // 等待连接线程
            ThreadStart acceptThreadStart = AcceptThreadStart;
            this.ListenAndAcceptThread = new Thread(acceptThreadStart);
            this.ListenAndAcceptThread.Start();
        }

        // 等待连接线程
        public void AcceptThreadStart()
        {
            try
            {
                while (true)
                {
                    // 接受连接
                    Socket aServerDestinationSocket = localServerConfig.LocalSocket.Accept();

                    // 获取连接套接字信息
                    IPEndPoint aServerDestinationHost = (IPEndPoint)aServerDestinationSocket.RemoteEndPoint;
                    string aServerDestinationAddress = aServerDestinationHost.Address.ToString();
                    int aServerDestinationPort = aServerDestinationHost.Port;
                    string key = aServerDestinationAddress + ":" + aServerDestinationPort.ToString();

                    // 存入字典
                    this.AllServerDestinationHost.Add(key, aServerDestinationHost);
                    this.AllServerDestinationSocket.Add(key, aServerDestinationSocket);

                    // 消息接收线程
                    ParameterizedThreadStart messageReceiveThreadStart = MessageReceiveThreadStart;
                    new Thread(messageReceiveThreadStart).Start(aServerDestinationSocket);

                    // 回调
                    this.AcceptSuccessCallback(key);
                }
            }
            catch
            {
                MessageBox.Show("错误代码2333", "提示", MessageBoxButtons.YesNo);
            }
        }

        // 消息接收线程 这里定义服务端应用层协议
        public void MessageReceiveThreadStart(Object socket)
        {
            IPEndPoint remoteEndPoint = (IPEndPoint)((Socket)socket).RemoteEndPoint;
            string messageHead = "\r\n[" + remoteEndPoint.Address.ToString() + ":"
                + remoteEndPoint.Port.ToString() + "]\r\n";
            byte[] receiveBuffer = new byte[1024];

            try
            {
                while (true)
                {
                    // 缓冲区长度
                    int bytes = 0;
                    while (bytes == 0)
                    {
                        bytes = ((Socket)socket).Receive(receiveBuffer, SocketFlags.None);
                    }

                    // 解码
                    string dataHead = Encoding.UTF8.GetString(receiveBuffer, 0, DATA_HEAD);
                    int dataLength = int.Parse(dataHead) / 10;

                    // 是消息
                    if (dataHead[DATA_HEAD - 1] == '0')
                    {
                        // 接收的数据
                        string data;
                        int nowDataLength;
                        // 缓冲区未清空
                        if (bytes > DATA_HEAD)
                        {
                            data = Encoding.UTF8.GetString(receiveBuffer, DATA_HEAD, bytes - DATA_HEAD);
                            nowDataLength = bytes - DATA_HEAD;
                        }
                        else
                        {
                            data = "";
                            nowDataLength = 0;
                        }
                        while (nowDataLength < dataLength)
                        {
                            bytes = ((Socket)socket).Receive(receiveBuffer, SocketFlags.None);
                            // 是本包数据
                            if (nowDataLength + bytes <= dataLength)
                            {
                                data += Encoding.UTF8.GetString(receiveBuffer, 0, bytes);
                                nowDataLength += bytes;
                            }
                            else
                            {
                                data += Encoding.UTF8.GetString(receiveBuffer, 0, dataLength - nowDataLength);
                                nowDataLength = dataLength;
                                // 还原缓冲区 看测试情况做
                            }
                        }

                        // 广播的消息 客户端无需再处理
                        string message = messageHead + data + "\r\n";

                        // 消息广播线程
                        ParameterizedThreadStart messageBroadcastThreadStart = MessageBroadcastThreadStart;
                        new Thread(messageBroadcastThreadStart).Start(message);

                        // 回调 消息上交服务器主机的前端
                        this.ServerMessageSyncCallback(message);
                    }
                    // 是文件
                    else if (dataHead[DATA_HEAD - 1] == '1')
                    {

                    }
                }
            }
            catch
            {

            }
        }

        // 消息广播线程
        public void MessageBroadcastThreadStart(object sourceData)
        {
            // 编码
            string data = (string)sourceData;
            int dataLength = data.Length;
            string dataLengthString = dataLength.ToString();
            int needZero = DATA_HEAD - dataLengthString.Length - 1;
            string zero = "";
            while (needZero > 0)
            {
                zero += "0";
                needZero--;
            }
            data = zero + dataLength.ToString() + "0" + data;

            // 广播
            foreach (var keyValuePair in this.AllServerDestinationSocket)
            {
                try
                {
                    keyValuePair.Value.Send(Encoding.UTF8.GetBytes(data));
                }
                catch
                {
                    // 善后工作 此处应有锁
                }
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
