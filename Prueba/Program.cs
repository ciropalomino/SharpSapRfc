using RFC.Model;
using SharpSapRfc;
using SharpSapRfc.Plain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba
{
    class Program
    {
        static void Main(string[] args)
        {

            List<IT_ORDERS> items =new List<IT_ORDERS>();

            items.Add(new IT_ORDERS() { BSTKD = "", VBELN = "" });

            using (SapRfcConnection conn = new PlainSapRfcConnection("RFCCONNECTDEV"))
            {
                var result = conn.ExecuteFunction("Z_SD_F_GET_VALIDATE_ORDERS", new
                {
                    DATOPS = 'X',
                    IT_ORDERS = items
                });

                result.GetTable<IT_ORDERS>("IT_ORDERS").ToList();
            }


        }
    }
}
