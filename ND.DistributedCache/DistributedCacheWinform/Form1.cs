using ND.DistributedCache.Core;
using ND.DistributedCache.Core.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributedCacheWinform
{
    public partial class Form1 : Form
    {
        Action<string> showMsg = null;
        event EventHandler<string> onListBoxItemAdded;
        public Form1()
        {
            
            InitializeComponent();
           bool r= CacheManger.Instance.BulkDeleteValue(CacheExpire.Expired);
            this.cbCacheLimit.SelectedIndex = 2;
            this.cbDateType.SelectedIndex = 0;
            this.cbExpire.SelectedIndex = 0;

            showMsg = new Action<string>((args) => {
                if (this.lstLog.Items.Count > 30) this.lstLog.Items.RemoveAt(0);
               this.lstLog.Items.Add(DateTime.Now+":"+args);
            });
            this.onListBoxItemAdded += (obj, arg) =>
            {
                try
                {
                    string path = System.IO.Directory.GetCurrentDirectory();
                    DateTime CurrTime = DateTime.Now;
                    string strPath = path + "\\HandDataLog\\" + CurrTime.Year + "-" + CurrTime.Month + "\\" + CurrTime.Day + ".txt";
                    AddLog(strPath, DateTime.Now+":"+arg);
                }
                catch { }
            };
            CacheManger.onOperating += CacheManger_onOperating;
        }

        void CacheManger_onOperating(object sender, string e)
        {
            showMsg(e);
            onListBoxItemAdded(sender, e);
        }
        

        #region 写入cache
        private void button1_Click(object sender, EventArgs e)
        {
            string key = this.txtKey.Text;
            string value = this.txtVal.Text;
           Cachelimit limit= (Cachelimit)this.cbCacheLimit.SelectedIndex;
           DateTime? expireDate=null ;
            if(limit == Cachelimit.ByExpireDate)
            {
                expireDate = this.dmpExpireDate.Value;
            }
            bool r = CacheManger.Instance.SetValue(key, value,limit,expireDate);
            this.button4.PerformClick();
            if(r)
            {
               
                MessageBox.Show("写入成功");
                return;
            }
            MessageBox.Show("写入失败");
        } 
        #endregion

        #region 读取cache
        private void button2_Click(object sender, EventArgs e)
        {
            string key = this.txtKey.Text;
           object value= CacheManger.Instance.GetValue(key);
           this.txtVal.Text = JsonConvert.SerializeObject(value);
        } 
        #endregion

        #region 读取缓存列表
        private void button4_Click(object sender, EventArgs e)
        {
          var lst= CacheManger.Instance.GetList(CacheExpire.All);
           this.dataGridView1.DataSource = lst;
        } 
        #endregion

        #region 批量删除
        private void button3_Click(object sender, EventArgs e)
        {
            
         bool r= CacheManger.Instance.BulkDeleteValue((CacheExpire)this.cbExpire.SelectedIndex,(DateType)this.cbDateType.SelectedIndex,Convert.ToDateTime(this.dtStart.Value.ToString("yyyy-MM-dd")+" 0:00:00"),Convert.ToDateTime(this.dtEnd.Value.ToString("yyyy-MM-dd")+" 23:59:59"));
         this.button4.PerformClick();
            if(r)
            {
                MessageBox.Show("批量删除成功");
                return;
            }
            MessageBox.Show("批量删除失败");
        } 
        #endregion

        #region 只按过期条件删除
        private void button5_Click(object sender, EventArgs e)
        {
            bool r = CacheManger.Instance.BulkDeleteValue((CacheExpire)this.cbExpire.SelectedIndex);
            this.button4.PerformClick();
            if (r)
            {
                MessageBox.Show("只按过期条件批量删除成功");
                return;
            }
            MessageBox.Show("只按过期条件批量删除失败");
        } 
        #endregion

        #region 删除指定的key值
        private void button6_Click(object sender, EventArgs e)
        {
             bool r = CacheManger.Instance.DeleteValue(this.txtDelKey.Text);
            this.button4.PerformClick();
            if (r)
            {
                MessageBox.Show("删除key值成功");
                return;
            }
            MessageBox.Show("删除key值失败");
        } 
        #endregion

        private void AddLog(string strPath, string txt)
        {
            string strDirecory = strPath.Substring(0, strPath.LastIndexOf('\\'));
            if (!Directory.Exists(strDirecory))
            {
                Directory.CreateDirectory(strDirecory);
            }
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }

            var fs = File.AppendText(strPath);
            fs.WriteLine(txt);
            fs.Flush();
            fs.Close();
            fs.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cachelimit limit = (Cachelimit)this.cbCacheLimit.SelectedIndex;
            
            if (limit == Cachelimit.ByExpireDate)
            {
                this.dmpExpireDate.Visible=true;
                this.label10.Visible = true;
            }else
            {
                this.dmpExpireDate.Visible = false;
                this.label10.Visible = false;
            }
        }

        #region 按缓存限制删除
        private void button7_Click(object sender, EventArgs e)
        {
            CacheManger.Instance.BulkDeleteValue(CacheExpire.All, DateType.CreateTime, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 0:00:00"), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59"));
            this.button4.PerformClick();
            MessageBox.Show("操作完成");
          
        } 
        #endregion

        private void button8_Click(object sender, EventArgs e)
        {
            CacheManger.Instance.BulkDeleteValue(CacheExpire.All, DateType.ExpireTime, Convert.ToDateTime("2099-12-30 0:00:00"), Convert.ToDateTime("2099-12-30 23:59:59"));
            this.button4.PerformClick();
            MessageBox.Show("操作完成");
           
        }
    }
}
