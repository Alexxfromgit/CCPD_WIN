using System;
using System.Windows.Forms;
using CCPD_v1._0._0._0._1.Data;
using CCPD_v1._0._0._0._1.Utilities;

namespace CCPD_v1._0._0._0._1
{
    public partial class Form1 : Form
    {
        private readonly TaskConditionsData _taskConditionsData = new TaskConditionsData();
        private readonly PropertiesData _propertiesData = new PropertiesData();
        private readonly ParametersData _parametersData = new ParametersData();
        private readonly ComponentsData _componentsData = new ComponentsData();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO::Implement Logic Here
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
            => MessageBox.Show(Constants.ProgramVersion);

        private void AcceptTaskConditionsButtonClick(object sender, EventArgs e)
        {
            _taskConditionsData.KOM_OV = int.Parse(ComOvTextBox.Text);
            _taskConditionsData.N_Particles = int.Parse(ParticlesTextBox.Text);
            _taskConditionsData.N_Basis = int.Parse(BasisTextBox.Text);
            _taskConditionsData.R_ROV = int.Parse(RrovTextBox.Text);
            _taskConditionsData.DIAGRAMA = int.Parse(DiagramTextBox.Text);
            _taskConditionsData.S_F = double.Parse(SFTextBox.Text);
            _taskConditionsData.S_IN_A = double.Parse(SLnATextBox.Text);
            _taskConditionsData.S_I = double.Parse(SLLoTextBox.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Вывод данных масива ARR
            //Ввод значений из датагрид1 для компонентной матрицы
            //Заполнение рядов из массива COMPONENTS
            for (int i = 0; i < _taskConditionsData.N_Basis; i++)
            {
                //Присвоение из PARTICLES данных в BAS_NAME до значения BAZIS
                for (int j = 0; j < 1; j++)
                {
                    _componentsData.BAS_NAME[j, i] = _componentsData.PARTICLES[j, i];
                }
            }

            dataGridView1.RowCount = _taskConditionsData.KOM_OV;
            dataGridView1.ColumnCount = _taskConditionsData.N_Basis;

            for (int i = 0; i < _taskConditionsData.KOM_OV; i++)
            {
                for (int j = 0; j < _taskConditionsData.N_Basis; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = _componentsData.ARR[i, j].ToString();
                    dataGridView1.Rows[i].HeaderCell.Value = _componentsData.COMPONENTS[0, i];
                    dataGridView1.Columns[j].HeaderCell.Value = _componentsData.BAS_NAME[0, j];
                }
            }
        }

        private void AcceptPropertiesButtonClick(object sender, EventArgs e)
        {
            _propertiesData.T_C = double.Parse(numericUpDown1.Value.ToString());
            _propertiesData.T_K = _propertiesData.T_C + 273.15;
            TkLabel.Text = _propertiesData.T_K.ToString();
            _propertiesData.W_SOL = double.Parse(WSolTextBox.Text);
            _propertiesData.VISK = double.Parse(ViscosityTextBox.Text);
            _propertiesData.DP = double.Parse(DPTextBox.Text);
            _propertiesData.DENS = double.Parse(DensityTextBox.Text);
            _propertiesData.M2 = double.Parse(M2TextBox.Text);
            _propertiesData.M1 = double.Parse(M1TextBox.Text);
        }

        private void AcceptParametersButtonClick(object sender, EventArgs e)
        {
            _parametersData.A_0A = double.Parse(A0ATextBox.Text);
            _parametersData.B_DEB = double.Parse(BTextBox.Text);
            _parametersData.R_A = double.Parse(RATextBox.Text);
            _parametersData.E0_A = double.Parse(E0ATextBox.Text);
            _parametersData.N_E_B = double.Parse(NebTextBox.Text);

            _parametersData.B_DEBYE = Math.Sqrt(2529.1171 * _propertiesData.DENS / _propertiesData.DP / _propertiesData.T_K);
            _parametersData.A_DEBYE = _parametersData.B_DEBYE * 36283.167 / _propertiesData.DP / _propertiesData.T_K;
            _parametersData.RT_F = 8.3142 * _propertiesData.T_K / 96487 * Math.Log(10) * 1000;

            ADebyeLabel.Text = _parametersData.A_DEBYE.ToString();
            BDebyeLabel.Text = _parametersData.B_DEBYE.ToString();
            RTFLabel.Text = _parametersData.RT_F.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Вывод значений из датагрид1 в массив ARR
            dataGridView1.RowCount = _taskConditionsData.KOM_OV;
            dataGridView1.ColumnCount = _taskConditionsData.N_Basis;

            for (int i = 0; i < _taskConditionsData.KOM_OV; i++)
            {
                for (int j = 0; j < _taskConditionsData.N_Basis; j++)
                {
                    _componentsData.ARR[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                    //dataGridView2.Rows[i].Cells[j].Value = ARR[i, j].ToString();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Вывод значений в датагрид2 из массива COMPONENTS
            dataGridView2.RowCount = 1;
            dataGridView2.ColumnCount = _taskConditionsData.KOM_OV;

            for (int j = 0; j < 1; j++)
            {
                for (int i = 0; i < _taskConditionsData.KOM_OV; i++)
                {
                    dataGridView2.Rows[j].Cells[i].Value = _componentsData.COMPONENTS[j, i];
                    //dataGridView1.Rows[i].HeaderCell.Value = Convert.ToString(i + 1);
                    //dataGridView1.Columns[j].HeaderCell.Value = Convert.ToString(j + 1);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Вывод из датагрид2 в массив COMPONENTS сохранение значений
            dataGridView2.RowCount = 1;
            dataGridView2.ColumnCount = _taskConditionsData.KOM_OV;

            for (int j = 0; j < 1; j++)
            {
                for (int i = 0; i < _taskConditionsData.KOM_OV; i++)
                {
                    _componentsData.COMPONENTS[j, i] = Convert.ToString(dataGridView2.Rows[j].Cells[i].Value);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            /*
            //Check

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
            dataGridView3.ColumnCount = _taskConditionsData.N_Particles;

            for (int j = 0; j < 1; j++)
            {
                for (int i = 0; i < _taskConditionsData.N_Particles; i++)
                {
                    dataGridView3.Rows[j].Cells[i].Value = _componentsData.PARTICLES[j, i];
                    //dataGridView1.Rows[i].HeaderCell.Value = Convert.ToString(i + 1);
                    //dataGridView1.Columns[j].HeaderCell.Value = Convert.ToString(j + 1);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Вывод из датагрид3 в массив PARTICLES сохранение значений
            dataGridView3.RowCount = 1;
            dataGridView3.ColumnCount = _taskConditionsData.N_Particles;

            for (int j = 0; j < 1; j++)
            {
                for (int i = 0; i < _taskConditionsData.N_Particles; i++)
                {
                    _componentsData.PARTICLES[j, i] = Convert.ToString(dataGridView3.Rows[j].Cells[i].Value);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Стехиометрическая матрица
            dataGridView4.RowCount = _taskConditionsData.N_Particles;
            dataGridView4.ColumnCount = _taskConditionsData.N_Basis;

            for (int i = 0; i < _taskConditionsData.N_Basis; i++)
            {
                _componentsData.NU_MATRIX[i, i] = 1;
            }

            for (int j = 0; j < _taskConditionsData.N_Particles; j++)
            {
                for (int i = 0; i < _taskConditionsData.N_Basis; i++)
                {
                    dataGridView4.Rows[j].Cells[i].Value = _componentsData.NU_MATRIX[j, i].ToString();
                    dataGridView4.Rows[j].HeaderCell.Value = _componentsData.PARTICLES[0, j];
                    dataGridView4.Columns[i].HeaderCell.Value = _componentsData.BAS_NAME[0, i];
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Вывод значений стехиометрической матрицы из датагрид4 в массив NU_MATRIX
            dataGridView4.RowCount = _taskConditionsData.N_Particles;
            dataGridView4.ColumnCount = _taskConditionsData.N_Basis;

            for (int i = 0; i < _taskConditionsData.N_Particles; i++)
            {
                for (int j = 0; j < _taskConditionsData.N_Basis; j++)
                {
                    _componentsData.NU_MATRIX[i, j] = Convert.ToDouble(dataGridView4.Rows[i].Cells[j].Value);
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //Constants
            dataGridView5.RowCount = _taskConditionsData.N_Particles;
            dataGridView5.ColumnCount = 1;

            for (int j = 0; j < _taskConditionsData.N_Particles; j++)
            {
                for (int i = 0; i < 1; i++)
                {
                    dataGridView5.Rows[j].Cells[i].Value = _componentsData.LGK[j, i].ToString();
                    dataGridView5.Rows[j].HeaderCell.Value = _componentsData.PARTICLES[0, j];
                    dataGridView5.Columns[i].HeaderCell.Value = Constants.Lgk;
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //Вывод из грид5 данных в массив LGK
            dataGridView5.RowCount = _taskConditionsData.N_Particles;
            dataGridView5.ColumnCount = 1;

            for (int i = 0; i < _taskConditionsData.N_Particles; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    _componentsData.LGK[i, j] = Convert.ToDouble(dataGridView5.Rows[i].Cells[j].Value);
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //Вывод в грид6 из массива CHARGE значений
            dataGridView6.RowCount = _taskConditionsData.N_Particles;
            dataGridView6.ColumnCount = 1;

            for (int j = 0; j < _taskConditionsData.N_Particles; j++)
            {
                for (int i = 0; i < 1; i++)
                {
                    dataGridView6.Rows[j].Cells[i].Value = _componentsData.CHARGE[j, i].ToString();
                    dataGridView6.Rows[j].HeaderCell.Value = _componentsData.PARTICLES[0, j];
                    dataGridView6.Columns[i].HeaderCell.Value = Constants.ZValue;
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //Вывод из грид6 данных в массив CHARGE
            dataGridView6.RowCount = _taskConditionsData.N_Particles;
            dataGridView6.ColumnCount = 1;

            for (int i = 0; i < _taskConditionsData.N_Particles; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    _componentsData.CHARGE[i, j] = Convert.ToInt32(dataGridView6.Rows[i].Cells[j].Value);
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //Эксперементальные данные. Вывод из масива CONC в грид7
            dataGridView7.RowCount = _taskConditionsData.R_ROV;
            dataGridView7.ColumnCount = _taskConditionsData.KOM_OV;

            for (int j = 0; j < _taskConditionsData.R_ROV; j++)
            {
                for (int i = 0; i < _taskConditionsData.KOM_OV; i++)
                {
                    dataGridView7.Rows[j].Cells[i].Value = _componentsData.CONC[j, i].ToString();
                    dataGridView7.Rows[j].HeaderCell.Value = Convert.ToString(j + 1);
                    dataGridView7.Columns[i].HeaderCell.Value = _componentsData.COMPONENTS[0, i];
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //Вывод значений Эксперементальных данных из датагрид7 в массив CONC
            dataGridView7.RowCount = _taskConditionsData.R_ROV;
            dataGridView7.ColumnCount = _taskConditionsData.KOM_OV;

            for (int i = 0; i < _taskConditionsData.R_ROV; i++)
            {
                for (int j = 0; j < _taskConditionsData.KOM_OV; j++)
                {
                    _componentsData.CONC[i, j] = Convert.ToDouble(dataGridView7.Rows[i].Cells[j].Value);
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //Измерения. Вывод из масива DATA в грид8
            dataGridView8.RowCount = _taskConditionsData.R_ROV;
            dataGridView8.ColumnCount = 1;

            for (int j = 0; j < _taskConditionsData.R_ROV; j++)
            {
                for (int i = 0; i < 1; i++)
                {
                    dataGridView8.Rows[j].Cells[i].Value = _componentsData.DATA[j, i].ToString();
                    dataGridView8.Rows[j].HeaderCell.Value = Convert.ToString(j + 1);
                    dataGridView8.Columns[i].HeaderCell.Value = "Data";
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //Вывод значений Измерений из датагрид8 в массив DATA
            dataGridView8.RowCount = _taskConditionsData.R_ROV;
            dataGridView8.ColumnCount = 1;

            for (int i = 0; i < _taskConditionsData.R_ROV; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    _componentsData.DATA[i, j] = Convert.ToDouble(dataGridView8.Rows[i].Cells[j].Value);
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //TODO::Matrix function is not working
            /*
            //Подготова начальных значений
            double determinant = 0;

            double sum, s1, s3, sum_delta;
            double ion_1, ion_2, eLn;
            int count = 0;
            eLn = Math.Log(10);
            double[,] H = new double[10, 10];//Not in the version 1.0.7
            double[,] H0 = new double[10, 10];//Not in the version 1.0.7
            double[,] H1 = new double[10, 10];//Not in the version 1.0.7

            for (int k = 0; k < _taskConditionsData.R_ROV; k++)
            {
                count = 0;

                for (int j = 0; j < _taskConditionsData.N_Basis; j++)
                {
                    s1 = 0;

                    for (int i = 0; i < _taskConditionsData.KOM_OV; i++)
                    {
                        s1 = s1 + _componentsData.CONC[k, i] * _componentsData.ARR[i, j];
                    }

                    _componentsData.CO_BAZIS[k, j] = s1;

                    if (s1 > 0)
                    {
                        _componentsData.LN_A[k, j] = Math.Log(s1 * 2);
                    }
                    else
                    {
                        _componentsData.LN_A[k, j] = -30;
                        _componentsData.CO_BAZIS[k, j] = 1.0E-12;
                    }
                }

                _componentsData.IONIC[k] = 0;
            } //NEED TO REVIEW

            double[] G = new double[10];//Not in the version 1.0.7

            //цикл по растворам

            for (int k = 0; k < _taskConditionsData.R_ROV; k++)
            {
                ion_1 = 1E-10;
                ion_2 = 10;
            A:;
                s1 = Math.Sqrt(ion_1);
                s3 = (-_parametersData.A_DEBYE * s1 / (1 + _parametersData.A_0A * _parametersData.B_DEBYE * s1) + _parametersData.B_DEB * ion_1);

                for (int i = 0; i < _taskConditionsData.N_Particles; i++)
                {
                    sum = 0;

                    for (int j = 0; j < _taskConditionsData.N_Basis; j++)
                    {
                        sum = sum + _componentsData.NU_MATRIX[i, j] * _componentsData.LN_A[k, j];
                    }

                    _componentsData.LN_GAMMA[k, i] = eLn * Math.Pow(_componentsData.CHARGE[i, 0], 2) * s3;
                    _componentsData.C_EQUIL[k, i] = Math.Exp(_componentsData.LGK[i, 0]) * eLn + sum - _componentsData.LN_GAMMA[k, i];
                }

                s3 = 0;

                for (int L = 0; L < _taskConditionsData.N_Basis; L++)
                {
                    sum = 0;

                    for (int i = 0; i < _taskConditionsData.N_Particles; i++)
                    {
                        sum = sum + _componentsData.NU_MATRIX[i, L] * _componentsData.C_EQUIL[k, i];
                    }

                    G[L] = _componentsData.CO_BAZIS[k, L] - sum;
                    s3 = s3 + Math.Abs(G[L]) / _componentsData.CO_BAZIS[k, L];
                }

                if (s3 < 1E-3)
                {
                    goto B;
                }

                //создание матрицы H()

                for (int L = 0; L < _taskConditionsData.N_Basis; L++)
                {
                    for (int j = 1; j < _taskConditionsData.N_Basis; j++)
                    {
                        sum = 0;

                        for (int i = 0; i < _taskConditionsData.N_Particles; i++)
                        {
                            sum += _componentsData.NU_MATRIX[i, L] * _componentsData.C_EQUIL[k, i] * _componentsData.NU_MATRIX[i, j];
                        }

                        H[L, j] = sum;
                        H[j, L] = sum;
                        H1[L, j] = sum;
                        H1[j, L] = sum;
                    }
                }

                determinant = H[0, 0] * H[1, 1] - H[1, 0] * H[0, 1];
                H0[0, 0] = H[1, 1] / determinant;
                H0[0, 1] = -H[0, 1] / determinant;
                H0[1, 0] = -H[1, 0] / determinant;
                H0[1, 1] = H[0, 0] / determinant;

                //Inversion(N_Basis, H);
                //H0 = H;

                //ПРОВЕРКА ОБРАЩЕНИЯ

                s1 = 0;

                for (int i = 0; i < _taskConditionsData.N_Basis; i++)
                {
                    for (int j = 0; j < _taskConditionsData.N_Basis; j++)
                    {
                        sum = 0;

                        for (int L = 0; L < _taskConditionsData.N_Basis; L++)
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

                for (int j = 0; j < _taskConditionsData.N_Basis; j++)
                {
                    sum = 0;

                    for (int L = 0; L < _taskConditionsData.N_Basis; L++)
                    {
                        sum += H0[j, L] * G[L];
                    }

                    _componentsData.DELTA_LN_A[j] = sum;
                    sum_delta += Math.Abs(sum);
                }

                //Критерий выхода по норме поправок

                if (sum_delta < 1E-5)
                {
                    goto B;
                }

                for (int j = 0; j < _taskConditionsData.N_Basis; j++)
                {
                    _componentsData.LN_A[k, j] = _componentsData.LN_A[k, j] + _componentsData.DELTA_LN_A[j] / 3;
                }

                count += 1;

                //textBox21.Text = Convert.ToString(count);
                //MessageBox.Show(Convert.ToString(count));

                goto A;

            B:;

                sum = 0;

                for (int i = 0; i < _taskConditionsData.N_Particles; i++)
                {
                    sum += Math.Pow(_componentsData.CHARGE[i, 0], 2) * _componentsData.C_EQUIL[k, i];
                }

                ion_1 = sum / 2;
                _componentsData.IONIC[k] = ion_1;

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
            double[,] MAZ = new double[3, 3] { { 1.00, 7.00, 9.00 }, { 2.00, 6.00, 2.00 }, { 4.00, 74.00, 0.00 } };
            //Запись значений из тестового массива для проверки
            double[,] MAZZ = new double[3, 3];

            //Проверка работы функции
            MAZZ = Operations.Inversion(3, MAZ);
        }
    }
}

