using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FungiParadise.Model
{
    public class Manager
    {
        //Constants
        public const double TRAINING_PERCENTAGE = 0.8;

        //Attributes
        private List<Mushroom> dataSet;
        private DecisionTree.Model.DecisionTree decisionTree;

        //Property
        public DecisionTree.Model.DecisionTree DecisionTree{ get { return decisionTree; } }

        //Constructor
        public Manager(string path)
        {
            dataSet = new List<Mushroom>();
            Load(path);
        }

        //Machine Learning
        public void GenerateDecisionTree()
        {
            decisionTree = new DecisionTree.Model.DecisionTree(GenerateTrainingDataTable());
        }

        public double DecisionTreeSuccessPercentage()
        {
            return decisionTree.Test(GenerateTestingDataTable());
        }

        //Table
        public DataTable GenerateEmptyTable()
        {
            DataTable table = new DataTable();

            table.Columns.Add("TYPE", typeof(string));//0

            table.Columns.Add("CAP SHAPE", typeof(char));//1
            table.Columns.Add("CAP SURFACE", typeof(char));//2
            table.Columns.Add("CAP COLOR", typeof(char));//3

            table.Columns.Add("BRUISES", typeof(char));//4
            table.Columns.Add("ODOR", typeof(char));//5

            table.Columns.Add("GILL ATTACHMENT", typeof(char));//6
            table.Columns.Add("GILL SPACING", typeof(char));//7
            table.Columns.Add("GILL SIZE", typeof(char));//8
            table.Columns.Add("GILL COLOR", typeof(char));//9

            table.Columns.Add("STALK SHAPE", typeof(char));//10
            table.Columns.Add("STALK ROOT", typeof(char));//11
            table.Columns.Add("STALK SURFACE ABOVE RING", typeof(char));//12
            table.Columns.Add("STALK SURFACE BELOW RING", typeof(char));//13
            table.Columns.Add("STALK COLOR ABOVE RING", typeof(char));//14
            table.Columns.Add("STALK COLOR BELOW RING", typeof(char));//15

            table.Columns.Add("VEIL TYPE", typeof(char));//16
            table.Columns.Add("VEIL COLOR", typeof(char));//17

            table.Columns.Add("RING NUMBER", typeof(char));//18
            table.Columns.Add("RING TYPE", typeof(char));//19

            table.Columns.Add("SPORE PRINT COLOR", typeof(char));//20
            table.Columns.Add("POPULATION", typeof(char));//21
            table.Columns.Add("HABITAT", typeof(char));//22

            return table;
        }

        public DataTable GenerateDataTable()
        {
            DataTable table = GenerateEmptyTable();

            foreach (Mushroom mushroom in dataSet)
            {
                DataRow row = table.NewRow();

                row["TYPE"] = mushroom.Type;//0

                row["CAP SHAPE"] = mushroom.CapShape;//1
                row["CAP SURFACE"] = mushroom.CapSurface;//2
                row["CAP COLOR"] = mushroom.CapColor;//3

                row["BRUISES"] = mushroom.Bruises;//4
                row["ODOR"] = mushroom.Odor;//5

                row["GILL ATTACHMENT"] = mushroom.GillAttachment;//6
                row["GILL SPACING"] = mushroom.GillSpacing;//7
                row["GILL SIZE"] = mushroom.GillSize;//8
                row["GILL COLOR"] = mushroom.GillColor;//9

                row["STALK SHAPE"] = mushroom.StalkShape;//10
                row["STALK ROOT"] = mushroom.StalkRoot;//11
                row["STALK SURFACE ABOVE RING"] = mushroom.StalkSurfaceAboveRing;//12
                row["STALK SURFACE BELOW RING"] = mushroom.StalkSurfaceBelowRing;//13
                row["STALK COLOR ABOVE RING"] = mushroom.StalkColorAboveRing;//14
                row["STALK COLOR BELOW RING"] = mushroom.StalkColorBelowRing;//15

                row["VEIL TYPE"] = mushroom.VeilType;//16
                row["VEIL COLOR"] = mushroom.VeilColor;//17

                row["RING NUMBER"] = mushroom.RingNumber;//18
                row["RING TYPE"] = mushroom.RingType;//19

                row["SPORE PRINT COLOR"] = mushroom.SporePrintColor;//20
                row["POPULATION"] = mushroom.Population;//21
                row["HABITAT"] = mushroom.Habitat;//22

                table.Rows.Add(row);
            }

            return table;
        }

        public DataTable GenerateTrainingDataTable()
        {
            DataTable table = GenerateEmptyTable();

            for(int i = 0; i < (dataSet.Count*TRAINING_PERCENTAGE); i++)
            {
                DataRow row = table.NewRow();

                row["TYPE"] = dataSet[i].Type;//0

                row["CAP SHAPE"] = dataSet[i].CapShape;//1
                row["CAP SURFACE"] = dataSet[i].CapSurface;//2
                row["CAP COLOR"] = dataSet[i].CapColor;//3

                row["BRUISES"] = dataSet[i].Bruises;//4
                row["ODOR"] = dataSet[i].Odor;//5

                row["GILL ATTACHMENT"] = dataSet[i].GillAttachment;//6
                row["GILL SPACING"] = dataSet[i].GillSpacing;//7
                row["GILL SIZE"] = dataSet[i].GillSize;//8
                row["GILL COLOR"] = dataSet[i].GillColor;//9

                row["STALK SHAPE"] = dataSet[i].StalkShape;//10
                row["STALK ROOT"] = dataSet[i].StalkRoot;//11
                row["STALK SURFACE ABOVE RING"] = dataSet[i].StalkSurfaceAboveRing;//12
                row["STALK SURFACE BELOW RING"] = dataSet[i].StalkSurfaceBelowRing;//13
                row["STALK COLOR ABOVE RING"] = dataSet[i].StalkColorAboveRing;//14
                row["STALK COLOR BELOW RING"] = dataSet[i].StalkColorBelowRing;//15

                row["VEIL TYPE"] = dataSet[i].VeilType;//16
                row["VEIL COLOR"] = dataSet[i].VeilColor;//17

                row["RING NUMBER"] = dataSet[i].RingNumber;//18
                row["RING TYPE"] = dataSet[i].RingType;//19

                row["SPORE PRINT COLOR"] = dataSet[i].SporePrintColor;//20
                row["POPULATION"] = dataSet[i].Population;//21
                row["HABITAT"] = dataSet[i].Habitat;//22

                table.Rows.Add(row);
            }

            return table;
        }

        public DataTable GenerateTestingDataTable()
        {
            DataTable table = GenerateEmptyTable();

            for (int i = (int)(dataSet.Count*TRAINING_PERCENTAGE); i < dataSet.Count; i++)
            {
                DataRow row = table.NewRow();

                row["TYPE"] = dataSet[i].Type;//0

                row["CAP SHAPE"] = dataSet[i].CapShape;//1
                row["CAP SURFACE"] = dataSet[i].CapSurface;//2
                row["CAP COLOR"] = dataSet[i].CapColor;//3

                row["BRUISES"] = dataSet[i].Bruises;//4
                row["ODOR"] = dataSet[i].Odor;//5

                row["GILL ATTACHMENT"] = dataSet[i].GillAttachment;//6
                row["GILL SPACING"] = dataSet[i].GillSpacing;//7
                row["GILL SIZE"] = dataSet[i].GillSize;//8
                row["GILL COLOR"] = dataSet[i].GillColor;//9

                row["STALK SHAPE"] = dataSet[i].StalkShape;//10
                row["STALK ROOT"] = dataSet[i].StalkRoot;//11
                row["STALK SURFACE ABOVE RING"] = dataSet[i].StalkSurfaceAboveRing;//12
                row["STALK SURFACE BELOW RING"] = dataSet[i].StalkSurfaceBelowRing;//13
                row["STALK COLOR ABOVE RING"] = dataSet[i].StalkColorAboveRing;//14
                row["STALK COLOR BELOW RING"] = dataSet[i].StalkColorBelowRing;//15

                row["VEIL TYPE"] = dataSet[i].VeilType;//16
                row["VEIL COLOR"] = dataSet[i].VeilColor;//17

                row["RING NUMBER"] = dataSet[i].RingNumber;//18
                row["RING TYPE"] = dataSet[i].RingType;//19

                row["SPORE PRINT COLOR"] = dataSet[i].SporePrintColor;//20
                row["POPULATION"] = dataSet[i].Population;//21
                row["HABITAT"] = dataSet[i].Habitat;//22

                table.Rows.Add(row);
            }

            return table;
        }

        public DataTable GenerateFilteredDataTable(string column, string value)
        {
            DataTable table = GenerateDataTable();

            table.DefaultView.RowFilter = "[" +column + "] = '" + value + "'";

            return table;
        }

        //Chart
        public DataTable GenerateTypeChart()//1
        {
            DataTable table = new DataTable();

            //Init
            table.Columns.Add("X", typeof(string));
            table.Columns.Add("Y", typeof(int));

            //Search
            int numE = 0;
            int numP = 0;
            foreach(Mushroom mushroom in dataSet)
            {
                if (mushroom.Type == Mushroom.MushroomType.Edible)
                    numE++;
                else if (mushroom.Type == Mushroom.MushroomType.Poisonous)
                    numP++;
            }

            //Values
            DataRow rowE = table.NewRow();
            rowE["X"] = Mushroom.MushroomType.Edible;
            rowE["Y"] = numE;
            table.Rows.Add(rowE);

            DataRow rowP = table.NewRow();
            rowP["X"] = Mushroom.MushroomType.Poisonous;
            rowP["Y"] = numP;
            table.Rows.Add(rowP);

            return table;
        }

        public DataTable GenerateOdorChart()//2
        {
            DataTable table = new DataTable();

            //Init
            table.Columns.Add("X", typeof(string));
            table.Columns.Add("Y", typeof(int));

            //Search
            int[] quantity = new int[Mushroom.ODOR.Length];
            foreach (Mushroom mushroom in dataSet)
            {
                bool found = false;
                for (int i = 0; (i < quantity.Length) && !found; i++)
                {
                    if (Mushroom.ODOR[i] == mushroom.Odor)
                    {
                        quantity[i]++;
                        found = true;
                    }
                }
            }

            //Values
            for (int i=0; i< quantity.Length; i++)
            {
                DataRow row = table.NewRow();

                row["X"] = Mushroom.ODOR[i];
                row["Y"] = quantity[i];

                table.Rows.Add(row);
            }

            return table;
        }

        public DataTable GenerateRingNumberChart()//3
        {
            DataTable table = new DataTable();

            //Init
            table.Columns.Add("X", typeof(int));
            table.Columns.Add("Y", typeof(int));

            //Search
            int[] quantity = new int[Mushroom.RING_NUMBER.Length];
            foreach (Mushroom mushroom in dataSet)
            {
                bool found = false;
                for (int i = 0; (i < quantity.Length) && !found; i++)
                {
                    if (Mushroom.RING_NUMBER[i].Equals(mushroom.RingNumber))
                    {
                        quantity[i]++;
                        found = true;
                    }
                }
            }

            //Values
            for (int i = 0; i < quantity.Length; i++)
            {
                DataRow row = table.NewRow();

                row["X"] = i;
                row["Y"] = quantity[i];

                table.Rows.Add(row);
            }

            return table;
        }

        public DataTable GenerateBruisesChart()//4
        {
            DataTable table = new DataTable();

            //Init
            table.Columns.Add("X", typeof(string));
            table.Columns.Add("Y", typeof(int));

            //Search
            int[] quantity = new int[Mushroom.BRUISES.Length];
            foreach (Mushroom mushroom in dataSet)
            {
                bool found = false;
                for (int i = 0; (i < quantity.Length) && !found; i++)
                {
                    if (Mushroom.BRUISES[i].Equals(mushroom.Bruises))
                    {
                        quantity[i]++;
                        found = true;
                    }
                }
            }

            //Values
            for (int i = 0; i < quantity.Length; i++)
            {
                DataRow row = table.NewRow();

                row["X"] = Mushroom.BRUISES[i];
                row["Y"] = quantity[i];

                table.Rows.Add(row);
            }

            return table;
        }

        public DataTable GenerateCapColorChart()//5
        {
            DataTable table = new DataTable();

            //Init
            table.Columns.Add("X", typeof(string));
            table.Columns.Add("Y", typeof(int));

            //Search
            int[] quantity = new int[Mushroom.CAP_COLOR.Length];
            foreach (Mushroom mushroom in dataSet)
            {
                bool found = false;
                for (int i = 0; (i < quantity.Length) && !found; i++)
                {
                    if (Mushroom.CAP_COLOR[i].Equals(mushroom.CapColor))
                    {
                        quantity[i]++;
                        found = true;
                    }
                }
            }

            //Values
            for (int i = 0; i < quantity.Length; i++)
            {
                DataRow row = table.NewRow();

                row["X"] = Mushroom.CAP_COLOR[i];
                row["Y"] = quantity[i];

                table.Rows.Add(row);
            }

            return table;
        }

        //Load
        public void Load(string path)
        {
            string[] info = File.ReadAllLines(path);
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");

            for (int i = 1; i < info.Length; i++)
            {
                //Split
                string[] dataInfo = Regex.Split(info[i], ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                //...

                try
                {
                    //Type
                    Mushroom.MushroomType type = Mushroom.MushroomType.Edible;//0
                    if (dataInfo[0].Equals("e"))
                        type = Mushroom.MushroomType.Edible;
                    else if (dataInfo[0].Equals("p"))
                        type = Mushroom.MushroomType.Poisonous;

                    //Info
                    char capShape = Char.Parse(dataInfo[1]);//1
                    char capSurface = Char.Parse(dataInfo[2]);//2
                    char capColor = Char.Parse(dataInfo[3]);//3

                    char bruises = Char.Parse(dataInfo[4]);//4
                    char odor= Char.Parse(dataInfo[5]);//5

                    char gillAttachment = Char.Parse(dataInfo[6]);//6
                    char gillSpacing = Char.Parse(dataInfo[7]);//7
                    char gillSize= Char.Parse(dataInfo[8]);//8
                    char gillColor = Char.Parse(dataInfo[9]);//9

                    char stalkShape = Char.Parse(dataInfo[10]);//10
                    char stalkRoot = Char.Parse(dataInfo[11]);//11
                    char stalkSurfaceAboveRing = Char.Parse(dataInfo[12]);//12
                    char stalkSurfaceBelowRing = Char.Parse(dataInfo[13]);//13
                    char stalkColorAboveRing = Char.Parse(dataInfo[14]);//14
                    char stalkColorBelowRing = Char.Parse(dataInfo[15]);//15

                    char veilType = Char.Parse(dataInfo[16]);//16
                    char veilColor = Char.Parse(dataInfo[17]);//17

                    char ringNumber = Char.Parse(dataInfo[18]);//18
                    char ringType = Char.Parse(dataInfo[19]);//19

                    char sporePrintColor = Char.Parse(dataInfo[20]);//20
                    char population = Char.Parse(dataInfo[21]);//21
                    char habitad= Char.Parse(dataInfo[22]);//22

                    //Add
                    Mushroom mushroom = new Mushroom(type, capShape, capSurface, capColor, bruises, odor, gillAttachment, gillSpacing, gillSize, gillColor, stalkShape, stalkRoot, stalkSurfaceAboveRing,
                                                        stalkSurfaceBelowRing, stalkColorAboveRing, stalkColorBelowRing, veilType, veilColor, ringNumber, ringType, sporePrintColor, population, habitad);
                    dataSet.Add(mushroom);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Error en dato!");
                }
                //...
            }
        }


    }
}
