using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ExamServer
{
    class Program
    {
        private static TcpListener _server;
        private static bool _isRunning = true;

        // Giả lập Database bằng bộ nhớ tạm (In-Memory)
        private static Dictionary<string, string> _users = new Dictionary<string, string>()
        {
            { "admin", "123456" },
            { "sinhvien1", "password" },
            { "khoi123", "khoi2026" }
        };

        // Giả lập danh sách câu hỏi đồng bộ với format Client mong muốn:
        // ID|Nội dung|Câu A|Câu B|Câu C|Câu D|Đáp án đúng
        private static List<string> _questions = new List<string>()
        {
            "1|Lập trình mạng sử dụng giao thức nào ở tầng Transport để đảm bảo độ tin cậy?|UDP|TCP|IP|HTTP|B",
            "2|Lệnh nào trong cmd dùng để kiểm tra các instance LocalDB đang có?|sqllocaldb v|sqllocaldb start|sqllocaldb info|sqllocaldb delete|C",
            "3|Ký tự nào được Client dùng để phân tách các câu hỏi trong gói QUESTIONS_LIST?|#|*|$|@|A",
            "4|Trong kiến trúc Client-Server qua Socket, hàm nào dùng để lắng nghe kết nối?|Connect|Accept/Listen|Send|Receive|B"
        };

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            StartServer(5000);
        }

        private static void StartServer(int port)
        {
            try
            {
                _server = new TcpListener(IPAddress.Any, port);
                _server.Start();
                Console.WriteLine($"[SERVER] Đang chạy tại port {port}...");

                while (_isRunning)
                {
                    TcpClient client = _server.AcceptTcpClient();
                    // Tạo một Thread riêng để xử lý mỗi Client (Multi-threading)
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
                    clientThread.Start(client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR] Lỗi khởi động Server: " + ex.Message);
            }
        }

        private static void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            string clientEndPoint = client.Client.RemoteEndPoint.ToString();
            Console.WriteLine($"\n[CONNECTED] Client kết nối từ: {clientEndPoint}");

            try
            {
                using (NetworkStream ns = client.GetStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = ns.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) return;

                    string request = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                    Console.WriteLine($"[REQUEST] Nhận từ {clientEndPoint}: {request}");

                    string response = "ERR_UNKNOWN_REQUEST";

                    // 1. XỬ LÝ ĐĂNG NHẬP (Format: LOGIN|username|password)
                    if (request.StartsWith("LOGIN|"))
                    {
                        string[] parts = request.Split('|');
                        if (parts.Length == 3)
                        {
                            string user = parts[1];
                            string pass = parts[2];

                            if (_users.ContainsKey(user) && _users[user] == pass)
                            {
                                int mockUserId = Math.Abs(user.GetHashCode()) % 1000; // Giả lập UserId
                                response = $"LOGIN_SUCCESS|{mockUserId}";
                            }
                            else
                            {
                                response = "LOGIN_FAILED";
                            }
                        }
                    }
                    // 2. XỬ LÝ ĐĂNG KÝ (Format: REGISTER|username|password)
                    else if (request.StartsWith("REGISTER|"))
                    {
                        string[] parts = request.Split('|');
                        if (parts.Length == 3)
                        {
                            string user = parts[1];
                            string pass = parts[2];

                            if (_users.ContainsKey(user))
                            {
                                // Gửi thông điệp có chứa cụm 'Violation of UNIQUE KEY' giống như lỗi SQL thật để Client bắt được
                                response = "REGISTER_FAILED: Violation of UNIQUE KEY (User already exists)";
                            }
                            else
                            {
                                _users.Add(user, pass);
                                response = "REGISTER_SUCCESS";
                                Console.WriteLine($"[DATABASE] Đã đăng ký thành công tài khoản mới: {user}");
                            }
                        }
                    }
                    // 3. XỬ LÝ QUÊN MẬT KHẨU (Format: FORGOT|username)
                    else if (request.StartsWith("FORGOT|"))
                    {
                        string[] parts = request.Split('|');
                        if (parts.Length == 2)
                        {
                            string user = parts[1];
                            if (_users.ContainsKey(user))
                            {
                                response = $"FORGOT_SUCCESS|{_users[user]}";
                            }
                            else
                            {
                                response = "FORGOT_FAILED";
                            }
                        }
                    }
                    // 4. XỬ LÝ LẤY ĐỀ THI (Format từ ExamForm.cs: GET_QUESTIONS)
                    else if (request == "GET_QUESTIONS")
                    {
                        // Khớp chính xác logic parse: res.StartsWith("QUESTIONS_LIST") và parts[i].Split('|')
                        StringBuilder sb = new StringBuilder();
                        sb.Append("QUESTIONS_LIST");
                        foreach (var q in _questions)
                        {
                            sb.Append("#").Append(q);
                        }
                        response = sb.ToString();
                    }

                    // GỬI PHẢN HỒI VỀ CLIENT
                    byte[] resBytes = Encoding.UTF8.GetBytes(response);
                    ns.Write(resBytes, 0, resBytes.Length);
                    Console.WriteLine($"[RESPONSE] Đã gửi về {clientEndPoint}: {response}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Lỗi xử lý Client {clientEndPoint}: " + ex.Message);
            }
            finally
            {
                client.Close();
                Console.WriteLine($"[DISCONNECTED] Đã đóng kết nối với: {clientEndPoint}");
            }
        }
    }
}