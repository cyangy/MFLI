//#define DEBUG_NetworkInterfaceAdapter
using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Forms;
using zhinst;


class myMFLI
{
    public String dev; //设备名
    public String SignalInputManualRangePath;
    public String SignalInputAutoRangePath;
    public String SignalInputScalingPath;
    public String SignalInputACCouplingPath;
    public String SignalInputSwitchBetween50And10MegaOhmPath;
    public String SignalInputFloatPath;
    public String SignalOutputSwitchOnPath;
    public String SignalOutputImpendence50Path;
    public String SignalOutputManualRangePath;
    public String SignalOutputAutoRangePath;
    public String SignalOutputOffsetPath;
    public String SignalOutputAmplitudesEnablePath;
    public String SignalOutputAmplitudesValuePath;
    public String SignalOscillatorsPath;
    public String DemodsEnablepath;
    public String DemodsRatepath;
    public String DemodSamplePath;
    public String OptionsPath;
    public myMFLI() //构造函数
    {
      dev = "dev3070";
        //输入的设置路径
        SignalInputManualRangePath = String.Format("/{0}/sigins/0/range", dev); //手动档  double number
        SignalInputAutoRangePath = String.Format("/{0}/sigins/0/autorange", dev); //自动档  1 0
        SignalInputScalingPath = String.Format("/{0}/sigins/0/scaling", dev); //缩放因子  double
        SignalInputACCouplingPath = String.Format("/{0}/sigins/0/ac", dev);  //是否交流耦合 1 是  0  否
        SignalInputSwitchBetween50And10MegaOhmPath = String.Format("/{0}/sigins/0/imp50", dev); // 1  50ohm  0 10mega ohm
        SignalInputFloatPath = String.Format("/{0}/sigins/0/float", dev);//悬浮地   1  float   0  ground
    //输出设置路径                                                                               //
     SignalOutputSwitchOnPath = String.Format("/{0}/sigouts/0/on", dev); //开启输出 灯亮，但不一定有信号输出  sigouts/0/enables/1 项和该项同时开启时才会有输出       1 0
     SignalOutputImpendence50Path = String.Format("/{0}/sigouts/0/imp50", dev);//50 ohm   1 0
     SignalOutputManualRangePath = String.Format("/{0}/sigouts/0/range", dev); //手动档  double number
     SignalOutputAutoRangePath = String.Format("/{0}/sigouts/0/autorange", dev); //自动档  1 0
     SignalOutputOffsetPath = String.Format("/{0}/sigouts/0/offset", dev); //直流偏置  double number
     SignalOutputAmplitudesEnablePath = String.Format("/{0}/sigouts/0/enables/1", dev); // //信号输出开启          /sigouts/0/on 和该项同时开启时才会有输出
     SignalOutputAmplitudesValuePath = String.Format("/{0}/sigouts/0/amplitudes/1", dev); //  信号幅度 有Vpp Vrms dB 三选项 其实均是三者之间相互转换 例如 Vpp 选择7.07m 时，切换到Vrms会自动转换成0.5m 即所有输入均为峰峰值
    //频率设置
    SignalOscillatorsPath = String.Format("/{0}/oscs/0/freq", dev); //默认 100kHz
    //数据传输
    DemodsEnablepath = String.Format("/{0}/demods/0/enable", dev);
    //数据传输速率
    DemodsRatepath = String.Format("/{0}/demods/0/rate", dev);
    //数据采样路径
    DemodSamplePath = String.Format("/{0}/demods/0/sample", dev);
    //配置信息
     OptionsPath= String.Format("/{0}/features/options", dev);
    }

