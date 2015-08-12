using DolPicCrawler.HashTag;
using DolPicCrawler.Image;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace DolPicCrawler
{
    public partial class Crawler : Form
    {
        private int CHECK_TIME = 0;
        private ErrFrm errfrm;
        private List<string[]> _arrTxt;

        /// <summary>
        /// 해쉬태그 고유 번호
        /// </summary>
        private List<int> _listTwitterNo;
        private List<int> _listInstagramNo;
        /// <summary>
        /// 트위터 해쉬태그 리스트
        /// </summary>
        private List<string> _listTwitterHashTag;
        /// <summary>
        /// 인스타그램 해쉬태그 리스트
        /// </summary>
        private List<string> _listInstagramHashTag;
        /// <summary>
        /// 서버에 전송될 이미지 경로가 담길 Dictionary
        /// </summary>
        private Dictionary<int, List<string>> _dImage;
        /// <summary>
        /// 카운트다운 변수
        /// </summary>
        private double dDay, dMod, dHour, dMin, dSec;

        private Dictionary<int, string> _dHashTag;

        /// <summary>
        /// 생성자
        /// </summary>
        public Crawler()
        {
            InitializeComponent();
            FormInit();

            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            txtLog.Text = version.ToString() + Environment.NewLine;
            txtLog.Text += Application.StartupPath + Environment.NewLine;
        }

        #region Init

        /// <summary>
        /// Grid 초기화
        /// </summary>
        private void GridInit()
        {
            dataGridView1.Rows.Clear();

            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "번호";
            dataGridView1.Columns[1].Name = "이미지경로";
            dataGridView1.Columns[2].Name = "해쉬태그";
            dataGridView1.Columns[3].Name = "사이트";

            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 400;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].ValueType = TypeCode.Int32.GetType();
        }

        /// <summary>
        /// Form 초기화
        /// </summary>
        private void FormInit()
        {
            lblChkTime.Text = "";
            _arrTxt = new List<string[]>();
            errfrm = new ErrFrm();
            btnImageLoad.Enabled = false;

            if (timer2.Enabled)
                btnImageLoad.Enabled = false;
            else
                btnImageLoad.Enabled = true;

            // 그리드 초기화
            GridInit();
        }

        /// <summary>
        /// 서버로 부터 XML 정보 읽어 오기
        /// </summary>
        private void XmlInfoInit()
        {
            try
            {
                // 트위터용 리스트 만들기
                OriginHashTag.XmlFactory(OriginSiteType.twitter).XmlListMake(ref _listTwitterNo, ref _listTwitterHashTag, ref _dHashTag);
                txtLog.Text += "트위터 XML 로딩 완료" + Environment.NewLine;

                // 인스타그램용 리스트 만들기
                OriginHashTag.XmlFactory(OriginSiteType.instagram).XmlListMake(ref _listInstagramNo, ref _listInstagramHashTag, ref _dHashTag);
                txtLog.Text += "인스타그램 XML 로딩 완료" + Environment.NewLine;
            }
            catch (Exception ex)
            {
                // 에러 보여주기
                ShowError(ex);
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

            // 시간 측정 시작
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (var nTagUrlType = 1; nTagUrlType < 3; nTagUrlType++)
            {
                // 이미지 처리
                ImageProc(nTagUrlType);
            }
            
            // 시간 측정 끝
            sw.Stop();
            lblWatch.Text = (sw.ElapsedMilliseconds / 1000.0F).ToString() + " 초 로딩";
        }

        /// <summary>
        /// 각 사이트별 처리
        /// </summary>
        /// <param name="a_nTagUrlType">사이트 타입 1:트위터 2:인스타그램 3:페이스북</param>
        private void ImageProc(int a_nTagUrlType)
        {
            // Dictionary 초기화
            _dImage = new Dictionary<int, List<string>>();

            switch (a_nTagUrlType)
            {
                case (int)OriginSiteType.twitter:
                    // 트위터 이미지 긁어 오기
                    OriginHashTag.XmlFactory(OriginSiteType.twitter).ImageSrcSearch(_listTwitterNo, _listTwitterHashTag, ref _dImage);
                    break;

                case (int)OriginSiteType.instagram:
                    // 인스타그램 이미지 긁어 오기
                    OriginHashTag.XmlFactory(OriginSiteType.instagram).ImageSrcSearch(_listInstagramNo, _listInstagramHashTag, ref _dImage);
                    break;

                case (int)OriginSiteType.facebook:
                    break;

                default:
                    break;
            }

            // 그리드 그리기
            SetGridInfo(a_nTagUrlType);

            // 해당 사이트로 부터 이미지정보를 가져오고 이미지 저장
            ImageService.getInstance.ImageSend(_dImage, a_nTagUrlType);
        }

        /// <summary>
        /// 그리드 셋팅
        /// </summary>
        /// <param name="a_nTagUrlType">사이트 타입 1:트위터 2:인스타그램 3:페이스북</param>
        private void SetGridInfo(int a_nTagUrlType)
        {
            foreach (KeyValuePair<int, List<string>> kvp in _dImage)
            {
                txtLog.Text += string.Format("태그 no == {0} / 태그 이름 == {2} / count == {1}", kvp.Key, kvp.Value.Count, _dHashTag[kvp.Key]) + Environment.NewLine;

                foreach (var item in kvp.Value)
                {
                    string[] arrApp = new string[4];

                    arrApp[0] = kvp.Key.ToString();
                    arrApp[1] = item;
                    arrApp[2] = _dHashTag[kvp.Key];

                    switch (a_nTagUrlType)
                    {
                        case (int)OriginSiteType.twitter:
                            arrApp[3] = "트위터";
                            break;

                        case (int)OriginSiteType.instagram:
                            arrApp[3] = "인스타그램";
                            break;

                        case (int)OriginSiteType.facebook:
                            arrApp[3] = "페이스북";
                            break;

                        default:
                            arrApp[3] = "어디야?";
                            break;
                    }

                    dataGridView1.Rows.Add(arrApp);
                    _arrTxt.Add(arrApp);
                }
            }
        }

        /// <summary>
        /// 에러 보여주기
        /// </summary>
        /// <param name="ex">에러 정보</param>
        private void ShowError(Exception ex)
        {
            errfrm.Owner = this;
            errfrm.textBox1.Text = ex.ToString();
            errfrm.Show();

            txtLog.Text = ex.ToString() + Environment.NewLine;

            Console.WriteLine(ex.ToString());
        }

        #region  자동체크

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

        /// <summary>
        /// 돈 좀 벌러 가볼까~~~
        /// </summary>
        private void GoShowMeTheMoney()
        {
            CHECK_TIME = Convert.ToInt32(txtTime.Text) * 60;

            ShowMeTheMoney();
        }

        /// <summary>
        /// 돈 좀 벌어 볼까~~~
        /// </summary>
        private void ShowMeTheMoney()
        {
            // 폼은 숨기고
            errfrm.Hide();

            // 초기화하고 시작하자
            FormInit();

            try
            {
                // 이미지 가져오기
                ImageGet();

                lblChkTime.Text = string.Format("{0} 에 체크 완료", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                // 파일 만들기
                MakeFile();
            }
            catch (Exception ex)
            {
                // 에러 보여주기
                ShowError(ex);
            }
        }

        /// <summary>
        /// 파일 만들기
        /// </summary>
        private void MakeFile()
        {
            string sDirName = string.Format("{0}{1}", "D:\\DolPicLogs\\", DateTime.Now.ToString("yyyy-MM-dd"));
            DirectoryInfo dir = new DirectoryInfo(sDirName);
            if (!dir.Exists)
            {
                dir.Create();
            }

            string sFileName = string.Format("{0}\\{1}.txt", sDirName, DateTime.Now.ToString("HHmmss"));

            using (StreamWriter file = new StreamWriter(sFileName, true))
            {
                foreach (string[] arrStr in _arrTxt)
                {
                    file.WriteLine(string.Format("{0}\t\t{1}\t\t{2}\t\t{3}", arrStr[0], arrStr[1], arrStr[2], arrStr[3]));
                }
            }
        }

        #endregion

        #region 남은시간 카운트다운

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

            try
            {
                ImageGet();
            }
            catch (Exception ex)
            {
                // 에러 보여주기
                ShowError(ex);
            }
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
            ShowForm();
        }

        private void ShowForm()
        {
            this.Visible = true; // 폼의 표시
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal; // 최소화를 멈춘다 
            this.Activate(); // 폼을 활성화 시킨다
            this.notifyIcon1.Visible = false;
        }

        private void Crawler_Load(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = true;
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            this.Dispose();
            Application.Exit();
        }

        private void Crawler_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 이벤트 취소
            e.Cancel = true;
            this.Hide();
            notifyIcon1.Visible = true;
        }

        #endregion
    }
}
