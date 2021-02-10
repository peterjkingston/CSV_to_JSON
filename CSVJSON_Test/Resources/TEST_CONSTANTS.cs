using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVJSON_Test.Resources
{
	public static class TEST_CONSTANTS
	{
		public static readonly string[,] DUMMY_CSVSTRING_ARRAY =
		{		  /*0*/				/*1*/			 /*2*/		 /*3*/		  /*4*/  /*5*/          /*6*/ /*7*/
		/*0*/	{ "Item1"         , "01/01/2021"   , ""        , "SodaFlavor", "", ""			   , "", "Code:Fun" },
		/*1*/	{ "Item2"         , "MambaJamba"   , ""        , "Grape"	 , "", "FavoriteFlavor", "", ""			},
		/*2*/	{ ""	          , ""		       , ""        , ""		     , "", "DoubleGrape"   , "", ""			},
		/*3*/	{ "Prod"          , "Num"	       , "Dt"      , "Val"       , "", ""              , "", ""			},
		/*4*/	{ "0"             , ""             , ""        , ""          , "", ""              , "", ""         },
		/*5*/	{ "Care"          , "0"            , "Tomorrow", "3"         , "", ""              , "", ""         },
		/*6*/	{ ""              ,""              ,""         ,""           , "", ""              , "", ""         },
		/*7*/	{ "SingleValue:24",""              ,""         ,""           , "", ""              , "", ""         },
		/*8*/   { ""              ,"SingleValue:18",""         ,""           , "", ""              , "", ""         }
		};
	}
}
