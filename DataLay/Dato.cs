using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Dato
    {
        public int Dag { get; set; }
        public int Måned { get; set; }
        public int År { get; set; }
        private static int[] daysPerMonth = {0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        public Dato( int dag, int måned, int år )
        {
            if( gyldigDato( dag, måned, år) )
            {
                Dag = dag;
                Måned = måned;
                År = år;
            }
            else
            {
                Dag = Måned = 1;
                År = 1900;
            }
        }

        public override string ToString()
        {
            return Dag + "." + Måned + "." + År;
        }

        private bool gyldigDato(int dag, int måned, int år)
        {
	        if( år < 1900 )										        // gyldigt år?
		        return false;
	        if( måned < 1 || måned > 12 )								// gyldig måned?
		        return false;
	        if( dag < 1 || dag > daysPerMonth[ måned ] )	            // gyldig dag?
		        return false;
	        if( måned == 2 && dag == 29 )								// February 29.?
		        if( !( år%4 == 0 && (år%100 != 0 || år%400 == 0) ) )	// ikke skudår?
			        return false;

	        return true;

            
        }
    }
}