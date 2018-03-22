using System;
using System.Web;
using System.IO;
using System.Net;
using System.Xml;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;

namespace Sau.Util
{
  
	/// <summary>
	/// updater ��ժҪ˵����
	/// </summary>
	public class AppUpdater:IDisposable
	{
		#region ��Ա���ֶ�����
		private string _updaterUrl;
		private bool disposed = false;
		private IntPtr handle;
		private Component component = new Component();
		[System.Runtime.InteropServices.DllImport("Kernel32")]
		private extern static Boolean CloseHandle(IntPtr handle);


		public string UpdaterUrl
		{
			set{_updaterUrl = value;}
			get{return this._updaterUrl;}
		}
		#endregion

		/// <summary>
		/// AppUpdater���캯��
		/// </summary>
		public AppUpdater()
		{
			//this.handle = handle;
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		private void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				if(disposing)
				{
				
					component.Dispose();
				}
				CloseHandle(handle);
				handle = IntPtr.Zero;            
			}
			disposed = true;         
		}

		~AppUpdater()      
		{
			Dispose(false);
		}


		/// <summary>
		/// �������ļ�
		/// </summary>
		/// <param name="serverXmlFile"></param>
		/// <param name="localXmlFile"></param>
		/// <param name="updateFileList"></param>
		/// <returns></returns>
		public int CheckForUpdate(string serverXmlFile,string localXmlFile,out Hashtable updateFileList)
		{
			updateFileList = new Hashtable();
			if(!File.Exists(localXmlFile) || !File.Exists(serverXmlFile))
			{
				return -1;
			}
			
			XmlFiles serverXmlFiles = new XmlFiles(serverXmlFile);
			XmlFiles localXmlFiles = new XmlFiles(localXmlFile);
			
			XmlNodeList newNodeList = serverXmlFiles.GetNodeList("AutoUpdater/Files");
			XmlNodeList oldNodeList = localXmlFiles.GetNodeList("AutoUpdater/Files");

			int k = 0;
			for(int i = 0;i < newNodeList.Count;i++)
			{
				string [] fileList = new string[3];

				string newFileName = newNodeList.Item(i).Attributes["Name"].Value.Trim();
				string newVer = newNodeList.Item(i).Attributes["Ver"].Value.Trim();
				
				ArrayList oldFileAl = new ArrayList();
				for(int j = 0;j < oldNodeList.Count;j++)
				{
					string oldFileName = oldNodeList.Item(j).Attributes["Name"].Value.Trim();
					string oldVer = oldNodeList.Item(j).Attributes["Ver"].Value.Trim();
					
					oldFileAl.Add(oldFileName);
					oldFileAl.Add(oldVer);

				}
				int pos = oldFileAl.IndexOf(newFileName);
				if(pos == -1)
				{
					fileList[0] = newFileName;
					fileList[1] = newVer;
					updateFileList.Add(k,fileList);
					k++;
				}
				else if(pos > -1 && newVer.CompareTo(oldFileAl[pos+1].ToString())>0 )
				{
					fileList[0] = newFileName;
					fileList[1] = newVer;
					updateFileList.Add(k,fileList);
					k++;
				}
				
			}
			return k;
		}
	
