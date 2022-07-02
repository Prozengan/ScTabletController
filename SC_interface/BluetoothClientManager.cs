using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace ScTabletController
{
    public class BluetoothClientManager
	{
		private BluetoothClient client = new BluetoothClient();

		private Guid mUUID = new Guid("8032b5d0-987d-45e9-aab1-aa033d3cc1ce");

		private List<string> items = new List<string>();

		private IReadOnlyCollection<BluetoothDeviceInfo> devices;

		private BluetoothDeviceInfo deviceInfo;

		private byte[] syncMsg;

		private Stream stream;

		private bool ready = false;

		private string myPin = "1234";

		public event EventHandler IsConnected;

		public string ServerName { get; set; }

		public BluetoothClientManager(string serverName)
		{
			this.ServerName = serverName;
		}

		public bool Start()
		{
			Tools.writeInLogFile("> Start");
			try
			{
				Thread thread = new Thread(delegate ()
				{
					this.startBluetooth();
				});
				thread.Start();
			}
			catch (Exception ex)
			{
				Tools.writeInLogFile(ex.Message);
				return false;
			}
			return true;
		}

		public void Disconnect()
		{
			this.SyncMessage("Disconnect");
			this.client.Dispose();
		}

		public void SyncMessage(string message)
		{
			Tools.writeInLogFile("> SyncMessage");
			bool flag = this.ready;
			if (flag)
			{
				Encoding utf = Encoding.UTF8;
				this.syncMsg = utf.GetBytes(message);
				try
				{
					this.stream.Write(this.syncMsg, 0, this.syncMsg.Length);
				}
				catch
				{
				}
			}
		}

		private void startBluetooth()
		{
			Tools.writeInLogFile("> startBluetooth");
			try
			{
				int tentative = 0;
				var pairedDevices = this.client.PairedDevices;
				// On cherche d'abord dans les devices apparairés
				Tools.writeInLogFile("> Search for device in already paired ones");
				foreach (BluetoothDeviceInfo bluetoothDeviceInfo in this.client.PairedDevices)
                {
					if (bluetoothDeviceInfo.DeviceName == this.ServerName)
					{
						this.deviceInfo = bluetoothDeviceInfo;
					}
				}
				// Si non trouvé, on étend la recherche
				if (null == this.deviceInfo)
				{
					Tools.writeInLogFile("> Not found in paired devices.");
					do
					{
						Tools.writeInLogFile("> Search for device : Tentative " + tentative);
						this.devices = this.client.DiscoverDevices();
						foreach (BluetoothDeviceInfo bluetoothDeviceInfo in this.devices)
						{
							if (bluetoothDeviceInfo.DeviceName == this.ServerName)
							{
								this.deviceInfo = bluetoothDeviceInfo;
							}
						}
						tentative++;
					} while (null == this.deviceInfo && tentative < 3);
				}
				// Si toujours pas trouvé on cut
				if (null == this.deviceInfo)
				{
					Tools.writeInLogFile("> Device not found");
					throw new Exception("Device not found");
                }
				this.startBTConnect();
			}
			catch
			{
			}
		}
		private void startBTConnect()
		{
			Tools.writeInLogFile("> startBTConnect");
			bool flag = this.checkDevicePaired();
			if (flag)
			{
				try
				{
					Thread thread = new Thread(delegate ()
					{
						this.connectServer();
					});
					thread.Start();
				}
				catch
				{
				}
			}
		}

		private bool checkDevicePaired()
		{
			Tools.writeInLogFile("> checkDevicePaired");
			bool flag = !this.deviceInfo.Authenticated;
			if (flag)
			{
				bool flag2 = !BluetoothSecurity.PairRequest(this.deviceInfo.DeviceAddress, this.myPin);
				if (flag2)
				{
					return false;
				}
			}
			return true;
		}

		private void connectServer()
		{
			Tools.writeInLogFile("> connectServer");
			this.client.BeginConnect(this.deviceInfo.DeviceAddress, this.mUUID, new AsyncCallback(this.BluetoothClientConnectCallback), this.client);
		}

		private void BluetoothClientConnectCallback(IAsyncResult result)
		{
			Tools.writeInLogFile("> BluetoothClientConnectCallback");
			BluetoothClient bluetoothClient = (BluetoothClient)result.AsyncState;
			bluetoothClient.EndConnect(result);
			this.stream = bluetoothClient.GetStream();
			this.stream.ReadTimeout = 1000;
			this.ready = true;
			bool flag = this.IsConnected != null;
			if (flag)
			{
				this.IsConnected(this, EventArgs.Empty);
			}
		}
	}
}
