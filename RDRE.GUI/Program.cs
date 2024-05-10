using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace RDRE.GUI {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());

        }
    }
    public static class Tools {
/*        public static string DisplayHertz(decimal hz) {
            const int scale = 1000;
            string[] orders = new string[] { "gHz", "mHz", "kHz", "Hz" };
            long max = (long)Math.Pow(scale, orders.Length - 1);
            foreach (string order in orders) {
                if (hz > max) return string.Format("{0:##.##} {1}", decimal.Divide(hz, max), order);
                max /= scale;
            }
            return "0 Hz";
        }

        public static string DisplayTime(decimal ns) {
            const int scale = 1000;
            string[] orders = new string[] { "Sec", "mSec", "uSec", "nSec" };
            long max = (long)Math.Pow(scale, orders.Length - 1);
            foreach (string order in orders) {
                if (ns > max) return string.Format("{0:##.##} {1}", decimal.Divide(ns, max), order);
                max /= (long)scale;
            }
            return "0 ns";
        }
*/    }
    public static class RDRE {
        public static double CharTime = 0;
        public static double CharTimeAvg = 0;
        public static int CharTimeCount = 0;
        public static double CurrentProgress = 0;
        private class CharMap {
            public static byte[] Char = new byte[97];
            public static int[] Index = new int[97];
            public static int GetIndex(byte c) {
                for (int x = 0; x < 97; x += 1) {
                    if (CharMap.Char[x] == c) return CharMap.Index[x];
                }
                return 0;
            }
            public static byte GetChar(int i) {
                for (int x = 0; x < 97; x += 1) {
                    if (CharMap.Index[x] == i) return CharMap.Char[x];
                }
                return 0x00;
            }
        }
        private class RandomPool {
            public static int Mode = 2; //{ get; set; }//v1, wait rand, v2 
            public static int Depth = 4096; //{ get; set; }
            static int[,] Pool;
            static Random RandomInt = new Random();
            public static void Init() {//[Re]Initialize RandomPool
                if (Mode == 1) Depth = 1;
                if (Mode == 0) return;
                Pool = new int[9, 1 + Depth];
                clear();
                fill();
                return;
            }
            public static int Get(int Root) {//Get RandomRoot, and destroy.
                if (Mode == 0) {
                    int Rand;
                    int NewRoot;
                    do {
                        Rand = RandomInt.Next(0x1, 0xFFFF);
                        NewRoot = GetRoot(Rand);
                    } while (NewRoot != Root);
                    return Rand;
                }
                Root--;
                if (Pool[Root, 0] <= 0) fill();
                int Return = Pool[Root, Depth - Pool[Root, 0] + 1];
                Pool[Root, Depth - Pool[Root, 0] + 1] = 0;
                Pool[Root, 0]--;
                return Return;
            }
            private static void fill() {//Get RandomRoot, and destroy.
                int Rand;
                int Root;
                bool Done;
                while (true) {
                    Done = true;
                    Rand = RandomInt.Next(0x1, 0xFFFF);
                    Root = GetRoot2(Rand) - 1;
                    if (Pool[Root, 0] < Depth) {
                        for (int i = 1; i <= Depth; i++) {
                            if (Pool[Root, i] == 0) {
                                Pool[Root, i] = Rand;
                                Pool[Root, 0]++;
                                break;
                            }
                        }
                    }
                    for (int i = 0; i <= 8; i++) {
                        if (Pool[i, 0] < Depth) Done = false;
                    }
                    if (!Done) {
                        continue;
                    } else {
                        break;
                    }
                }
            }
            private static void clear() {
                for (int x = 0; x < Pool.GetLength(0); x += 1) {
                    for (int y = 0; y < Pool.GetLength(1); y += 1) {
                        Pool[x, y] = 0;
                    }
                }
            }

            public static int GetRoot(int i)
            {
                int j;
                do
                {
                    j = 0;
                    do
                    {
                        j += i % 10;
                        i /= 10;
                    } while (i > 0.9);
                    i = j;
                } while (j >= 10);
                return j;
            }
            public static int GetRoot2(int i)
            {
                int j;
                j = i % 9;
                if (j == 0) return 9;
                return j;
            }

        }
        public static void SetDepth(int NewDepth) {
            if (RandomPool.Depth == NewDepth) return;
            RandomPool.Depth = NewDepth;
            RandomPool.Init();
        }
        public static void SetMode(int NewMode) {
            if (RandomPool.Mode == NewMode) return;
            RandomPool.Mode = NewMode;
            RandomPool.Init();
        }
        public static void Init() {
            byte[] bIndex = { 0x42, 0x60, 0x03, 0x22, 0x05, 0x06, 0x07, 0x40, 0x08, 0x0C, 0x0A, 0x0B, 0x0F, 0x41, 0x1F, 0x0D, 0x3D, 0x5D, 0x3F, 0x5F, 0x3E, 0x5E, 0x1D, 0x1C, 0x09, 0x04, 0x0E, 0x1E, 0x10, 0x20, 0x11, 0x21, 0x02, 0x01, 0x00 };
            byte[] Dict = new byte[97];
            Dict[0] = 0x09;
            Dict[1] = 0x0A;
            int i = 2;
            for (byte j = 0x20; j <= 0x7E; j++) {
                Dict[i] = j;
                i++;
            }
            i = 0;
            byte[] SeqAlNumMap = { 0x30, 0x39, 0x61, 0x7A, 0x41, 0x5A };
            for (byte j = 0; j <= 5; j += 2) {
                for (byte k = SeqAlNumMap[j]; k <= SeqAlNumMap[j + 1]; k++) {
                    CharMap.Char[i] = k;
                    i++;
                }
            }
            i = 62;
            foreach (int j in bIndex) {
                CharMap.Char[i] = Dict[j];
                i++;
            }
            i = 111;
            for (int j = 0; j <= 96; j++) {
                CharMap.Index[j] = i;
                i++;
                while (i.ToString().Contains("0")) {
                    i++;
                }
            }
            //Tools.PrintInt("",CharMap.Index);
            //Debug.WriteLine(i);
            RandomPool.Init();

        }
        public static int AutoDepth(string Input) {
            int Index;
            int maxDepth;
            int[] Roots = new int[10];
            foreach (byte chr in Input) {
                Index = CharMap.GetIndex(chr);
                int i;
                i = 0;
                if (Index == 0) {
                    continue;
                }
                do {
                    i = Index % 10;
                    Roots[i] += 1;
                    Index /= 10;
                } while (Index > 0.9);
            }
            maxDepth = Roots.Max();
            maxDepth = (int)Math.Pow(2, Math.Ceiling(Math.Log(maxDepth) / Math.Log(2)));
            RDRE.SetDepth(maxDepth);
            return maxDepth;
        }
        //228
        public static string DecodeString(string Input) {
            string Output = "";
            uint[] DecBuffer= new uint[Input.Length];
            uint[] aIndex = new uint[3];
            int Index = 0;
            Regex ValidDec = new Regex(@"^[0123456789 ]+$");
            Regex ValidHexSp = new Regex(@"^[0123456789ABCDEF ]+$");
            Regex ValidHex = new Regex(@"^[0123456789ABCDEF]+$");
            //Debug.WriteLine(Input);
            if (ValidDec.IsMatch(Input)) {
                string[] DecBuffTmp=Input.Split(new string[] {" 0 "," "}, StringSplitOptions.None);
                DecBuffer = new uint[DecBuffTmp.Length];
                for (int i = 0; i < DecBuffTmp.Length-1; i++) {
                    DecBuffer[i] = Convert.ToUInt32(DecBuffTmp[i]);
                    //Debug.WriteLine(DecBuffer[i]);
                }
            } else if (ValidHexSp.IsMatch(Input)) {
                if (!ValidHex.IsMatch(Input)) {
                    Input = Input.Replace(" ", "");
                    //Debug.WriteLine(Input);
                }
                if (Input.Length % 4 != 0) {
                    return "Invalid Input Data Found!";
                }
                //Debug.WriteLine(Input.Length);
                //Debug.WriteLine(Input.Length/4);
                DecBuffer = new uint[Input.Length/4];
                for (int i = 0; i < DecBuffer.Length; i++) {
                    DecBuffer[i] = Convert.ToUInt32(Input.Substring(i * 4, 4), 16);
                }
                //Debug.WriteLine(DecBuffer.Length);
                //Debug.WriteLine(DecBuffer.Length/3);
            } else {
                return "Invalid Input Data Found!";
            }
            for (int i = 0; i <= DecBuffer.Length-3; i+=3) {
                Index = RandomPool.GetRoot((int)DecBuffer[i+2]) * 100;//Convert.ToInt32(Math.Pow(10, 3));
                Index += RandomPool.GetRoot((int)DecBuffer[i+1]) * 10;//Convert.ToInt32(Math.Pow(10, 2));
                Index += RandomPool.GetRoot((int)DecBuffer[i]); //Convert.ToInt32(Math.Pow(10, 1));
                Output+=(char)CharMap.GetChar(Index);
                Debug.WriteLine(Index);
            }

            //Detect Input Type
            //Decimal,Hex,Hex /w Spacing
            return Output;
        }
        public static string EncodeString(string Input, int Mode = 0, bool Spaceing = false) {
            int Index;
            int Pos = 0;
            string Output = "";
            string Invalid = "";
            int Char;
            //Stopwatch stopWatch = new Stopwatch();
            int InputSize = Input.Length;

            foreach (byte chr in Input) {
                //stopWatch = Stopwatch.StartNew();
                Index = CharMap.GetIndex(chr);
                int i;
                i = 0;
                if (Index == 0) {
                    Invalid += chr + "@" + Pos + ", ";
                    continue;
                }
                //Debug.WriteLine(Index);
                do {
                    i = Index % 10;
                    if (Mode == 0) {
                        Output += RandomPool.Get(i) + " ";
                    } else if (Mode == 1) {
                        Output += RandomPool.Get(i).ToString("X4");
                        if (Spaceing) {
                            Output += " ";
                        }
                        //} else if (Mode == 3) {
                        //    Output += Convert.ToChar(RandomPool.Get(i));
                    }
                    Index /= 10;
                } while (Index > 0.9);
                if (Mode == 0) {
                    Output += "0 ";
                }
                Pos++;
                //CurrentProgress = ((double)Pos / Input.Length) * 1000;
                //Debug.WriteLine((Input.Length));
                //Debug.WriteLine((Pos));
                //Debug.WriteLine(((double)Pos /Input.Length)*1000);
                //Main.UpdateProgress(CurrentProgress);
                //Main.UpdateProgress
                //Main.Progress;
                //RDRE.CharTime = stopWatch.Elapsed.TotalMilliseconds;
                //RDRE.CharTimeAvg += CharTime;
                //RDRE.CharTimeCount++;
            }
            if (Invalid.Length > 0) {
                Console.WriteLine("Invalid Characters:" + Invalid);
            }
            return Output;
        }
    }
}
