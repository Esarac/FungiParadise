using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FungiParadise.Exception;
using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.Statistics.Filters;
using Accord.Math.Optimization.Losses;
using Accord.MachineLearning.DecisionTrees.Rules;

namespace FungiParadise.Model
{
    public class Manager
    {
        //Constants
        public const double TRAINING_PERCENTAGE = 0.8;

        //Attributes
        private List<Mushroom> dataSet;

        private DecisionTree.Model.DecisionTree decisionTreeOrg;

        private Codification codebook;
        private Accord.MachineLearning.DecisionTrees.DecisionTree decisionTreeLib;

        //Property
        public DecisionTree.Model.DecisionTree DecisionTreeOrg{ get { return decisionTreeOrg; } }
        public Codification Codebook { get { return codebook; } }
        public Accord.MachineLearning.DecisionTrees.DecisionTree DecisionTreeLib { get { return decisionTreeLib; } }

        //Constructor
        public Manager(string path)
        {
            dataSet = new List<Mushroom>();
            Load(path);
        }

        //Experiment
        public void GenerateExperiments()
        {
            int[] trainQua = { 4, 40, 400, 4000 };
            int[] testQua = { 4, 40, 400, 4000 };
            int rep = 100;
            List<string> rowsOrg = new List<string>();
            List<string> rowsLib = new List<string>();

            AddHeaders(rowsOrg);

            for (int i = 0; i < trainQua.Length; i++)
            {
                for (int j = 0; j < testQua.Length; j++)
                {
                    for(int k = 0; k < rep; k++)
                    {
                        DataTable[] tables = GenerateExperimentDataTables(trainQua[i], testQua[j]);

                        //Original
                        DecisionTree.Model.DecisionTree original = new DecisionTree.Model.DecisionTree(tables[0]);
                        double perOrg = original.Test(tables[1]);
                        //...

                        //Library
                        Codification codebook = GenerateDecisionTreeLib(tables[0]);
                        double perLib = DecisionTreeAccuracyPercentageLib(tables[1], codebook);
                        //...

                        Console.WriteLine((k + 1) + ". [trainQ:" + trainQua[i] + ", testQ:" + testQua[j] + "] = [dtOrg:" + perOrg + ", dtLib:" + perLib + "]");
                        rowsOrg.Add("Org" + "," + trainQua[i] + "," + testQua[j] + "," + rep + "," + perOrg);
                        rowsLib.Add("Lib" + "," + trainQua[i] + "," + testQua[j] + "," + rep + ", " + perLib);
                    }
                }
            }

            ExportResults(rowsOrg, rowsLib);
        }

        public void AddHeaders(List<string> list)
        {
            list.Add("Decision Tree," + "Train Quantity," + "Test Quantity," + "Repetition," + "Accuracy");
        }

        public void ExportResults(List<string> listA, List<string> listB)
        {
            listA.AddRange(listB);
            File.WriteAllLines("../../Doc/results.csv", listA);
        }

        //...

        //Machine Learning
        //Original
        public void GenerateDecisionTreeOrg()
        {
            decisionTreeOrg = new DecisionTree.Model.DecisionTree(GenerateTrainingDataTableOrg());
        }

        public double DecisionTreeAccuracyPercentageOrg()
        {
            return decisionTreeOrg.Test(GenerateTestingDataTableOrg());
        }
        //...

