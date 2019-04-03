using System;
using System.Collections;

namespace demo_code
{
    class OpenSchool
    {
        public struct Lahev
        {
            public string Material;
            public float Objem;

            public Lahev(string m, float o)
            {
                this.Material = m;
                this.Objem = o;
            }

            public float Vylej(float o)
            {
                this.Objem = this.Objem - o;
                return this.Objem;
            }
        }

        class TriedaLahev
        {
            public string Material;
            public float Objem;

            public TriedaLahev(float o)
            {
                this.Objem = o;
            }

            public float Vylej(float o)
            {
                this.Objem = this.Objem - o;
                return this.Objem;
            }
        }

        static void Main(string[] args)
        {
            Lahev plastovaLahev = new Lahev("plast", 1);

            Lahev novaPlastovaLahev = plastovaLahev;

            Console.WriteLine($"plastovaLahev: {plastovaLahev.Vylej(0.5f)}");
            Console.WriteLine($"novaPlastovaLahev: {novaPlastovaLahev.Objem}");

            TriedaLahev sklenenaLahev = new TriedaLahev(2){
                Material = "sklo"
            };

            TriedaLahev novaSklenenaLahev = sklenenaLahev;

            Console.WriteLine($"sklenenaLahev: {sklenenaLahev.Vylej(0.5f)}");
            Console.WriteLine($"novaSklenenaLahev: {novaSklenenaLahev.Objem}");


            Console.WriteLine("Hello OpenSchool!");
        }
    }
}
