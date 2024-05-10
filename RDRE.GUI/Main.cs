using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//using System.Logic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Controls;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.Cryptography;
using System.IO.Compression;
using System.Reflection;
using QRCoder;
using System.Drawing.Drawing2D;

namespace RDRE.GUI {
    public partial class Main : Form {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);
        private const int EM_SETCUEBANNER = 0x1501;
        QRCodeGenerator qrGenerator;
        QRCodeGenerator.ECCLevel eccLevel;
        QRCodeData qrCodeData;
        QRCode qrCode;
        bool AutoDepth;
        int OutputMode;
        bool Spacing;
        bool LastSpacing;
        bool Insane;
        int InsaneDelay;
        Thread InsaneThread;
        Thread ProgressThread;
        Stopwatch stopWatch = new Stopwatch();
        double TotalTime = 0;
        //double TotalTimeAvg = 0;
        //int TotalTimeCount = 0;
        bool Secure;
        bool SecEncMode;
        bool ModeRDR;
        string SecureKey;
        bool EncLZMA;
        bool EncBase64;
        bool Realtime;
        bool RealtimeLast;
        bool ShiftRet;
        bool ClearOnRet;
        bool ClearOnRetLast;
        //public double ProgressRDR;
        public Main() {
            eccLevel = (QRCodeGenerator.ECCLevel)1;
            qrGenerator = new QRCodeGenerator();
            InitializeComponent();
            RDRE.Init();
            UpdateStates();
        }
        protected override CreateParams CreateParams {
            get {
                const int WS_EX_COMPOSITED = 0x02000000;
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_COMPOSITED;
                return cp;
                //Application.EnableVisualStyles();
            }
        }
        private void UpdateOutput() {
            string Text = Input.Text.ToString();

            /*PerfInputLen.Text = Text.Length.ToString();*/
            //byte[] TextByte;
            if (Text.Length > 0) {
/*                Progress.Value = 0;
                stopWatch = Stopwatch.StartNew();
                if (ProgressThread.IsAlive) {
                    ProgressThread.Resume();
                } else {
                    ProgressThread.Start();
                }
*/                if (!ModeRDR) {
                    Text = Text.Replace("\r", "\n");
                    /*if (EncLZMA) {
                        Text = Encoding.ASCII.GetString(CompressLZMA(Encoding.ASCII.GetBytes(Text)));
                        if (!Secure) {
                            Text = Convert.ToBase64String(Encoding.ASCII.GetBytes(Text));
                        }
                    }*/
                    //Debug.WriteLine(Text);
                    if (SecureKey != null) {
                        if (Secure && SecureKey.Length > 0) {
                            Text = StringCipher.Encrypt(Text, SecureKey);//RC4.Encrypt(SecureKey,Text);//
                        }
                    }
                    //Debug.WriteLine(Text);
                    Text = RDRE.EncodeString(Text, OutputMode, Spacing);
                    //Debug.WriteLine(Text);
                    if (EncBase64) {
                        //Debug.WriteLine(StringToByteArray(Text));
                        Text = Convert.ToBase64String(StringToByteArray(Text));
                    }
                }
                /*if (SecureKey!=null) {
                    if (Secure && SecureKey.Length > 0) {
                        if (!SecEncMode) {
                        } else {
                            Text = StringCipher.Decrypt(Text, SecureKey);
                        }

                    }
                }*/
                if (!ModeRDR) {
                    Output.Text = Text;
                } else {
                    if (EncBase64) {
                        try {
                            Text = ByteArrayToString(Convert.FromBase64String(Text)).ToUpper();
                        } catch {
                            Output.Text = "Invalid Input Data Found!";
                            return;
                        }
                        //Text = BitConverter.ToString(Temp);
                        //Text = BitConverter.ToString(Temp.Reverse().ToArray()).Replace("-", "");
                    }
                    /*if (EncLZMA) {
                        Text = Base64Decode(Text);
                        Text = System.Text.Encoding.ASCII.GetString(DecompressLZMA(Encoding.ASCII.GetBytes(Text)));
                    }*/
                    Text = RDRE.DecodeString(Text);
                    if (SecureKey != null) {
                        if (Secure && SecureKey.Length > 0) {
                            try {
                                Text = StringCipher.Decrypt(Text, SecureKey);//RC4.Encrypt(SecureKey,Text);//
                            } catch {
                                Text = "Invalid Input Data Found!";
                                return;
                            }
                            
                        }
                    }
                    /*if (EncLZMA) {
                        if (!Secure) {
                            Text = Convert.ToBase64String(Encoding.ASCII.GetBytes(Text));
                        }
                        Text = Encoding.ASCII.GetString(DecompressLZMA(Encoding.ASCII.GetBytes(Text)));
                    }*/

                    Output.Text = Text;
                }
                qrCodeData = qrGenerator.CreateQrCode(Text, eccLevel);
                qrCode = new QRCode(qrCodeData);
                
                //pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                
                pictureBox1.Image = qrCode.GetGraphic(8, Color.Black, Color.White, true);
                //pictureBox1.Size = new System.Drawing.Size(pictureBox1.Width, pictureBox1.Height);

                //stopWatch.Stop();
                //Output.Text = Output.Text;
                //TotalTime = stopWatch.Elapsed.TotalMilliseconds;
                //TotalTimeAvg += TotalTime;
                //TotalTimeCount++;
                //PerfTotalTime.Text = Tools.DisplayTime(Convert.ToDecimal(TotalTime * 1000 * 1000));//.ToString()+"ms";
                //PerfCharRate.Text = Tools.DisplayHertz(Convert.ToDecimal(((1 / RDRE.CharTime) * 1000)));
                //PerfTotalTimeAvg.Text = Tools.DisplayTime(Convert.ToDecimal((TotalTimeAvg / TotalTimeCount) * 1000 * 1000));
                //PerfCharRateAvg.Text = Tools.DisplayHertz(Convert.ToDecimal(((1 / (RDRE.CharTimeAvg / RDRE.CharTimeCount)) * 1000)));
                //Progress.Value = (int)RDRE.CurrentProgress;
                //Progress.Increment(100);
                /*                if (OutputMode == 0) {
                                    PerfOutputLen.Text = Output.Text.Length.ToString("D");
                                } else if (OutputMode == 1) {
                                    PerfOutputLen.Text = (Output.Text.Length / 2).ToString("D");
                                }*/
                //if (ProgressThread.IsAlive) {
                //    ProgressThread.Suspend();
                //ProgressThread.Abort();
                //}
                //Progress.Value = 1000;
            }
            else if (Text.Length == 0) {
                Output.Text = "";
                Output.Text = Output.Text;
                pictureBox1.Image = null;
                pictureBox1.Update();
            }
            
        }

