using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
//using Oracle.DataAccess.Client;
//using Oracle.DataAccess.Types;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace DAIS_ORM {
    class Program {
        static void Main(string[] args) {
//            Database db = new Database();
//            db.Connect("rzbi");
//            Console.WriteLine(db.Connection.ToString());
//            Obec obec = new Obec();
//            obec.Connect();
//            obec.VytvorObec("Rybi");

//
//            using (OracleConnection con = new OracleConnection(
//                "User Id=kvi0029;Password=n2HO69fi3w;Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = dbsys.cs.vsb.cz)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = oracle.dbsys.cs.vsb.cz)));")
//            ) {
//                con.Open();
//                Console.WriteLine("ahoj");
//                using (OracleCommand cmd = new OracleCommand()) {
//                    cmd.Connection = con;
//                    cmd.CommandText = "INSERT INTO SEM_OBEC(obec_id, nazev, vidible) VALUES (2,'Závišice',1)";
//                    int tmo = cmd.ExecuteNonQuery();
//                    con.Close();
//                }
//            }

            Database db = new Database();
            db.Connect();
            Obec obec = new Obec();
            //obec.VytvorObec("Závišice");
//            obec.SkryjObec(2);
            var tmp= obec.ZobrazVsechnyObce();
            foreach (var obc in tmp) {
                Console.WriteLine(obc.Nazev + "\t" + obc.Visibility);
            }
            db.Disconnect();


            
            
            
            
            
            
            
            
            


//            using (OracleConnection con = new OracleConnection("User Id=sku0084;Password=kZtothRHMv;Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = dbsys.cs.vsb.cz)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = oracle.dbsys.cs.vsb.cz)));"))
//            {
//                con.Open();
//                Console.WriteLine("ahoj");
//                using(OracleCommand cmd = new OracleCommand())
//                {
//                    cmd.Connection = con;
//                    cmd.CommandText = "SELECT * FROM Package";
//                    var r = cmd.ExecuteReader();
//                    while (r.Read())
//                    {
//                        Console.WriteLine("|{0,5}|{1,20}|",r.GetValue(0),r.GetValue(1));
//                    }
//                }
//                con.Close();
//            }


        }
    }
}