        //Library
        public void GenerateDecisionTreeLib()
        {
            DataTable data = GenerateTrainingDataTableLib();

            codebook = new Codification(data);

            DataTable symbols = codebook.Apply(data);

            int[][] inputs = DataTableToMatrix(symbols, new string[] { "CAP SHAPE" , "CAP SURFACE" , "CAP COLOR" ,
                                                                        "BRUISES" , "ODOR","GILL ATTACHMENT",
                                                                        "GILL SPACING", "GILL SIZE", "GILL COLOR",
                                                                        "STALK SHAPE","STALK ROOT","STALK SURFACE ABOVE RING",
                                                                        "STALK SURFACE BELOW RING","STALK COLOR ABOVE RING","STALK COLOR BELOW RING",
                                                                        "VEIL TYPE","VEIL COLOR","RING NUMBER",
                                                                        "RING TYPE","SPORE PRINT COLOR","POPULATION",
                                                                        "HABITAT"
            });

            int[][] mOutputs = DataTableToMatrix(symbols, new string[] { "TYPE" });
            int[] outputs = new int[mOutputs.Length];
            for (int i = 0; i < mOutputs.Length; i++)
                outputs[i] = mOutputs[i][0];

            ID3Learning id3learning = new ID3Learning()
            {
                new DecisionVariable("CAP SHAPE", Mushroom.CAP_SHAPE.Length),//1
                new DecisionVariable("CAP SURFACE", Mushroom.CAP_SURFACE.Length),//2
                new DecisionVariable("CAP COLOR", Mushroom.CAP_COLOR.Length),//3

                new DecisionVariable("BRUISES", Mushroom.BRUISES.Length),//4
                new DecisionVariable("ODOR", Mushroom.ODOR.Length),//5

                new DecisionVariable("GILL ATTACHMENT", Mushroom.GILL_ATTACHMENT.Length),//6
                new DecisionVariable("GILL SPACING", Mushroom.GILL_SPACING.Length),//7
                new DecisionVariable("GILL SIZE", Mushroom.GILL_SIZE.Length),//8
                new DecisionVariable("GILL COLOR", Mushroom.GILL_COLOR.Length),//9

                new DecisionVariable("STALK SHAPE", Mushroom.STALK_SHAPE.Length),//10
                new DecisionVariable("STALK ROOT", Mushroom.STALK_ROOT.Length),//11
                new DecisionVariable("STALK SURFACE ABOVE RING", Mushroom.STALK_SURFACE_ABOVE_RING.Length),//12
                new DecisionVariable("STALK SURFACE BELOW RING", Mushroom.STALK_SURFACE_BELOW_RING.Length),//13
                new DecisionVariable("STALK COLOR ABOVE RING", Mushroom.STALK_COLOR_ABOVE_RING.Length),//14
                new DecisionVariable("STALK COLOR BELOW RING", Mushroom.STALK_COLOR_BELOW_RING.Length),//15

                new DecisionVariable("VEIL TYPE", Mushroom.VEIL_TYPE.Length),//16
                new DecisionVariable("VEIL COLOR", Mushroom.VEIL_COLOR.Length),//17

                new DecisionVariable("RING NUMBER", Mushroom.RING_NUMBER.Length),//18
                new DecisionVariable("RING TYPE", Mushroom.RING_TYPE.Length),//19

                new DecisionVariable("SPORE PRINT COLOR", Mushroom.SPORE_PRINT_COLOR.Length),//20
                new DecisionVariable("POPULATION", Mushroom.POPULATION.Length),//21
                new DecisionVariable("HABITAT", Mushroom.HABITAT.Length)//22
            };

            decisionTreeLib = id3learning.Learn(inputs, outputs);

        }

        public Codification GenerateDecisionTreeLib(DataTable data)
        {
            Codification b = new Codification(data);

            DataTable symbols = b.Apply(data);

            int[][] inputs = DataTableToMatrix(symbols, new string[] { "CAP SHAPE" , "CAP SURFACE" , "CAP COLOR" ,
                                                                        "BRUISES" , "ODOR","GILL ATTACHMENT",
                                                                        "GILL SPACING", "GILL SIZE", "GILL COLOR",
                                                                        "STALK SHAPE","STALK ROOT","STALK SURFACE ABOVE RING",
                                                                        "STALK SURFACE BELOW RING","STALK COLOR ABOVE RING","STALK COLOR BELOW RING",
                                                                        "VEIL TYPE","VEIL COLOR","RING NUMBER",
                                                                        "RING TYPE","SPORE PRINT COLOR","POPULATION",
                                                                        "HABITAT"
            });

            int[][] mOutputs = DataTableToMatrix(symbols, new string[] { "TYPE" });
            int[] outputs = new int[mOutputs.Length];
            for (int i = 0; i < mOutputs.Length; i++)
                outputs[i] = mOutputs[i][0];

            ID3Learning id3learning = new ID3Learning()
            {
                new DecisionVariable("CAP SHAPE", Mushroom.CAP_SHAPE.Length),//1
                new DecisionVariable("CAP SURFACE", Mushroom.CAP_SURFACE.Length),//2
                new DecisionVariable("CAP COLOR", Mushroom.CAP_COLOR.Length),//3

                new DecisionVariable("BRUISES", Mushroom.BRUISES.Length),//4
                new DecisionVariable("ODOR", Mushroom.ODOR.Length),//5

                new DecisionVariable("GILL ATTACHMENT", Mushroom.GILL_ATTACHMENT.Length),//6
                new DecisionVariable("GILL SPACING", Mushroom.GILL_SPACING.Length),//7
                new DecisionVariable("GILL SIZE", Mushroom.GILL_SIZE.Length),//8
                new DecisionVariable("GILL COLOR", Mushroom.GILL_COLOR.Length),//9

                new DecisionVariable("STALK SHAPE", Mushroom.STALK_SHAPE.Length),//10
                new DecisionVariable("STALK ROOT", Mushroom.STALK_ROOT.Length),//11
                new DecisionVariable("STALK SURFACE ABOVE RING", Mushroom.STALK_SURFACE_ABOVE_RING.Length),//12
                new DecisionVariable("STALK SURFACE BELOW RING", Mushroom.STALK_SURFACE_BELOW_RING.Length),//13
                new DecisionVariable("STALK COLOR ABOVE RING", Mushroom.STALK_COLOR_ABOVE_RING.Length),//14
                new DecisionVariable("STALK COLOR BELOW RING", Mushroom.STALK_COLOR_BELOW_RING.Length),//15

                new DecisionVariable("VEIL TYPE", Mushroom.VEIL_TYPE.Length),//16
                new DecisionVariable("VEIL COLOR", Mushroom.VEIL_COLOR.Length),//17

                new DecisionVariable("RING NUMBER", Mushroom.RING_NUMBER.Length),//18
                new DecisionVariable("RING TYPE", Mushroom.RING_TYPE.Length),//19

                new DecisionVariable("SPORE PRINT COLOR", Mushroom.SPORE_PRINT_COLOR.Length),//20
                new DecisionVariable("POPULATION", Mushroom.POPULATION.Length),//21
                new DecisionVariable("HABITAT", Mushroom.HABITAT.Length)//22
            };

            decisionTreeLib = id3learning.Learn(inputs, outputs);

            return b;
        }

