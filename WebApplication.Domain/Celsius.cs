namespace WebApplication.Domain
{
    public class Celsius
    {
        protected bool Equals(Celsius other)
        {
            return Temperature.Equals(other.Temperature);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Celsius) obj);
        }

        public override int GetHashCode()
        {
            return Temperature.GetHashCode();
        }

        public Celsius(Fahrenheit fahrenheit) : this((fahrenheit.Temperature - 32) * 0.555555555555556D){ }
        
        public Celsius(double temperature)
        {
            Temperature = temperature;
        }
        
        public double Temperature { get; }
    }
}