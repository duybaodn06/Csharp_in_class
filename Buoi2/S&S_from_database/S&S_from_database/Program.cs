using MySql.Data.MySqlClient;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
struct SinhVien
{
    public string id;
    public string name;
    public float gpa;
}


namespace search_and_sort
{
    internal class Program
    {
        static Array arsv;
        static List<SinhVien> lsv;
        static ArrayList alsv;

        static void init()
        {
            arsv = Array.CreateInstance(typeof(SinhVien), 100);
            lsv = new List<SinhVien>();
            alsv = new ArrayList();
        }

        //Search
        static T SearchByGpa<T>(float from, float to)
        {
            if (typeof(T) == typeof(Array))
            {
                Array temp = Array.CreateInstance(typeof(SinhVien), 100);
                int count = 0;
                for (int i = 0; i < arsv.GetLength(0); i++)
                {
                    SinhVien t = (SinhVien)arsv.GetValue(i);
                    if (t.id != null && t.gpa >= from && t.gpa <= to)
                    {
                        temp.SetValue(t, count);
                        count++;
                    }
                }
                return (dynamic)temp;
            }
            else if (typeof(T) == typeof(List<SinhVien>))
            {
                List<SinhVien> temp = new List<SinhVien>();
                foreach (SinhVien x in lsv)
                {
                    if (x.gpa >= from && x.gpa <= to)
                    {
                        temp.Add(x);
                    }
                }
                return (dynamic)temp;
            }
            else
            {
                ArrayList temp = new ArrayList();
                foreach (SinhVien x in alsv)
                {
                    if (x.gpa >= from && x.gpa <= to)
                    {
                        temp.Add(x);
                    }
                }
                return (dynamic)temp;
            }
            return (dynamic)null;
        }
        //end of search



