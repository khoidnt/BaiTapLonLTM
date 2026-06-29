using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ExamServer
{
    public partial class Form1 : Form
    {
        private string connString = @"Server=(localdb)\MSSQLLocalDB;Database=OnlineExam;Trusted_Connection=True;";

        public Form1() { InitializeComponent(); CheckForIllegalCrossThreadCalls = false; }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Thread serverThread = new Thread(() => {
                try
                {
                    TcpListener server = new TcpListener(IPAddress.Any, 5000);
                    server.Start();
                    AddLog("Server đã khởi động trên cổng 5000...");
                    while (true)
                    {
                        TcpClient client = server.AcceptTcpClient();
                        new Thread(() => HandleClient(client)).Start();
                    }
                }
                catch (Exception ex) { AddLog("Lỗi khởi động: " + ex.Message); }
            });
            serverThread.IsBackground = true;
            serverThread.Start();
            btnStart.Enabled = false;
        }

        private void HandleClient(TcpClient client)
        {
            try
            {
                using (NetworkStream ns = client.GetStream())
                {
                    byte[] buf = new byte[4096];
                    int read = ns.Read(buf, 0, buf.Length);
                    string req = Encoding.UTF8.GetString(buf, 0, read);

                    AddLog("Yêu cầu: " + req);
                    string res = ProcessRequest(req);

                    byte[] resBuf = Encoding.UTF8.GetBytes(res);
                    ns.Write(resBuf, 0, resBuf.Length);
                    AddLog("Phản hồi: " + res);
                }
            }
            catch (Exception ex) { AddLog("Lỗi Client: " + ex.Message); }
            finally { client.Close(); }
        }

        private string ProcessRequest(string req)
        {
            try
            {
                string[] p = req.Split('|');
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // --- MỚI: Xử lý Đăng ký ---
                    if (p[0] == "REGISTER")
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, Password) VALUES (@u, @p)", conn);
                        cmd.Parameters.AddWithValue("@u", p[1]);
                        cmd.Parameters.AddWithValue("@p", p[2]);
                        cmd.ExecuteNonQuery();
                        return "REGISTER_SUCCESS";
                    }

                    // --- Các chức năng cũ ---
                    if (p[0] == "LOGIN")
                    {
                        SqlCommand cmd = new SqlCommand("SELECT UserID FROM Users WHERE Username=@u AND Password=@p", conn);
                        cmd.Parameters.AddWithValue("@u", p[1]); cmd.Parameters.AddWithValue("@p", p[2]);
                        object o = cmd.ExecuteScalar();
                        return o != null ? $"LOGIN_SUCCESS|{o}" : "LOGIN_FAILED";
                    }
                    if (p[0] == "GET_QUESTIONS")
                    {
                        SqlCommand cmd = new SqlCommand("SELECT QuestionID, QuestionText, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer FROM Questions", conn);
                        StringBuilder sb = new StringBuilder("QUESTIONS_LIST");
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read()) sb.Append($"#{dr[0]}|{dr[1]}|{dr[2]}|{dr[3]}|{dr[4]}|{dr[5]}|{dr[6]}");
                        }
                        return sb.ToString();
                    }
                    if (p[0] == "SUBMIT")
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Results (UserID, Score) VALUES (@u, @s)", conn);
                        cmd.Parameters.AddWithValue("@u", p[1]); cmd.Parameters.AddWithValue("@s", p[2]);
                        cmd.ExecuteNonQuery();
                        return "SUBMIT_SUCCESS";
                    }
                }
            }
            catch (Exception ex)
            {
                AddLog("Lỗi SQL: " + ex.Message);
                return "ERROR|" + ex.Message;
            }
            return "UNKNOWN";
        }

        private void AddLog(string log)
        {
            if (this.InvokeRequired) this.Invoke(new Action(() => AddLog(log)));
            else lstLog.Items.Add($"[{DateTime.Now:HH:mm:ss}] {log}");
        }
    }
}