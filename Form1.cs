using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDJS_Vision.Forms.ShapeDraw;
using static Test_软包电池定位极耳中心.MatchTemplate;

namespace Test_软包电池定位极耳中心
{
    public partial class Form1 : Form
    {
        Bitmap curSrcImage = null;
        Bitmap curModelImage = null;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 选择图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "图片文件 (*.BMP, *.JPG, *.JPEG, *.PNG)|*.BMP;*.JPG;*.JPEG;*.PNG|所有文件 (*.*)|*.*";
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "请选择图片";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(openFileDialog1.FileName))
                {
                    MessageBox.Show("文件路径不能为空");
                    return;
                }
                curSrcImage = new Bitmap(openFileDialog1.FileName);
                imageROIEditControl1.SetROIType2Draw(ROIType.Rectangle);
                imageROIEditControl1.SetImage(curSrcImage);
            }
        }
        /// <summary>
        /// 保存模版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "图片文件 (*.BMP, *.JPG, *.JPEG, *.PNG)|*.BMP;*.JPG;*.JPEG;*.PNG|所有文件 (*.*)|*.*";
            saveFileDialog1.Title = "请选择保存路径";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(saveFileDialog1.FileName))
                {
                    MessageBox.Show("文件路径不能为空");
                    return;
                }
                imageROIEditControl1.GetROIImages().Save(saveFileDialog1.FileName);
            }
        }
        /// <summary>
        /// 选择使用的模版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "图片文件 (*.BMP, *.JPG, *.JPEG, *.PNG)|*.BMP;*.JPG;*.JPEG;*.PNG|所有文件 (*.*)|*.*";
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "请选择图片";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(openFileDialog1.FileName))
                {
                    MessageBox.Show("文件路径不能为空");
                    return;
                }
                curModelImage = new Bitmap(openFileDialog1.FileName);
            }
        }
        /// <summary>
        /// 清除ROI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            imageROIEditControl1.ClearROI();
        }
        /// <summary>
        /// 执行模版匹配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                long timeTotal = 0;
                // ±5°角度范围内，步长0.5°的模版匹配
                var res = MatchTemplate.Match(curSrcImage, curModelImage, 8.0f, 0.5f, -8.0, 8.0, 0.2);
                //绘制结果
                var image = MatchTemplate.DrawResult(res, 4f, 8);
                imageROIEditControl1.SetImage(image);
                labelTime.Text = res.TimeCost.ToString();
                labelRes.Text = res.Rect.Angle.ToString();
                buttonIsOK.Text = res.IsOk ? "OK" : "NG";
                buttonIsOK.BackColor = res.IsOk ? Color.Green : Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
