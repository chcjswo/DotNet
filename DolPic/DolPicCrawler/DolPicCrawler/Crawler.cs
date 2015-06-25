using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;

namespace DolPicCrawler
{
    public partial class Crawler : Form
    {
        private const string TW_IMAGE_URL = "http://twitter.com/hashtag/{0}";
        //private const string IMAGE_SEND_URL = "http://localhost:3281/Pics/DolPicImageSave/{0}/{1}/{2}/{3}";
        private const string IMAGE_SEND_URL = "http://www.dolpic.kr/Pics/DolPicImageSave/{0}/{1}/{2}/{3}";
        
        private int CHECK_TIME = 0;
        private StringBuilder _sbErr;
        private ErrFrm errfrm;
        private List<string[]> _arrTxt;
        private int _curNo = 0;
        private string _curTag = "";

        private List<int> _arrNo;
        private List<string> _arrTag;
        private Dictionary<int, List<string>> _dImage;


        private const string MATCH_TAG = "data-resolved-url-small=\"(?<ImageSrc>.*?)\".*?";
        //private const string MATCH_TAG = "<img src=\"(?<ImageSrc>.*?)\".*?>";
        //private const string MATCH_TAG = "<span class=\"(?<cl>.*?)\".*? data-status-id=\"(?<sid>.*?)\".*? data-url=\"(?<url1>.*?)\".*? data-resolved-url-small=\"(?<url>.*?)\".*? data-resolved-url-large=\"(?<url333>.*?)\".*? data-width=\"(?<url22>.*?)\".*? data-height=\"(?<url11>.*?)\".*?></span>";
        private const string XML_URL = "http://www.dolpic.kr/twitter_image.xml";

        private double dDay, dMod, dHour, dMin, dSec;

        public Crawler()
        {
            InitializeComponent();
            FormInit();
            btnImageLoad.Enabled = false;

            //this.WindowState = FormWindowState.Minimized;
            //this.ShowInTaskbar = false;
            //this.Visible = false;
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            txtLog.Text = version.ToString();

            this.notifyIcon1.Visible = true;
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;

        }

        #region Init
        /// <summary>
        /// Grid 초기화
        /// </summary>
        private void GridInit()
        {
            dataGridView1.Rows.Clear();

            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "번호";
            dataGridView1.Columns[1].Name = "이미지경로";
            dataGridView1.Columns[2].Name = "해쉬태그";

            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 400;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].ValueType = TypeCode.Int32.GetType();
        }

        /// <summary>
        /// Form 초기화
        /// </summary>
        private void FormInit()
        {
            lblChkTime.Text = "";
            _sbErr = new StringBuilder();
            _arrTxt = new List<string[]>();
            errfrm = new ErrFrm();
            _dImage = new Dictionary<int, List<string>>();
            comSite.SelectedIndex = 0;

            //btnImageLoad.Enabled = false;

            if (timer2.Enabled)
                btnImageLoad.Enabled = false;
            else
                btnImageLoad.Enabled = true;

            GridInit();
        }

        /// <summary>
        /// 서버로 부터 XML 정보 읽어 오기
        /// </summary>
        private void XmlInfoInit()
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(XML_URL);
                XmlNodeList xnList = xml.SelectNodes("/twitter/images"); //접근할 노드

                _arrNo = new List<int>(xnList.Count);
                _arrTag = new List<string>(xnList.Count);

                foreach (XmlNode xn in xnList)
                {
                    _arrNo.Add(int.Parse(xn.Attributes["no"].Value));
                    _arrTag.Add(xn.Attributes["tag"].Value);
                }