        private void Input_TextChanged(object sender, EventArgs e) {
            //PerfInputLen.Text = Input.Text.Length.ToString("D");
            if (Realtime) {
                if (AutoDepth) {
                    int Depth = RDRE.AutoDepth(Input.Text.ToString());
                    OptDepthSelect.Text = Depth.ToString();
                }
                UpdateOutput();
            } else {
                if (!ShiftRet) {
                    if (Input.Text.Contains(Environment.NewLine)) {
                        Input.Text = Input.Text.Remove(Input.Text.Length-1); //Input.Text.TrimEnd('\r','\n');
                    }
                    Input.Select(Input.Text.Length, 0);
                }
            }
        }

        private void OptSpacing_CheckedChanged(object sender, EventArgs e) {
            Spacing = OptSpacing.Checked;
            UpdateOutput();
        }

        private void Main_Load(object sender, EventArgs e) {
            AutoDepth = true;
            OutputMode = 1;
            Spacing = false;
            Insane = true;
            InsaneDelay = 125;
            /*PerfInputLen.Text = "0 Bytes";
            PerfOutputLen.Text = "0 Bytes";
            PerfCharRate.Text = "0.0000ms";
            PerfTotalTime.Text = "0.0000ms";*/
            InsaneThread = new Thread(InsaneUpdate);
            InsaneThread.IsBackground = true;
            InsaneDelayTicker.Enabled = false;
            InsaneDelayTicker.Value = 125;
            //ProgressThread = new Thread(ProgressUpdate);
            //ProgressThread.IsBackground = true;
            Secure = false;
            SecEncMode = false;
            OptSecEnc.Enabled = false;
            OptSecDec.Enabled = false;
            OptSecKey.Enabled = false;
            ModeRDR = false;
            SendMessage(OptSecKey.Handle, EM_SETCUEBANNER, 1, "Password");
            EncLZMA = false;
            EncBase64 = false;
            Realtime = true;
            ShiftRet = false;
            ClearOnRet = false;
            //OptOutLZMA.Enabled = false;
            //OptOutLZMA.Checked = false;
            Input.KeyDown += new KeyEventHandler(Input_KeyDown);
        }