        //sort desc
        static T SortByGpa<T>()
        {
            //bubble sort

            if (typeof(T) == typeof(Array))
            {
                //create clone 
                Array temp = (Array)arsv.Clone();
                int n = temp.GetLength(0);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        SinhVien sv1 = (SinhVien)temp.GetValue(j);
                        SinhVien sv2 = (SinhVien)temp.GetValue(j + 1);
                        if (sv1.id == null && sv2.id != null)
                        {
                            temp.SetValue(sv2, j);
                            temp.SetValue(sv1, j + 1);
                        }
                        if (sv1.id == null || sv2.id == null)
                        {
                            continue;
                        }
                        if (sv1.gpa < sv2.gpa)
                        {
                            temp.SetValue(sv2, j);
                            temp.SetValue(sv1, j + 1);
                        }
                    }
                }
                return (dynamic)temp;
            }
            else if (typeof(T) == typeof(List<SinhVien>))
            {
                //selection sort
                for (int i = 0; i < lsv.Count() - 1; i++)
                {
                    float max = lsv[i].gpa;
                    int index = i;
                    for (int j = 1 + i; j < lsv.Count(); j++)
                    {
                        if (max < lsv[j].gpa)
                        {
                            max = lsv[j].gpa;
                            index = j;
                        }
                    }
                    (lsv[index], lsv[i]) = (lsv[i], lsv[index]);
                }
                return (dynamic)lsv;
            }
            else if (typeof(T) == typeof(ArrayList))
            {
                for (int i = 0; i < alsv.Count - 1; i++)
                {
                    float max = ((SinhVien)alsv[i]).gpa;
                    int index = i;
                    for (int j = 1 + i; j < alsv.Count; j++)
                    {
                        if (max < ((SinhVien)alsv[j]).gpa)
                        {
                            max = ((SinhVien)alsv[j]).gpa;
                            index = j;
                        }
                    }
                    (alsv[index], alsv[i]) = (alsv[i], alsv[index]);
                }
                return (dynamic)alsv;
            }
            return (dynamic)null;
        }
        //end of sort


        //start seaching
        static void start_searching(float from,float to)
        {
            //searching
            Array ares = SearchByGpa<Array>(from, to);
            List<SinhVien> lres = SearchByGpa<List<SinhVien>>(from, to);
            ArrayList alres = SearchByGpa<ArrayList>(from, to);

            //printing
            for (int i = 0; i < ares.GetLength(0); i++)
            {
                if (((SinhVien)ares.GetValue(i)).id == null) continue;
                Console.WriteLine($"ID: {((SinhVien)ares.GetValue(i)).id} | Ten: {((SinhVien)ares.GetValue(i)).name} | Diem: {((SinhVien)ares.GetValue(i)).gpa}");
            }
            Console.WriteLine();

            foreach (SinhVien x in lres)
            {
                Console.WriteLine($"ID: {x.id} | Ten: {x.name} | Diem: {x.gpa}");
            }
            Console.WriteLine();

            foreach (SinhVien x in alres)
            {
                Console.WriteLine($"ID: {x.id} | Ten: {x.name} | Diem: {x.gpa}");
            }
        }
        //end searching


        //start sorting
        static void start_sorting()
        {
            //sorting
            Array sortasv = SortByGpa<Array>();
            List<SinhVien> sortlsv = SortByGpa<List<SinhVien>>();
            ArrayList sortalsv = SortByGpa<ArrayList>();


            //printing
            foreach (SinhVien x in sortasv)
            {
                if (x.id != null)
                {
                    Console.WriteLine($"ID: {x.id} | Ten: {x.name} | Diem: {x.gpa}");
                }
            }
            Console.WriteLine();
            foreach (SinhVien x in sortlsv)
            {
                Console.WriteLine($"ID: {x.id} | Ten: {x.name} | Diem: {x.gpa}");
            }
            Console.WriteLine();
            foreach (SinhVien x in sortalsv)
            {
                Console.WriteLine($"ID: {x.id} | Ten: {x.name} | Diem: {x.gpa}");
            }
        }
        //end sorting




        static List<SinhVien> GetSinhVienFromDB()
        {
            List<SinhVien> listResult = new List<SinhVien>();

            // 2. CHUỖI KẾT NỐI (Connection String)
            // Đây là chìa khóa để mở cửa vào nhà (Database)
            string server = "127.0.0.1"; // Hoặc "localhost"
            string database = "csharp"; // Tên database bạn đã tạo
            string uid = "root"; // Tên đăng nhập (XAMPP thường là root)
            string password = "123456789"; // Mật khẩu (XAMPP thường để trống)

            string connString = $"Server={server};Database={database};User Id={uid};Password={password};";

            // 3. TẠO KẾT NỐI
            // Dùng 'using' để đảm bảo kết nối tự đóng sau khi dùng xong (Rất quan trọng để không bị lag máy)
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    Console.WriteLine("Dang ket noi database...");
                    conn.Open(); // Mở cửa
                    Console.WriteLine("Ket noi thanh cong!");

                    // 4. RA LỆNH (Command)
                    string sql = "SELECT * FROM student";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    // 5. ĐỌC DỮ LIỆU (DataReader)
                    // ExecuteReader dùng cho lệnh SELECT
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Vòng lặp: Đọc từng dòng (Row) từ trên xuống dưới
                        while (reader.Read())
                        {
                            SinhVien sv = new SinhVien();

                            // Lấy dữ liệu theo tên cột trong MySQL và ép kiểu
                            // reader["tên_cột_mysql"]
                            sv.id = reader["id"].ToString();
                            sv.name = reader["name"].ToString();

                            // Với số, nên dùng Convert cho an toàn
                            sv.gpa = Convert.ToSingle(reader["gpa"]);

                            // Thêm vào List
                            listResult.Add(sv);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Nếu sai pass hay tên DB, nó sẽ báo lỗi ở đây
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            } // Kết nối tự động đóng tại đây (conn.Close())

            return listResult;
        }
        static void LoadDbToGlobalVars()
        {
            // 1. Lấy dữ liệu thô từ Database
            List<SinhVien> dataFromDb = GetSinhVienFromDB();

            if (dataFromDb.Count == 0)
            {
                Console.WriteLine("Khong co du lieu trong Database!");
                return;
            }

            Console.WriteLine($"Da tim thay {dataFromDb.Count} sinh vien tu Database.");

            // 2. Đổ vào List (lsv)
            // Xóa cũ đi (nếu có) rồi thêm mới
            lsv.Clear();
            lsv.AddRange(dataFromDb);

            // 3. Đổ vào ArrayList (alsv)
            alsv.Clear();
            foreach (var sv in dataFromDb)
            {
                alsv.Add(sv);
            }

            // 4. Đổ vào Array (arsv)
            // Array cần kích thước cố định, nên ta tạo mới dựa trên số lượng lấy về
            arsv = Array.CreateInstance(typeof(SinhVien), dataFromDb.Count);

            for (int i = 0; i < dataFromDb.Count; i++)
            {
                arsv.SetValue(dataFromDb[i], i);
            }

            Console.WriteLine("Da dong bo du lieu vao arsv, lsv va alsv thanh cong!\n");
        }


        static void Main(string[] args)
        {
            init();

            LoadDbToGlobalVars();

            // Gọi hàm lấy dữ liệu


            // In ra kiểm tra
            //Console.WriteLine("\n--- DANH SACH SINH VIEN TU MYSQL ---");
            //foreach (var sv in lsv)
            //{
            //    Console.WriteLine($"ID: {sv.id} | Ten: {sv.name} | Diem: {sv.gpa}");
            //}
            //Console.ReadKey();


            //print result 
            Console.WriteLine("Insert sorting GPA:");
            Console.Write("From: "); float from = float.Parse(Console.ReadLine());
            Console.Write("To: "); float to = float.Parse(Console.ReadLine());
            start_searching(from, to);
            
            //start_sorting();
        }
    }
}
