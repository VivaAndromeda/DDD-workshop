﻿namespace HelloWorld.Domain
{
    public class RaumNummer
    {
        private RaumNummer(string raumNummer)
        {
            Nummer = raumNummer;
        }
        public static RaumNummer Create(string raumNummer)
        {
            if(raumNummer?.Length != 4 || raumNummer.Any(x => !int.TryParse(x + "",out int _)))
            {
                throw new ArgumentException(nameof(raumNummer));
            }
            return new RaumNummer(raumNummer);
        }

        public string Nummer { get;  } 
    }
}