        public double DecisionTreeAccuracyPercentageLib()
        {
            DataTable data = GenerateTestingDataTableLib();

            DataTable symbols = codebook.Apply(data);

            int[][] inputs = DataTableToMatrix(symbols, new string[] { "CAP SHAPE" , "CAP SURFACE" , "CAP COLOR" ,
                                                                        "BRUISES" , "ODOR", "GILL ATTACHMENT",
                                                                        "GILL SPACING", "GILL SIZE", "GILL COLOR",
                                                                        "STALK SHAPE","STALK ROOT","STALK SURFACE ABOVE RING",
                                                                        "STALK SURFACE BELOW RING","STALK COLOR ABOVE RING","STALK COLOR BELOW RING",
                                                                        "VEIL TYPE","VEIL COLOR","RING NUMBER",
                                                                        "RING TYPE","SPORE PRINT COLOR","POPULATION",
                                                                        "HABITAT"
            });

            int[][] mOutputs = DataTableToMatrix(symbols, new string[] { "TYPE" });
            int[] outputs = new int[mOutputs.Length];
            for (int i = 0; i < mOutputs.Length; i++)
                outputs[i] = mOutputs[i][0];

            double error = new ZeroOneLoss(outputs).Loss(decisionTreeLib.Decide(inputs));

            return 1 - error;
        }

        public double DecisionTreeAccuracyPercentageLib(DataTable data, Codification codebook)
        {
            DataTable symbols = codebook.Apply(data);

            int[][] inputs = DataTableToMatrix(symbols, new string[] { "CAP SHAPE" , "CAP SURFACE" , "CAP COLOR" ,
                                                                        "BRUISES" , "ODOR", "GILL ATTACHMENT",
                                                                        "GILL SPACING", "GILL SIZE", "GILL COLOR",
                                                                        "STALK SHAPE","STALK ROOT","STALK SURFACE ABOVE RING",
                                                                        "STALK SURFACE BELOW RING","STALK COLOR ABOVE RING","STALK COLOR BELOW RING",
                                                                        "VEIL TYPE","VEIL COLOR","RING NUMBER",
                                                                        "RING TYPE","SPORE PRINT COLOR","POPULATION",
                                                                        "HABITAT"
            });

            int[][] mOutputs = DataTableToMatrix(symbols, new string[] { "TYPE" });
            int[] outputs = new int[mOutputs.Length];
            for (int i = 0; i < mOutputs.Length; i++)
                outputs[i] = mOutputs[i][0];

            double error = new ZeroOneLoss(outputs).Loss(decisionTreeLib.Decide(inputs));

            return 1 - error;
        }