    // The resetDeviceToDefault will reset the device settings
    // to factory default. The call is quite expensive
    // in runtime. Never use it inside loops!
    public bool  resetDeviceToDefault(ziDotNET daq)
    {
            daq.setInt(String.Format("/{0}/system/preset/index", dev), 0);
            daq.setInt(String.Format("/{0}/system/preset/load", dev), 1);
            while (daq.getInt(String.Format("/{0}/system/preset/busy", dev)) != 0)
            {
                System.Threading.Thread.Sleep(100);
            }
            System.Threading.Thread.Sleep(1000);
        return true;
    }
    //检查serverapi版本
    public void apiServerVersionCheck(ziDotNET daq)
    {
        String serverVersion = daq.getByte("/zi/about/version");
        String apiVersion = daq.version();

        //Assert.AreEqual(serverVersion, apiVersion,
         // "Version mismatch between LabOne API and Data Server.");
        //Console.WriteLine("Current   Firmware   Version  is:    " + apiVersion);
    }
    //设备初始化连接
    public ziDotNET connect(ziDotNET daq, String dev)
    {
        String id = daq.discoveryFind(dev);
        String iface = daq.discoveryGetValueS(dev, "connected");
        if (string.IsNullOrWhiteSpace(iface))
        {
            // Device is not connected to the server
            String ifacesList = daq.discoveryGetValueS(dev, "interfaces");
            // Select the first available interface and use it to connect
            string[] ifaces = ifacesList.Split('\n');
            if (ifaces.Length > 0)
            {
                iface = ifaces[0];
            }
        }
        String host = daq.discoveryGetValueS(dev, "serveraddress");
        long port = daq.discoveryGetValueI(dev, "serverport");
        long api = daq.discoveryGetValueI(dev, "apilevel");
        //该函数会自动抛出异常
        daq.init(host, Convert.ToUInt16(port), (ZIAPIVersion_enum)api);
        // Ensure that LabOne API and LabOne Data Server are from
        // the same release version.
        apiServerVersionCheck(daq);
        // If device is not yet connected a reconnect
        // will not harm.
        daq.connectDevice(dev, iface, "");


        return daq;
    }

    public  bool isNetWorkDeviceContainStringExsit(String MFLINetworkadapterDescriptionNameContainString= "Zurich Instruments MF Instrument RNDIS interface")
    {
        //通过查看是否存在 Zurich Instruments  RNDIS 网卡判断是否存在 MFLI 设备 
        NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();

        foreach (NetworkInterface adapter in adapters)
        {
            String adapterDescriptionName = adapter.Description;//所有网络设备在设备管理器中的名字
#if DEBUG_NetworkInterfaceAdapter
            MessageBox.Show(adapterDescriptionName,
                                       "发现网卡",
                                        MessageBoxButtons.OK,
                                       //MessageBoxIcon.Warning // for Warning  
                                       //MessageBoxIcon.Error // for Error 
                                       MessageBoxIcon.Information  // for Information
                                                            //MessageBoxIcon.Question // for Question
                                       );
#endif
            if (adapterDescriptionName.Contains(MFLINetworkadapterDescriptionNameContainString))
            {
                //System.Windows.Forms.MessageBox.Show(adapterDescriptionName, "存在指定网卡");
#if DEBUG_NetworkInterfaceAdapter
                MessageBox.Show(adapterDescriptionName,
                                           "找到需要的网卡",
                                            MessageBoxButtons.OK,
                                           //MessageBoxIcon.Warning // for Warning  
                                           //MessageBoxIcon.Error // for Error 
                                           MessageBoxIcon.Information  // for Information
                                                                       //MessageBoxIcon.Question // for Question
                                           );
#endif
                return true;//如果存在此处即会返回
            }


        }
        return false;//如果运行到此处说明不存在
    }

    //初始化连接和设置
    public String InitTheDevice(ziDotNET daq,String dev)
    {
        if (isNetWorkDeviceContainStringExsit())
        {
            //通过查看是否存在 Zurich Instruments  RNDIS 网卡判断是否存在 MFLI 设备 
            daq = connect(daq, dev);//初始化
            //SetSignalOutputSetting(daq, dev);//设置输出信号
            //SetSignalInputSetting(daq, dev);//设置信号输入各参数
            //SetSignalOscillators(daq, dev);//设置频率
                                                     //返回当前版本表示连接成功
            return daq.version();
        }
        return null;//返回null表示设备不存在
    }
    //开启数据传输 设置传输速率
    public bool  setMFLIenableAndrate(ziDotNET daq, String dev)
    {
        //开始采集前必须确保数据传输开启
        daq.syncSetInt(DemodsEnablepath, 1);
        //数据传输速率
        daq.syncSetInt(DemodsEnablepath, 857100); // 最大857100

        return true;
    }
    //获取采样数据
    public ZIDemodSample GetDemodSample(ziDotNET daq, String dev)
    {   
        ZIDemodSample sample = daq.getDemodSample(DemodSamplePath);
        return sample;
    }