        public void InsaneUpdate() {
            try {
                while (Insane) {
                    if (InsaneDelay > 0) {
                        Thread.Sleep(InsaneDelay);
                    }
                    MethodInvoker mi = delegate () {
                        UpdateOutput();
                    };
                    this.Invoke(mi);
                }
            } catch (ThreadInterruptedException e) {
                Console.WriteLine("newThread cannot go to sleep - " +
                    "interrupted by main thread.");
            }
        }

/*        public void ProgressUpdate() {
            try {
                while (true) {
                    Thread.Sleep(10);
                    MethodInvoker mi = delegate () {
                        Progress.Value = (int)RDRE.CurrentProgress;
                    };
                    this.Invoke(mi);
                }
            } catch (ThreadInterruptedException e) {
                Console.WriteLine("newThread cannot go to sleep - " +
                    "interrupted by main thread.");
            }
        }*/

        private void Input_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (!Realtime) {
                    if (e.Modifiers.HasFlag(Keys.Shift)) {
                        ShiftRet = true;
                    } else {
                        ShiftRet = false;
                    }
                    if (AutoDepth) {
                        int Depth = RDRE.AutoDepth(Input.Text.ToString());
                        OptDepthSelect.Text = Depth.ToString();
                    }
                    UpdateOutput();
                }
            }

        }

        private void OptOutMode_CheckStateChanged(object sender, EventArgs e) {
            if (OptOutputDec.Checked) {
                OutputMode = 0;
                OptSpacing.Enabled = false;
                LastSpacing = OptSpacing.Checked;
                OptSpacing.Checked = true;
            } else if (OptOutputHex.Checked) {
                OutputMode = 1;
                OptSpacing.Enabled = true;
                OptSpacing.Checked = LastSpacing;
            }
            UpdateOutput();
        }

        private void OptAutoDepth_CheckStateChanged(object sender, EventArgs e) {
            //If Enabled, Disable DepthSelect
            //If Disabled, Enable DepthSelect
            if (OptAutoDepth.Checked) {
                OptDepthSelect.Enabled = false;
                AutoDepth = true;
                int Depth = RDRE.AutoDepth(Input.Text.ToString());
                OptDepthSelect.Text = Depth.ToString();
            } else if (!OptAutoDepth.Checked) {
                OptDepthSelect.Enabled = true;
                AutoDepth = false;
            }
            UpdateOutput();
        }

        private void DepthSelect_SelectedIndexChanged(object sender, EventArgs e) {
            if (!OptAutoDepth.Checked) {
                RDRE.SetDepth(Convert.ToInt32(OptDepthSelect.SelectedItem.ToString()));
                UpdateOutput();
            }
        }

        private void InsaneDelayTicker_ValueChanged(object sender, EventArgs e) {
            InsaneDelay = Convert.ToInt32(InsaneDelayTicker.Value);
        }

        private void OptInsane_CheckedChanged(object sender, EventArgs e) {
            if (OptInsane.Checked) {
                InsaneDelayTicker.Enabled = true;
                Insane = true;
                if (InsaneThread.IsAlive) {
                    InsaneThread.Resume();
                } else {
                    InsaneThread.Start();
                }
            } else if (!OptInsane.Checked) {
                InsaneDelayTicker.Enabled = false;
                Insane = false;
                InsaneThread.Suspend();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e) {
            if (!Insane && InsaneThread.IsAlive) {
                InsaneThread.Resume();
            }
            InsaneThread.Abort();
        }

        private void StatsGroup_Enter(object sender, EventArgs e) {

        }

        private void OptSecKey_TextChanged(object sender, EventArgs e) {
            SecureKey = OptSecKey.Text;
            if (OptSecKey.Text.Length > 0) {
                Secure = true;
            } else {
                Secure = false;
            }
            UpdateOutput();
        }

        private void OptSecure_CheckedChanged(object sender, EventArgs e) {
            if (OptSecure.Checked) {
                if (OptSecKey.Text.Length > 0) {
                    Secure = true;
                }
                OptSecKey.Enabled = true;
            } else if (!OptSecure.Checked) {
                OptSecKey.Enabled = false;
                Secure = false;
            }
            UpdateOutput();
        }

        private void OptSecEncDec_CheckChanged(object sender, EventArgs e) {
        }
           
        private void UpdateStates()
        {
            if (ModeEncRDR.Checked)
            {
                if (Secure)
                {
                    if (OptSecKey.Text.Length > 0)
                    {
                        OptSecEnc.Enabled = true;
                    }
                }
                OptOutputDec.Enabled = true;
                OptOutputHex.Enabled = true;
                if (OutputMode > 0)
                {
                    OptSpacing.Enabled = true;
                    OptSpacing.Checked = LastSpacing;
                }
                OptAutoDepth.Enabled = true;
                if (AutoDepth)
                {
                    OptAutoDepth.Checked = true;
                    OptDepthSelect.Enabled = false;
                }
                else
                {
                    OptAutoDepth.Checked = false;
                    OptDepthSelect.Enabled = true;
                }
                OptInsane.Enabled = true;
                if (Insane)
                {
                    OptInsane.Checked = true;
                    InsaneDelayTicker.Enabled = true;
                }
                else
                {
                    OptInsane.Checked = false;
                    InsaneDelayTicker.Enabled = false;
                }
                OptRealtime.Enabled = true;
                if (RealtimeLast)
                {
                    OptClearOnRet.Enabled = true;
                    OptRealtime.Checked = true;
                }
                else
                {
                    OptClearOnRet.Enabled = false;
                }
                //                OptRealtime.Checked = RealtimeLast;
                OptClearOnRet.Checked = ClearOnRetLast;
                SecEncMode = false;
                OptSecEnc.Checked = true;
                ModeRDR = false;
            }
            else if (ModeDecRDR.Checked)
            {
                if (Secure)
                {
                    OptSecEnc.Enabled = false;
                }
                SecEncMode = true;
                OptSecDec.Checked = true;
                OptDepthSelect.Enabled = false;
                OptAutoDepth.Enabled = false;
                if (OptRealtime.Checked)
                {
                    RealtimeLast = OptRealtime.Checked;
                    ClearOnRetLast = OptClearOnRet.Checked;
                }
                OptRealtime.Enabled = false;
                OptRealtime.Checked = false;
                OptClearOnRet.Enabled = true;
                OptInsane.Enabled = false;
                InsaneDelayTicker.Enabled = false;
                OptOutputDec.Enabled = false;
                OptOutputHex.Enabled = false;
                LastSpacing = OptSpacing.Checked;
                OptSpacing.Enabled = false;
                ModeRDR = true;
            }
        }
        private void ModeRDR_CheckedChanged(object sender, EventArgs e) {
            UpdateStates();
            UpdateOutput();
        }

        //Source https://stackoverflow.com/a/10177020
        public static class StringCipher {
            // This constant is used to determine the keysize of the encryption algorithm in bits.
            // We divide this by 8 within the code below to get the equivalent number of bytes.
            private const int Keysize = 256;

            // This constant determines the number of iterations for the password bytes generation function.
            private const int DerivationIterations = 1000;

            public static string Encrypt(string plainText, string passPhrase) {
                // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
                // so that the same Salt and IV values can be used when decrypting.  
                var saltStringBytes = Generate256BitsOfRandomEntropy();
                var ivStringBytes = Generate256BitsOfRandomEntropy();
                var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations)) {
                    var keyBytes = password.GetBytes(Keysize / 8);
                    using (var symmetricKey = new RijndaelManaged()) {
                        symmetricKey.BlockSize = 256;
                        symmetricKey.Mode = CipherMode.CBC;
                        symmetricKey.Padding = PaddingMode.PKCS7;
                        using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes)) {
                            using (var memoryStream = new MemoryStream()) {
                                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)) {
                                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                    cryptoStream.FlushFinalBlock();
                                    // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                    var cipherTextBytes = saltStringBytes;
                                    cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                    cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                    memoryStream.Close();
                                    cryptoStream.Close();
                                    return Convert.ToBase64String(cipherTextBytes);
                                }
                            }
                        }
                    }
                }
            }

            public static string Decrypt(string cipherText, string passPhrase) {
                // Get the complete stream of bytes that represent:
                // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
                var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
                // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
                var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
                // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
                var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
                // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
                var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

                using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations)) {
                    var keyBytes = password.GetBytes(Keysize / 8);
                    using (var symmetricKey = new RijndaelManaged()) {
                        symmetricKey.BlockSize = 256;
                        symmetricKey.Mode = CipherMode.CBC;
                        symmetricKey.Padding = PaddingMode.PKCS7;
                        using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes)) {
                            using (var memoryStream = new MemoryStream(cipherTextBytes)) {
                                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)) {
                                    var plainTextBytes = new byte[cipherTextBytes.Length];
                                    var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                    memoryStream.Close();
                                    cryptoStream.Close();
                                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }

            private static byte[] Generate256BitsOfRandomEntropy() {
                var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
                using (var rngCsp = new RNGCryptoServiceProvider()) {
                    // Fill the array with cryptographically secure random bytes.
                    rngCsp.GetBytes(randomBytes);
                }
                return randomBytes;
            }
        }
        private void CpyOut_Click(object sender, EventArgs e) {
            if (Output.Text.Length > 0) {
                Clipboard.SetText(Output.Text);
            }
        }

        private void ClearAll_Click(object sender, EventArgs e) {
            Output.Text = "";
            Input.Text = "";
        }

        private void CpyOutIn_Click(object sender, EventArgs e) {
            if (Output.Text.Length > 0) {
                Input.Text = Output.Text;
            }
        }

