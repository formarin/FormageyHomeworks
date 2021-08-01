using System;

namespace EqualsAndGetHashCode
{
    public class Person
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int PasspotID { get; set; }

        public Person(string surname, string name, string patronymic, DateTime dateOfBirth, int passpotID)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            DateOfBirth = dateOfBirth;
            PasspotID = passpotID;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Person))
            {
                return false;
            }
            Person result = (Person)obj;
            return result.Surname == Surname
                && result.Name == Name
                && result.Patronymic == Patronymic
                && result.DateOfBirth == DateOfBirth
                && result.PasspotID == PasspotID;
        }

        public static bool operator ==(Person first, Person second)
        {
            return first.Equals(second);
        }
        public static bool operator !=(Person first, Person second)
        {
            return !first.Equals(second);
        }

        public override int GetHashCode()
        {
            return Surname.GetHashCode() + Name.GetHashCode() + Patronymic.GetHashCode() + DateOfBirth.GetHashCode() + PasspotID.GetHashCode();
        }
    }
}