		/// <summary>
		/// �������ļ�
		/// </summary>
		/// <param name="serverXmlFile"></param>
		/// <param name="localXmlFile"></param>
		/// <param name="updateFileList"></param>
		/// <returns></returns>
		public int CheckForUpdate()
		{
			string localXmlFile = Application.StartupPath + "\\UpdateList.xml";
			if(!File.Exists(localXmlFile))
			{
                //�����ļ�������
				return -1;
			}

			XmlFiles updaterXmlFiles = new XmlFiles(localXmlFile );


			string tempUpdatePath = Environment.GetEnvironmentVariable("Temp") + "\\"+ "_"+ updaterXmlFiles.FindNode("//Application").Attributes["applicationId"].Value+"_"+"y"+"_"+"x"+"_"+"m"+"_"+"\\";
			this.UpdaterUrl = updaterXmlFiles.GetNodeValue("//Url") + "/UpdateList.xml";
			this.DownAutoUpdateFile(tempUpdatePath);

			string serverXmlFile = tempUpdatePath  +"\\UpdateList.xml";
			if(!File.Exists(serverXmlFile))
			{
                //�����������ʧ��,������ʱ!
				return -2;
			}
			
			XmlFiles serverXmlFiles = new XmlFiles(serverXmlFile);
			XmlFiles localXmlFiles = new XmlFiles(localXmlFile);
			
			XmlNodeList newNodeList = serverXmlFiles.GetNodeList("AutoUpdater/Files");
			XmlNodeList oldNodeList = localXmlFiles.GetNodeList("AutoUpdater/Files");

			int k = 0;
			for(int i = 0;i < newNodeList.Count;i++)
			{
				string [] fileList = new string[3];

				string newFileName = newNodeList.Item(i).Attributes["Name"].Value.Trim();
				string newVer = newNodeList.Item(i).Attributes["Ver"].Value.Trim();
				
				ArrayList oldFileAl = new ArrayList();
				for(int j = 0;j < oldNodeList.Count;j++)
				{
					string oldFileName = oldNodeList.Item(j).Attributes["Name"].Value.Trim();
					string oldVer = oldNodeList.Item(j).Attributes["Ver"].Value.Trim();
					
					oldFileAl.Add(oldFileName);
					oldFileAl.Add(oldVer);

				}
				int pos = oldFileAl.IndexOf(newFileName);
				if(pos == -1)
				{
					fileList[0] = newFileName;
					fileList[1] = newVer;
					k++;
				}
				else if(pos > -1 && newVer.CompareTo(oldFileAl[pos+1].ToString())>0 )
				{
					fileList[0] = newFileName;
					fileList[1] = newVer;
					k++;
				}
				
			}
			return k;
		}
		/// <summary>
		/// �������ظ����ļ�����ʱĿ¼
		/// </summary>
		/// <returns></returns>
		public void DownAutoUpdateFile(string downpath)
		{
			if(!System.IO.Directory.Exists(downpath))
				System.IO.Directory.CreateDirectory(downpath);
			string serverXmlFile = downpath+@"/UpdateList.xml";

			try
			{
				WebRequest req = WebRequest.Create(this.UpdaterUrl);
				WebResponse res = req.GetResponse();
				if(res.ContentLength >0)
				{
					try
					{
						WebClient wClient = new WebClient();
						wClient.DownloadFile(this.UpdaterUrl,serverXmlFile);
					}
					catch
					{
						return;
					}
				}
			}
			catch
			{
				return;
			}
			//return tempPath;
		}

        //�����Զ����³���
        public void StartUpdateProcess()
        {
            string updateExePath = AppDomain.CurrentDomain.BaseDirectory + "AutoUpdate.exe";
            System.Diagnostics.Process myProcess = System.Diagnostics.Process.Start(updateExePath);     

        }

        public static bool AutoUpdate()
        {
            AppUpdater appUpdater = new AppUpdater();
            int cnt = appUpdater.CheckForUpdate();
            if (cnt > 0)
            {
                appUpdater.StartUpdateProcess();
                return true;
            }

            return false;
        }
	}

    /// <summary>
    /// XmlFiles ��ժҪ˵����
    /// </summary>
    public class XmlFiles : XmlDocument
    {
        #region �ֶ�������
        private string _xmlFileName;
        public string XmlFileName
        {
            set { _xmlFileName = value; }
            get { return _xmlFileName; }
        }
        #endregion

        public XmlFiles(string xmlFile)
        {
            XmlFileName = xmlFile;

            this.Load(xmlFile);
        }
        /// <summary>
        /// ����һ���ڵ��xPath���ʽ������һ���ڵ�
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public XmlNode FindNode(string xPath)
        {
            XmlNode xmlNode = this.SelectSingleNode(xPath);
            return xmlNode;
        }
        /// <summary>
        /// ����һ���ڵ��xPath���ʽ������ֵ
        /// </summary>
        /// <param name="xPath"></param>
        /// <returns></returns>
        public string GetNodeValue(string xPath)
        {
            XmlNode xmlNode = this.SelectSingleNode(xPath);
            return xmlNode.InnerText;
        }
        /// <summary>
        /// ����һ���ڵ�ı��ʽ���ش˽ڵ��µĺ��ӽڵ��б�
        /// </summary>
        /// <param name="xPath"></param>
        /// <returns></returns>
        public XmlNodeList GetNodeList(string xPath)
        {
            XmlNodeList nodeList = this.SelectSingleNode(xPath).ChildNodes;
            return nodeList;

        }

    }
}
