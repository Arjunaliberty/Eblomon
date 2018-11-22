using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Eblomon
{
    public partial class MainForm : Form
    {
        private string[] _cookies;
        private readonly string auth;
        private const string boundary = "---------------------------000000000000000";

        public MainForm()
        {
            InitializeComponent();
            //auth = File.ReadAllText("Cookie.header");
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }
        private void tmrCheck_Tick(object sender, EventArgs e)
        {
            try
            {
                var lastTime = GetLastTimeUtc();
                lblTime.Text = lastTime.ToLocalTime().ToString("HH:mm:ss");
                if (DateTime.UtcNow - lastTime > TimeSpan.FromMinutes(3))
                {
                    lblTime.ForeColor = Color.Red;
                    TopMost = true;
                    WindowState = FormWindowState.Normal;
                }
                else
                {
                    lblTime.ForeColor = SystemColors.ControlText;
                    TopMost = false;
                }
            }
            catch
            {
                lblTime.Text = "ERROR";
                lblTime.ForeColor = Color.Red;
            }
        }
        private DateTime GetLastTimeUtc()
        {
            var request = WebRequest.CreateHttp("https://wplan.io/home/getworkshifts");
            request.Method = "POST";
            request.Timeout = 60000;
            request.ContinueTimeout = 60000;
            request.Accept = " */*";
            //request.Headers.Add("Cookie", auth);
            //foreach (var cookie in _cookies)
            //{
            //    request.Headers.Add("Cookie", cookie);
            //}
            request.Headers.Add("Cookie", _cookies.Select(c => c).Last());

            request.ContentType = $"multipart/form-data; boundary={boundary}";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            var today = DateTime.Today;
            var postData = $"--{boundary}\n" +
                           $"Content-Disposition: form-data; name=\"date_end\"\n\n" +
                           $"{today.Day:D2}.{today.Month:D2}.{today.Year}\n" +
                           $"--{boundary}\n" +
                           $"Content-Disposition: form-data; name=\"date_start\"\n\n" +
                           $"01.{today.Month:D2}.{today.Year}\n" +
                           $"--{boundary}--";

            var postBytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = postBytes.Length;
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(postBytes, 0, postBytes.Length);
            }
            var strResp = GetResponseString(request);

            var respOpj = JsonConvert.DeserializeObject<EblResp>(strResp);

            return respOpj.TodayShift.Parts.Last().EndDtUtc;
        }
        public static string GetResponseString(HttpWebRequest request)
        {
            HttpWebResponse response = null;
            try
            {
                return ReadResponce((HttpWebResponse)request.GetResponse());
            }
            catch (WebException we)
            {
                if (we.Response != null && (we.Response is HttpWebResponse))
                {
                    response = (HttpWebResponse)we.Response;
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.BadRequest:
                            throw new Exception($"Bad Request (400) with message: {ReadResponce(response)}");
                        case HttpStatusCode.Unauthorized:
                            throw new Exception($"Unauthorized (401) with message: {ReadResponce(response)}");
                        case HttpStatusCode.Forbidden:
                            throw new Exception($"Forbidden (403) with message: {ReadResponce(response)}");
                        case (HttpStatusCode)429:
                            throw new Exception($"To many requests (429). Response: {ReadResponce(response)}");
                        default:
                            throw;
                    }
                }
                else throw;
            }
            finally
            {
                response?.Close();
            }
        }
        private static string ReadResponce(HttpWebResponse response)
        {
            using (var stream = response.GetResponseStream())
            {
                if (stream == null) throw new NullReferenceException("The HttpWebRequest's response stream is empty.");

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DateTime.Now.TimeOfDay > TimeSpan.FromHours(19.9)
                || MessageBox.Show("Точно закрыть? Не рановато ли домой?", "Подтверждение закрытия",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                return;

            e.Cancel = true;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void enter_Click(object sender, EventArgs e)
        {
            var cookieContainer = new CookieContainer(); 
            HttpClientHandler handler = new HttpClientHandler { CookieContainer = cookieContainer };
            HttpClient client = new HttpClient(handler);
                       
            Dictionary<string, string> keys = new Dictionary<string, string>
            {
                //{ "login", "pervov" },
                //{ "pass", "gfgasdfg9875asdfasdgas978" }
                { "login", loginBox.Text },
                { "pass", passwordBox.Text }
            };

            FormUrlEncodedContent post_content = new FormUrlEncodedContent(keys);
            var post_response = client.PostAsync("https://wplan.io/mobile/login", post_content).GetAwaiter().GetResult();
            //var post_response = client.PostAsync("http://localhost:64282/mobile/login", post_content).GetAwaiter().GetResult();

            if(post_response.StatusCode == HttpStatusCode.OK)
            {
                _cookies = post_response.Headers.GetValues("Set-Cookie").ToArray();
                lblTime.Visible = true;
                loginPanel.Visible = false;

                tmrCheck_Tick(null, null);
                tmrCheck.Start();
            }
            else
            {
               
            }
        }
    }
}