                txtLog.Text = "XML 로딩 완료" + Environment.NewLine;
            }
            catch (ArgumentException ex)
            {
                txtLog.Text = "XML 문제 발생\r\n" + ex.ToString();
            }
        }
        #endregion

        /// <summary>
        /// 이미지 정보 가져오기
        /// </summary>
        private void ImageGet()
        {
            // 일단 XML 로딩
            XmlInfoInit();

            //응답요청을 한다
            WebRequest request = null;
            WebResponse response = null;

            //스트림으로 받아온다
            Stream resStream = null;
            StreamReader resReader = null;

            var nLoopCnt = 0;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // 해쉬 태그대로 검색
            foreach (var tag in _arrTag)
            {
                _curNo = _arrNo[nLoopCnt++];
                _curTag = tag;

                try
                {
                    //URI로부터 요청을 생성한다
                    request = WebRequest.Create(string.Format(TW_IMAGE_URL, tag));

                    //요청을 보내고 응답을 받는다
                    response = request.GetResponse();

                    //응답을 스트림으로 얻어온다
                    resStream = response.GetResponseStream();

                    var resString = "";
                    using (resReader = new StreamReader(resStream, System.Text.Encoding.Default))
                    {
                        resString = resReader.ReadToEnd();
                    }

                    // 결과물에서 이미지 URL 추출
                    ImageSearch(resString, _curNo);
                }
                catch (Exception ex)
                {
                    errfrm.Show();
                    errfrm.textBox1.Text = ex.ToString();

                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (resReader != null) resReader.Close();
                    if (response != null) response.Close();
                }
            }

            // 이미지 저장
            ImageSend();

            sw.Stop();
            lblWatch.Text = (sw.ElapsedMilliseconds / 1000.0F).ToString() + " 초 로딩";
        }

        /// <summary>
        /// 이미지 찾기
        /// </summary>
        /// <param name="resString">결과 스트링</param>
        private void ImageSearch(string resString, int a_nTagNo)
        {
            // 이미지 찾기
            Regex re = new Regex(MATCH_TAG, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            List<string> ltImg = new List<string>();

            for (Match m = re.Match(resString); m.Success; m = m.NextMatch())
            {
                string sImageSrc = m.Groups["ImageSrc"].Value;

                ltImg.Add(sImageSrc);
            }

            // Dictionary 저장
            _dImage.Add(a_nTagNo, ltImg);

            txtLog.Text += string.Format("태그 no == {0} / count == {1}", a_nTagNo, ltImg.Count) + Environment.NewLine;

            // 그리드 그리기
            SetGridInfo(ltImg);
        }

        /// <summary>
        /// 시간 입력 체크
        /// </summary>
        /// <returns>체크값</returns>
        private bool IsTimeCheck()
        {
            if (string.IsNullOrEmpty(txtTime.Text))
            {
                MessageBox.Show("체크시간을 입력해야지~~~", "에러 발생", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void GoShowMeTheMoney()
        {
            CHECK_TIME = Convert.ToInt32(txtTime.Text) * 60;

            ShowMeTheMoney();
        }

        private void ShowMeTheMoney()
        {
            // 폼은 숨기고
            HideFrm();

            // 초기화하고 시작하자
            FormInit();

            ImageGet();

            lblChkTime.Text = string.Format("{0} 에 체크 완료", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            // 에러가 있으면 에러를 보여주자
            ShowError();

            // 파일 만들기
            MakeFile();
        }

        /// <summary>
        /// 파일 만들기
        /// </summary>
        private void MakeFile()
        {
            string sDirName = string.Format("{0}{1}", "D:\\DolPic\\", DateTime.Now.ToString("yyyy-MM-dd"));
            DirectoryInfo dir = new DirectoryInfo(sDirName);
            if (!dir.Exists)
            {
                dir.Create();
            }

            string sFileName = string.Format("{0}\\{1}.txt", sDirName, DateTime.Now.ToString("HHmmss"));

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(sFileName, true))
            {
                foreach (string[] arrStr in _arrTxt)
                {
                    file.WriteLine(string.Format("{0}\t\t{1}\t\t{2}", arrStr[0], arrStr[1], arrStr[2]));
                }
            }
        }

        private void SetGridInfo(List<string> a_list)
        {
            foreach (var item in a_list)
            {
                string[] arrApp = new string[3];

                arrApp[0] = _curNo.ToString();
                arrApp[1] = item;
                arrApp[2] = _curTag;

                dataGridView1.Rows.Add(arrApp);
                _arrTxt.Add(arrApp);
            }
        }

        private void HideFrm()
        {
            errfrm.Hide();
        }

        private void ShowError()
        {
            errfrm.Owner = this;
            errfrm.textBox1.Text = _sbErr.ToString();
            errfrm.Show();
        }

        /// <summary>
        /// 남은시간 카운트다운
        /// </summary>
        private void CountDown()
        {
            string text = "";

            // 남은일수
            dDay = Math.Floor(Convert.ToDouble(CHECK_TIME) / (3600 * 24));
            dMod = CHECK_TIME % (24 * 3600);

            // 남은시간
            dHour = Math.Floor(dMod / 3600);
            dMod = dMod % 3600;

            // 남은분
            dMin = Math.Floor(dMod / 60);

            // 남은초
            dSec = dMod % 60;

            text = (dDay > 0) ? dDay + "일 " : "";
            text = (dHour > 0) ? text + dHour + "시간 " : (text.Length > 0) ? text + dHour + "시간 " : text;
            text = (dMin > 0) ? text + dMin + "분 " : (text.Length > 0) ? text + dMin + "분 " : text;
            text = text + dSec + "초";

            CHECK_TIME--;
            lblCountdown.Text = text.ToString();
        }

        #region 이미지 저장하기
        /// <summary>
        /// 이미지 저장
        /// </summary>
        private void ImageSend()
        {
            //응답요청을 한다
            WebRequest request = null;
            WebResponse response = null;

            var TagUrlType = comSite.SelectedIndex + 1;

            try
            {
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    if (row.Cells[1].Value == null)
                //        continue;

                //    var sBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(row.Cells[1].Value.ToString()));

                //    //URI로부터 요청을 생성한다
                //    request = WebRequest.Create(string.Format(IMAGE_SEND_URL, row.Cells[0].Value, sBase64, TagUrlType, 1));

                //    Console.WriteLine("url == " + string.Format(IMAGE_SEND_URL, row.Cells[0].Value, sBase64, TagUrlType, 1));

                //    //요청을 보내고 응답을 받는다
                //    response = request.GetResponse();

                //    //txtLog.Text += row.Cells[0].Value + Environment.NewLine;
                //    //txtLog.Text += row.Cells[1].Value + Environment.NewLine;
                //    //txtLog.Text += row.Cells[2].Value + Environment.NewLine;

                //    Console.WriteLine("TagNo == " + row.Cells[0].Value);
                //    Console.WriteLine("ImageSrc =={0} / {1}", row.Cells[1].Value, sBase64);
                //}

                foreach (KeyValuePair<int, List<string>> kvp in _dImage)
                {
                    Console.WriteLine("Key: " + kvp.Key);
                    Console.WriteLine("Value: " + kvp.Value);

                    foreach (var item in kvp.Value)
                    {
                        var sBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(item));

                        //URI로부터 요청을 생성한다
                        request = WebRequest.Create(string.Format(IMAGE_SEND_URL, kvp.Key, sBase64, TagUrlType, 1));

                        Console.WriteLine("url == " + string.Format(IMAGE_SEND_URL, kvp.Key, sBase64, TagUrlType, 1));

                        //요청을 보내고 응답을 받는다
                        response = request.GetResponse();

                        Console.WriteLine("TagNo == " + kvp.Key);
                        Console.WriteLine("ImageSrc == " + sBase64);

                    }
                }
            }
            catch (Exception ex)
            {
                errfrm.Show();
                errfrm.textBox1.Text = ex.ToString();
                txtLog.Text += ex.ToString();

                Console.WriteLine(ex.ToString());
            }
        }
        #endregion

        #region 이벤트 모음
        /// <summary>
        /// 이미지 가져오기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImageLoad_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";
            dataGridView1.Rows.Clear();
            btnImageLoad.Enabled = false;

            ImageGet();
        }

        /// <summary>
        /// XML 정보 읽기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXmlLoad_Click(object sender, EventArgs e)
        {
            btnXmlLoad.Enabled = false;

            XmlInfoInit();

            btnImageLoad.Enabled = true;
            btnAuthCheck.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GoShowMeTheMoney();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            CountDown();
        }

        /// <summary>
        /// 자동 체크 시작
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAuthCheck_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                btnAuthCheck.Text = "자동 체크 시작";
                btnImageLoad.Enabled = true;
                lblCountdown.Visible = false;
                label2.Visible = false;
                txtTime.ReadOnly = false;
                lblRemainTime.Visible = false;
                comSite.Enabled = true;
                btnXmlLoad.Enabled = true;

                timer1.Stop();
                timer2.Stop();
            }
            else
            {
                if (IsTimeCheck())
                {
                    timer1.Interval = Convert.ToInt32(txtTime.Text) * 60000;

                    btnAuthCheck.Text = "자동 체크 멈춤";
                    btnImageLoad.Enabled = false;
                    lblCountdown.Visible = true;
                    label2.Visible = true;
                    txtTime.ReadOnly = true;
                    lblRemainTime.Visible = true;
                    comSite.Enabled = false;

                    timer1.Start();
                    timer2.Start();
                    timer2.Enabled = true;

                    GoShowMeTheMoney();
                }
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            // 아이콘을 더블클릭하면 폼 화면을 보여줌
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Activate();

        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {

        }

        private void Crawler_Load(object sender, EventArgs e)
        {
            // NotifyIcon에 메뉴 추가
            ContextMenu ctx = new ContextMenu();
            ctx.MenuItems.Add(new MenuItem("열기"));
            ctx.MenuItems.Add(new MenuItem("실행"));
            ctx.MenuItems.Add("-");
            ctx.MenuItems.Add(new MenuItem("종료", new EventHandler((s, ex) => this.Close())));
            notifyIcon1.ContextMenu = ctx;
        }
        #endregion
    }
}
