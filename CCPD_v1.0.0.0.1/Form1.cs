﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace CCPD_v1._0._0._0._1
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Функция из VisualBasic
        public double[,] Invers(int n, double[,] b)
        {
            int[,] r = new int[10, 4];
            int l = 0;
            int m = 0;
            int i = 0;
            int j = 0;
            int k = 0;
            int ja = 0;
            int jb = 0;
            int nj = 0;
            double s = 0;
            double amax = 0;
            double p = 0;
            double c = 0;
            double[] cc = new double[10];

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    r[i, j] = 0;
                }

                p = Math.Abs(b[i, i]);

                if (p <= 1E-20)
                {
                    k = 2;
                }                                    
                else if (p <= 1)
                {
                    k = 1;
                }                                    
                else if (p < 9)
                {
                    k = 2;
                }
                else
                {
                    k = 3;
                }                                    

                j = 0;

                switch (k)
                {
                    case 1:
                        s = 4;
                        while (p <= 2)
                        {
                            j += 1;
                            p *= s;
                        }
                        break;
                    case 3:
                        s = 1 / 4;
                        while (p >= 9)
                        {
                            j += 1;
                            p *= s;
                        }
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }

                if (k == 3)
                {
                    nj = -j;
                }
                else
                {
                    nj = j;
                }                                    

                cc[i] = Math.Exp(nj * Math.Log(2));
            }

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    b[i, j] = b[i, j] * cc[i] * cc[j];
                }                    
            }                            

            for (i = 0; i < n; i++)
            {
                amax = 0;

                for (j = 0; j < n; j++)
                {
                    if (r[j, 2] != 1)
                    {
                        for (k = 0; k < n; k++)
                        {
                            s = Math.Abs(b[j, k]);
                            if ((r[k, 2] != 1) && (amax < s))
                            {
                                ja = j;
                                jb = k;
                                amax = s;
                            }
                        }                            
                    }                    
                }                                    

                r[jb, 2] = 1;
                r[i, 0] = ja;
                r[i, 1] = jb;

                if (ja != jb)
                {
                    for (m = 0; m < n; m++)
                    {
                        s = b[ja, m];
                        b[ja, m] = b[jb, m];
                        b[jb, m] = s;
                    }
                }               

                s = b[jb, jb];
                b[jb, jb] = 1;

                for (m = 0; m < n; m++)
                {
                    b[jb, m] /= s;
                }                

                for (m = 0; m < n; m++)
                {
                    if (m != jb)
                    {
                        c = b[m, jb];
                        b[m, jb] = 0;
                    }                                            

                    for (l = 0; l < n; l++)
                    {
                        b[m, l] -= b[jb, l] * c;
                    }                                            
                }
            }

            for (i = 0; i < n; i++)
            {
                m = n - i + 1;

                if (r[m, 0] != r[m, 1])
                {
                    ja = r[m, 0];
                    jb = r[m, 1];

                    for (k = 0; k < n; k++)
                    {
                        s = b[k, ja];
                        b[k, ja] = b[k, jb];
                        b[k, jb] = s;
                    }                    
                }
            }

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    b[i, j] = b[i, j] * cc[i] * cc[j];
                }
            }

            return b;
        }

        public Int32 KOM_OV = 1;
        public Int32 N_Particles = 3; //Changed
        public Int32 N_Basis = 2; //Changed
        public Int32 R_ROV = 1;
        public Int32 DIAGRAMA = 1;
        public double S_F = 0.0001;
        public double S_IN_A = 0.000001;
        public double S_I = 0.0001;

        public double T_C = 25.00;
        public double T_K = 299.15;
        public double W_SOL = 0.00;
        public double VISK = 0.008905;
        public double DP = 78.3;
        public double DENS = 0.99707;
        public double M2 = 0.00;
        public double M1 = 18.15;

        public double A_DEBYE = 0.00;
        public double B_DEBYE = 0.00;
        public double A_0A = 3.5;
        public double B_DEB = 0.2;
        public double RT_F = 59.157;
        public double R_A = 3.5;
        public double E0_A = 222.00;
        public double N_E_B = 1.00;

        public string lg_k = "lg(K)";

        public Int32[,] ARR = new Int32[5, 10];
        public String[,] COMPONENTS = new String[1, 10];
        public String[,] BAS_NAME = new String[1, 10];
        public String[,] PARTICLES = new String[1, 15];
        public double[,] NU_MATRIX = new double[15, 10]; //Changed
        public double[,] LGK = new double[15, 1];
        public Int32[,] CHARGE = new Int32[15, 1];
        public double[,] CONC = new double[60, 4];
        public double[,] DATA = new double[60, 1];
        public double[,] LN_A = new double[60, 8];
        public double[,] CO_BAZIS = new double[60, 8];
        public double[] IONIC = new double[60];
        public double[,] LN_GAMMA = new double[60, 10];
        public double[,] C_EQUIL = new double[60, 10];
        public double[] DELTA_LN_A = new double[10];

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e) => MessageBox.Show("CCPD\nversion - 1.0.9");

        private void button1_Click(object sender, EventArgs e)
        {
            KOM_OV = Int32.Parse(textBox1.Text);
            N_Particles = Int32.Parse(textBox2.Text);
            N_Basis = Int32.Parse(textBox3.Text);
            R_ROV = Int32.Parse(textBox4.Text);
            DIAGRAMA = Int32.Parse(textBox5.Text);
            S_F = Double.Parse(textBox6.Text);
            S_IN_A = Double.Parse(textBox7.Text);
            S_I = Double.Parse(textBox8.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Вывод данных масива ARR
            //Ввод значений из датагрид1 для компонентной матрицы
            //Заполнение рядов из массива COMPONENTS

            for (int i = 0; i < N_Basis; i++)
            {
                //Присвоение из PARTICLES данных в BAS_NAME до значения BAZIS
                for (int j = 0; j < 1; j++)
                {
                    BAS_NAME[j, i] = PARTICLES[j, i];
                }
            }

            dataGridView1.RowCount = KOM_OV;
            dataGridView1.ColumnCount = N_Basis;

            for (int i = 0; i < KOM_OV; i++)
            {
                for (int j = 0; j < N_Basis; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = ARR[i, j].ToString();
                    dataGridView1.Rows[i].HeaderCell.Value = COMPONENTS[0, i];
                    dataGridView1.Columns[j].HeaderCell.Value = BAS_NAME[0, j];
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            T_C = Convert.ToDouble(numericUpDown1.Value);
            T_K = T_C + 273.15;
            label19.Text = Convert.ToString(T_K);
            W_SOL = Convert.ToDouble(textBox9.Text);
            VISK = Convert.ToDouble(textBox10.Text);
            DP = Convert.ToDouble(textBox11.Text);
            DENS = Convert.ToDouble(textBox12.Text);
            M2 = Convert.ToDouble(textBox13.Text);
            M1 = Convert.ToDouble(textBox14.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            A_0A = Convert.ToDouble(textBox15.Text);
            B_DEB = Convert.ToDouble(textBox16.Text);
            R_A = Convert.ToDouble(textBox17.Text);
            E0_A = Convert.ToDouble(textBox18.Text);
            N_E_B = Convert.ToDouble(textBox19.Text);
                        
            B_DEBYE = Math.Sqrt(2529.1171 * DENS / DP / T_K);
            A_DEBYE = B_DEBYE * 36283.167 / DP / T_K;

            RT_F = 8.3142 * T_K / 96487 * Math.Log(10) * 1000;

            label29.Text = Convert.ToString(A_DEBYE);
            label30.Text = Convert.ToString(B_DEBYE);
            label31.Text = Convert.ToString(RT_F);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Вывод значений из датагрид1 в массив ARR
            dataGridView1.RowCount = KOM_OV;
            dataGridView1.ColumnCount = N_Basis;

            for (int i = 0; i < KOM_OV; i++)
            {
                for (int j = 0; j < N_Basis; j++)
                {
                    ARR[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                    //dataGridView2.Rows[i].Cells[j].Value = ARR[i, j].ToString();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Вывод значений в датагрид2 из массива COMPONENTS
            dataGridView2.RowCount = 1;
            dataGridView2.ColumnCount = KOM_OV;

            for (int j = 0; j < 1; j++)
            {
                for (int i = 0; i < KOM_OV; i++)
                {
                    dataGridView2.Rows[j].Cells[i].Value = COMPONENTS[j, i];
                    //dataGridView1.Rows[i].HeaderCell.Value = Convert.ToString(i + 1);
                    //dataGridView1.Columns[j].HeaderCell.Value = Convert.ToString(j + 1);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Вывод из датагрид2 в массив COMPONENTS сохранение значений
            dataGridView2.RowCount = 1;
            dataGridView2.ColumnCount = KOM_OV;

            for (int j = 0; j < 1; j++)
            {
                for (int i = 0; i < KOM_OV; i++)
                {
                    COMPONENTS[j, i] = Convert.ToString(dataGridView2.Rows[j].Cells[i].Value);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            /*
            //ПРОВЕРКА

            dataGridView3.RowCount = 1;
            dataGridView3.ColumnCount = KOM_OV;

            for (int j = 0; j < 1; j++)
            {
                for (int i = 0; i < KOM_OV; i++)
                {
                    dataGridView3.Rows[j].Cells[i].Value = COMPONENTS[j, i];
                    //dataGridView1.Rows[i].HeaderCell.Value = Convert.ToString(i + 1);
                    //dataGridView1.Columns[j].HeaderCell.Value = Convert.ToString(j + 1);
                }
            }
            */

            //Вывод значений в датагрид3 из массива PARTICLES
            dataGridView3.RowCount = 1;
            dataGridView3.ColumnCount = N_Particles;

            for (int j = 0; j < 1; j++)
            {
                for (int i = 0; i < N_Particles; i++)
                {
                    dataGridView3.Rows[j].Cells[i].Value = PARTICLES[j, i];
                    //dataGridView1.Rows[i].HeaderCell.Value = Convert.ToString(i + 1);
                    //dataGridView1.Columns[j].HeaderCell.Value = Convert.ToString(j + 1);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Вывод из датагрид3 в массив PARTICLES сохранение значений
            dataGridView3.RowCount = 1;
            dataGridView3.ColumnCount = N_Particles;

            for (int j = 0; j < 1; j++)
            {
                for (int i = 0; i < N_Particles; i++)
                {
                    PARTICLES[j, i] = Convert.ToString(dataGridView3.Rows[j].Cells[i].Value);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Стехиометрическая матрица
            dataGridView4.RowCount = N_Particles;
            dataGridView4.ColumnCount = N_Basis;

            for (int i = 0; i < N_Basis; i++)
            {
                NU_MATRIX[i, i] = 1;
            }

            for (int j = 0; j < N_Particles; j++)
            {
                for (int i = 0; i < N_Basis; i++)
                {
                    dataGridView4.Rows[j].Cells[i].Value = NU_MATRIX[j, i].ToString();
                    dataGridView4.Rows[j].HeaderCell.Value = PARTICLES[0, j];
                    dataGridView4.Columns[i].HeaderCell.Value = BAS_NAME[0, i];
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Вывод значений стехиометрической матрицы из датагрид4 в массив NU_MATRIX
            dataGridView4.RowCount = N_Particles;
            dataGridView4.ColumnCount = N_Basis;

            for (int i = 0; i < N_Particles; i++)
            {
                for (int j = 0; j < N_Basis; j++)
                {
                    NU_MATRIX[i, j] = Convert.ToDouble(dataGridView4.Rows[i].Cells[j].Value);
                }
            }
        }
                
        private void button12_Click(object sender, EventArgs e)
        {
            //Константы
            dataGridView5.RowCount = N_Particles;
            dataGridView5.ColumnCount = 1;

            for (int j = 0; j < N_Particles; j++)
            {
                for (int i = 0; i < 1; i++)
                {
                    dataGridView5.Rows[j].Cells[i].Value = LGK[j, i].ToString();
                    dataGridView5.Rows[j].HeaderCell.Value = PARTICLES[0, j];
                    dataGridView5.Columns[i].HeaderCell.Value = lg_k;
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //Вывод из грид5 данных в массив LGK
            dataGridView5.RowCount = N_Particles;
            dataGridView5.ColumnCount = 1;

            for (int i = 0; i < N_Particles; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    LGK[i, j] = Convert.ToDouble(dataGridView5.Rows[i].Cells[j].Value);
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //Вывод в грид6 из массива CHARGE значений
            dataGridView6.RowCount = N_Particles;
            dataGridView6.ColumnCount = 1;

            for (int j = 0; j < N_Particles; j++)
            {
                for (int i = 0; i < 1; i++)
                {
                    dataGridView6.Rows[j].Cells[i].Value = CHARGE[j, i].ToString();
                    dataGridView6.Rows[j].HeaderCell.Value = PARTICLES[0, j];
                    dataGridView6.Columns[i].HeaderCell.Value = "Z";
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //Вывод из грид6 данных в массив CHARGE
            dataGridView6.RowCount = N_Particles;
            dataGridView6.ColumnCount = 1;

            for (int i = 0; i < N_Particles; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    CHARGE[i, j] = Convert.ToInt32(dataGridView6.Rows[i].Cells[j].Value);
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //Эксперементальные данные. Вывод из масива CONC в грид7
            dataGridView7.RowCount = R_ROV;
            dataGridView7.ColumnCount = KOM_OV;

            for (int j = 0; j < R_ROV; j++)
            {
                for (int i = 0; i < KOM_OV; i++)
                {
                    dataGridView7.Rows[j].Cells[i].Value = CONC[j, i].ToString();
                    dataGridView7.Rows[j].HeaderCell.Value = Convert.ToString(j + 1);
                    dataGridView7.Columns[i].HeaderCell.Value = COMPONENTS[0, i];
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //Вывод значений Эксперементальных данных из датагрид7 в массив CONC
            dataGridView7.RowCount = R_ROV;
            dataGridView7.ColumnCount = KOM_OV;

            for (int i = 0; i < R_ROV; i++)
            {
                for (int j = 0; j < KOM_OV; j++)
                {
                    CONC[i, j] = Convert.ToDouble(dataGridView7.Rows[i].Cells[j].Value);
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //Измерения. Вывод из масива DATA в грид8
            dataGridView8.RowCount = R_ROV;
            dataGridView8.ColumnCount = 1;

            for (int j = 0; j < R_ROV; j++)
            {
                for (int i = 0; i < 1; i++)
                {
                    dataGridView8.Rows[j].Cells[i].Value = DATA[j, i].ToString();
                    dataGridView8.Rows[j].HeaderCell.Value = Convert.ToString(j + 1);
                    dataGridView8.Columns[i].HeaderCell.Value = "Data";
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //Вывод значений Измерений из датагрид8 в массив DATA
            dataGridView8.RowCount = R_ROV;
            dataGridView8.ColumnCount = 1;

            for (int i = 0; i < R_ROV; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    DATA[i, j] = Convert.ToDouble(dataGridView8.Rows[i].Cells[j].Value);
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //Подготова начальных значений
            double determinant = 0;

            double sum, s1, s3, sum_delta;
            double ion_1, ion_2, eLn;
            int count = 0;
            eLn = Math.Log(10);
            double[,] H = new double[10, 10];//нет в новой версии 1.0.7
            double[,] H0 = new double[10, 10];//нет в новой версии 1.0.7
            double[,] H1 = new double[10, 10];//нет в новой версии 1.0.7

            for (int k = 0; k < R_ROV; k++)
            {
                count = 0;

                for (int j = 0; j < N_Basis; j++)
                {
                    s1 = 0;

                    for (int i = 0; i < KOM_OV; i++)
                    {
                        s1 = s1 + CONC[k, i] * ARR[i, j];
                    }

                    CO_BAZIS[k, j] = s1;

                    if (s1 > 0)
                    {
                        LN_A[k, j] = Math.Log(s1 * 2);
                    }
                    else
                    {
                        LN_A[k, j] = -30;
                        CO_BAZIS[k, j] = 1.0E-12;
                    }
                }

                IONIC[k] = 0;
            } //NEED TO REVIEW

            double[] G = new double[10];//нет в новой версии 1.0.7

            //цикл по растворам

            for (int k = 0; k < R_ROV; k++)
            {
                ion_1 = 1E-10;
                ion_2 = 10;
            A:;
                s1 = Math.Sqrt(ion_1);
                s3 = (-A_DEBYE * s1 / (1 + A_0A * B_DEBYE * s1) + B_DEB * ion_1);

                for (int i = 0; i < N_Particles; i++)
                {
                    sum = 0;

                    for (int j = 0; j < N_Basis; j++)
                    {
                        sum = sum + NU_MATRIX[i, j] * LN_A[k, j];
                    }

                    LN_GAMMA[k, i] = eLn * Math.Pow(CHARGE[i, 0], 2) * s3;
                    C_EQUIL[k, i] = Math.Exp(LGK[i, 0]) * eLn + sum - LN_GAMMA[k, i];
                }

                s3 = 0;

                for (int L = 0; L < N_Basis; L++)
                {
                    sum = 0;

                    for (int i = 0; i < N_Particles; i++)
                    {
                        sum = sum + NU_MATRIX[i, L] * C_EQUIL[k, i];
                    }

                    G[L] = CO_BAZIS[k, L] - sum;
                    s3 = s3 + Math.Abs(G[L]) / CO_BAZIS[k, L];
                }

                if (s3 < 1E-3)
                {
                    goto B;
                }

                //
                //
                //
                //создание матрицы H()

                for (int L = 0; L < N_Basis; L++)
                {
                    for (int j = 1; j < N_Basis; j++)
                    {
                        sum = 0;

                        for (int i = 0; i < N_Particles; i++)
                        {
                            sum += NU_MATRIX[i, L] * C_EQUIL[k, i] * NU_MATRIX[i, j];
                        }

                        H[L, j] = sum;
                        H[j, L] = sum;
                        H1[L, j] = sum;
                        H1[j, L] = sum;
                    }
                }

                determinant = H[0, 0] * H[1, 1] - H[1, 0] * H[0, 1];
                H0[0, 0] = H[1, 1] / determinant;
                H0[0, 1] = - H[0, 1] / determinant;
                H0[1, 0] = - H[1, 0] / determinant;
                H0[1, 1] = H[0, 0] / determinant;

                //Invers(N_Basis, H);
                //H0 = H;

                //ПРОВЕРКА ОБРАЩЕНИЯ

                s1 = 0; 

                for (int i = 0; i < N_Basis; i++)
                {
                    for (int j = 0; j < N_Basis; j++)
                    {
                        sum = 0;

                        for (int L = 0; L < N_Basis; L++)
                        {
                            sum = sum + H0[i, L] * H1[L, j];
                        }

                        s1 = s1 + Math.Abs(sum);
                    }
                }

                //textBox20.Text = Convert.ToString(s1);
                //MessageBox.Show(Convert.ToString(s1));

                //Расчет поправок - произведение H^(-1)*G

                sum_delta = 0;

                for (int j = 0; j < N_Basis; j++)
                {
                    sum = 0;

                    for (int L = 0; L < N_Basis; L++)
                    {
                        sum += H0[j, L] * G[L];
                    }

                    DELTA_LN_A[j] = sum;
                    sum_delta += Math.Abs(sum);
                }

                //Критерий выхода по норме поправок

                if (sum_delta < 1E-5)
                {
                    goto B;
                }

                for (int j = 0; j < N_Basis; j++)
                {
                    LN_A[k, j] = LN_A[k, j] + DELTA_LN_A[j] / 3;
                }

                count += 1;

                //textBox21.Text = Convert.ToString(count);
                //MessageBox.Show(Convert.ToString(count));

                goto A;

            B:;

                sum = 0;

                for (int i = 0; i < N_Particles; i++)
                {
                    sum += Math.Pow(CHARGE[i, 0], 2) * C_EQUIL[k, i];
                }

                ion_1 = sum / 2;
                IONIC[k] = ion_1;

                if (Math.Abs((ion_2 - ion_1) / ion_1) > 1E-3)
                {
                    ion_2 = ion_1;
                    goto A;
                }
            }

            //Эксперементальные данные. Вывод из масива CONC в грид7
            /*
            dataGridView9.RowCount = R_ROV;
            dataGridView9.ColumnCount = BAZIS;

            for (int j = 0; j < R_ROV; j++)
            {
                for (int i = 0; i < BAZIS; i++)
                {
                    dataGridView9.Rows[j].Cells[i].Value = LN_A[j, i].ToString();
                    //dataGridView9.Rows[j].HeaderCell.Value = Convert.ToString(j + 1);
                    //dataGridView9.Columns[i].HeaderCell.Value = COMPONENTS[0, i];
                }
            }*/
        }

        private void button21_Click(object sender, EventArgs e)
        {
            //TEST BUTTON #21
            //Проверка обращения матрицы

            //Проверочный тестовый массив
            //{{1.00, 7.00, 9.00}, {2.00, 6.00, 2.00}, {4.00, 74.00, 0.00}};
            double[,] MAZ = new double[3,3] { { 1.00, 7.00, 9.00 }, { 2.00, 6.00, 2.00 }, { 4.00, 74.00, 0.00 } };
            //Запись значений из тестового массива для проверки
            double[,] MAZZ = new double[3,3];

            //Проверка работы функции
            MAZZ = Invers(3, MAZ);            
        }
    }
}

