using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace FungiParadise.Model
{
    public class Mushroom
    {
        //Constants
        public enum MushroomType {Edible, Poisonous}//0

        public static readonly char[] CAP_SHAPE = {'b', 'c', 'x', 'f', 'k', 's'};//1
        public static readonly char[] CAP_SURFACE = { 'f', 'g', 'y', 's' };//2
        public static readonly char[] CAP_COLOR = {'n', 'b', 'c', 'g', 'r', 'p', 'u', 'e', 'w', 'y'};//3

        public static readonly char[] BRUISES = {'t', 'f'};//4
        public static readonly char[] ODOR = {'a', 'l', 'c', 'y', 'f', 'm', 'n', 'p', 's'};//5

        public static readonly char[] GILL_ATTACHMENT = { 'a', 'd', 'f', 'n' };//6
        public static readonly char[] GILL_SPACING = { 'c', 'w', 'd' };//7
        public static readonly char[] GILL_SIZE = {'b', 'n'};//8
        public static readonly char[] GILL_COLOR = { 'k', 'n', 'b', 'h', 'g', 'r', 'o', 'p', 'u', 'e', 'w', 'y' };//9

        public static readonly char[] STALK_SHAPE = {'e', 't'};//10
        public static readonly char[] STALK_ROOT = {'b', 'c', 'u', 'e', 'z', 'r', '?' };//11
        public static readonly char[] STALK_SURFACE_ABOVE_RING = { 'f', 'y', 'k', 's' };//12
        public static readonly char[] STALK_SURFACE_BELOW_RING = { 'f', 'y', 'k', 's' };//13
        public static readonly char[] STALK_COLOR_ABOVE_RING = { 'n', 'b', 'c', 'g', 'o', 'p', 'e', 'w', 'y' };//14
        public static readonly char[] STALK_COLOR_BELOW_RING = { 'n', 'b', 'c', 'g', 'o', 'p', 'e', 'w', 'y' };//15

        public static readonly char[] VEIL_TYPE = { 'p', 'u' };//16
        public static readonly char[] VEIL_COLOR = { 'n', 'o', 'w', 'y' };//17

        public static readonly char[] RING_NUMBER = {'n', 'o', 't' };//18
        public static readonly char[] RING_TYPE = { 'c', 'e', 'f', 'l', 'n', 'p', 's', 'z' };//19

        public static readonly char[] SPORE_PRINT_COLOR = { 'k', 'n', 'b', 'h', 'r', 'o', 'u', 'w', 'y' };//20
        public static readonly char[] POPULATION = { 'a', 'c', 'n', 's', 'v', 'y' };//21
        public static readonly char[] HABITAD = { 'g', 'l', 'm', 'p', 'u', 'w', 'd' };//22

        //Attributes
            //Class
        private MushroomType type;//0

            //Vars
        private char capShape;//1
        private char capSurface;//2
        private char capColor;//3

        private char bruises;//4
        private char odor;//5

        private char gillAttachment;//6
        private char gillSpacing;//7
        private char gillSize;//8
        private char gillColor;//9

        private char stalkShape;//10
        private char stalkRoot;//11
        private char stalkSurfaceAboveRing;//12
        private char stalkSurfaceBelowRing;//13
        private char stalkColorAboveRing;//14
        private char stalkColorBelowRing;//15

        private char veilType;//16
        private char veilColor;//17

        private char ringNumber;//18
        private char ringType;//19

        private char sporePrintColor;//20
        private char population;//21
        private char habitad;//22

        //Properties
        public MushroomType Type { get { return type; } set { type = value; } }//0
        public char CapShape { get { return capShape; } set { capShape = value; } }//1
        public char CapSurface { get { return capSurface; } set { capSurface = value; } }//2
        public char CapColor { get { return capColor; } set { capColor = value; } }//3
        public char Bruises { get { return bruises; } set { bruises = value; } }//4
        public char Odor { get { return odor; } set { odor = value; } }//5
        public char GillAttachment { get { return gillAttachment; } set { gillAttachment = value; } }//6
        public char GillSpacing { get { return gillSpacing; } set { gillSpacing = value; } }//7
        public char GillSize { get { return gillSize; } set { gillSize = value; } }//8
        public char GillColor { get { return gillColor; } set { gillColor = value; } }//9
        public char StalkShape { get { return stalkShape; } set { stalkShape = value; } }//10
        public char StalkRoot { get { return stalkRoot; } set { stalkRoot = value; } }//11
        public char StalkSurfaceAboveRing { get { return stalkSurfaceAboveRing; } set { stalkSurfaceAboveRing = value; } }//12
        public char StalkSurfaceBelowRing { get { return stalkSurfaceBelowRing; } set { stalkSurfaceBelowRing = value; } }//13
        public char StalkColorAboveRing { get { return stalkColorAboveRing; } set { stalkColorAboveRing = value; } }//14
        public char StalkColorBelowRing { get { return stalkColorBelowRing; } set { stalkColorBelowRing = value; } }//15
        public char VeilType { get { return veilType; } set { veilType = value; } }//16
        public char VeilColor { get { return veilColor; } set { veilColor = value; } }//17
        public char RingNumber { get { return ringNumber; } set { ringNumber = value; } }//18
        public char RingType { get { return ringType; } set { ringType = value; } }//19
        public char SporePrintColor { get { return sporePrintColor; } set { sporePrintColor = value; } }//20
        public char Population { get { return population; } set { population = value; } }//21
        public char Habitad { get { return habitad; } set { habitad = value; } }//22

        //Constructor
        public Mushroom(MushroomType type, char capShape, char capSurface, char capColor, char bruises, char odor, char gillAttachment, char gillSpacing,
        char gillSize, char gillColor, char stalkShape, char stalkRoot, char stalkSurfaceAboveRing, char stalkSurfaceBelowRing, char stalkColorAboveRing,
        char stalkColorBelowRing, char veilType, char veilColor, char ringNumber, char ringType, char sporePrintColor, char population, char habitad)
        {
            if (CAP_SHAPE.Contains(capShape) && CAP_SURFACE.Contains(capSurface) && CAP_COLOR.Contains(capColor) && BRUISES.Contains(bruises)
            && ODOR.Contains(odor) && GILL_ATTACHMENT.Contains(gillAttachment) && GILL_SPACING.Contains(gillSpacing) && GILL_SIZE.Contains(gillSize)
            && GILL_COLOR.Contains(gillColor) && STALK_SHAPE.Contains(stalkShape) && STALK_ROOT.Contains(stalkRoot)
            && STALK_SURFACE_ABOVE_RING.Contains(stalkSurfaceAboveRing) && STALK_SURFACE_BELOW_RING.Contains(stalkSurfaceBelowRing)
            && STALK_COLOR_ABOVE_RING.Contains(stalkColorAboveRing) && STALK_COLOR_BELOW_RING.Contains(stalkColorBelowRing) && VEIL_TYPE.Contains(veilType)
            && VEIL_COLOR.Contains(veilColor) && RING_NUMBER.Contains(ringNumber) && RING_TYPE.Contains(ringType)
            && SPORE_PRINT_COLOR.Contains(sporePrintColor) && POPULATION.Contains(population) && HABITAD.Contains(habitad))
            {
                this.type = type;//0

                this.capShape = capShape;//1
                this.capSurface = capSurface;//2
                this.capColor = capColor;//3

                this.bruises = bruises;//4
                this.odor = odor;//5

                this.gillAttachment = gillAttachment;//6
                this.gillSpacing = gillSpacing;//7
                this.gillSize = gillSize;//8
                this.gillColor = gillColor;//9

                this.stalkShape = stalkShape;//10
                this.stalkRoot = stalkRoot;//11
                this.stalkSurfaceAboveRing = stalkSurfaceAboveRing;//12
                this.stalkSurfaceBelowRing = stalkSurfaceBelowRing;//13
                this.stalkColorAboveRing = stalkColorAboveRing;//14
                this.stalkColorBelowRing = stalkColorBelowRing;//15

                this.veilType = veilType;//16
                this.veilColor = veilColor;//17

                this.ringNumber = ringNumber;//18
                this.ringType = ringType;//19

                this.sporePrintColor = sporePrintColor;//20
                this.population = population;//21
                this.habitad = habitad;//22
            }
            else
            {
                Console.WriteLine("Error bip bup");
            }
        }



    }
}
