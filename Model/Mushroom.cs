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
    class Mushroom
    {
        //Constants
        public enum Type {Edible, Poisonous}
        public static readonly char[] CAP_SHAPE = {'b', 'c', 'x', 'f', 'k', 's'};
        public static readonly char[] CAP_SURFACE = {'f', 'g', 'y', 's'};
        public static readonly char[] CAP_COLOR = {'n', 'b', 'c', 'g', 'r', 'p', 'u', 'e', 'w', 'y'};
        public static readonly char[] BRUISES = {'t', 'f'};
        public static readonly char[] ODOR = {'a', 'l', 'c', 'y', 'f', 'm', 'n', 'p', 's'};
        public static readonly char[] GILL_ATTACHMENT = {'a', 'd', 'f', 'n'};
        public static readonly char[] GILL_SPACING = {'c', 'w', 'd'};
        public static readonly char[] GILL_SIZE = {'b', 'n'};
        public static readonly char[] GILL_COLOR = {'k', 'n', 'b', 'h', 'g', 'r', 'o', 'p', 'u', 'e', 'w', 'y'};
        public static readonly char[] STALK_SHAPE = {'e', 't'};
        public static readonly char[] STALK_ROOT = {'b', 'c', 'u', 'e', 'z', 'r', '?' };
        public static readonly char[] STALK_SURFACE_ABOVE_RING = {'f', 'y', 'k', 's' };
        public static readonly char[] STALK_SURFACE_BELOW_RING = {'f', 'y', 'k', 's' };
        public static readonly char[] STALK_COLOR_ABOVE_RING = {'n', 'b', 'c', 'g', 'o', 'p', 'e', 'w', 'y'};
        public static readonly char[] STALK_COLOR_BELOW_RING = {'n', 'b', 'c', 'g', 'o', 'p', 'e', 'w', 'y' };
        public static readonly char[] VEIL_TYPE = {'p', 'u'};
        public static readonly char[] VEIL_COLOR = {'n', 'o', 'w', 'y'};
        public static readonly char[] RING_NUMBER = {'n', 'o', 't' };
        public static readonly char[] RING_TYPE = {'c', 'e', 'f', 'l', 'n', 'p', 's', 'z' };
        public static readonly char[] SPORE_PRINT_COLOR = {'k', 'n', 'b', 'h', 'r', 'o', 'u', 'w', 'y'};
        public static readonly char[] POPULATION = { 'a', 'c', 'n', 's', 'v', 'y' };
        public static readonly char[] HABITAD = { 'g', 'l', 'm', 'p', 'u', 'w', 'd' };

        //Attributes
            //Class
        private Type type;
            //Vars
        private char capShape;
        private char capSurface;
        private char capColor;

        private char bruises;
        private char odor;

        private char gillAttachment;
        private char gillSpacing;
        private char gillSize;
        private char gillColor;

        private char stalkShape;
        private char stalkRoot;
        private char stalkSurfaceAboveRing;
        private char stalkSurfaceBelowRing;
        private char stalkColorAboveRing;
        private char stalkColorBelowRing;

        private char veilType;
        private char veilColor;

        private char ringNumber;
        private char ringType;

        private char sporePrintColor;
        private char population;
        private char habitad;

        //Constructor
        public Mushroom(Type type, char capShape, char capSurface, char capColor, char bruises, char odor, char gillAttachment, char gillSpacing, 
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
                this.type = type;

                this.capShape = capShape;
                this.capSurface = capSurface;
                this.capColor = capColor;

                this.bruises = bruises;
                this.odor = odor;

                this.gillAttachment = gillAttachment;
                this.gillSpacing = gillSpacing;
                this.gillSize = gillSize;
                this.gillColor = gillColor;

                this.stalkShape = stalkShape;
                this.stalkRoot = stalkRoot;
                this.stalkSurfaceAboveRing = stalkSurfaceAboveRing;
                this.stalkSurfaceBelowRing = stalkSurfaceBelowRing;
                this.stalkColorAboveRing = stalkColorAboveRing;
                this.stalkColorBelowRing = stalkColorBelowRing;

                this.veilType = veilType;
                this.veilColor = veilColor;

                this.ringNumber = ringNumber;
                this.ringType = ringType;

                this.sporePrintColor = sporePrintColor;
                this.population = population;
                this.habitad = habitad;
            }
            else
            {
                Console.WriteLine("Error bip bup");
            }

        }
    }
}
