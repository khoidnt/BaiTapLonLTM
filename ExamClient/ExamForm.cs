using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamClient
{
    public partial class ExamForm : Form
    {
        private int _currentUserId;
        private List<Question> qList = new List<Question>();
        private int currentIndex = 0;
        private int totalSeconds = 600;

        public ExamForm(int userId)
        {
            InitializeComponent();
            this._currentUserId = userId;
            this.Load += ExamForm_Load;
        }

        public class Question { public string ID, Text, A, B, C, D, Correct, UserAnswer; }

        private async void ExamForm_Load(object sender, EventArgs e)
        {
            // Tải đề bất đồng bộ để tránh treo giao diện
            bool success = await LoadQuestionsAsync();

            // Cập nhật UI an toàn sau khi đã có dữ liệu
            this.Invoke(new Action(() => {
                if (success && qList.Count > 0)
                {
                    DisplayQuestion();
                    timer1.Start();
                }
                else
                {
                    MessageBox.Show("Không thể tải đề thi. Vui lòng kiểm tra Server!");
                    this.Close();
                }
            }));
        }

        private async Task<bool> LoadQuestionsAsync()
        {
            return await Task.Run(() => {
                try
                {
                    using (TcpClient client = new TcpClient("127.0.0.1", 5000))
                    using (NetworkStream ns = client.GetStream())
                    {
                        byte[] buf = Encoding.UTF8.GetBytes("GET_QUESTIONS");
                        ns.Write(buf, 0, buf.Length);

                        byte[] resBuf = new byte[1024 * 50];
                        int read = ns.Read(resBuf, 0, resBuf.Length);
                        string res = Encoding.UTF8.GetString(resBuf, 0, read);

                        if (res.StartsWith("QUESTIONS_LIST"))
                        {
                            string[] parts = res.Split('#');
                            for (int i = 1; i < parts.Length; i++)
                            {
                                string[] d = parts[i].Split('|');
                                qList.Add(new Question { ID = d[0], Text = d[1], A = d[2], B = d[3], C = d[4], D = d[5], Correct = d[6], UserAnswer = "" });
                            }
                            return true;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine("Lỗi: " + ex.Message); }
                return false;
            });
        }

        private void DisplayQuestion()
        {
            var q = qList[currentIndex];
            lblQuestion.Text = q.Text;
            rdA.Text = q.A; rdB.Text = q.B; rdC.Text = q.C; rdD.Text = q.D;

            // Xóa chọn trước đó
            rdA.Checked = rdB.Checked = rdC.Checked = rdD.Checked = false;

            // Đặt lại radio nếu user đã từng chọn câu này
            if (q.UserAnswer == "A") rdA.Checked = true;
            else if (q.UserAnswer == "B") rdB.Checked = true;
            else if (q.UserAnswer == "C") rdC.Checked = true;
            else if (q.UserAnswer == "D") rdD.Checked = true;

            btnNext.Text = (currentIndex == qList.Count - 1) ? "Nộp bài" : "Câu tiếp theo";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // Lưu lại đáp án của câu hiện tại trước khi chuyển
            if (rdA.Checked) qList[currentIndex].UserAnswer = "A";
            else if (rdB.Checked) qList[currentIndex].UserAnswer = "B";
            else if (rdC.Checked) qList[currentIndex].UserAnswer = "C";
            else if (rdD.Checked) qList[currentIndex].UserAnswer = "D";

            if (currentIndex < qList.Count - 1)
            {
                currentIndex++;
                DisplayQuestion();
            }
            else { SubmitExam(); }
        }

        private void SubmitExam()
        {
            timer1.Stop();
            int correct = 0;
            foreach (var q in qList) if (q.UserAnswer == q.Correct) correct++;
            double score = Math.Round(((double)correct / qList.Count) * 10, 2);

            MessageBox.Show($"Bạn đã hoàn thành bài thi!\nSố câu đúng: {correct}/{qList.Count}\nĐiểm: {score}");
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (totalSeconds > 0)
            {
                totalSeconds--;
                lblTimer.Text = $"Thời gian: {totalSeconds / 60:00}:{totalSeconds % 60:00}";
            }
            else { SubmitExam(); }
        }
    }
}