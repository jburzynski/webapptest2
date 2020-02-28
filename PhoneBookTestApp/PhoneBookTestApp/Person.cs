﻿namespace PhoneBookTestApp
{
    public class Person
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"{Name}, {PhoneNumber}, {Address}";
        }
    }
}