        public string[] DecisionTreeClassifyLib(DataTable data)
        {
            DataTable symbols = codebook.Apply(data);

            int[][] inputs = DataTableToMatrix(symbols, new string[] { "CAP SHAPE" , "CAP SURFACE" , "CAP COLOR" ,
                                                                        "BRUISES" , "ODOR","GILL ATTACHMENT",
                                                                        "GILL SPACING", "GILL SIZE", "GILL COLOR",
                                                                        "STALK SHAPE","STALK ROOT","STALK SURFACE ABOVE RING",
                                                                        "STALK SURFACE BELOW RING","STALK COLOR ABOVE RING","STALK COLOR BELOW RING",
                                                                        "VEIL TYPE","VEIL COLOR","RING NUMBER",
                                                                        "RING TYPE","SPORE PRINT COLOR","POPULATION",
                                                                        "HABITAT"
            });

            int[] predicted = decisionTreeLib.Decide(inputs);

            string[] predictedString = new string[predicted.Length];
            for (int i = 0; i < predicted.Length; i++)
            {
                predictedString[i] = codebook.Revert("TYPE", predicted[i]);
                //Aqui se queda mucho tiempo
            }

            return predictedString;
        }

        public string DecisionTreeDecisionsLib()
        {
            DecisionSet rules = decisionTreeLib.ToRules();
            return rules.ToString(codebook, "TYPE", System.Globalization.CultureInfo.InvariantCulture);
        }
        //...

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

        public int[][] DataTableToMatrix(DataTable table, string[] columns)
        {
            int[][] matrix = new int[table.Rows.Count][];
            for (int i = 0; i < matrix.Length; i++)
                matrix[i] = new int[columns.Length];

            for (int r = 0; r < table.Rows.Count; r++)
            {
                DataRow row = table.Rows[r];
                for (int c = 0; c < columns.Length; c++)
                {
                    matrix[r][c] = (int)row[columns[c]];
                }
            }

            return matrix;
        }

        public DataTable GenerateFilteredDataTable(string column, string value)
        {
            DataTable table = GenerateDataTable();

            table.DefaultView.RowFilter = "[" + column + "] = '" + value + "'";

            return table;
        }

        //Experiment
        public DataTable[] GenerateExperimentDataTables(int trainQua, int testQua)
        {
            List<Mushroom> values = new List<Mushroom>(dataSet);

            Random r = new Random();

            //Train
            DataTable train = GenerateEmptyTableLib();
            for (int i = 0; i < trainQua; i++)
            {
                int pos = r.Next(values.Count);

                DataRow row = train.NewRow();
                row["TYPE"] = values[pos].Type;//0
                row["CAP SHAPE"] = values[pos].CapShape;//1
                row["CAP SURFACE"] = values[pos].CapSurface;//2
                row["CAP COLOR"] = values[pos].CapColor;//3
                row["BRUISES"] = values[pos].Bruises;//4
                row["ODOR"] = values[pos].Odor;//5
                row["GILL ATTACHMENT"] = values[pos].GillAttachment;//6
                row["GILL SPACING"] = values[pos].GillSpacing;//7
                row["GILL SIZE"] = values[pos].GillSize;//8
                row["GILL COLOR"] = values[pos].GillColor;//9
                row["STALK SHAPE"] = values[pos].StalkShape;//10
                row["STALK ROOT"] = values[pos].StalkRoot;//11
                row["STALK SURFACE ABOVE RING"] = values[pos].StalkSurfaceAboveRing;//12
                row["STALK SURFACE BELOW RING"] = values[pos].StalkSurfaceBelowRing;//13
                row["STALK COLOR ABOVE RING"] = values[pos].StalkColorAboveRing;//14
                row["STALK COLOR BELOW RING"] = values[pos].StalkColorBelowRing;//15
                row["VEIL TYPE"] = values[pos].VeilType;//16
                row["VEIL COLOR"] = values[pos].VeilColor;//17
                row["RING NUMBER"] = values[pos].RingNumber;//18
                row["RING TYPE"] = values[pos].RingType;//19
                row["SPORE PRINT COLOR"] = values[pos].SporePrintColor;//20
                row["POPULATION"] = values[pos].Population;//21
                row["HABITAT"] = values[pos].Habitat;//22
                train.Rows.Add(row);

                values.Remove(values[pos]);
            }
            //...

            //Test
            DataTable test = GenerateEmptyTableLib();
            for (int i = 0; i < testQua; i++)
            {
                int pos = r.Next(values.Count);

                DataRow row = test.NewRow();
                row["TYPE"] = values[pos].Type;//0
                row["CAP SHAPE"] = values[pos].CapShape;//1
                row["CAP SURFACE"] = values[pos].CapSurface;//2
                row["CAP COLOR"] = values[pos].CapColor;//3
                row["BRUISES"] = values[pos].Bruises;//4
                row["ODOR"] = values[pos].Odor;//5
                row["GILL ATTACHMENT"] = values[pos].GillAttachment;//6
                row["GILL SPACING"] = values[pos].GillSpacing;//7
                row["GILL SIZE"] = values[pos].GillSize;//8
                row["GILL COLOR"] = values[pos].GillColor;//9
                row["STALK SHAPE"] = values[pos].StalkShape;//10
                row["STALK ROOT"] = values[pos].StalkRoot;//11
                row["STALK SURFACE ABOVE RING"] = values[pos].StalkSurfaceAboveRing;//12
                row["STALK SURFACE BELOW RING"] = values[pos].StalkSurfaceBelowRing;//13
                row["STALK COLOR ABOVE RING"] = values[pos].StalkColorAboveRing;//14
                row["STALK COLOR BELOW RING"] = values[pos].StalkColorBelowRing;//15
                row["VEIL TYPE"] = values[pos].VeilType;//16
                row["VEIL COLOR"] = values[pos].VeilColor;//17
                row["RING NUMBER"] = values[pos].RingNumber;//18
                row["RING TYPE"] = values[pos].RingType;//19
                row["SPORE PRINT COLOR"] = values[pos].SporePrintColor;//20
                row["POPULATION"] = values[pos].Population;//21
                row["HABITAT"] = values[pos].Habitat;//22
                test.Rows.Add(row);

                values.Remove(values[pos]);
            }
            //...

            return new DataTable[] { train, test};
        } 
        //..

