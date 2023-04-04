namespace CCPD_v1._0._0._0._1.Data
{
    public class ComponentsData
    {
        public int[,] ARR { get; set; } = new int[5, 10];
        public string[,] COMPONENTS { get; set; } = new string[1, 10];
        public string[,] BAS_NAME { get; set; } = new string[1, 10];
        public string[,] PARTICLES { get; set; } = new string[1, 15];
        public double[,] NU_MATRIX { get; set; } = new double[15, 10]; //Changed
        public double[,] LGK { get; set; } = new double[15, 1];
        public int[,] CHARGE { get; set; } = new int[15, 1];
        public double[,] CONC { get; set; } = new double[60, 4];
        public double[,] DATA { get; set; } = new double[60, 1];
        public double[,] LN_A { get; set; } = new double[60, 8];
        public double[,] CO_BAZIS { get; set; } = new double[60, 8];
        public double[] IONIC { get; set; } = new double[60];
        public double[,] LN_GAMMA { get; set; } = new double[60, 10];
        public double[,] C_EQUIL { get; set; } = new double[60, 10];
        public double[] DELTA_LN_A { get; set; } = new double[10];
    }
}
