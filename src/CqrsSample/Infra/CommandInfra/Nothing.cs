﻿namespace CqrsSample.Infra
{
    public class Nothing
    {
        private Nothing()
        {
        }

        public static Nothing Instance { get; } = new Nothing();

        public override string ToString() => string.Empty;
    }
}