        //Original
        public DataTable GenerateTrainingDataTableOrg()
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

        public DataTable GenerateTestingDataTableOrg()
        {
            DataTable table = GenerateEmptyTable();

            for (int i = (int)(dataSet.Count * TRAINING_PERCENTAGE); i < dataSet.Count; i++)
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
        //...

        //Library
        public DataTable GenerateEmptyTableLib()
        {
            DataTable table = new DataTable();

            table.Columns.Add("TYPE", typeof(string));//0

            table.Columns.Add("CAP SHAPE", typeof(string));//1
            table.Columns.Add("CAP SURFACE", typeof(string));//2
            table.Columns.Add("CAP COLOR", typeof(string));//3

            table.Columns.Add("BRUISES", typeof(string));//4
            table.Columns.Add("ODOR", typeof(string));//5

            table.Columns.Add("GILL ATTACHMENT", typeof(string));//6
            table.Columns.Add("GILL SPACING", typeof(string));//7
            table.Columns.Add("GILL SIZE", typeof(string));//8
            table.Columns.Add("GILL COLOR", typeof(string));//9

            table.Columns.Add("STALK SHAPE", typeof(string));//10
            table.Columns.Add("STALK ROOT", typeof(string));//11
            table.Columns.Add("STALK SURFACE ABOVE RING", typeof(string));//12
            table.Columns.Add("STALK SURFACE BELOW RING", typeof(string));//13
            table.Columns.Add("STALK COLOR ABOVE RING", typeof(string));//14
            table.Columns.Add("STALK COLOR BELOW RING", typeof(string));//15

            table.Columns.Add("VEIL TYPE", typeof(string));//16
            table.Columns.Add("VEIL COLOR", typeof(string));//17

            table.Columns.Add("RING NUMBER", typeof(string));//18
            table.Columns.Add("RING TYPE", typeof(string));//19

            table.Columns.Add("SPORE PRINT COLOR", typeof(string));//20
            table.Columns.Add("POPULATION", typeof(string));//21
            table.Columns.Add("HABITAT", typeof(string));//22

            return table;
        }

        public DataTable GenerateTrainingDataTableLib()
        {
            DataTable table = GenerateEmptyTableLib();

            //Rows
            for (int i = 0; i < (dataSet.Count * TRAINING_PERCENTAGE); i++)
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
            //...

            return table;
        }

        public DataTable GenerateTestingDataTableLib()
        {
            DataTable table = GenerateEmptyTableLib();

            for (int i = (int)(dataSet.Count * TRAINING_PERCENTAGE); i < dataSet.Count; i++)
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
        //...

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
        public int Load(string path)
        {
            string[] info = File.ReadAllLines(path);
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");

            int invalidData = 0;

            for (int i = 1; i < info.Length; i++)
            {
                //Split
                string[] dataInfo = Regex.Split(info[i], ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                //...

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
                    invalidData++;
                }
                catch (InvalidValuesException)
                {
                    invalidData++;
                }
                //...
            }
            return invalidData;
        }

    }
}
