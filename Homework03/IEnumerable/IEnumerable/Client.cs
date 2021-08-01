using System;

namespace IEnumerable
{
    public class Client
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int PasspotID { get; set; }
        public double MoneyBalance { get; set; }
        public Client(string surname, string name, string patronymic, int passpotID, double moneyBalance)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            PasspotID = passpotID;
            MoneyBalance = moneyBalance;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Client))
            {
                return false;
            }
            Client result = (Client)obj;
            return result.PasspotID == PasspotID;
        }

        public static bool operator ==(Client first, Client second)
        {
            return first.Equals(second);
        }
        public static bool operator !=(Client first, Client second)
        {
            return !first.Equals(second);
        }
        public override int GetHashCode()
        {
            return Surname.GetHashCode() + Name.GetHashCode() + Patronymic.GetHashCode() + PasspotID.GetHashCode() + MoneyBalance.GetHashCode();
        }
    }
}
