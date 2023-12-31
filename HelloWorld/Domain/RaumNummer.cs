﻿namespace HelloWorld.Domain
{
    public class RaumNummer
    {
        public string Value { get; }

        private RaumNummer(string raumNummer)
        {
            Value = raumNummer;
        }

        public static RaumNummer? Create(string raumNummer)
        {
            if (raumNummer?.Length != 4 || raumNummer.Any(x => !int.TryParse(x + "", out int _)))
            {
                return null;
            }

            return new RaumNummer(raumNummer);
        }
    }
}