/*        private void OutLZMA_CheckedChanged(object sender, EventArgs e) {
            if (OptOutLZMA.Checked) {
                EncLZMA = true;
            } else if (!OptOutLZMA.Checked) {
                EncLZMA = false;
            }
            UpdateOutput();
        }*/

        private void OutBase64_CheckedChanged(object sender, EventArgs e) {
            if (OptOutBase64.Checked) {
                OutputMode = 1;
                UpdateOutput();
                OptOutputHex.Checked= true;
                OptOutputDec.Enabled = false;
                OptOutputHex.Enabled = false;
                LastSpacing = OptSpacing.Checked;
                OptSpacing.Enabled = false;
                EncBase64 = true;
                Spacing = false;
                //OptOutLZMA.Enabled = true;
            } else if (!OptOutBase64.Checked) {
                if (!ModeRDR) {
                    OptOutputDec.Enabled = true;
                    OptOutputHex.Enabled = true;
                    if (OutputMode > 0) {
                        OptSpacing.Enabled = true;
                        OptSpacing.Checked = LastSpacing;
                        Spacing=LastSpacing;
                    }
                }
                EncBase64 = false;
                //OptOutLZMA.Enabled = false;
                //OptOutLZMA.Checked = false;
            }
            UpdateOutput();
        }

        private void OptRealtime_CheckedChanged(object sender, EventArgs e) {
            if (OptRealtime.Checked) {
                Realtime = true;
                //OptClearOnRet.Enabled = true;
            } else if (!OptRealtime.Checked) {
                Realtime = false;
                //OptClearOnRet.Enabled = false;
            }
            UpdateOutput();
        }

        private void OptClearOnRet_CheckedChanged(object sender, EventArgs e) {
            if (OptClearOnRet.Checked) {
                ClearOnRet = true;
            } else if (!OptClearOnRet.Checked) {
                ClearOnRet = false;
            }
            UpdateOutput();
        }
        public static string Base64Encode(string plainText) {
            var plainTextBytes = System.Text.Encoding.ASCII.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData) {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.ASCII.GetString(base64EncodedBytes);
        }
