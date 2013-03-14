using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Week4.Algorithms
{
    class SobolAlgorithm : VisionAlgorithm
    {
        //auteur: J Smit

        private int[,] arrGrey;
        private Bitmap sobolOutput;

        public SobolAlgorithm(String name) : base(name)
        {
        }

        public void toGreyArray(Bitmap sourceImage)
        {
            //converts the image to greyscale
            //uses greyArray with average values

            Bitmap original = new Bitmap(sourceImage);

            arrGrey = new int[sourceImage.Width,sourceImage.Height];

		    for(int x = 0; x<sourceImage.Width; x++){
			    for(int y = 0; y<sourceImage.Height; y++){
				    //get pixel
				    Color c = original.GetPixel(x,y);
				    /* get rgb
				    int r,g,b;
				    r = p & 0xFF;
				    g = (p >> 8) & 0xFF;
				    b = (p >> 16) & 0xFF;
                     * */
				    //get average
				    int avg = (c.R+c.G+c.B) / 3;
				    //new pixel
                    /*
				    int np = avg & 0xFF;
				    np = (np << 8) | (avg & 0xFF);
				    np = (np << 8) | (avg & 0xFF);
				    np = (np << 8) | (avg & 0xFF);
                     * */
				    //save pixel in arrGrey
				    arrGrey[x,y] = avg;
				    //save pixel
				    //filter.setRGB(x,y, np);	
			    }
		    }
        }

        public NumberPlateCoordinates scan(Bitmap sourceImage)
        {
            //sobol scan begins here
            //...
            //end scan

            NumberPlateCoordinates npc = new NumberPlateCoordinates()
            {
                LeftTop = new Point(0, 0),
                RightBottom = new Point(0, 0),
                RightTop = new Point(0, 0),
                LeftBottom = new Point(0, 0)
            };

            return npc;
        }

        public override NumberPlateCoordinates DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            //convert to grey
            toGreyArray(sourceImage);

             Bitmap original = new Bitmap(sourceImage);

            //create sobol output image
             sobolOutput = new Bitmap(sourceImage);

            int[,] GX = new int[3,3];
		    int[,] GY = new int[3,3];
		
		int sumX, sumY;
		int SUM;
		
		/* 3x3 GX Sobel mask.  Ref: www.cee.hw.ac.uk/hipr/html/sobel.html */
		   GX[0,0] = -1; GX[0,1] = 0; GX[0,2] = 1;
		   GX[1,0] = -2; GX[1,1] = 0; GX[1,2] = 2;
		   GX[2,0] = -1; GX[2,1] = 0; GX[2,2] = 1;

		   /* 3x3 GY Sobel mask.  Ref: www.cee.hw.ac.uk/hipr/html/sobel.html */
		   GY[0,0] =  1; GY[0,1] =  2; GY[0,2] =  1;
		   GY[1,0] =  0; GY[1,1] =  0; GY[1,2] =  0;
		   GY[2,0] = -1; GY[2,1] = -2; GY[2,2] = -1;

		
		   /*---------------------------------------------------
			SOBEL ALGORITHM STARTS HERE
	   ---------------------------------------------------*/
	   for(int Y=0; Y<=(original.Height-1); Y++)  {
		for(int X=0; X<=(original.Width-1); X++)  {
		     sumX = 0;
		     sumY = 0;

	             /* image boundaries */
		     if(Y==0 || Y==original.Height-1){
			  SUM = 0;
		     }else if(X==0 || X==original.Width-1){
			  SUM = 0;

		     /* Convolution starts here */
		     }else   {

		       /*-------X GRADIENT APPROXIMATION------*/
		       for(int I=-1; I<=1; I++)  {
			   for(int J=-1; J<=1; J++)  {
				   int value = arrGrey[X+I,Y+J];
			      sumX = sumX + (int)( value * GX[I+1,J+1]);
			   }
		       }

		       /*-------Y GRADIENT APPROXIMATION-------*/
		       for(int I=-1; I<=1; I++)  {
			   for(int J=-1; J<=1; J++)  {
				   int value = arrGrey[X+I,Y+J];
			       sumY = sumY + (int)( value * GY[I+1,J+1]);
			   }
		       }

		       /*---GRADIENT MAGNITUDE APPROXIMATION ----*/
	               SUM = Math.Abs(sumX) + Math.Abs(sumY);
	             }

	             if(SUM>255) SUM=255;
	             if(SUM<0) SUM=0;

	             int v = 255 - (SUM); 
                 /*
	             int px = 0xFF;
					px 	= (px << 8) | (v & 0xFF);
					px	= (px << 8) | (v & 0xFF);
					px	= (px << 8) | (v & 0xFF);
                  */
                 Color color = Color.FromArgb(v, v, v);

                 sobolOutput.SetPixel(X, Y, color);
		        }
	        }

            //scan the sobol and get the coordinates
            NumberPlateCoordinates npc = scan(sobolOutput);

            return npc;
        }
    }
}