    //设置输入
    public bool SetSignalOutputSetting(ziDotNET daq, String dev, long isSignalOutputSwitchOn = 1, long isSignalOutputImpendence50 = 1, double SignalOutputManualRangeValue = 0.500000, long isSignalOutputAutoRange = 0, double SignalOutputOffsetValue = 0, long isSignalOutputAmplitudesEnable = 1, double SignalOutputAmplitudesValue = 0.212132034)
    {
        //开始设置输出参数
        try
        {
            daq.syncSetInt(SignalOutputSwitchOnPath, isSignalOutputSwitchOn); //默认 开启 1
            daq.syncSetInt(SignalOutputImpendence50Path, isSignalOutputImpendence50); //默认开启 1
            if ((int)isSignalOutputAutoRange !=0 ) //如果自动量程开启则不用设置手动量程
            {
                daq.syncSetDouble(SignalOutputManualRangePath, SignalOutputManualRangeValue); // 量程 默认500mV （0.500000）
            }
                daq.syncSetInt(SignalOutputAutoRangePath, isSignalOutputAutoRange); //默认关闭 0
            daq.syncSetDouble(SignalOutputOffsetPath, SignalOutputOffsetValue);//默认 0
            daq.syncSetInt(SignalOutputAmplitudesEnablePath, isSignalOutputAmplitudesEnable);//默认开启
            daq.syncSetDouble(SignalOutputAmplitudesValuePath, SignalOutputAmplitudesValue);//默认150mV Vrms 0.212132034
        }
        catch (ZIException e)
        {
            System.Diagnostics.Trace.WriteLine(e.ToString(), "Warning");
        }
        return true;//设置成功标志
    }
    //设置输出
    public bool SetSignalInputSetting(ziDotNET daq, String dev, double SignalInputManualRangeValue = 0.30000, long isSignalInputAutoRange = 0, double SignalInputScalingValue = 1.000, long isSignalInputACCoupling = 1, long isSignalInput50Ohm = 1, long isSignalInputFloatGround = 1)
    {
        //开始设置输入参数
        try
        {
            if ( (int)isSignalInputAutoRange != 0)  //如果自动量程开启则不用设置手动量程
            {
                daq.syncSetDouble(SignalInputManualRangePath, SignalInputManualRangeValue); //默认300mV ,若设置的量程低于实际输入值，系统会自动选择一个合适的量程
            }
            daq.syncSetInt(SignalInputAutoRangePath, isSignalInputAutoRange);//默认关闭
            daq.syncSetDouble(SignalInputScalingPath, SignalInputScalingValue); //缩放因子，默认不缩放 1.000
            daq.syncSetInt(SignalInputACCouplingPath, isSignalInputACCoupling);//默认 使用AC耦合
            daq.syncSetInt(SignalInputSwitchBetween50And10MegaOhmPath, isSignalInput50Ohm);//默认使用50欧姆
            daq.syncSetInt(SignalInputFloatPath, isSignalInputFloatGround);//默认悬浮地
        }
        catch (ZIException e)
        {
            System.Diagnostics.Trace.WriteLine(e.ToString(), "Warning");
        }
        return true;//设置成功标志
    }
    //内部晶振频率设置 
    public bool SetSignalOscillators(ziDotNET daq, String dev, double theOscillatorsFrequency = 100000.000)
    {
        //开始设置参数
        try
        {
            daq.syncSetDouble(SignalOscillatorsPath, theOscillatorsFrequency); ////默认 100kHz
        }
        catch (ZIException e)
        {
            System.Diagnostics.Trace.WriteLine(e.ToString(), "Warning");
        }
        return true;//设置成功标志
    }
}