/*        public static byte[] CompressLZMA(byte[] Data) {
            LzmaEncoder EncoderLZMA = new LzmaEncoder(); ;
            MemoryStream OutputBuff = new MemoryStream();
            EncoderLZMA.WriteEndMark = false;
            EncoderLZMA.CompressionLevel.Equals(new LzmaCompressionLevel(9));
            EncoderLZMA.CompressionMode = LzmaCompressionMode.Normal;
            EncoderLZMA.Encode(Data, OutputBuff);
            return OutputBuff.ToArray();
        }
        public static byte[] DecompressLZMA(byte[] Data) {
            MemoryStream InputBuff = new MemoryStream(Data);
            MemoryStream OutputBuff = new MemoryStream();
            //ata.CopyTo(InputBuff,0);
            LzmaReader DecoderLZMA = new LzmaReader(InputBuff);
            DecoderLZMA.CopyTo(OutputBuff);
            return OutputBuff.ToArray();
        }*/
        public static string ByteArrayToString(byte[] ba) {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
        public static byte[] StringToByteArray(String hex) {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
        public static class RC4 {
            public static string Encrypt(string key, string data) {
                Encoding unicode = Encoding.Unicode;

                return Convert.ToBase64String(Encrypt(unicode.GetBytes(key), unicode.GetBytes(data)));
            }

            public static string Decrypt(string key, string data) {
                Encoding unicode = Encoding.Unicode;

                return unicode.GetString(Encrypt(unicode.GetBytes(key), Convert.FromBase64String(data)));
            }

            public static byte[] Encrypt(byte[] key, byte[] data) {
                return EncryptOutput(key, data).ToArray();
            }

            public static byte[] Decrypt(byte[] key, byte[] data) {
                return EncryptOutput(key, data).ToArray();
            }

            private static byte[] EncryptInitalize(byte[] key) {
                byte[] s = Enumerable.Range(0, 256)
                  .Select(i => (byte)i)
                  .ToArray();

                for (int i = 0, j = 0; i < 256; i++) {
                    j = (j + key[i % key.Length] + s[i]) & 255;

                    Swap(s, i, j);
                }

                return s;
            }

            private static IEnumerable<byte> EncryptOutput(byte[] key, IEnumerable<byte> data) {
                byte[] s = EncryptInitalize(key);

                int i = 0;
                int j = 0;

                return data.Select((b) =>
                {
                    i = (i + 1) & 255;
                    j = (j + s[i]) & 255;

                    Swap(s, i, j);

                    return (byte)(b ^ s[(s[i] + s[j]) & 255]);
                });
            }

            private static void Swap(byte[] s, int i, int j) {
                byte c = s[i];

                s[i] = s[j];
                s[j] = c;
            }
        }
    }
}
